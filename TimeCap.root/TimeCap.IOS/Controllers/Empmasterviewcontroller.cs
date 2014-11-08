using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Threading.Tasks;
using Simple.OData.Client.Extensions;
using Simple.OData.Client;
using TimeCap.iOS.Models;
using TimeCap.iOS.Code;
using System.Collections.Generic;
using System.Net.Http;
using System.Drawing;
using MonoTouch.ImageIO;
using System.IO;

namespace TimeCap.iOS
{
	partial class Empmasterviewcontroller : UITableViewController
    {
        #region Parameter
        LoadingOverlay loadingOverlay;
        public string EmpImage { get; set; }
        #endregion

        #region Controller
        public Empmasterviewcontroller (IntPtr handle) : base (handle)
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

            var response = await client.GetAsync<IEnumerable<LaborListDTO>>(TimeCapServices.LaborList,
                new Dictionary<string, string>() { { "timeKeeperPersonnelNumber", "278715" }, { "workDate", "2014-08-28" } });

            var tableSource = new LaborListTableSource();

            var data = new List<LaborListRowData>();
            HashSet<int> employeeNumbers = new HashSet<int>();
                     
            foreach (var item in response.Value)
            {
                System.Console.WriteLine(item.EmployeePersonnelNumber);
                
                if (!employeeNumbers.Contains(item.EmployeePersonnelNumber))
                {
                    employeeNumbers.Add(item.EmployeePersonnelNumber);
                    data.Add(new LaborListRowData() { EmployeeName = item.EmployeePersonnelName, EmployeeNumber = item.EmployeePersonnelNumber, });
                }
            }
            tableSource.Data = data;
            tableSource.OnRowSelected += (object sender, LaborListTableSource.RowSelectedEventArgs e) =>
            {
                new UIAlertView("Selected", tableSource.Data[e.indexPath.Row].ToString(), null, "OK", null).Show();

            };
            TableView.Source = tableSource;
            TableView.ReloadData();
        }
        #endregion
    }
}

