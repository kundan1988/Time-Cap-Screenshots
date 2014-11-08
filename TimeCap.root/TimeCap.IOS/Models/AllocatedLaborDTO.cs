using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace TimeCap.iOS.Models
{
    [DataContract]
    public class AllocatedLaborDTO
    {
        [DataMember]
        public string ProjectNumber { get; set; }
        [DataMember]
        public string WorkDate { get; set; }
        [DataMember]
        public int TimekeeperPersonnelNumber { get; set; }
        [DataMember]
        public string ChargeType { get; set; }
        [DataMember]
        public string ChargeCode { get; set; }
        [DataMember]
        public int EmployeePersonnelNumber { get; set; }
        [DataMember]
        public Nullable<decimal> AllocatedHours { get; set; }
        [DataMember]
        public int OccupationCode { get; set; }
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
