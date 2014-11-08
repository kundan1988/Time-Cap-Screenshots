using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Code
{
    public class TimekeeperTablSource : UITableViewSource
    {
        public List<IsupportTimekeeper> Data { get; set; }
        protected string cellIdentifier = "TableCell";

        public override int RowsInSection(UITableView tableview, int section)
        {
            return Data.Count;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            TimekeeperTablItem cell = tableView.DequeueReusableCell(cellIdentifier) as TimekeeperTablItem;

            if (cell == null)
                cell = new TimekeeperTablItem(cellIdentifier);
            cell.UpdateCell(Data[indexPath.Row].Timekeepernumber
                    , Data[indexPath.Row].Timekeepername
                    , Data[indexPath.Row].Timekeeperphoto);
            return cell;
        }
        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 55f;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            IsupportTimekeeper selectedItem = Data[indexPath.Row];

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
    }
}