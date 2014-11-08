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
using System.Data.SqlClient;
using System.Xml;

namespace TimeCap.iOS
{
	partial class Searchemployeeviewcontroller : UITableViewController
    {
        #region Parameter
        LoadingOverlay loadingOverlay;
        UISearchBar searchbar;   
        public SearchItem Item { get; set; }
        List<SearchItem> searchResults;
        static NSString cellId = new NSString("SearchResultCell");
        #endregion
        
        #region controller
        public Searchemployeeviewcontroller()
        {
            searchResults = new List<SearchItem> ();
        }
        #endregion

        #region SearchDelegate
        public class searchdelegate : UISearchBarDelegate
        {
            UITableViewController uitbl = new UITableViewController();

            #region Searchbutton
            public async override void SearchButtonClicked(UISearchBar searchbar)
            {
                searchbar.ResignFirstResponder();

                ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                JsonClient client = new JsonClient(serializer);

                var response = await client.GetAsync<IEnumerable<ProjectEmployeeDTO>>(TimeCapServices.LaborMaster);
                var tableSource = new LaborListTableSource();
                var data = new List<ProjectEmployeeDTO>();

                HashSet<string> employeename = new HashSet<string>();

                var newitem = new List<LaborListRowData>();
                foreach (var item in response.Value)
                {
                    if (item.EmployeePersonnelName.StartsWith(searchbar.Text))
                    {
                        newitem.Add(new LaborListRowData() { EmployeeName = item.EmployeePersonnelName, EmployeeNumber = item.EmployeePersonnelNumber });
                    }
                }
                tableSource.Data = newitem;

                tableSource.OnRowSelected += (object sender, LaborListTableSource.RowSelectedEventArgs e) =>
                {
                    new UIAlertView("Selected", tableSource.Data[e.indexPath.Item].ToString(), null, "OK", null).Show();
                    e.tableView.DeselectRow(e.indexPath, true);
                };
                UITableViewController ob = new UITableViewController();
                ob.TableView.Source = tableSource;
                ob.TableView.ReloadData();

                UIApplication.SharedApplication.NetworkActivityIndicatorVisible = false;
            }
            #endregion

            #region Cancelbtn
            public override void CancelButtonClicked(UISearchBar searchbar)
            {
                searchbar.ResignFirstResponder();
            }
            #endregion
       }
        #endregion

        #region searchvwcntrllr
        public Searchemployeeviewcontroller (IntPtr handle) : base (handle)
		{
		}
        #endregion

        #region Didload
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Title = "Search Employee";
            View.BackgroundColor = UIColor.GroupTableViewBackgroundColor;
            var f = new RectangleF(0f, 0f, View.Frame.Width, 44f);
            searchbar = new UISearchBar(f)
            {
                Delegate = new searchdelegate(),
                ShowsCancelButton = true,
            };
            searchbar.Placeholder = "Enter Employee name";
            searchbar.SizeToFit();
            searchbar.AutocorrectionType = UITextAutocorrectionType.No;
            searchbar.AutocapitalizationType = UITextAutocapitalizationType.None;
            //searchbar.SearchButtonClicked += (sender, e) =>
            //{
            //    Search();

            //};

            View.AddSubview(searchbar);
            TableView.TableHeaderView = searchbar;
            UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
        }
        #endregion

        #region Appear
        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            
            await LoadData();
        }
        #endregion

        #region LoadData
        async Task LoadData()
        {
            loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);
            View.Add(loadingOverlay);
            UISearchBar search = new UISearchBar();
            try
            {
                if (search.Text != null)
                {
                    await DoLoadData();
                }
                //await DoLoadData();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                loadingOverlay.Hide();
            }
        }
        #endregion

        #region DoLoadData
        async Task DoLoadData()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);
            var searchtxt = searchbar.Text.ToString().Trim();
            var response = await client.GetAsync<IEnumerable<ProjectEmployeeDTO>>(TimeCapServices.LaborMaster);

            var tableSource = new LaborListTableSource();
            var data = new List<LaborListRowData>();

            HashSet<string> employeename = new HashSet<string>();
            foreach (var item in response.Value)
            {
                if (item.EmployeePersonnelName.StartsWith(searchbar.Text))
                {
                    data.Add(new LaborListRowData() { EmployeeName = item.EmployeePersonnelName, EmployeeNumber = item.EmployeePersonnelNumber });
                }
            }
            
            tableSource.Data = data;

            tableSource.OnRowSelected += (object sender, LaborListTableSource.RowSelectedEventArgs e) =>
            {
                new UIAlertView("Row Selected", tableSource.Data[e.indexPath.Item].ToString(), null, "OK", null).Show();
                e.tableView.DeselectRow(e.indexPath, true);
            };
            TableView.Source = tableSource;
            TableView.ReloadData();
        }
        #endregion

        
    }
}
