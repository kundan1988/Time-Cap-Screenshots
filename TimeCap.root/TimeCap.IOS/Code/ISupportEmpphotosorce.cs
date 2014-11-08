using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public interface ISupportEmpphotosorce
    {
		string EmployeeName { get; }
        string EmployeeNumber { get; }
        UIImage ImageUri { get; }
    }
}