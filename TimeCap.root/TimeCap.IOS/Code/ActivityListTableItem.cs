using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace TimeCap.iOS
{
    public class ActivityListTableItem : UITableViewCell
    {
        UILabel headingLabel, subheadingLabel, activitySubHeadingLabel;
        //public UIImageView imageView { get; set; }

        public ActivityListTableItem(IntPtr handle)
            : base(handle)
		{
		}
        public ActivityListTableItem(string cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            //ContentView.BackgroundColor = UIColor.FromRGB (218, 255, 127);
            //imageView = new UIImageView();
            headingLabel = new UILabel () {
                Font = UIFont.SystemFontOfSize(16f),
                TextColor = UIColor.Brown, // UIColor.FromRGB (127, 51, 0),
                BackgroundColor = UIColor.Clear
            };
            subheadingLabel = new UILabel {
                Font = UIFont.SystemFontOfSize(12f),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Left,
                BackgroundColor = UIColor.Clear
            };
            activitySubHeadingLabel = new UILabel
            {
                Font = UIFont.SystemFontOfSize(10f),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Left,
                BackgroundColor = UIColor.Clear
            };
            ContentView.Add (headingLabel);
            ContentView.AddSubviews(subheadingLabel, activitySubHeadingLabel);
            //ContentView.Add(imageView);
        }
        public void UpdateCell(string caption, string subtitle, string activitySubTitle)//,UIImage image)
        {
            headingLabel.Text = caption;
            subheadingLabel.Text = subtitle;
            activitySubHeadingLabel.Text = activitySubTitle;
            //imageView.Image = image;
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            //imageView.Frame = new RectangleF(ContentView.Bounds.Width - 65, 5,33,33);
            headingLabel.Frame = new RectangleF(5, 4, ContentView.Bounds.Width - 63, 25);
            subheadingLabel.Frame = new RectangleF(10, 25, 200, 20);
            activitySubHeadingLabel.Frame = new RectangleF(10, 45, 200, 20);
        }

       
    }
}