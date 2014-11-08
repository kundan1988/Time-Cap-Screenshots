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
	[Register ("AllocationsActualViewController")]
	partial class AllocationsActualViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton allocActivityButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton allocEmployeeButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton allocEquipmentButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lbltimekprname { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lbltimekprnum { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Timecapwrkdate { get; set; }

		[Action ("allocEmployeeButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void allocEmployeeButton_TouchUpInside (UIButton sender);

		[Action ("allocEquipmentButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void allocEquipmentButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (allocActivityButton != null) {
				allocActivityButton.Dispose ();
				allocActivityButton = null;
			}
			if (allocEmployeeButton != null) {
				allocEmployeeButton.Dispose ();
				allocEmployeeButton = null;
			}
			if (allocEquipmentButton != null) {
				allocEquipmentButton.Dispose ();
				allocEquipmentButton = null;
			}
			if (lbltimekprname != null) {
				lbltimekprname.Dispose ();
				lbltimekprname = null;
			}
			if (lbltimekprnum != null) {
				lbltimekprnum.Dispose ();
				lbltimekprnum = null;
			}
			if (Timecapwrkdate != null) {
				Timecapwrkdate.Dispose ();
				Timecapwrkdate = null;
			}
		}
	}
}
