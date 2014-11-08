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
	[Register ("ProjectListViewController")]
	partial class ProjectListViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem btnadd { get; set; }

		[Action ("btnadd_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnadd_Activated (UIBarButtonItem sender);

		[Action ("UIBarButtonItem677_Activated:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void UIBarButtonItem677_Activated (UIBarButtonItem sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnadd != null) {
				btnadd.Dispose ();
				btnadd = null;
			}
		}
	}
}
