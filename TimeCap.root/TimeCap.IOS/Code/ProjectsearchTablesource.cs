using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Code
{
    public class ProjectsearchTablesource : UITableViewSource
    {
        public List<Isupportsearch> Data { get; set; }
        protected string cellidentifier = "TableCell";

        public override int RowsInSection(UITableView tableview, int section)
        {
            //throw new NotImplementedException();
            return Data.Count;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {
            //throw new NotImplementedException();
            ProjectsearchTableItem cell = tableView.DequeueReusableCell(cellidentifier) as ProjectsearchTableItem;
            if (cell == null)
                cell = new ProjectsearchTableItem(cellidentifier);
            cell.updatecell(Data[indexPath.Row].text,
                Data[indexPath.Row].DetailText, 
                Data[indexPath.Row].SubDetailsText,
            Data[indexPath.Row].AllSubdetailText);
            //cell.ImageView.Image = UIImage.FromFile("Resources/" + Data[indexPath.Row].SubDetailsText);
            return cell;
        }
        public override float GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
        {
            return 65f;
            //return base.GetHeightForRow(tableView, indexPath);
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

        public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
        {
            //base.RowSelected(tableView, indexPath);
            Isupportsearch selectditm = Data[indexPath.Row];
            tableView.DeselectRow(indexPath, true);
            if(OnRowSelected != null)
            {
                OnRowSelected(this, new RowSelectedEventArgs(tableView, indexPath));
            }
            
        }

    }
}