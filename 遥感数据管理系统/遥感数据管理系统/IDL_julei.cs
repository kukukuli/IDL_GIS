﻿using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 遥感数据管理系统
{
    public partial class IDL_julei : Form
    {
        private COM_IDL_connectLib.COM_IDL_connect IDLcom;
        AxMapControl m_pMapCtrl;
        public IDL_julei(COM_IDL_connectLib.COM_IDL_connect IDLco, AxMapControl pMapControl)
        {
            InitializeComponent();
            this.IDLcom = IDLco;
            this.m_pMapCtrl = pMapControl;
         
        }

        private void btnyingxiang_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "tif图像|*.tif";
            of.ShowDialog();
            this.txtyingxiang.Text = of.FileName;
        }

        private void btnxml_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog of = new FolderBrowserDialog();
            of.ShowDialog();
            this.textidl.Text = of.SelectedPath;
        }

        private void btnbaocun_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Title = "另存为tif图像";
            save.Filter = "tif图像|*.tif";
            save.ShowDialog();
            string filePath = save.FileName;
            if (filePath != null)
            {
                this.txtbaocun.Text = filePath;
            }
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            string InputFile = this.txtyingxiang.Text.Trim();
            string InputSaveFile = this.txtbaocun.Text.Trim();
            string proCommand = this.textidl.Text;
            try
            {
                string paths = @"['" + InputFile + "']";


                

                string i1 = @".compile -v '" + proCommand + "\\InitClassCenter.pro" + "'";
                this.IDLcom.ExecuteString(i1);
                string i2 = @".compile -v '" + proCommand + "\\KmeansAlg.pro" + "'";
                this.IDLcom.ExecuteString(i2);
                string i3 = @".compile -v '" + proCommand + "\\Kmeans.pro" + "'";
                this.IDLcom.ExecuteString(i3);


                this.IDLcom.ExecuteString(@"Kmeans," + paths + ",'" + InputSaveFile + "'");

                MessageBox.Show("执行完毕！");
                if (addresult.Checked==true)
                {
                    if (File.Exists(InputSaveFile))
                    {
                        IRasterLayer rRL = new RasterLayerClass();
                        rRL.CreateFromFilePath(InputSaveFile);
                        ILayer rL = rRL as ILayer;
                        if (rL != null)
                            m_pMapCtrl.AddLayer(rL);
 
                    }
                    else
                    {
                        MessageBox.Show(InputSaveFile + "不存在！");
                    }
                   
                }
                
            }
            catch
            {
                MessageBox.Show("执行失败！");
            }
        }
    }
}
