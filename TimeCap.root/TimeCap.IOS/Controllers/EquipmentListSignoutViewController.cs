using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Threading.Tasks;
using Simple.OData.Client.Extensions;
using Simple.OData.Client;
using TimeCap.iOS.Models;
using TimeCap.iOS.Code;

namespace TimeCap.iOS
{
	partial class EquipmentListSignoutViewController : UITableViewController
    {
        #region Parameter
        readonly UIRefreshControl _refresh = new UIRefreshControl();
        LoadingOverlay loadingOverlay;
        #endregion

        #region Controller
        public EquipmentListSignoutViewController (IntPtr handle) : base (handle)
		{
		}
        #endregion

        #region ViewDidLoad
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            await LoadData();
        }
        #endregion

        #region LoadData
        async Task LoadData()
        {
            loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);
            TableView.UserInteractionEnabled = false;
            try
            {
                await DoLoadData();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                loadingOverlay.Hide();
                TableView.UserInteractionEnabled = true;
            }
        }
        #endregion

        #region DoLoadData
        async Task DoLoadData()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<LaborListDTO>>(TimeCapServices.EquipList,
                new Dictionary<string, string>() { { "timeKeeperPersonnelNumber", "1000000002" }, { "workDate", "2014-09-26" } });

            var tableSource = new LaborListTableSource();

            var data = new List<LaborListRowData>();
            HashSet<string> employeename = new HashSet<string>();
            foreach (var item in response.Value)
            {
                System.Console.Write(item.TimekeeperPersonnelNumber);
                if (!employeename.Contains(item.TimekeeperPersonnelName))
                {
                    employeename.Add(item.EmployeePersonnelName);
                    data.Add(new LaborListRowData()
                    {
                        //EmployeeNumber = item.TimekeeperPersonnelNumber,
                        //EmployeeName = item.TimekeeperPersonnelName,
                    });
                }
            }
            tableSource.Data = data;
            tableSource.OnRowSelected += (object sender, LaborListTableSource.RowSelectedEventArgs e) =>
            {
                new UIAlertView("Row Selected",
                    tableSource.Data[e.indexPath.Row].ToString(), null, "OK", null).Show();
                e.tableView.DeselectRow(e.indexPath, true);
            };
            TableView.Source = tableSource;
            TableView.ReloadData();
        }
        #endregion

    }
}
