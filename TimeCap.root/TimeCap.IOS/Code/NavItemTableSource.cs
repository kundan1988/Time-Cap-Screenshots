using System;
using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;
using System.Reflection;
using TimeCap.iOS.Models;
using TimeCap.iOS.Code;

namespace FontList.Code
{
	/// <summary>
	/// Combined DataSource and Delegate for our UITableView
	/// </summary>
	public class NavItemTableSource : UITableViewSource
	{
		protected List<NavItemGroup> navItems;
		string cellIdentifier = "NavTableCellView";
		UINavigationController navigationController;
		UIStoryboard storyboard = new UIStoryboard();

		public NavItemTableSource (UINavigationController navigationController, List<NavItemGroup> items)
		{
			navItems = items;
			this.navigationController = navigationController;
		}

		/// <summary>
		/// Called by the TableView to determine how many sections(groups) there are.
		/// </summary>
		public override int NumberOfSections (UITableView tableView)
		{
			return navItems.Count;
		}

		/// <summary>
		/// Called by the TableView to determine how many cells to create for that particular section.
		/// </summary>
		public override int RowsInSection (UITableView tableview, int section)
		{
			return navItems[section].Items.Count;
		}

		/// <summary>
		/// Called by the TableView to retrieve the header text for the particular section(group)
		/// </summary>
		public override string TitleForHeader (UITableView tableView, int section)
		{
            return navItems[section].Name + "  " + navItems[section].Description;
		}

		/// <summary>
		/// Called by the TableView to retrieve the footer text for the particular section(group)
		/// </summary>
        //public override string TitleForFooter (UITableView tableView, int section)
        //{
        //    return navItems[section].Footer;
        //}

		/// <summary>
		/// Called by the TableView to actually build each cell. 
		/// </summary>
		public override UITableViewCell GetCell (UITableView tableView, NSIndexPath indexPath)
		{
			NavItem navItem = this.navItems[indexPath.Section].Items[indexPath.Row];
			
			var cell = tableView.DequeueReusableCell (this.cellIdentifier);
			if (cell == null) 
            {
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, this.cellIdentifier);
				cell.Tag = Environment.TickCount;
            }
			
			//---- set the cell properties
            cell.TextLabel.Text = this.navItems[indexPath.Section].Items[indexPath.Row].Name +
            "   " + navItems[indexPath.Section].Items[indexPath.Row].Description;// +"\n" + "0.0 CY" + " " + navItems[indexPath.Section].Items[indexPath.Row].Footer + " WHr" + ",  " + "0.0 EHr";
            cell.DetailTextLabel.Text = "0.0 CY" + " " + this.navItems[indexPath.Section].Items[indexPath.Row].Footer + " WHr" + ",  " + "0.0 EHr";
            cell.TextLabel.LineBreakMode = UILineBreakMode.CharacterWrap;
            cell.TextLabel.Lines = 0;
            cell.BackgroundColor = UIColor.White;
            cell.TextLabel.TextColor = UIColor.Black;
            //cell.TextLabel.ShadowColor = UIColor.FromRGBA(0, 0, 0, 0.8f);

            cell.DetailTextLabel.Font = UIFont.FromName("Times New Roman", 11);
            cell.DetailTextLabel.TextColor = UIColor.FromRGB(1, 120, 200);
            cell.TextLabel.Font = UIFont.FromName("helvetica", 12f);
            //cell.Accessory = this.navItems[indexPath.Row].Done ? UITableViewCellAccessory.Checkmark : UITableViewCellAccessory.None;
            //cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            //Xamarin.Themes.IndustrialTheme.Apply(cell);
            return cell;
		}

        public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, MonoTouch.Foundation.NSIndexPath indexPath)
        {
            try
            {
                switch (editingStyle)
                {
                    case UITableViewCellEditingStyle.Delete:
                        //tableItems = RemoveAt(tableItems, indexPath.Row);
                        navItems.RemoveAt(indexPath.Row);
                        tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Top);
                        break;
                    case UITableViewCellEditingStyle.None:
                        Console.WriteLine("CommitEditingStyle:None called");
                        break;
                }
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }

		public event EventHandler<RowSelectedEventArgs> OnRowSelected;

		/// <summary>
		/// Is called when a row is selected
		/// </summary>
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			// NOTE: Don't call the base implementation on a Model class
			// see http://docs.xamarin.com/guides/ios/application_fundamentals/delegates,_protocols,_and_events
			//throw new NotImplementedException ();
			NavItem navItem = navItems[indexPath.Section].Items[indexPath.Row];
			tableView.DeselectRow (indexPath, true);
			if (OnRowSelected != null) 
			{
				OnRowSelected (this, new RowSelectedEventArgs (tableView, indexPath));
			}
		}
		public class RowSelectedEventArgs : EventArgs
		{
			public UITableView tableview { get; set; }
			public NSIndexPath indexpath { get; set; }
			public RowSelectedEventArgs(UITableView tableview, NSIndexPath indexpath): base()
			{
				this.tableview = tableview;
				this.indexpath = indexpath;
			}
		}
	}
}