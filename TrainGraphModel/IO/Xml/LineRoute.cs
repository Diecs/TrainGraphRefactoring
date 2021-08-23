namespace TrainGraphModel.IO.Xml
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class LineRoute
    {

        private ushort[] routStopAreaField;

        private ushort idField;

        private string nameField;

        private ushort startIDField;

        private ushort endIDField;

        private string directionField;

        private string showMarkContentField;

        private string relateRouteListField;

        private string discriptionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RoutStopArea")]
        public ushort[] RoutStopArea
        {
            get
            {
                return this.routStopAreaField;
            }
            set
            {
                this.routStopAreaField = value;
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
        public string Direction
        {
            get
            {
                return this.directionField;
            }
            set
            {
                this.directionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ShowMarkContent
        {
            get
            {
                return this.showMarkContentField;
            }
            set
            {
                this.showMarkContentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RelateRouteList
        {
            get
            {
                return this.relateRouteListField;
            }
            set
            {
                this.relateRouteListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Discription
        {
            get
            {
                return this.discriptionField;
            }
            set
            {
                this.discriptionField = value;
            }
        }
    }


}
