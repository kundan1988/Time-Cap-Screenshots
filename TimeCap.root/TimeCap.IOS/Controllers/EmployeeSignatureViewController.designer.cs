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
	[Register ("EmployeeSignatureViewController")]
	partial class EmployeeSignatureViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton saveButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		SignaturePad.SignaturePadView signaturePad { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIImageView signView { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (saveButton != null) {
				saveButton.Dispose ();
				saveButton = null;
			}
			if (signaturePad != null) {
				signaturePad.Dispose ();
				signaturePad = null;
			}
			if (signView != null) {
				signView.Dispose ();
				signView = null;
			}
		}
	}
}
