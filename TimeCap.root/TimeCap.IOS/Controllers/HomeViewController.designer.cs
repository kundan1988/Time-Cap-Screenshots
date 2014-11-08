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
	[Register ("HomeViewController")]
	partial class HomeViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton dailyLogButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel dailyLogEntriesCountLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel dateLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton employeeSignoutButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton equipmentSignoutButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel equipmentSignoutCountLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lblsignutcnt { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lbltimekeeperid { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel lbltimekeppername { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton settingsButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel taskCaptureActivityCountLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton taskCaptureButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel taskCaptureCompActLabel { get; set; }

		[Action ("dailyLogButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void dailyLogButton_TouchUpInside (UIButton sender);

		[Action ("employeeSignoutButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void employeeSignoutButton_TouchUpInside (UIButton sender);

		[Action ("equipmentSignoutButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void equipmentSignoutButton_TouchUpInside (UIButton sender);

		[Action ("settingsButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void settingsButton_TouchUpInside (UIButton sender);

		[Action ("taskCaptureButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void taskCaptureButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (dailyLogButton != null) {
				dailyLogButton.Dispose ();
				dailyLogButton = null;
			}
			if (dailyLogEntriesCountLabel != null) {
				dailyLogEntriesCountLabel.Dispose ();
				dailyLogEntriesCountLabel = null;
			}
			if (dateLabel != null) {
				dateLabel.Dispose ();
				dateLabel = null;
			}
			if (employeeSignoutButton != null) {
				employeeSignoutButton.Dispose ();
				employeeSignoutButton = null;
			}
			if (equipmentSignoutButton != null) {
				equipmentSignoutButton.Dispose ();
				equipmentSignoutButton = null;
			}
			if (equipmentSignoutCountLabel != null) {
				equipmentSignoutCountLabel.Dispose ();
				equipmentSignoutCountLabel = null;
			}
			if (lblsignutcnt != null) {
				lblsignutcnt.Dispose ();
				lblsignutcnt = null;
			}
			if (lbltimekeeperid != null) {
				lbltimekeeperid.Dispose ();
				lbltimekeeperid = null;
			}
			if (lbltimekeppername != null) {
				lbltimekeppername.Dispose ();
				lbltimekeppername = null;
			}
			if (settingsButton != null) {
				settingsButton.Dispose ();
				settingsButton = null;
			}
			if (taskCaptureActivityCountLabel != null) {
				taskCaptureActivityCountLabel.Dispose ();
				taskCaptureActivityCountLabel = null;
			}
			if (taskCaptureButton != null) {
				taskCaptureButton.Dispose ();
				taskCaptureButton = null;
			}
			if (taskCaptureCompActLabel != null) {
				taskCaptureCompActLabel.Dispose ();
				taskCaptureCompActLabel = null;
			}
		}
	}
}
