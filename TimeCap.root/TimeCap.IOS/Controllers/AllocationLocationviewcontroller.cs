using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using MonoTouch.MapKit;
using MonoTouch.CoreLocation;

namespace TimeCap.iOS
{
	partial class AllocationLocationviewcontroller : UIViewController
	{
		MKMapView mapview;
		UISegmentedControl maptypes;

		public AllocationLocationviewcontroller (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			mymap.ShowsUserLocation = true;
			mymap = new MKMapView (View.Bounds);
			mymap.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
			View.AddSubview (mymap);
			Console.WriteLine ("initial loc:"+ mymap.UserLocation.Coordinate.Latitude+","+mymap.UserLocation.Coordinate.Longitude);
		}
	}
}
