using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Models
{
    [DataContract]
    public class LaborSignoutDTO
    {
        //[Key, DataMember]
        ////[XmlElement(DataType = "date")]
        //public string WorkDate { get; set; }
        [DataMember]
        public string WorkDate { get; set; }
        
        [DataMember]
        public Nullable<System.DateTime> LaborSignoutDateTime { get; set; }
        
        [DataMember]
        public decimal? Longitude { get; set; }

        [DataMember]
        public decimal? Latitude { get; set; }
        
        [Key, DataMember]
        public int EmployeePersonnelNumber { get; set; }

        [DataMember]
        public string EmployeePersonnelName { get; set; }

        [DataMember]
        public Nullable<decimal> TotalSignoutHours { get; set; }

        [DataMember]
        public Nullable<decimal> AllocatedHours { get; set; }
        
        [DataMember]
        public string ZeroHourCode { get; set; }
        
        [DataMember]
        public Nullable<decimal> TotalAdjustedHours { get; set; }
        
        [DataMember]
        public string Injured { get; set; }

        [DataMember]
        public bool IsSigned { get; set; }

        [DataMember]
        public string UnavailableToSign { get; set; }

        [DataMember]
        public string SignoutReasonCode { get; set; }

        [DataMember]
        public string Notes { get; set; }
        
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