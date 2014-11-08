using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace TimeCap.iOS.Code
{
    partial class ProjectsearchTableItem : UITableViewCell
    {
        UILabel headinglbl, subheadinglbl, activitysubheadinglbl,allsubelement;

        public ProjectsearchTableItem(IntPtr handle)
            : base(handle)
        {
 
        }
        public ProjectsearchTableItem(string cellid):base(UITableViewCellStyle.Default, cellid)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;
            
            headinglbl = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(16f),
                TextColor = UIColor.Brown,
                BackgroundColor = UIColor.Clear,

            };
            subheadinglbl = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(12f),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Left,
                BackgroundColor = UIColor.Clear
            };
            activitysubheadinglbl = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(12f),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Left,
                BackgroundColor = UIColor.Clear
            };
            allsubelement = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(12f),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Left,
            };
            ContentView.Add(headinglbl);
            
            ContentView.AddSubviews(subheadinglbl, activitysubheadinglbl,allsubelement);
        }
        public void updatecell(string caption, string subtitle, string subactivitytitl, string allsubelementtitle)
        {
            headinglbl.Text = caption;
            subheadinglbl.Text = subtitle;
            activitysubheadinglbl.Text = subactivitytitl;
            allsubelement.Text = allsubelementtitle;
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            headinglbl.Frame = new RectangleF(5, 4, ContentView.Bounds.Width - 63, 25);
            subheadinglbl.Frame = new RectangleF(10, 25, 200, 20);
            activitysubheadinglbl.Frame = new RectangleF(10, 45, 200, 20);
            allsubelement.Frame = new RectangleF(10, 45, 200, 20);
        }
    }
}