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
	[Register ("MapViewController")]
	partial class MapViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MonoTouch.MapKit.MKMapView mymap { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (mymap != null) {
				mymap.Dispose ();
				mymap = null;
			}
		}
	}
}
