using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace TimeCap.iOS.Models
{
    [DataContract]
    public class AllocatedEquipDTO
    {
        [DataMember]
        public string ProjectNumber { get; set; }
        [DataMember]
        public string WorkDate { get; set; }
        [DataMember]
        public int TimekeeperPersonnelNumber { get; set; }
        [DataMember]
        public string TransformedActivityNumber { get; set; }
        [DataMember]
        public string EquipmentNumber { get; set; }
        [DataMember]
        public Nullable<decimal> AllocatedHours { get; set; }
        [DataMember]
        public Nullable<decimal> HourlyRate { get; set; }
        [DataMember]
        public string Currency { get; set; }
        [DataMember]
        public Nullable<decimal> ActualCost { get; set; }
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
