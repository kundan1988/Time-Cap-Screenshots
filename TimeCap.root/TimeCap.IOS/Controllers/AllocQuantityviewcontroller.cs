using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace TimeCap.iOS
{
	partial class AllocQuantityviewcontroller : UIViewController
	{

		public AllocQuantityviewcontroller (IntPtr handle) : base (handle)
		{

		}
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.White;

			fieldphoto = new UIImageView (UIImage.FromBundle ("field.jpg"));
			fieldphoto.Frame = new RectangleF(84, fieldphoto.Frame.Height + 168,
				View.Frame.Width - 168, View.Frame.Width / 2);
			View.AddSubview (fieldphoto);
		}
	}
}
