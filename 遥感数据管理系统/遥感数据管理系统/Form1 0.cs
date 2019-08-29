using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
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
    public partial class Form1 : Form
    {
        private COM_IDL_connectLib.COM_IDL_connect com = null;//IDL对象
        public struct pfeaturelayer
        {
            public static IFeatureLayer pFeatureLayer;
        }
        public struct MouseOperate
        {
            public static string pMouseOperate = null;
        }
        public struct envelope

        {
            public static IEnvelope penv;
        }
        public Form1()
        {
            InitializeComponent();
            axTOCControl1.SetBuddyControl(axMapControl1);
            com = new COM_IDL_connectLib.COM_IDL_connect();
            com.CreateObject(0, 0, 0);
        }

        private void Form1_0_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog popenfiledialog = new OpenFileDialog();
            popenfiledialog.CheckFileExists = true;
            popenfiledialog.Title = "打开地图文档";
            popenfiledialog.Filter = "ArcMap文档(*.mxd)|*.mxd";
            popenfiledialog.Multiselect = false;
            popenfiledialog.ReadOnlyChecked = true;
            if (popenfiledialog.ShowDialog() == DialogResult.OK)
            {
                axMapControl1.LoadMxFile(popenfiledialog.FileName);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //打开矢量文件
            OpenFileDialog openfiledialog = new OpenFileDialog();
            openfiledialog.CheckFileExists = true;
            openfiledialog.Title = "打开文件";
            openfiledialog.Filter = "文件(*.*)|*.bmp;*.tif;*jpg;*.img|(*.bmp)|*.bmp|(*.tif)|*.tif|(*.jpg)|*.jpg|(*.img)|*.img|(*.shp)|*.shp";
            openfiledialog.ShowDialog();

            String fullpath = openfiledialog.FileName;
            if (fullpath == "")
                return;
            String path = System.IO.Path.GetDirectoryName(fullpath);
            //获取文件名
            String filename = System.IO.Path.GetFileName(fullpath);
            //文件名之前的路径名  
            int index = fullpath.LastIndexOf("\\");
            string filePathName = fullpath.Substring(0, index);
            //获取后缀名
            string aLastName = fullpath.Substring(fullpath.LastIndexOf(".") + 1, (fullpath.Length - fullpath.LastIndexOf(".") - 1));
            if (aLastName == "shp")
            {
                axMapControl1.AddShapeFile(filePathName, filename);
                axMapControl1.ActiveView.Refresh();

            }
            else
            {

                //打开栅格文件
                IWorkspaceFactory pWorkspacefactory = new RasterWorkspaceFactory();//创建工作空间工厂
                IWorkspace pWorkspace = pWorkspacefactory.OpenFromFile(path, 0);//打开工作空间
                IRasterWorkspace pRasterworkspace = pWorkspace as IRasterWorkspace;//创建栅格工作空间
                IRasterDataset pRasterdataset = pRasterworkspace.OpenRasterDataset(filename);//创建Dataset
                //影像金字塔的判断与创建
                IRasterPyramid3 pRaspyrmid = pRasterdataset as IRasterPyramid3;
                if (pRaspyrmid != null)
                    if (!(pRaspyrmid.Present))
                        pRaspyrmid.Create();
                IRaster pRaster = pRasterdataset.CreateDefaultRaster();
                IRasterLayer pRasterlayer = new RasterLayerClass();
                pRasterlayer.CreateFromRaster(pRaster);
                ILayer pLayer = pRasterlayer as ILayer;
                axMapControl1.AddLayer(pLayer, 0);
            }
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void 保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (axMapControl1.DocumentMap == null)
                MessageBox.Show("地图文档不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    IMapDocument pMapDocument = new MapDocumentClass();
                    string saveFileName = axMapControl1.DocumentFilename;
                    IMxdContents pMxdcontents = axMapControl1.Map as IMxdContents;
                    pMapDocument.New(saveFileName);
                    pMapDocument.ReplaceContents(pMxdcontents);
                    if (pMapDocument.get_IsReadOnly(saveFileName))
                    {
                        MessageBox.Show("本地图文档只读的，不能保存！");
                    }
                    else
                    {
                        pMapDocument.Save(pMapDocument.UsesRelativePaths, true);
                        MessageBox.Show("保存地图文档成功！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (axMapControl1.DocumentMap == null)
                MessageBox.Show("地图文档不能为空", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    IMapDocument pMapDocument = new MapDocumentClass();
                    string saveFileName = axMapControl1.DocumentFilename;
                    if (saveFileName != "" && axMapControl1.CheckMxFile(saveFileName))
                    {
                        if (pMapDocument.get_IsReadOnly(saveFileName))
                        {
                            MessageBox.Show("本地图文档只读的，不能保存！");
                            pMapDocument.Close();
                            return;
                        }
                        else
                        {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.Title = "保存文档";
                            saveFileDialog.Filter = "MXD文档(*.mxd)|*.mxd";
                            string fileName = System.IO.Path.GetFileName(saveFileName);
                            saveFileDialog.FileName = fileName;
                            if (saveFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                saveFileName = saveFileDialog.FileName;
                                pMapDocument.New(saveFileName);
                                pMapDocument.ReplaceContents(axMapControl1.Map as IMxdContents);
                                pMapDocument.Save(true, true);
                                pMapDocument.Close();
                                MessageBox.Show("保存成功！");
                            }
                            else
                            {
                                pMapDocument.Close();
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("无法保存！");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            axMapControl1.ClearLayers();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form_Clip fc = new Form_Clip(axMapControl1);
            fc.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Form_CompositeBands fcb = new Form_CompositeBands(axMapControl1);
            fcb.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form_Moasic fm = new Form_Moasic(axMapControl1);
            fm.Show();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Form_Pansharpen fp = new Form_Pansharpen(axMapControl1);
            fp.Show();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Form_Resample fr = new Form_Resample(axMapControl1);
            fr.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form_SaveAs fs = new Form_SaveAs(axMapControl1);
            fs.Show();
        }

        private void RC_Click(object sender, EventArgs e)
        {
            IDL_RC rc = new IDL_RC(this.com, this.axMapControl1);
            rc.Show();
        }

        private void AR_Click(object sender, EventArgs e)
        {
            IDL_AR ar = new IDL_AR(this.com, this.axMapControl1);
            ar.Show();
        }

        private void NDVI_Click(object sender, EventArgs e)
        {
            IDL_NDVI ndvi = new IDL_NDVI(this.com, this.axMapControl1);
            ndvi.Show();
        }

        private void VCI_Click(object sender, EventArgs e)
        {
            IDL_VCI vci = new IDL_VCI(this.com, this.axMapControl1);
            vci.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            IDL_boduantiqv bd = new IDL_boduantiqv(com, axMapControl1);
            bd.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            IDL_sanboduanronghe sbd = new IDL_sanboduanronghe(com, axMapControl1);
            sbd.Show();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            IDL_julei jl = new IDL_julei(com, axMapControl1);
            jl.Show();
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            IEnvelope pEnvelope = axMapControl1.Extent;
            envelope.penv = null;
            switch (MouseOperate.pMouseOperate)
            {
                case "lakuang":

                    envelope.penv = axMapControl1.TrackRectangle();
                    IGeometry pgeo = envelope.penv as IGeometry;
                    drawMapshape(pgeo);
                    MouseOperate.pMouseOperate = null;
                    break;
                case "Pan":
                    axMapControl1.Pan();
                    MouseOperate.pMouseOperate = null;
                    break;

                default: break;
            }
        }
        private void axMapControl1_OnMapReplaced(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMapReplacedEvent e)
        {
            axMapControl2.Map = new MapClass();
            for (int i = 1; i < this.axMapControl1.LayerCount; i++)
            {

                this.axMapControl2.AddLayer(this.axMapControl1.get_Layer(this.axMapControl1.LayerCount - i));
            }
            axMapControl2.Extent = axMapControl1.FullExtent;
            axMapControl2.Refresh();
        }
        private void drawMapshape(IGeometry pgeo)
        {
            IRgbColor pcolor = new RgbColorClass();
            pcolor.Red = 135;
            pcolor.Green = 206;
            pcolor.Blue = 250;
            object symbol = null;
            ISimpleFillSymbol simplefillsymbol = new SimpleFillSymbolClass();
            simplefillsymbol.Color = pcolor;
            symbol = simplefillsymbol;
            axMapControl1.DrawShape(pgeo, ref symbol);
        }
        private void 打开属性表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pfeaturelayer.pFeatureLayer = ptocfesturelayer;
            if (ptocfesturelayer == null)
                return;
            shuxingbiao sxb = new shuxingbiao(axMapControl1.Map);
            sxb.Show();
        }

        private void 移除此图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ptocfesturelayer == null)
                return;
            DialogResult result = MessageBox.Show("是否删除" + ptocfesturelayer.Name + "图层", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (result == DialogResult.OK)
            {
                axMapControl1.Map.DeleteLayer(ptocfesturelayer);
                axMapControl2.Map.DeleteLayer(ptocfesturelayer);
            }
            axMapControl1.ActiveView.Refresh();
            axMapControl2.ActiveView.Refresh();
        }
        private ILayer pmovelayer;
        IFeatureLayer ptocfesturelayer = null;
        private void axTOCControl1_OnMouseDown(object sender, ESRI.ArcGIS.Controls.ITOCControlEvents_OnMouseDownEvent e)
        {
            if (e.button == 1)
            {
                esriTOCControlItem pitem = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap pmap = null;
                object unk = null;
                object data = null;
                ILayer player = null;
                axTOCControl1.HitTest(e.x, e.y, ref pitem, ref pmap, ref player, ref unk, ref data);
                if (pitem == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    if (player is IAnnotationSublayer)
                        return;
                    else
                        pmovelayer = player;
                }
            }
            if (e.button == 2)
            {
                esriTOCControlItem pitem = esriTOCControlItem.esriTOCControlItemNone;
                IBasicMap pmap = null;
                object unk = null;
                object data = null;
                ILayer player = null;
                axTOCControl1.HitTest(e.x, e.y, ref pitem, ref pmap, ref player, ref unk, ref data);
                ptocfesturelayer = player as IFeatureLayer;
                if (pitem == esriTOCControlItem.esriTOCControlItemLayer && ptocfesturelayer != null)
                {
                    axTOCControl1.ContextMenuStrip.Visible = true;
                    axTOCControl1.ContextMenuStrip.Show(MousePosition.X, MousePosition.Y);
                }
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string fullpath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();       //获得路径

            if (fullpath == "")
                return;
            String path = System.IO.Path.GetDirectoryName(fullpath);
            //获取文件名
            String filename = System.IO.Path.GetFileName(fullpath);
            //文件名之前的路径名  
            int index = fullpath.LastIndexOf("\\");
            string filePathName = fullpath.Substring(0, index);
            //获取后缀名
            string aLastName = fullpath.Substring(fullpath.LastIndexOf(".") + 1, (fullpath.Length - fullpath.LastIndexOf(".") - 1));
            if (aLastName == "shp")
            {
                axMapControl1.AddShapeFile(filePathName, filename);
                //axMapControl1.ActiveView.Refresh();

            }
            else
            {

                //打开栅格文件
                IWorkspaceFactory pWorkspacefactory = new RasterWorkspaceFactory();//创建工作空间工厂
                IWorkspace pWorkspace = pWorkspacefactory.OpenFromFile(path, 0);//打开工作空间
                IRasterWorkspace pRasterworkspace = pWorkspace as IRasterWorkspace;//创建栅格工作空间
                IRasterDataset pRasterdataset = pRasterworkspace.OpenRasterDataset(filename);//创建Dataset
                //影像金字塔的判断与创建
                IRasterPyramid3 pRaspyrmid = pRasterdataset as IRasterPyramid3;
                if (pRaspyrmid != null)
                    if (!(pRaspyrmid.Present))
                        pRaspyrmid.Create();
                IRaster pRaster = pRasterdataset.CreateDefaultRaster();
                IRasterLayer pRasterlayer = new RasterLayerClass();
                pRasterlayer.CreateFromRaster(pRaster);
                ILayer pLayer = pRasterlayer as ILayer;
                axMapControl1.AddLayer(pLayer, 0);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;                                                              //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
