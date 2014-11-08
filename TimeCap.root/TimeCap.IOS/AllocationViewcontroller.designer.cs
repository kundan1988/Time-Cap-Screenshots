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
		UIButton btncancel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnsave { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (btncancel != null) {
				btncancel.Dispose ();
				btncancel = null;
			}
			if (btnsave != null) {
				btnsave.Dispose ();
				btnsave = null;
			}
		}
	}
}
