using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using TimeCap.iOS.Models;
using System.Threading.Tasks;
using TimeCap.iOS.Code;
using System.Collections.Generic;
using System.Drawing;
using SearchDemo;
using System.Net;
using System.Data;
using System.Xml;

namespace TimeCap.iOS
{
	partial class EmployeeListSearchviewcontroller : UITableViewController
	{
        //LoadingOverlay loadingOverlay;
        //UISearchBar searchbar;
        public SearchItem Item { get; set; }

        class searchdelegate : UISearchBarDelegate
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            //XmlReader xmlFile;

            public async override void SearchButtonClicked(UISearchBar searchbar)
            {
                searchbar.ResignFirstResponder();
                UITableViewController uitbl = new UITableViewController();

                ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                JsonClient client = new JsonClient(serializer);

                var response = await client.GetAsync<IEnumerable<ProjectEmployeeDTO>>(TimeCapServices.LaborMaster);
                var tableSource = new LaborListTableSource();
                var data = new List<LaborListRowData>();

                HashSet<string> employeename = new HashSet<string>();

                foreach (var item in response.Value)
                {
                    if (!employeename.Contains(item.EmployeePersonnelName))
                    {

                        var searchnew = searchbar.Text.ToString().Trim();
                        searchnew = item.EmployeePersonnelName;
                        data.Add(new LaborListRowData() { EmployeeName = searchnew });
                    }
                }
                tableSource.Data = data;

                tableSource.OnRowSelected += (object sender, LaborListTableSource.RowSelectedEventArgs e) =>
                {
                    new UIAlertView("Row Selected", tableSource.Data[e.indexPath.Row].ToString(), null, "OK", null).Show();
                    e.tableView.DeselectRow(e.indexPath, true);
                };
                uitbl.TableView.Source = tableSource;
                uitbl.TableView.ReloadData();
            }
            public override void CancelButtonClicked(UISearchBar searchbar)
            {
                searchbar.ResignFirstResponder();
            }
        }

		public EmployeeListSearchviewcontroller (IntPtr handle) : base (handle)
		{

		}
	}
}
