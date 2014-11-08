using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Platform.iOS;

namespace TimeCap.iOS
{
	partial class Xamarinformsviewcontroller
	{
		public static Page GetMainPage ()
		{	
			return new ContentPage 
			{ 
				Content = new Label 
				{
					Text = "Hello World!",
					VerticalOptions = LayoutOptions.CenterAndExpand,
					HorizontalOptions = LayoutOptions.CenterAndExpand,
				},
			};
		}
	}
}
