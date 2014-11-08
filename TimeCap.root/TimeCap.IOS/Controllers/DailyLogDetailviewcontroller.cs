using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using TimeCap.iOS.Code;
using TableEditing.Code;
using System.Threading.Tasks;
using TimeCap.iOS.Models;
using System.Collections.Generic;

namespace TimeCap.iOS
{
	partial class DailyLogDetailviewcontroller : UITableViewController
	{
        LoadingOverlay loadingOverlay;
        
		public DailyLogDetailviewcontroller (IntPtr handle) : base (handle)
		{

		}

        async Task LoadData()
        {
            loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);
            View.Add(loadingOverlay);

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
        async Task DoLoadData()
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<LaborListDTO>>(TimeCapServices.DailyLog,
                new Dictionary<string, string>() { { "timeKeeperPersonnelNumber", "1000000002" }, { "workDate", "2014-09-24" } });

            var tableSource = new EquipmentListTableSource();

            var data = new List<EquiplistRowData>();

            foreach (var item in response.Value)
            {
                
            }
            tableSource.Data = data;
            tableSource.OnRowSelected += (object sender, EquipmentListTableSource.RowSelectedEventArgs e) =>
            {
				new UIAlertView("row selected","", null, "ok", null).Show();
            };
            TableView.Source = tableSource;
            TableView.ReloadData();
        }
	}
}
