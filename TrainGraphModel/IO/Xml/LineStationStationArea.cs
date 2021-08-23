namespace TrainGraphModel.IO.Xml
{
    /// <summary>
    /// xml文件中的停车区域
    /// </summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LineStationStationArea
    {

        private ushort idField;

        private string nameField;

        private string dSNNameField;

        private double kiloField;

        private ushort maxStopTimeField;

        private ushort minStopTimeField;

        private ushort defaultStopTimeField;

        private ushort maxReversalTimeField;

        private ushort minReversalTimeField;

        private ushort defaultReversalTimeField;

        private string isTransferTrackField;

        private string isReversalTrackField;

        private string isPlatTrackField;

        private string trackNameField;

        private double virtualKiloField;

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
        public string DSNName
        {
            get
            {
                return this.dSNNameField;
            }
            set
            {
                this.dSNNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double Kilo
        {
            get
            {
                return this.kiloField;
            }
            set
            {
                this.kiloField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort MaxStopTime
        {
            get
            {
                return this.maxStopTimeField;
            }
            set
            {
                this.maxStopTimeField = value;
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort MaxReversalTime
        {
            get
            {
                return this.maxReversalTimeField;
            }
            set
            {
                this.maxReversalTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort MinReversalTime
        {
            get
            {
                return this.minReversalTimeField;
            }
            set
            {
                this.minReversalTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public ushort DefaultReversalTime
        {
            get
            {
                return this.defaultReversalTimeField;
            }
            set
            {
                this.defaultReversalTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IsTransferTrack
        {
            get
            {
                return this.isTransferTrackField;
            }
            set
            {
                this.isTransferTrackField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IsReversalTrack
        {
            get
            {
                return this.isReversalTrackField;
            }
            set
            {
                this.isReversalTrackField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string IsPlatTrack
        {
            get
            {
                return this.isPlatTrackField;
            }
            set
            {
                this.isPlatTrackField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TrackName
        {
            get
            {
                return this.trackNameField;
            }
            set
            {
                this.trackNameField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public double VirtualKilo
        {
            get
            {
                return this.virtualKiloField;
            }
            set
            {
                this.virtualKiloField = value;
            }
        }
    }


}
