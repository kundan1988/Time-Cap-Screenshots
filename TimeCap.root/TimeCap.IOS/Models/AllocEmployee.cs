using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Runtime.Serialization;

namespace TimeCap.iOS
{
	[DataContract]
	public class AllocEmployee
	{
		[DataMember]
		public string ProjectNumber { get; set; }
		[DataMember]
		public DateTime Workdate { get; set; }
		[DataMember]
		public int TimekeeperPersonnelNumber { get; set; }
		[DataMember]
		public string ChargeType { get; set; }
		[DataMember]
		public string ChargeCode { get; set; }
		[DataMember]
		public int EmployeePersonnelNumber { get; set;}
		[DataMember]
		public string AllocatedHours { get; set; }
		[DataMember]
		public string OccupationCode { get; set; }
		[DataMember]
		public Nullable<decimal> HourlyRate { get; set; }
		[DataMember]
		public string Currency { get; set; }
		[DataMember]
		public string ActualCost { get; set; }
		[DataMember]
		public DateTime? CreateDate { get; set; }
		[DataMember]
		public string CreateUser { get; set; }
		[DataMember]
		public DateTime? LastChangeDate { get; set; }
		[DataMember]
		public string LastChangeUser { get; set; }
		[DataMember]
		public string UpdateFlag { get; set; }
	}
}

