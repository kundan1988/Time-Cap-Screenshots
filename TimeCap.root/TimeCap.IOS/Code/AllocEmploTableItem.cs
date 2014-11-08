using System;
using System.Collections.Generic;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace TimeCap.iOS.Code
{
    public class AllocEmploTableItem : UITableViewCell
    {
        UILabel headinglbl, subheadinglbl, allsubfooter;

        public AllocEmploTableItem(IntPtr handle)
            : base(handle)
        {

        }

         public AllocEmploTableItem(string CellId)
            : base(UITableViewCellStyle.Default, CellId)
        {
            SelectionStyle = UITableViewCellSelectionStyle.Gray;

            headinglbl = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(12f),
                TextColor = UIColor.Brown,
                TextAlignment = UITextAlignment.Justified,
                BackgroundColor = UIColor.Clear,

            };
            subheadinglbl = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(12f),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Justified,
                BackgroundColor = UIColor.Clear
            };
            allsubfooter = new UILabel()
            {
                Font = UIFont.SystemFontOfSize(12f),
                TextColor = UIColor.Black,
                TextAlignment = UITextAlignment.Justified,
                BackgroundColor = UIColor.Clear
            };
             ContentView.Add(headinglbl);

             ContentView.AddSubviews(subheadinglbl,allsubfooter);
        }
        public void updatecell(string caption, string subtitle,string footer)
        {
            headinglbl.Text = caption;
            subheadinglbl.Text = subtitle;
            allsubfooter.Text = footer;
        }
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            headinglbl.Frame = new RectangleF(5, 4, ContentView.Bounds.Width - 63, 25);
            subheadinglbl.Frame = new RectangleF(10, 25, 200, 20);
            allsubfooter.Frame = new RectangleF(10, 25, 200, 20);
        }

    }
}
