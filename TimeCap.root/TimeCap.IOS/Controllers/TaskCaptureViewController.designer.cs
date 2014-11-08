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
	[Register ("TaskCaptureViewController")]
	partial class TaskCaptureViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton actualAllocationsButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton employeeListButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lbldate { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblprojectcnt { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lbltimekeepername { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lbltimekeepernumbr { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton projectMasterButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		TaskCaptureView TaskCaptureView { get; set; }

		[Action ("actualAllocationsButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void actualAllocationsButton_TouchUpInside (UIButton sender);

		[Action ("projectMasterButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void projectMasterButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (actualAllocationsButton != null) {
				actualAllocationsButton.Dispose ();
				actualAllocationsButton = null;
			}
			if (employeeListButton != null) {
				employeeListButton.Dispose ();
				employeeListButton = null;
			}
			if (lbldate != null) {
				lbldate.Dispose ();
				lbldate = null;
			}
			if (lblprojectcnt != null) {
				lblprojectcnt.Dispose ();
				lblprojectcnt = null;
			}
			if (lbltimekeepername != null) {
				lbltimekeepername.Dispose ();
				lbltimekeepername = null;
			}
			if (lbltimekeepernumbr != null) {
				lbltimekeepernumbr.Dispose ();
				lbltimekeepernumbr = null;
			}
			if (projectMasterButton != null) {
				projectMasterButton.Dispose ();
				projectMasterButton = null;
			}
			if (TaskCaptureView != null) {
				TaskCaptureView.Dispose ();
				TaskCaptureView = null;
			}
		}
	}
}
