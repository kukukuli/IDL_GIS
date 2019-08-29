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
    public partial class Form_Moasic : Form
    {
        AxMapControl axmapcontrol;
        public Form_Moasic(AxMapControl axMapControl1)
        {
            InitializeComponent();
            axmapcontrol = axMapControl1;
            //在comboBox1添加项
            for (int i = 0; i < axmapcontrol.LayerCount; i++)
            {
                shurushange.Items.Add(axmapcontrol.get_Layer(i).Name.ToString());
            }
        }

        private void shurushange_SelectedIndexChanged(object sender, EventArgs e)
        {
            listshange.Items.Add(shurushange.Text);
        }

        private void Form_Moasic_Load(object sender, EventArgs e)
        {
            //像素类型
            xiangsuleixing.Text = "16_BIT_UNSIGNED";
            xiangsuleixing.Items.Add("1_BIT");
            xiangsuleixing.Items.Add("2_BIT");
            xiangsuleixing.Items.Add("4_BIT");
            xiangsuleixing.Items.Add("8_BIT-UNSIGNED");
            xiangsuleixing.Items.Add("8_BIT-SIGNED");
            xiangsuleixing.Items.Add("16_BIT-UNSIGNED");
            xiangsuleixing.Items.Add("16_BIT-SIGNED");
            xiangsuleixing.Items.Add("32_BIT-UNSIGNED");
            xiangsuleixing.Items.Add("32_BIT-SIGNED");
            xiangsuleixing.Items.Add("32_BIT-FLOAT");
            xiangsuleixing.Items.Add("64_BIT");

            //波段数
            boduanshu.Text = "1";

            //镶嵌运算符
            xiangyun.Text = "LAST";
            xiangyun.Items.Add("FIRST");
            xiangyun.Items.Add("LAST");
            xiangyun.Items.Add("BLEND");
            xiangyun.Items.Add("MEAN");
            xiangyun.Items.Add("MINIMUM");
            xiangyun.Items.Add("MAXIMUM");
            xiangyun.Items.Add("SUM");

            //镶嵌色彩映射表模式
            xiangsebiao.Text = "FIRST";
            xiangsebiao.Items.Add("FIRST");
            xiangsebiao.Items.Add("LAST");
            xiangsebiao.Items.Add("MATCH");
            xiangsebiao.Items.Add("REJECT");

         
        }
        //获得每个选中图层的路径
        private string GetLayerList()
        {
            string layerList = "";
            string fistLayer = "";
            ILayer pInputLayer = null;
            IRasterLayer prasterlayer = null;
            for (int j = 0; j < listshange.Items.Count; j++)
            {
                string layname = listshange.Items[j].ToString();
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
                    if (j == 0)
                    {
                        fistLayer = rasterPath;
                    }
                    layerList += rasterPath + ";";
                }
            }
            return layerList;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            ESRI.ArcGIS.DataManagementTools.MosaicToNewRaster m2nr = new MosaicToNewRaster();
            m2nr.input_rasters = GetLayerList();
            m2nr.output_location = System.IO.Path.GetDirectoryName(textbaocun.Text);
            m2nr.pixel_type = xiangsuleixing.Text;
            m2nr.number_of_bands = Convert.ToInt32(boduanshu.Text);
            m2nr.raster_dataset_name_with_extension = System.IO.Path.GetFileName(textbaocun.Text);
            m2nr.mosaic_method = xiangyun.Text;
            m2nr.mosaic_colormap_mode = xiangsebiao.Text;

            Geoprocessor gp = new Geoprocessor();
            gp.OverwriteOutput = true;
            IGeoProcessorResult gpResult = gp.Execute(m2nr, null) as IGeoProcessorResult;
            if (gpResult.Status == esriJobStatus.esriJobSucceeded)
            {
                DialogResult dr = MessageBox.Show("数据镶嵌操作成功");
                if (dr == DialogResult.OK)
                {    //结果添加到工作空间
                    if (addresult.Checked == true)
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
                MessageBox.Show("数据镶嵌操作失败");
            }

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

        private void btnshang_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listshange.Items.Count; i++)
            {
                if (listshange.Items[i].ToString() == listshange.SelectedItem.ToString())
                {
                    if (i == 0)
                    {
                        break;
                    }
                    else
                    {
                        string a = listshange.Items[i].ToString();
                        listshange.Items[i] = listshange.Items[i - 1];
                        listshange.Items[i - 1] = a;
                        listshange.SelectedIndex = i - 1;
                        break;
                    }
                }
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            listshange.Items.Remove(listshange.SelectedItem);
        }

        private void btnxia_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listshange.Items.Count; i++)
            {
                if (listshange.Items[i].ToString() == listshange.SelectedItem.ToString())
                {
                    if (i == listshange.Items.Count - 1)
                    {
                        break;
                    }
                    else
                    {
                        string a = listshange.SelectedItem.ToString();
                        listshange.Items[i] = listshange.Items[i + 1];
                        listshange.Items[i + 1] = a;
                        listshange.SelectedIndex = i + 1;
                        break;
                    }
                }
            }
        }

        private void btnquit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
