using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;

namespace TimeCap.iOS
{
	partial class Timekeeperimagelistcontroller : UIViewController
	{
        UITableView table;

		public Timekeeperimagelistcontroller (IntPtr handle) : base (handle)
		{
		}
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            table = new UITableView(View.Bounds);
            table.AutoresizingMask = UIViewAutoresizing.All;
            List<TableItem> tableItems = new List<TableItem>();
        }
	}
}
