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
	[Register ("IGCalendarViewXamarinViewController")]
	partial class IGCalendarViewXamarinViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lbltimekeepername { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lbltimekeepernum { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel timekeepername { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel Timekeepernum { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel timekeepernumber { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (lbltimekeepername != null) {
				lbltimekeepername.Dispose ();
				lbltimekeepername = null;
			}
			if (lbltimekeepernum != null) {
				lbltimekeepernum.Dispose ();
				lbltimekeepernum = null;
			}
			if (timekeepername != null) {
				timekeepername.Dispose ();
				timekeepername = null;
			}
			if (Timekeepernum != null) {
				Timekeepernum.Dispose ();
				Timekeepernum = null;
			}
			if (timekeepernumber != null) {
				timekeepernumber.Dispose ();
				timekeepernumber = null;
			}
		}
	}
}
