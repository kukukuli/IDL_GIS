﻿using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace 遥感数据管理系统
{
    public partial class IDL_RC : Form
    {
        private COM_IDL_connectLib.COM_IDL_connect IDLcom;
        private AxMapControl m_pMapCtrl = null;
        public IDL_RC(COM_IDL_connectLib.COM_IDL_connect IDLco, AxMapControl pMapControl)
        {
            InitializeComponent();
            this.IDLcom = IDLco;
            this.m_pMapCtrl = pMapControl;
            
        }

       

        //待提取影像按钮
        private void btnyingxiang_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "tif图像|*.tif";
            of.ShowDialog();
            this.txtyingxiang.Text = of.FileName;
           

        }
       
        //IDL命令按钮
        private void btnmingling_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog of = new FolderBrowserDialog();
            of.ShowDialog();
            this.txtmingling.Text = of.SelectedPath;

        }
        //输出保存位置按钮
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
        //XML位置
        private void btnxml_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "xml文件|*.xml";
            of.ShowDialog();
            this.txtxml.Text = of.FileName;
        }
        //确定按钮
        private void btnok_Click(object sender, EventArgs e)
        {
            string InputFile = this.txtyingxiang.Text.Trim();
            string InputSaveFile = txtbaocun.Text.Trim();
            string Inputxml = txtxml.Text.Trim();
            string proCommand = this.txtmingling.Text;
            try
            {
                string i1 = @".compile -v '" + proCommand + "\\GetXMLNodeValue.pro" + "'";
                this.IDLcom.ExecuteString(i1);
                string i2 = @".compile -v '" + proCommand + "\\Coef_GF1.pro" + "'";
                this.IDLcom.ExecuteString(i2);
                string i3 = @".compile -v '" + proCommand + "\\RadiometricCalibration.pro" + "'";
                this.IDLcom.ExecuteString(i3);
                string i4 = @".compile -v '" + proCommand + "\\Calibration_Alg.pro" + "'";
                this.IDLcom.ExecuteString(i4);
                string i5 = @".compile -v '" + proCommand + "\\CalibrationRExct.pro" + "'";
                this.IDLcom.ExecuteString(i5);

                string cm = @"CalibrationRExct,'" + InputFile + "','" + Inputxml + "','" + InputSaveFile + "'";
                this.IDLcom.ExecuteString(cm);

                MessageBox.Show("执行完毕！");
                if (addresult.Checked == true)
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
