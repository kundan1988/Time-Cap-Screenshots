using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Simple.OData.Client.Extensions;
using Simple.OData.Client;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Linq.Expressions;
using TimeCap.iOS.Code;
using TimeCap.iOS.Models;

namespace TimeCap.iOS
{
    public class ProjectListTableSource : UITableViewSource
    {
        public List<ISupportTableSource> Data { get; set; }
        protected string cellIdentifier = "TableCell";
        public override int RowsInSection(UITableView tableview, int section)
        {
            return Data.Count;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            ProjectListTableItem cell = tableView.DequeueReusableCell(cellIdentifier) as ProjectListTableItem;

            if (cell == null)
                cell = new ProjectListTableItem(cellIdentifier);
			cell.UpdateCell(Data[indexPath.Row].ProjectNum
				, Data[indexPath.Row].ProjectDescrip
				, Data[indexPath.Row].Transformedactnumber
				, Data[indexPath.Row].Transformedactelemnumber
                    , null);
            return cell;
        }

        public override string TitleForHeader(UITableView tableView, int section)
        {
			return Data[section].ProjectNum;
        }

        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 85f;
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            ISupportTableSource selectedItem = Data[indexPath.Row];

            // normal iOS behaviour is to remove the blue highlight
            tableView.DeselectRow(indexPath, true);

            if (OnRowSelected != null)
            {
                OnRowSelected(this, new RowSelectedEventArgs(tableView, indexPath));
            }
        }

        public event EventHandler<RowSelectedEventArgs> OnRowSelected;

        public class RowSelectedEventArgs : EventArgs
        {
            public UITableView tableView { get; set; }
            public NSIndexPath indexPath { get; set; }

            public RowSelectedEventArgs(UITableView tableView, NSIndexPath indexPath)
                : base()
            {
                this.tableView = tableView;
                this.indexPath = indexPath;
            }
        }
        public override bool CanMoveRow(UITableView tableView, NSIndexPath indexPath)
        {
            return base.CanMoveRow(tableView, indexPath);
        }
        
		public override void CommitEditingStyle(UITableView tableView, UITableViewCellEditingStyle editingStyle, NSIndexPath indexPath)
        {
			if (editingStyle == UITableViewCellEditingStyle.Delete) 
			{
				Data.RemoveAt (indexPath.Row);
				tableView.DeleteRows (new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
			}
            else if (editingStyle == UITableViewCellEditingStyle.Insert)
            {
                
            }
        }
		public override bool CanEditRow (UITableView tableView, NSIndexPath indexPath)
		{
			return true;
		}
    }
}