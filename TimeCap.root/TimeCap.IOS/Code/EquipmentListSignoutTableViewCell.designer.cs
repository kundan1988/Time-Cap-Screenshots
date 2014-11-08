// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace TimeCap.iOS
{
	[Register ("EquipmentListSignoutTableViewCell")]
	partial class EquipmentListSignoutTableViewCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel aLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.UIKit.UILabel employeeIdLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (aLabel != null) {
				aLabel.Dispose ();
				aLabel = null;
			}
			if (employeeIdLabel != null) {
				employeeIdLabel.Dispose ();
				employeeIdLabel = null;
			}
		}
	}
}
