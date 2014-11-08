using System;
using System.Collections.Generic;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Code
{
    class AllocEmpTablesource : UITableViewSource
    {
        public List<AllocEmpRowData> Data { get; set; }
        protected string cellIdentifier = "TableCell";

        public override int RowsInSection(UITableView tableview, int section)
        {
            return Data.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            AllocEmpTableItem cell = tableView.DequeueReusableCell(cellIdentifier) as AllocEmpTableItem;
            if (cell == null)
                cell = new AllocEmpTableItem(cellIdentifier);
            cell.UpdateCell(Data[indexPath.Row]);
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            return cell;
        }

        AllocEmpTableItem protoType = new AllocEmpTableItem("TableCell");

        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return protoType.MeasureHeight(tableView, Data[indexPath.Row]);
        }

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            AllocEmpRowData selectedItem = Data[indexPath.Row];

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
