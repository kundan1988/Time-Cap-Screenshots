using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public  class AllocEmployeePhoto : IsupportAllocEmployee
    {
        public string EmployeePersonnelNumber { get; set; }
        public string EmployeePersonnelName { get; set; }
        public UIImage EmployeePhoto { get; set; }
        public string AllocHours { get; set; }
        public string WorkdHours { get; set; }
        public string EquipHours { get; set; }

        public string EmployeeName
        {
            get { return EmployeePersonnelName; }
        }

        public string EmployeeNumber
        {
            get { return EmployeePersonnelNumber; }
        }

        public UIImage ImageUri
        {
            get { return EmployeePhoto; }
        }

        public string AllocatedHours
        {
            get { return AllocHours; }
        }
        public string WorkedHours
        {
            get { return WorkdHours; }
        }
        public string EquipmentHours
        {
            get { return EquipHours; }
        }
    }
}
