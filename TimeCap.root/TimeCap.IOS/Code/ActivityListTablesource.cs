using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Code
{
    public class ActivityListTablesource : UITableViewSource
    {
        public List<IsupportActivity> Data { get; set; }
        protected string cellidentifier = "TableCell";

        public override int RowsInSection(UITableView tableview, int section)
        {
            return Data.Count;
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            ActivityListTableItem cell = tableView.DequeueReusableCell(cellidentifier) as ActivityListTableItem;
            if (cell == null)
                cell = new ActivityListTableItem(cellidentifier);
            cell.UpdateCell(Data[indexPath.Row].Text
                    , Data[indexPath.Row].Details
                    , Data[indexPath.Row].Subdetail);
                    //UIImage.LoadFromData(Data[indexPath.Row].imageurl));
            //cell.TextLabel.Text = Data[indexPath.Row].Text;
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            return cell;
        }
        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 65f;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            IsupportActivity selectedItem = Data[indexPath.Row];
            
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
    }
}