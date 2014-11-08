using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using TimeCap.iOS.Code;
using System.Collections.Generic;
using TimeCap.iOS.Models;
using System.Threading.Tasks;

namespace TimeCap.iOS
{
	partial class EquipmentMasterViewcontroller : UITableViewController
	{
        #region Parameter
        LoadingOverlay loadingOverlay;
        UILabel lbltimekeeperid = new UILabel();
        List<object> objectNumbers = new List<object>();
		object timenum, wrkdt, timekprname;
        EquipmentMasterDTO equipList = new EquipmentMasterDTO();
        //string saveMessage;
        #endregion

        #region EquipController
        public EquipmentMasterViewcontroller (IntPtr handle) : base (handle)
		{

		}
        #endregion

        #region SetTimeKeeperDetails
        public void settimekeeperdetail (Equipmentsignoutviewcontroll equipmentsignoutviewcontroll, string Timekeepernum, string Workdate, string TimekeeperName)
		{
			try
			{
			timenum = Timekeepernum.ToString ();
			wrkdt = Workdate.ToString ();
			timekprname = TimekeeperName.ToString();
			}
			catch(Exception ex)
			{
				Console.WriteLine (ex.Message);
			}
		}
        #endregion

        #region ViewDidLoad
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            await CheckExist();
            await LoadData();
        }
        #endregion

        #region LoadData
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
        #endregion

        #region DoLoad
        async Task DoLoadData()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            string timekeepernum = lbltimekeeperid.Text;

            var response = await client.GetAsync<IEnumerable<EquipmentMasterDTO>>(TimeCapServices.EquipmentMaster,
                new Dictionary<string, string>() { { "username", "test-fe91" }, { "role", "timekeeper" } });

            var tableSource = new EquipmentListTableSource();

            var data = new List<EquiplistRowData>();
            HashSet<int> employeeNumbers = new HashSet<int>();
            foreach (var item in response.Value)
            {
                if (!objectNumbers.Contains(item.EquipmentNumber))
                {
                    data.Add(new EquiplistRowData() { EquipmentDescription = item.EquipmentDescription, EquipmentNumber = item.EquipmentNumber });
                }
            }
            tableSource.Data = data;
            tableSource.OnRowSelected += (object sender, EquipmentListTableSource.RowSelectedEventArgs e) =>
            {
                EquiplistRowData equimaster = tableSource.Data[e.indexPath.Row];
                equipList = new EquipmentMasterDTO
                {
					Workdate = Convert.ToDateTime(wrkdt),
					TimekeeperPersonnelNumber = Convert.ToInt32(timenum),
					TimekeeperPersonnelName = timekprname.ToString(),
                    EquipmentNumber = equimaster.EquipmentNumber,
                    EquipmentDescription = equimaster.EquipmentDescription,
                    EquipmentSerialNumber = equimaster.EquipmentSerialNumber,
                    EquipmentClassCode = equimaster.EquipmentClassCode,
					CreateDate = Convert.ToDateTime(wrkdt),
					CreateUser = timekprname.ToString(),
					LastChangeDate = Convert.ToDateTime(wrkdt),
					LastChangeUser = timekprname.ToString(),
                    UpdateFlag = "I",
                };

                var equi = DoSaveData();
            };
            TableView.Source = tableSource;
            TableView.ReloadData();
        }
        #endregion

        #region DoSaveData
        async Task DoSaveData()
        {
            string saveMessage = null;

            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var request = await client.PostAsync<EquipmentMasterDTO>(TimeCapServices.EquipList, equipList);
            var value = request.Value;
            if (value != null)
            {
                new UIAlertView("Saved", "Equipment Added Sucessfully", null, "OK", null).Show();
                var equipment = Storyboard.InstantiateViewController("Equipmentsignoutviewcontroll") as Equipmentsignoutviewcontroll;
                NavigationController.PushViewController(equipment, true);
            }
            else
            {
                new UIAlertView("Error", "Error while adding Equipment", null, "OK", null).Show();
            }
        }
        #endregion

        #region CheckExisting_Employees
        async Task CheckExist()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<EquipmentMasterDTO>>(TimeCapServices.EquipList,
				new Dictionary<string, string>() { { "timeKeeperPersonnelNumber", timenum.ToString() }, { "workDate", wrkdt.ToString() } });

            foreach (var item in response.Value)
            {
                objectNumbers.Add((object)item.EquipmentNumber);
            }
        }
        #endregion
	}
}
