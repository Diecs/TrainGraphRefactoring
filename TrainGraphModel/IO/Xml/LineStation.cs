namespace TrainGraphModel.IO.Xml
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LineStation
    {

        private LineStationTrackStopArea[] trackStopAreasField;

        private LineStationStationArea[] stopAreasField;

        private ushort idField;

        private string nameField;

        private string typeField;

        private string fontIsBoldField;

        private ushort lineIDField;

        private bool lineIDFieldSpecified;

        private string lineNameField;

        private bool lineNameFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("TrackStopArea", IsNullable = false)]
        public LineStationTrackStopArea[] TrackStopAreas
        {
            get
            {
                return this.trackStopAreasField;
            }
            set
            {
                this.trackStopAreasField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("StationArea", IsNullable = false)]
        public LineStationStationArea[] StopAreas
        {
            get
            {
                return this.stopAreasField;
            }
            set
            {
                this.stopAreasField = value;
            }
        }

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
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FontIsBold
        {
            get
            {
                return this.fontIsBoldField;
            }
            set
            {
                this.fontIsBoldField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort LineID
        {
            get
            {
                return this.lineIDField;
            }
            set
            {
                this.lineIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LineIDSpecified
        {
            get
            {
                return this.lineIDFieldSpecified;
            }
            set
            {
                this.lineIDFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LineName
        {
            get
            {
                return this.lineNameField;
            }
            set
            {
                this.lineNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LineNameSpecified
        {
            get
            {
                return this.lineNameFieldSpecified;
            }
            set
            {
                this.lineNameFieldSpecified = value;
            }
        }
    }


}
