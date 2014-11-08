using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TimeCap.iOS.Models
{
    [DataContract]
    public class LaborSignatureDTO
    {
        [DataMember]
        //[XmlElement(DataType = "date")]
        public string WorkDate { get; set; }

        [DataMember]
        public int EmployeePersonnelNumber { get; set; }

        [DataMember]
        public string EmployeePersonnelName { get; set; }

        [DataMember]
        public string SignatureScreen { get; set; }

        [DataMember]
        public Nullable<System.DateTime> CreateDate { get; set; }

        [DataMember]
        public string CreateUser { get; set; }

        [DataMember]
        public Nullable<System.DateTime> LastChangeDate { get; set; }

        [DataMember]
        public string LastChangeUser { get; set; }

        [DataMember]
        public string UpdateFlag { get; set; }
    }
}