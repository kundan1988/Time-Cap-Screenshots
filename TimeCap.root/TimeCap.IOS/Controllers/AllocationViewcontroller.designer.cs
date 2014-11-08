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
	[Register ("AllocationViewcontroller")]
	partial class AllocationViewcontroller
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btndone { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView empimg { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblempname { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblempnumber { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblprojectactivitynum { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtallocatedhrs { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtremininghrs { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txttotalhourswrktoday { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btndone != null) {
				btndone.Dispose ();
				btndone = null;
			}
			if (empimg != null) {
				empimg.Dispose ();
				empimg = null;
			}
			if (lblempname != null) {
				lblempname.Dispose ();
				lblempname = null;
			}
			if (lblempnumber != null) {
				lblempnumber.Dispose ();
				lblempnumber = null;
			}
			if (lblprojectactivitynum != null) {
				lblprojectactivitynum.Dispose ();
				lblprojectactivitynum = null;
			}
			if (txtallocatedhrs != null) {
				txtallocatedhrs.Dispose ();
				txtallocatedhrs = null;
			}
			if (txtremininghrs != null) {
				txtremininghrs.Dispose ();
				txtremininghrs = null;
			}
			if (txttotalhourswrktoday != null) {
				txttotalhourswrktoday.Dispose ();
				txttotalhourswrktoday = null;
			}
		}
	}
}
