using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TrainGraphModel.IO.Xml
{

    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。

    /// <summary>
    /// LineInfo.xml文件对应的数据类
    /// </summary>
    [SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [XmlTypeAttribute(AnonymousType = true)]
    [XmlRootAttribute("Line",Namespace = "", IsNullable = false)]
    public class LineXmlDto
    {

        private object lineInfosField;

        private LineStation[] stationsField;

        private LinePathUnit[] pathUnitsField;

        private LineRoute[] routesField;

        private ushort idField;

        private string nameField;

        private string fsVersionField;

        /// <remarks/>
        public object LineInfos
        {
            get
            {
                return this.lineInfosField;
            }
            set
            {
                this.lineInfosField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Station", IsNullable = false)]
        public LineStation[] Stations
        {
            get
            {
                return this.stationsField;
            }
            set
            {
                this.stationsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("PathUnit", IsNullable = false)]
        public LinePathUnit[] PathUnits
        {
            get
            {
                return this.pathUnitsField;
            }
            set
            {
                this.pathUnitsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Route", IsNullable = false)]
        public LineRoute[] Routes
        {
            get
            {
                return this.routesField;
            }
            set
            {
                this.routesField = value;
            }
        }


        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FsVersion
        {
            get
            {
                return this.fsVersionField;
            }
            set
            {
                this.fsVersionField = value;
            }
        }
    }

}
