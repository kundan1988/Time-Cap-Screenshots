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
    public class ProjectEmployeeDTO
    {
        [DataMember]
        public string ProjectNumber { get; set; }

        [DataMember]
        public string ProjectDescription { get; set; }

		[DataMember]
		public string Workdate { get; set; }

        [DataMember]
        public int EmployeePersonnelNumber { get; set; }

        [DataMember]
        public string EmployeePersonnelName { get; set; }
        
        [DataMember]
        public Nullable<int> TimekeeperPersonnelNumber { get; set; }

        [DataMember]
        public string TimekeeperPersonnelName { get; set; }

        [DataMember]
        public string TransformedActivityNumber { get; set; }

        [DataMember]
        public string TransformedActivityElementNumber { get; set; }

        [DataMember]
        public string ActivityDescription { get; set; }

        [DataMember]
        public string ActivityElementDescription { get; set; }

        [DataMember]
        public Nullable<int> HRTimekeeperPersonnelNumber { get; set; }

        [DataMember]
        public string HRTimekeeperPersonnelName { get; set; }
        
        [DataMember]
        public Nullable<System.DateTime> ValidFromDate { get; set; }
        
        [DataMember]
        public Nullable<System.DateTime> ValidToDate { get; set; }

        [DataMember]
        public string EmployeePhoto { get; set; }

        [DataMember]
        public Nullable<System.DateTime> CreateDate { get; set; }
        [DataMember]
        public string CreateUser { get; set; }
        [DataMember]
        public Nullable<System.DateTime> LastChangeDate { get; set; }
        public string LastChangeUser { get; set; }
    }
}