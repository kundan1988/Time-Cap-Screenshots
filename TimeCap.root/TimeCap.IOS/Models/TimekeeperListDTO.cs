using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TimeCap.iOS.Models
{
    [DataContract]
    public class TimekeeperListDTO
    {
        [DataMember]
        public int TimekeeperPersonnelNumber { get; set; }
        [DataMember]
        public string TimekeeperPersonnelName { get; set; }
        [DataMember]
        public int ProjectNumber { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int EmployeePersonnelNumber { get; set; }
        [DataMember]
        public string EmployeePersonnelName { get; set; }
        [DataMember]
        public string EmployeePhoto { get; set; }
    }
}
