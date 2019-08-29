using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geoprocessing;
using ESRI.ArcGIS.Geoprocessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 遥感数据管理系统
{
    public partial class Form_Pansharpen : Form
    {
        AxMapControl axmapcontrol;
        public Form_Pansharpen(AxMapControl axMapControl)
        {
            InitializeComponent();
            axmapcontrol = axMapControl;
            //将mapcontrol中的图层的名字添加到Combobox中
            for (int i = 0; i < axmapcontrol.LayerCount; i++)
            {
                quanse.Items.Add(axmapcontrol.get_Layer(i).Name.ToString());
                duoguangpu.Items.Add(axmapcontrol.get_Layer(i).Name.ToString());
            }
        }

        private void Form_Pansharpen_Load(object sender, EventArgs e)
        {
            //传感器
            chuanganqi.Text = "UNKNOWN";
            chuanganqi.Items.Add("UNKNOWN");
            chuanganqi.Items.Add("GeoEye-1");
            chuanganqi.Items.Add("IKONOS");
            chuanganqi.Items.Add("KOMPSAT-2");
            chuanganqi.Items.Add("Landsat 1-5 MSS");
            chuanganqi.Items.Add("Landsat 7 ETM+");
            chuanganqi.Items.Add("QuickBird");
            chuanganqi.Items.Add("SPOT 5");
            chuanganqi.Items.Add("UltraCam");
            chuanganqi.Items.Add("WorldView-2");
            //融合方法（全色锐化类型）
            ronghefangfa.Text = "Esri";
            ronghefangfa.Items.Add("Esri");
            ronghefangfa.Items.Add("IHS");
            ronghefangfa.Items.Add("BROVEY");
            ronghefangfa.Items.Add("SIMPLE_MEAN");
            ronghefangfa.Items.Add("Gram-Schmidt");
            //波段
            //红波段
            redboduan.Text = "1";
            redboduan.Items.Add("1");
            redboduan.Items.Add("2");
            redboduan.Items.Add("3");
            //绿波段
            greenboduan.Text = "2";
            greenboduan.Items.Add("1");
            greenboduan.Items.Add("2");
            greenboduan.Items.Add("3");
            //蓝波段
            blueboduan.Text = "3";
            blueboduan.Items.Add("1");
            blueboduan.Items.Add("2");
            blueboduan.Items.Add("3");
            //近红外
            jinhongwai.Text = "1";
            jinhongwai.Items.Add("1");
            jinhongwai.Items.Add("2");
            jinhongwai.Items.Add("3");

            //权重
            //红波段权重
            redquanzhong.Text = "0.166";
            greenquanzhong.Text = "0.167";
            bluequanzhong.Text = "0.167";
            jinhongwaiquanzhong.Text = "0.5";
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            ESRI.ArcGIS.DataManagementTools.CreatePansharpenedRasterDataset cpr = new CreatePansharpenedRasterDataset();

            string inraster = GetLayerList(quanse.Text);
            string inpanchromaticimage = GetLayerList(duoguangpu.Text);
            cpr.in_raster = inraster;
            cpr.in_panchromatic_image = inpanchromaticimage;
            cpr.out_raster_dataset = textbaocun.Text;

            cpr.red_channel = Convert.ToInt32(redboduan.Text.ToString());
            cpr.green_channel = Convert.ToInt32(greenboduan.Text.ToString());
            cpr.blue_channel = Convert.ToInt32(blueboduan.Text.ToString());
            cpr.infrared_channel = 1;

            cpr.red_weight = Convert.ToDouble(redquanzhong.Text.ToString());
            cpr.green_weight = Convert.ToDouble(greenquanzhong.Text.ToString());
            cpr.blue_weight = Convert.ToDouble(bluequanzhong.Text.ToString());
            cpr.infrared_weight = Convert.ToDouble(jinhongwaiquanzhong.Text.ToString());
            cpr.pansharpening_type = ronghefangfa.Text;
            cpr.sensor = chuanganqi.Text;

            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            object obj = gp.Execute(cpr, null);
            IGeoProcessorResult gpResult = obj as IGeoProcessorResult;
            if (gpResult.Status == esriJobStatus.esriJobSucceeded)
            {
                DialogResult dr = MessageBox.Show("多波段合成操作成功");
                if (dr == DialogResult.OK)
                {    //结果添加到工作空间
                    if (addResult.Checked == true)
                    {
                        string fileFullName = textbaocun.Text;
                        if (fileFullName == "") return;
                        string filePathName = System.IO.Path.GetDirectoryName(fileFullName);
                        string fileName = System.IO.Path.GetFileName(fileFullName);
                        IWorkspaceFactory pWorkspaceFactory = new RasterWorkspaceFactory();//创建工作空间工厂
                        IWorkspace pWorkspace = pWorkspaceFactory.OpenFromFile(filePathName, 0);//打开工作空间
                        IRasterWorkspace pRasterWorkspace = pWorkspace as IRasterWorkspace;//创建栅格工作空间
                        IRasterDataset pRasterDataset = pRasterWorkspace.OpenRasterDataset(fileName);//创建Dataset
                        //影像金字塔创建与判断
                        IRasterPyramid2 pRasPymid = pRasterDataset as IRasterPyramid2;
                        if (pRasPymid != null)
                        {
                            if (!(pRasPymid.Present))
                            {
                                pRasPymid.Create();//创建金字塔
                            }
                        }
                        IRaster pRaster = pRasterDataset.CreateDefaultRaster();
                        IRasterLayer pRasterLayer = new RasterLayer();
                        pRasterLayer.CreateFromRaster(pRaster);
                        ILayer pLayer = pRasterLayer as ILayer;
                        axmapcontrol.AddLayer(pLayer, 0);

                    }
                }
            }
            else
            {
                MessageBox.Show("多波段合成操作失败");
            }
        }
        //获得每个选中图层的路径
        private string GetLayerList(string layname)
        {
            string layerList = "";
            ILayer pInputLayer = null;
            IRasterLayer prasterlayer = null;
            for (int i = 0; i < axmapcontrol.LayerCount; i++)
            {
                if (axmapcontrol.get_Layer(i).Name == layname)
                {
                    pInputLayer = axmapcontrol.get_Layer(i);
                }
            }
            if (pInputLayer != null && (pInputLayer as IRasterLayer) != null)
            {
                prasterlayer = pInputLayer as IRasterLayer;
                String rasterPath = prasterlayer.FilePath;
                layerList = rasterPath;
            }
            return layerList;
        }

        private void btnbaocun_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存路径";
            saveFileDialog.Filter = "tif图像(*.tif)|*.tif";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textbaocun.Text = saveFileDialog.FileName;
            }
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }





    }
}
