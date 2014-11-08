using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace TimeCap.iOS.Models
{
    [DataContract]
    public class EmployeePhotoDTO
    {
        [DataMember]
        public int ProjectNumber { get; set; }
        [DataMember]
        public string ProjectDescription { get;set; }
        [DataMember]
        public int EmployeePersonnelNumber  { get; set; }
        [DataMember]
        public string  EmployeePersonnelName  { get; set; }
        [DataMember]
        public int  TimekeeperPersonnelNumber { get; set; }
        [DataMember]
        public string  TimekeeperPersonnelName  { get; set; }
        [DataMember]
        public int  HRTimekeeperPersonnelNumber { get; set; }
        [DataMember]
        public string  HRTimekeeperPersonnelName  { get; set; }
        [DataMember]
        public string  ValidFromDate { get; set; }
        [DataMember]
        public string   ValidToDate  { get; set; }
        [DataMember]
        public string EmployeePhoto { get; set; }
        [DataMember]
        public Nullable<System.DateTime> CreateDate { get; set; }
        [DataMember]
        public string    CreateUser    { get; set; }
        [DataMember]
        public Nullable<System.DateTime> LastChangeDate { get; set; }
    }
}