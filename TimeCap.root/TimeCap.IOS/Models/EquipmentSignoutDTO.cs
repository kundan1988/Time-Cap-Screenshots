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
   public class EquipmentSignoutDTO
    {
        [DataMember]
        public string WorkDate { get; set; }
        [DataMember]
        public string EquipmentNumber { get; set; }
        [DataMember]
        public string Longitude { get; set; }
        [DataMember]
        public string Latitude { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ShiftStart { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ShiftEnd { get; set; }
        [DataMember]
        public string AllocatedHours { get; set; }
        [DataMember]
        public string TotalMeterHours { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
        public string EquipmentDescription { get; set; }
        [DataMember]
        public string EquipmentSerialNumber { get; set; }
        [DataMember]
        public string EquipmentClassCode { get; set; }
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