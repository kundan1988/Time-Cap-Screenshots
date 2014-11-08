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
     public class TimekeeperTablItem : UITableViewCell
    {
         UILabel Heading, SubHeading;
         UIImageView TimekeeperPhoto;

         public TimekeeperTablItem(IntPtr handle)
             : base(handle)
         {
         }
         public TimekeeperTablItem(string cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            
            TimekeeperPhoto = new UIImageView();
            Heading = new UILabel () {
                Font = UIFont.SystemFontOfSize(16f),
                TextColor = UIColor.Brown,
                BackgroundColor = UIColor.Clear
            };
            SubHeading = new UILabel {
                Font = UIFont.SystemFontOfSize(12f),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Left,
                BackgroundColor = UIColor.Clear
            };
            ContentView.AddSubviews(new UIView[] { Heading, SubHeading, TimekeeperPhoto });
        }
         public void UpdateCell(string caption, string subtitle, UIImage image)
         {
             TimekeeperPhoto.Image = image;
             Heading.Text = caption;
             SubHeading.Text = subtitle;

         }
         public override void LayoutSubviews()
         {
             base.LayoutSubviews();
             TimekeeperPhoto.Frame = new RectangleF(40, 10, ContentView.Bounds.Left - 30, 38);
             Heading.Frame = new RectangleF(5, 4, ContentView.Bounds.Width - 75, 35);
             SubHeading.Frame = new RectangleF(15, 25, 200, 20);
         }
    }
}