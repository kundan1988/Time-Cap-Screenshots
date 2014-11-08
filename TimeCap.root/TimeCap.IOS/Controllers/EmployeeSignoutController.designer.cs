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
	[Register ("EmployeeSignoutController")]
	partial class EmployeeSignoutController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField actualHoursWorkedTextbox { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton cancelButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel employeeNameLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel employeeNumberLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextView notesTextView { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel remainingHoursLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton submitButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (actualHoursWorkedTextbox != null) {
				actualHoursWorkedTextbox.Dispose ();
				actualHoursWorkedTextbox = null;
			}
			if (cancelButton != null) {
				cancelButton.Dispose ();
				cancelButton = null;
			}
			if (employeeNameLabel != null) {
				employeeNameLabel.Dispose ();
				employeeNameLabel = null;
			}
			if (employeeNumberLabel != null) {
				employeeNumberLabel.Dispose ();
				employeeNumberLabel = null;
			}
			if (notesTextView != null) {
				notesTextView.Dispose ();
				notesTextView = null;
			}
			if (remainingHoursLabel != null) {
				remainingHoursLabel.Dispose ();
				remainingHoursLabel = null;
			}
			if (submitButton != null) {
				submitButton.Dispose ();
				submitButton = null;
			}
		}
	}
}
