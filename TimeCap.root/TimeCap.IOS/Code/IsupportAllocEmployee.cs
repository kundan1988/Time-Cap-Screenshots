using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public interface IsupportAllocEmployee
    {
        string EmployeeName { get; }
        string EmployeeNumber { get; }
        UIImage ImageUri { get; }
        string AllocatedHours { get; }
        string WorkedHours { get; }
        string EquipmentHours { get; }
    }
}