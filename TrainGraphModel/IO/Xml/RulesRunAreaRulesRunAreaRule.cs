namespace TrainGraphModel.IO.Xml
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class RulesRunAreaRulesRunAreaRule
    {

        private ushort startIDField;

        private ushort endIDField;

        private ushort defaultRunTimeField;

        private ushort valueField;

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
        public ushort DefaultRunTime
        {
            get
            {
                return this.defaultRunTimeField;
            }
            set
            {
                this.defaultRunTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public ushort Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }





}
