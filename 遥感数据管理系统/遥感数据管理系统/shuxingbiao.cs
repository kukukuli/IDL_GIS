using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
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
    public partial class shuxingbiao : Form
    {
        public IMap smap;
        public shuxingbiao(IMap pmap)
        {
            InitializeComponent();
            this.smap = pmap;
            Opentable();
        }

        public static string ParseFieldType(esriFieldType fieldType)
        //将EsriType 转换为String  
        {
            switch (fieldType)
            {
                case esriFieldType.esriFieldTypeBlob:
                    return "System.String";
                case esriFieldType.esriFieldTypeDate:
                    return "System.DateTime";
                case esriFieldType.esriFieldTypeDouble:
                    return "System.Double";
                case esriFieldType.esriFieldTypeGeometry:
                    return "System.String";
                case esriFieldType.esriFieldTypeGlobalID:
                    return "System.String";
                case esriFieldType.esriFieldTypeGUID:
                    return "System.String";
                case esriFieldType.esriFieldTypeInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeOID:
                    return "System.String";
                case esriFieldType.esriFieldTypeRaster:
                    return "System.String";
                case esriFieldType.esriFieldTypeSingle:
                    return "System.Single";
                case esriFieldType.esriFieldTypeSmallInteger:
                    return "System.Int32";
                case esriFieldType.esriFieldTypeString:
                    return "System.String";
                default:
                    return "System.String";
            }
        }
        public void Opentable()
        {

            IFields pfields;
            pfields = 遥感数据管理系统.Form1.pfeaturelayer.pFeatureLayer.FeatureClass.Fields;
            dataGridView1.ColumnCount = pfields.FieldCount;
            for (int i = 0; i < pfields.FieldCount; i++)
            {
                String fldname = pfields.get_Field(i).Name;
                dataGridView1.Columns[i].Name = fldname;
                dataGridView1.Columns[i].ValueType = System.Type.GetType(ParseFieldType(pfields.get_Field(i).Type));
            }
            IFeatureCursor pfeaturecursor = 遥感数据管理系统.Form1.pfeaturelayer.pFeatureLayer.FeatureClass.Search(null, false);
            IFeature pfeature = pfeaturecursor.NextFeature();
            while (pfeature != null)
            {
                String[] fldvalue = new string[pfields.FieldCount];
                for (int i = 0; i < pfields.FieldCount; i++)
                {
                    string fldname = pfields.get_Field(i).Name;
                    if (fldname == 遥感数据管理系统.Form1.pfeaturelayer.pFeatureLayer.FeatureClass.ShapeFieldName)
                        fldvalue[i] = Convert.ToString(pfeature.Shape.GeometryType);
                    else
                        fldvalue[i] = Convert.ToString(pfeature.get_Value(i));
                }
                dataGridView1.Rows.Add(fldvalue);
                pfeature = pfeaturecursor.NextFeature();
            }

        }
    }
}
