using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public class Empphotodata : ISupportEmpphotosorce
    {
        public string EmployeePersonnelNumber { get; set; }
        public string EmployeePersonnelName { get; set; }
        public UIImage EmployeePhoto { get; set; }

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
    }
}