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
    public partial class Form_CompositeBands : Form
    {
        AxMapControl axmapcontrol;
        public Form_CompositeBands(AxMapControl axMapControl1)
        {
            InitializeComponent();
            axmapcontrol = axMapControl1;
            for (int i = 0; i < axmapcontrol.LayerCount; i++)
            {
                comboBox1.Items.Add(axmapcontrol.get_Layer(i).Name.ToString());
            }
        }
        private string GetLayerList()
        {
            string layerList = "";
            string firstLayer = "";
            ILayer pInputLayer = null;
            IRasterLayer presterlayer = null;
            for (int j = 0; j < listBox1.Items.Count; j++)
            {
                string layname = listBox1.Items[j].ToString();
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
                    if (j == 0)
                    {
                        firstLayer = rasterPath;
                    }
                    layerList += rasterPath + ";";
                }
            }
            return layerList;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CompositeBands cb = new CompositeBands();
            cb.in_rasters = GetLayerList();
            cb.out_raster = textBox1.Text;
            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            IGeoProcessorResult gpResult = gp.Execute(cb, null) as IGeoProcessorResult;
            if (gpResult.Status == esriJobStatus.esriJobSucceeded)
            {
                DialogResult dr = MessageBox.Show("波段合成成功");
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
                MessageBox.Show("波段合成失败");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i;
            for (i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString() == comboBox1.Text.ToString())
                    break;
            }
            if (i == listBox1.Items.Count)
            {
                listBox1.Items.Add(comboBox1.Text);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "保存路径";
            saveFileDialog.Filter = "tif图像(*.tif)|*.tif";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog.FileName;
            }
                 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString() == listBox1.SelectedItem.ToString())
                {
                    if (i + 1 == listBox1.Items.Count)
                        break;
                    else
                    {
                        string a = listBox1.Items[i].ToString();
                        listBox1.Items[i] = listBox1.Items[i + 1];
                        listBox1.Items[i + 1] = a;
                        listBox1.SelectedIndex = i + 1;
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                if (listBox1.Items[i].ToString() == listBox1.SelectedItem.ToString())
                {
                    if (i == 0)
                        break;
                    else
                    {
                        string a = listBox1.Items[i].ToString();
                        listBox1.Items[i] = listBox1.Items[i - 1];
                        listBox1.Items[i - 1] = a;
                        listBox1.SelectedIndex = i - 1;
                        break;
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
              this.Close();
        }

        private void Form_CompositeBands_Load(object sender, EventArgs e)
        {
        
        }

        }




}




