using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Runtime.Serialization;

namespace TimeCap.iOS.Models
{
    [DataContract]
    public class EquipmentMasterDTO
    {
        [DataMember]
        public DateTime Workdate { get; set; }
        [DataMember]
        public int TimekeeperPersonnelNumber { get; set; }
        [DataMember]
        public string TimekeeperPersonnelName { get; set; }
        [DataMember]
        public string ProjectNumber { get; set; }
        [DataMember]
        public string EquipmentNumber { get; set; }
        [DataMember]
        public string EquipmentDescription { get; set; }
        [DataMember]
        public string EquipmentSerialNumber { get; set; }
        [DataMember]
        public string EquipmentClassCode { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ValidFromDate { get; set; }
        [DataMember]
        public Nullable<System.DateTime> ValidToDate { get; set; }
        [DataMember]
        public Nullable<decimal> HourlyRate { get; set; }
        [DataMember]
        public Nullable<decimal> UtilizedRate { get; set; }
        [DataMember]
        public Nullable<decimal> StandbyRate { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public string Photo { get; set; }
        [DataMember]
        public DateTime? CreateDate { get; set; }
        [DataMember]
        public DateTime? LastChangeDate { get; set; }
        [DataMember]
        public string CreateUser { get; set; }
        [DataMember]
        public string LastChangeUser { get; set; }
        
        public string UpdateFlag { get; set; }
    }
}