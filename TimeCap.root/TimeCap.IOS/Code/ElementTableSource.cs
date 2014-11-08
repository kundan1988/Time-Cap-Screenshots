using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Code
{
    public class ElementTableSource : UITableViewSource
    {
        public List<ISupportElement> Data { get; set; }
        protected string cellidentifier = "TableCell";
       
        public override int RowsInSection(UITableView tableview, int section)
        {
            return Data.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            ElementTableItem cell = tableView.DequeueReusableCell(cellidentifier) as ElementTableItem;
            if (cell == null)
                cell = new ElementTableItem(cellidentifier);
            cell.updatecell(Data[indexPath.Row].Transformedactnumber,
                Data[indexPath.Row].Activitynum,
                Data[indexPath.Row].ActivityDescription);
            cell.BackgroundColor = UIColor.Clear;
            cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
            return cell;
        }
                
        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 55f;
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
                //Delete the row from the data source.
                Data.RemoveAt(indexPath.Row);
                tableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);// controller.TableView.DeleteRows(new NSIndexPath[] { indexPath }, UITableViewRowAnimation.Fade);
            }
            else if (editingStyle == UITableViewCellEditingStyle.Insert)
            {
                // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
            }
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //base.RowSelected(tableView, indexPath);
            ISupportElement selectditm = Data[indexPath.Row];
            tableView.DeselectRow(indexPath, true);
            if (OnRowSelected != null)
            {
                OnRowSelected(this, new RowSelectedEventArgs(tableView, indexPath));
            }

        }
    }
}