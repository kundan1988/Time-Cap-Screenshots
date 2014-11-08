using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using DataAccess;

namespace TimeCap.iOS.Code
{
    public class AllocEmployeeTableSource : UITableViewSource
    {
        public List<IsupportAllocEmployee> Data { get; set; }
        IList<Stock> tableItems;
        IEnumerable<Stock> items;
        protected string cellIdentifier = "TableCell";

        public override int RowsInSection(UITableView tableview, int section)
        {    
            return Data.Count;
        }
        public AllocEmployeeTableSource()
        {
            // TODO: Complete member initialization
            try
            {
                tableItems = items.ToList();
            }
            catch(Exception ex)
            {

            }
        }
        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            AllocEmployeeTableitem cell = tableView.DequeueReusableCell(cellIdentifier) as AllocEmployeeTableitem;
             if (cell == null)

                    cell = new AllocEmployeeTableitem(cellIdentifier);
                cell.UpdateCell(Data[indexPath.Row].EmployeeNumber + "   " + Data[indexPath.Row].EmployeeName
                    //, Data[indexPath.Row].EmployeeNumber //+ " " + "0.0 Allocated" + "  " + "0.0 Worked" + "  " + "0.0 Remaining"
                         , Data[indexPath.Row].ImageUri
                        , Data[indexPath.Row].AllocatedHours + " " + "  Allocated"
                            , Data[indexPath.Row].WorkedHours
                                , Data[indexPath.Row].EquipmentHours);
                return cell;
        }
        public Stock GetItem(int id)
        {
            return tableItems[id];
        }

        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 55f;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            IsupportAllocEmployee selectedItem = Data[indexPath.Row];
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
