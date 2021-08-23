namespace TrainGraphModel.IO.Xml
{
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public class RulesReturnTimeRules
    {

        private RulesReturnTimeRulesReturnTimeRule[] returnTimeRuleField;

        private string nameField;

        private string descriptionField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ReturnTimeRule")]
        public RulesReturnTimeRulesReturnTimeRule[] ReturnTimeRule
        {
            get
            {
                return this.returnTimeRuleField;
            }
            set
            {
                this.returnTimeRuleField = value;
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
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }





}
