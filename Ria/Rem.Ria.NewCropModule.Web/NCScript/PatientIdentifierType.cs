﻿namespace Rem.Ria.NewCropModule.Web.NCScript
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.225")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://secure.newcropaccounts.com/interfaceV7", TypeName = "PatientIdentifierType")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "http://secure.newcropaccounts.com/interfaceV7", IsNullable = true, ElementName = "PatientIdentifierType")]
    public partial class PatientIdentifierType
    {

        private string patientIDField;

        private string patientIDTypeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "patientID")]
        public virtual string PatientID
        {
            get
            {
                return this.patientIDField;
            }
            set
            {
                this.patientIDField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(ElementName = "patientIDType")]
        public virtual string PatientIDType
        {
            get
            {
                return this.patientIDTypeField;
            }
            set
            {
                this.patientIDTypeField = value;
            }
        }
    }
}