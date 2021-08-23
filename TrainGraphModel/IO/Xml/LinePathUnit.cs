namespace TrainGraphModel.IO.Xml
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LinePathUnit
    {

        private ushort idField;

        private ushort startIDField;

        private ushort endIDField;

        private string runDirectionField;

        private string isDefaultField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort ID
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
        public ushort StartID
        {
            get
            {
                return this.startIDField;
            }
            set
            {
                this.startIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort EndID
        {
            get
            {
                return this.endIDField;
            }
            set
            {
                this.endIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RunDirection
        {
            get
            {
                return this.runDirectionField;
            }
            set
            {
                this.runDirectionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IsDefault
        {
            get
            {
                return this.isDefaultField;
            }
            set
            {
                this.isDefaultField = value;
            }
        }
    }


}
