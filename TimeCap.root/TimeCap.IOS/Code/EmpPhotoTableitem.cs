using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Code
{
    public class EmpPhotoTableitem : UITableViewCell
    {
        UILabel headingLabel, subheadingLabel;
        UIImageView imageView;

        public EmpPhotoTableitem(IntPtr handle)
            : base(handle)
		{
		}

        public EmpPhotoTableitem(string cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            
            imageView = new UIImageView();
            headingLabel = new UILabel () {
                Font = UIFont.SystemFontOfSize(14f),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Right,
                BackgroundColor = UIColor.Clear
            };
            //subheadingLabel = new UILabel
            //{
            //    Font = UIFont.FromName("AmericanTypewriter", 10f),
            //    TextColor = UIColor.FromRGB(38, 127, 0),
            //    TextAlignment = UITextAlignment.Center,
            //    BackgroundColor = UIColor.Clear

            //};
            ContentView.AddSubviews(new UIView[] { headingLabel,imageView,  });//subheadingLabel,  });
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            imageView.Frame = new RectangleF(40, 10, ContentView.Bounds.Left - 30, 38);
            headingLabel.Frame = new RectangleF(5, 4, ContentView.Bounds.Width - 75, 35);
            //subheadingLabel.Frame = new RectangleF(15, 25, 200, 20);
        }

        internal void UpdateCell(string caption, UIImage uIImage)// string subtitle,)
        {
            imageView.Image = uIImage;
            headingLabel.Text = caption;
           // subheadingLabel.Text = subtitle;
        }
    }
}