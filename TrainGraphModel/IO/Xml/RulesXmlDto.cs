using System;
using System.Collections.Generic;
using System.Text;

namespace TrainGraphModel.IO.Xml
{
    // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。

    /// <summary>
    /// GraphRulesManage.xml文件对应的数据类
    /// </summary>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute("Rules",Namespace = "", IsNullable = false)]
    public class RulesXmlDto
    {
        private RulesRunAreaRules[] runRulesField;

        private RulesStopTimeRules[] stopRulesField;

        private RulesReturnTimeRules[] returnRulesField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("RunAreaRules", IsNullable = false)]
        public RulesRunAreaRules[] RunRules
        {
            get
            {
                return this.runRulesField;
            }
            set
            {
                this.runRulesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("StopTimeRules", IsNullable = false)]
        public RulesStopTimeRules[] StopRules
        {
            get
            {
                return this.stopRulesField;
            }
            set
            {
                this.stopRulesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReturnTimeRules", IsNullable = false)]
        public RulesReturnTimeRules[] ReturnRules
        {
            get
            {
                return this.returnRulesField;
            }
            set
            {
                this.returnRulesField = value;
            }
        }
    }





}
