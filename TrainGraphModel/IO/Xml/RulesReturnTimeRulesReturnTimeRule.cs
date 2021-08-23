namespace TrainGraphModel.IO.Xml
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class RulesReturnTimeRulesReturnTimeRule
    {

        private ushort stationAreaIdField;

        private ushort minReturnTimeField;

        private ushort defaultReturnTimeField;

        private ushort valueField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort StationAreaId
        {
            get
            {
                return this.stationAreaIdField;
            }
            set
            {
                this.stationAreaIdField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort MinReturnTime
        {
            get
            {
                return this.minReturnTimeField;
            }
            set
            {
                this.minReturnTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort DefaultReturnTime
        {
            get
            {
                return this.defaultReturnTimeField;
            }
            set
            {
                this.defaultReturnTimeField = value;
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
