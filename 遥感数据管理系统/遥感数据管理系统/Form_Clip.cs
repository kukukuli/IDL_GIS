using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataManagementTools;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
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
    public partial class Form_Clip : Form
    {
        AxMapControl axmapcontrol;
        public Form_Clip(AxMapControl axMapControl1)
        {
            InitializeComponent();
            axmapcontrol = axMapControl1;
            for (int i = 0; i < axmapcontrol.LayerCount; i++)
            {
                comboBox1.Items.Add(axmapcontrol.get_Layer(i).Name.ToString());
                comboBox2.Items.Add(axmapcontrol.get_Layer(i).Name.ToString());
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

        private void button3_Click(object sender, EventArgs e)
        {
            ESRI.ArcGIS.DataManagementTools.Clip clp = new Clip();
            clp.in_raster = getlayer(comboBox1.Text.ToString());
            clp.out_raster = textBoxsave.Text;
            if (checkBox1.Checked == true)
            {
                IGPUtilities gputilities = new GPUtilitiesClass();
                IEnvelope penvelope = 遥感数据管理系统.Form1.envelope.penv;
                clp.rectangle = string.Format("{0} {1} {2} {3} ", penvelope.XMin, penvelope.YMin, penvelope.XMax, penvelope.YMax);
            }
            else
            {
                IGPUtilities gputilities = new GPUtilitiesClass();
                IGeoDataset pgeodataset = gputilities.OpenRasterDatasetFromString(getlayer(comboBox2.Text.ToString())) as IGeoDataset;
                IEnvelope penvelope = pgeodataset.Extent;
                clp.in_template_dataset = getlayer(comboBox2.Text.ToString());
                clp.rectangle = string.Format("{0} {1} {2} {3} ", penvelope.XMin, penvelope.YMin, penvelope.XMax, penvelope.YMax);
            }
            clp.clipping_geometry = "true";
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            IGeoProcessorResult gpresult = gp.Execute(clp, null) as IGeoProcessorResult;
            if (gpresult.Status == esriJobStatus.esriJobSucceeded)
            {
                DialogResult dl = MessageBox.Show("裁剪成功");
                if (dl == DialogResult.OK)
                {
                    if (checkBox3.Checked == true)
                    {
                        string fileFullName = textBoxsave.Text;
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
                MessageBox.Show("裁剪失败");

            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存路径";
            saveFileDialog.Filter = "tif图像(*.tif)|*.tif";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxsave.Text = saveFileDialog.FileName;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            IGPUtilities gputilities = new GPUtilitiesClass();
            IGeoDataset pgeodataset = gputilities.OpenRasterDatasetFromString(getlayer(comboBox2.Text.ToString())) as IGeoDataset;
            IEnvelope penvelope = pgeodataset.Extent;
            textBoxXMin.Text = penvelope.XMin.ToString();
            textBoxYMin.Text = penvelope.YMin.ToString();
            textBoxXMax.Text = penvelope.XMax.ToString();
            textBoxYMax.Text = penvelope.YMax.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                comboBox2.Enabled = false;
                button1.Enabled = true;
            }
            else
            {
                comboBox2.Enabled = true;
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            遥感数据管理系统.Form1.MouseOperate.pMouseOperate = "lakuang";
            axmapcontrol.Refresh();
        }



    }
}
