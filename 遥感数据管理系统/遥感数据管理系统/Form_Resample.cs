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
    public partial class Form_Resample : Form
    {
        AxMapControl axmapcontrol;
        public Form_Resample(AxMapControl axMapControl1)
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
            axmapcontrol = axMapControl1;
            for (int i = 0; i < axmapcontrol.LayerCount; i++)
            {
                comboBox1.Items.Add(axmapcontrol.get_Layer(i).Name);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存路径";
            saveFileDialog.Filter = "tif图像(*.tif)|*.tif";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog.FileName;
            }
        }
        private string getlayer(string layer)
        {
            string layerpath = "";
            ILayer pInputLayer = null;
            IRasterLayer presterlayer = null;
            string layname = layer;
            for (int i = 0; i < axmapcontrol.LayerCount; i++)
            {
                if (axmapcontrol.get_Layer(i).Name == layname)
                {
                    pInputLayer = axmapcontrol.get_Layer(i);
                }
            }
            if (pInputLayer != null && (pInputLayer as IRasterLayer) != null)
            {
                presterlayer = pInputLayer as IRasterLayer;
                String rasterPath = presterlayer.FilePath;
                layerpath = rasterPath;
            }
            return layerpath;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text != "")
            {
                if (textBox1.Text != "")
                {
                    ESRI.ArcGIS.DataManagementTools.Resample rsp = new Resample();
                    rsp.in_raster = getlayer(comboBox1.Text);
                    rsp.out_raster = textBox1.Text;
                    //重采样技术
                    rsp.resampling_type = comboBox2.Text;
                    //重采样分辨率
                    rsp.cell_size = Int32.Parse(textBox2.Text) * Int32.Parse(textBox3.Text);
                    Geoprocessor gp = new Geoprocessor();
                    gp.OverwriteOutput = true;
                    object obj = gp.Execute(rsp, null);
                    IGeoProcessorResult pgeoprcessorresult = obj as IGeoProcessorResult;
                    if (pgeoprcessorresult.Status == esriJobStatus.esriJobSucceeded)
                    {
                        DialogResult dr = MessageBox.Show("重采样操作成功");
                        if (dr == DialogResult.OK)
                        {    //结果添加到工作空间
                            if (checkBox1.Checked == true)
                            {
                                string fileFullName = textBox1.Text;
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
                        MessageBox.Show("重采样操作失败");
                    }
                }
                else
                {
                    MessageBox.Show("未选择需要保存的数据路径");
                }
            }
            else
            {
                MessageBox.Show("未选择需要重采样的栅格数据");
            }

        }

    }
}
