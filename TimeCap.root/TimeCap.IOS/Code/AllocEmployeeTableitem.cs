using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Code
{
    public class AllocEmployeeTableitem: UITableViewCell
    {
        UILabel headingLabel, subheadingLabel, Allocatedhrs, WorkedHrs, EquipentHrs;
        UIImageView imageView;

        public AllocEmployeeTableitem(IntPtr handle)
            : base(handle)
		{
		}

        public AllocEmployeeTableitem(string cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            
            imageView = new UIImageView();
            headingLabel = new UILabel () 
            {
                Font = UIFont.SystemFontOfSize(14f),
                TextColor = UIColor.Brown,
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };
            subheadingLabel = new UILabel {
                Font = UIFont.FromName("AmericanTypewriter", 11f),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };
            Allocatedhrs = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(9f),
                TextColor = UIColor.Brown,
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };
            WorkedHrs = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(9f),
                TextColor = UIColor.Brown,
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };
            EquipentHrs = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(9f),
                TextColor = UIColor.Brown,
                TextAlignment = UITextAlignment.Center,
                BackgroundColor = UIColor.Clear
            };
            ContentView.AddSubviews(new UIView[] { headingLabel, subheadingLabel, imageView, Allocatedhrs, WorkedHrs, EquipentHrs });
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            
            imageView.Frame = new RectangleF(40, 10, ContentView.Bounds.Left - 30, 38);
            headingLabel.Frame = new RectangleF(10, 8, ContentView.Bounds.Width - 75, 35);
            subheadingLabel.Frame = new RectangleF(15, 25, 250, 20);
            Allocatedhrs.Frame = new RectangleF(15, 30, 500, 20);
            WorkedHrs.Frame = new RectangleF(15, 35, 200, 20);
            EquipentHrs.Frame = new RectangleF(15, 45, 200, 20);
        }

        internal void UpdateCell(string Employeenamenumber, UIImage image, string lblalloHrs, string lblrkHrs, string lblEquiHr)
        {
            imageView.Image = image;
            headingLabel.Text = Employeenamenumber;
            subheadingLabel.Text = lblalloHrs;
        }
    }
}
