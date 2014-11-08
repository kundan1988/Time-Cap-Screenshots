using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Code
{
    public class EquipmentListTableSource : UITableViewSource
    {
        public List<EquiplistRowData> Data { get; set; }
        protected string cellIdentifier = "TableCell";

        public override int RowsInSection(UITableView tableview, int section)
        {
            return Data.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            EquipmentListTableItem cell = tableView.DequeueReusableCell(cellIdentifier) as EquipmentListTableItem;
            if (cell == null)
                cell = new EquipmentListTableItem(cellIdentifier);
            //cell.UpdateCell(Data[indexPath.Row]);
            cell.UpdateCell(Data[indexPath.Row]);
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            return cell;

        }

        //EquipmentListTableItem protoType = new EquipmentListTableItem("TableCell");

        //public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        //{
          //  return protoType.MeasureHeight(tableView, Data[indexPath.Row]);
        //}

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            EquiplistRowData selectedItem = Data[indexPath.Row];

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
    }
}