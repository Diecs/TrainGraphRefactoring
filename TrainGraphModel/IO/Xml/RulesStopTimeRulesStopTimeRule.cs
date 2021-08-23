namespace TrainGraphModel.IO.Xml
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class RulesStopTimeRulesStopTimeRule
    {

        private ushort stationAreaIdField;

        private ushort minStopTimeField;

        private ushort defaultStopTimeField;

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
        public ushort MinStopTime
        {
            get
            {
                return this.minStopTimeField;
            }
            set
            {
                this.minStopTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort DefaultStopTime
        {
            get
            {
                return this.defaultStopTimeField;
            }
            set
            {
                this.defaultStopTimeField = value;
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
