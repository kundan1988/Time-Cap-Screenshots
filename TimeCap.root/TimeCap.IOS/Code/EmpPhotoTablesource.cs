using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
//using Xamarin.Themes;

namespace TimeCap.iOS.Code
{
    public class EmpPhotoTablesource : UITableViewSource
    {
        public List<ISupportEmpphotosorce> Data { get; set; }
        protected string cellIdentifier = "TableCell";

        public override int RowsInSection(UITableView tableview, int section)
        {
            return Data.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            EmpPhotoTableitem cell = tableView.DequeueReusableCell(cellIdentifier) as EmpPhotoTableitem;
            
            if (cell == null)
                cell = new EmpPhotoTableitem(cellIdentifier);
			cell.UpdateCell(Data[indexPath.Row].EmployeeNumber +"  " + Data[indexPath.Row].EmployeeName
                    ,Data[indexPath.Row].ImageUri);
            //Industrial`Theme.Apply(cell);
            return cell;
        }
        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 55f;
        }
        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            ISupportEmpphotosorce selectedItem = Data[indexPath.Row];

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
    }
}