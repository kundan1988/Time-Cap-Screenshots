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
    public class LaborListDTO
    {
        [Key, DataMember]
        public string WorkDate { get; set; }
        [Key, DataMember]
        public int TimekeeperPersonnelNumber { get; set; }
        [DataMember]
        public string TimekeeperPersonnelName { get; set; }
        [DataMember]
        public int EmployeePersonnelNumber { get; set; }
        [DataMember]
        public string EmployeePersonnelName { get; set; }
        [DataMember]
        public Nullable<System.DateTime> CreateDate { get; set; }
        [DataMember]
        public string CreateUser { get; set; }
        [DataMember]
        public string EmployeePhoto { get; set; }
        [DataMember]
        public Nullable<System.DateTime> LastChangeDate { get; set; }
        [DataMember]
        public string LastChangeUser { get; set; }
        [DataMember]
        public string UpdateFlag { get; set; }
        [DataMember]
        public Nullable<System.DateTime> LaborSignoutDateTime { get; set; }

        internal LaborListDTO ShallowCopy()
        {
            return (LaborListDTO)this.MemberwiseClone();
        }

    }
}