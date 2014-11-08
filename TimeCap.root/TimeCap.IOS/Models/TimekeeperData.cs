using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public class TimekeeperData : IsupportTimekeeper
    {
        public string TimekeeperPersonnelName { get; set; }
        public string TimekeeperPersonnelNumber { get; set; }
        public UIImage EmployeePhoto { get; set; }

        public string Timekeepername
        {
            get { return TimekeeperPersonnelName; }
        }
        public string Timekeepernumber
        {
            get { return Timekeepernumber; }
        }
        public UIImage Timekeeperphoto
        {
            get { return EmployeePhoto; }
        }
    }
}   