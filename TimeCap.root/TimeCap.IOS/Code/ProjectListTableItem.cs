using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Drawing;

namespace TimeCap.iOS
{
	partial class ProjectListTableItem : UITableViewCell
	{
        UILabel headingLabel, subheadingLabel, activitySubHeadingLabel, subactivydecrlabel;
        //UIImageView imageView;
        
        public ProjectListTableItem(IntPtr handle) : base(handle)
		{
		}

        public ProjectListTableItem(string cellId)
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
            subactivydecrlabel = new UILabel
            {
                Font = UIFont.SystemFontOfSize(10f),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Left,
                BackgroundColor = UIColor.Clear
            };
            ContentView.Add(headingLabel);
            ContentView.AddSubviews(subheadingLabel,activitySubHeadingLabel,subactivydecrlabel);
            //ContentView.AddSubviews(new UIView[] { headingLabel, subheadingLabel, imageView });
        }

        public void UpdateCell(string caption, string subtitle, string activitySubTitle, string subactdesctitl, UIImage image)
        {
            //imageView.Image = image;
            headingLabel.Text = caption;
            subheadingLabel.Text = subtitle;
            activitySubHeadingLabel.Text = activitySubTitle;
            subactivydecrlabel.Text = subactdesctitl;

        }

        public override void LayoutSubviews ()
        {
            base.LayoutSubviews ();
            //imageView.Frame = new RectangleF(ContentView.Bounds.Width - 63, 5, 33, 33);
            headingLabel.Frame = new RectangleF(5, 4, ContentView.Bounds.Width - 63, 25);
            subheadingLabel.Frame = new RectangleF(10, 25, 200, 20);
            activitySubHeadingLabel.Frame = new RectangleF(10, 45, 200, 20);
            subactivydecrlabel.Frame = new RectangleF(10, 65, 200, 20);
        }
	}
}
