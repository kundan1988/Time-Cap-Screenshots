using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Models
{
    [DataContract]
    public class TaskListDTO
    {
        [DataMember]
        public string ProjectNumber { get; set; }
        [DataMember]
        public string ProjectDescription { get; set; }
        [DataMember]
		public string WorkDate { get; set; }
        [DataMember]
        public int TimekeeperPersonnelNumber { get; set; }
        [DataMember]
        public string TransformedActivityElementNumber { get; set; }
        [DataMember]
        public string NetworkNumber { get; set; }
        [DataMember]
        public string ActivityNumber { get; set; }
        [DataMember]
        public string ActivityDescription { get; set; }
        [DataMember]
        public string ElementNumber { get; set; }
        [DataMember]
        public Nullable<decimal> ActualQuantity { get; set; }
        [DataMember]
        public string UoM { get; set; }
        [DataMember]
        public string Notes { get; set; }
        [DataMember]
		public string CreateDate { get; set; }
        [DataMember]
        public string CreateUser { get; set; }
        [DataMember]
		public string LastChangeDate { get; set; }
        [DataMember]
        public string LastChangeUser { get; set; }
        [DataMember]
        public string WBSElementNumber { get; set; }
        [DataMember]
        public string WBSElementDescription { get; set; }
        [DataMember]
        public Nullable<decimal> TakeoffQuantity { get; set; }
        [DataMember]
        public string TransformedActivityNumber { get; set; }
        [DataMember]
        public string ActivityElementDescription { get; set; }
        [DataMember]
        public Nullable<decimal> EstimatedQuantity { get; set; }
        [DataMember]
        public Nullable<int> Percent { get; set; }
        [DataMember]
        public Nullable<decimal> Factor { get; set; }
        [DataMember]
        public Nullable<decimal> BudgetLaborAmountByUnit { get; set; }
        [DataMember]
        public Nullable<decimal> BudgetLaborHoursByUnit { get; set; }
        [DataMember]
        public Nullable<decimal> BudgetEquipAmountByUnit { get; set; }
        [DataMember]
        public string UpdateFlag { get; set; }
    }
}