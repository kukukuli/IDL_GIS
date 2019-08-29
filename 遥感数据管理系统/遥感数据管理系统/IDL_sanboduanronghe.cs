using ESRI.ArcGIS.Carto;
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
    public partial class IDL_sanboduanronghe : Form
    {
        private COM_IDL_connectLib.COM_IDL_connect IDLcom;
        AxMapControl m_pMapCtrl;
        public IDL_sanboduanronghe(COM_IDL_connectLib.COM_IDL_connect IDLco, AxMapControl pMapControl)
        {
            InitializeComponent();
              this.IDLcom = IDLco;
            this.m_pMapCtrl = pMapControl;
        }

        private void btnyingxiang_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Multiselect = true;
            of.Filter = "tif图像|*.tif";
            of.ShowDialog();
            string[] paths = of.FileNames;
            for (int i = 0; i < paths.Length; i++)
            {
                listBox1.Items.Add(paths[i]);
            }
        }

        private void btnxml_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "pro|*.pro";
            of.ShowDialog();
            this.textidl.Text = of.FileName;
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
            string InputFile=null;
            for(int i=0;i<listBox1.Items.Count;i++)
            {
               
                if (i + 1 == listBox1.Items.Count)
                {
                    InputFile += "'" + listBox1.Items[i] + "'";
                }
                else
                {
                    InputFile += "'" + listBox1.Items[i] + "',";

                }

            }
            string InputSaveFile = this.txtbaocun.Text.Trim();
            string proCommand = this.textidl.Text.Trim();
            try
            {
                string paths = @"[" + InputFile + "]";
                this.IDLcom.ExecuteString(@".compile -v '" + proCommand + "'");
                this.IDLcom.ExecuteString(@"LayerStacking," + paths + ",'" + InputSaveFile + "'");
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

        private void IDL_sanboduanronghe_Load(object sender, EventArgs e)
        {

        }
    }
}
