using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using TimeCap.iOS.Code;
using TimeCap.iOS.Models;
using System.Threading.Tasks;
using Simple.OData.Client.Extensions;
using Simple.OData.Client;
using System.Collections.Generic;

namespace TimeCap.iOS
{
	partial class Elementlistviewcontroller : UITableViewController
    {
		#region Parameter
        UILabel lblprojectnum = new UILabel();
        UILabel lbltransfrmactnum = new UILabel();
        LoadingOverlay loadingOverlay;
        object timekprid,timekprname,wrkdt;
        TaskListDTO activitylist = new TaskListDTO();
        #endregion

        #region controller
        public Elementlistviewcontroller (IntPtr handle) : base (handle)
		{
		}
        #endregion

        #region Settingkeeprdetails
        public void settimekeeperdetls (ActivityListviewcontroller activityListviewcontroller, string TimekeeperID, string TimekeeperName, string Workdate)
		{
			timekprid = TimekeeperID.ToString ();
			timekprname = TimekeeperName.ToString ();
			wrkdt = Workdate.ToString ();
		}
        #endregion

        #region Loaddata
        async Task LoadData()
        {
            loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);
            View.Add(loadingOverlay);

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
            }
        }
        #endregion

        #region Doloadactivity
        async Task DoLoadData()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<ActivityListDTO>>(TimeCapServices.ActivityMaster,
                new Dictionary<string, string>() { { "projectNumber", lblprojectnum.Text }, { "transformedActivityNumber", lbltransfrmactnum.Text } });

            var tablesource = new ElementTableSource();

            var data = new List<ISupportElement>();
            
            foreach (var item in response.Value)
            {
                data.Add(new ElementSearch() { TransformedActivityElementNumber = item.TransformedActivityElementNumber, ActivityElementDescription = item.ActivityElementDescription,});
            }
            tablesource.Data = data;

           tablesource.OnRowSelected += (object sender, ElementTableSource.RowSelectedEventArgs e) =>
            {
                ISupportElement selecteditm = tablesource.Data[e.indexPath.Row];
                lbltransfrmactnum.Text = selecteditm.Transformedactnumber;
                
                activitylist = new TaskListDTO
                {
                    ProjectNumber = lblprojectnum.Text,
                    ProjectDescription = "Concrete Structure",
					WorkDate =  wrkdt.ToString(),
					TimekeeperPersonnelNumber = Convert.ToInt32(timekprid),
                    TransformedActivityElementNumber = selecteditm.Transformedactnumber,
                    NetworkNumber = "N.10018.1002",
                    ActivityNumber = selecteditm.Activitynum,
                    ActivityDescription = selecteditm.ActivityDescription,
                    ElementNumber = "0100",
                    ActualQuantity = null,
                    UoM = "CY",
                    Notes = null,
                    CreateDate = wrkdt.ToString(),
					CreateUser = timekprname.ToString(),
                    LastChangeDate = wrkdt.ToString(),
					LastChangeUser = timekprname.ToString(),
                    WBSElementNumber = "10018.1002",
                    WBSElementDescription = "FRP Columns",
                    TakeoffQuantity = 250,
                    TransformedActivityNumber = lbltransfrmactnum.Text,
                    ActivityElementDescription = "Concrete Test Project",
                    EstimatedQuantity = 1,
                    Percent = 1,
                    Factor = 1,
                    BudgetLaborAmountByUnit = 1,
                    BudgetLaborHoursByUnit = 1,
                    BudgetEquipAmountByUnit = 1,
                    UpdateFlag = "I",
                };

                var act = SaveTask();
            }; 
            TableView.Source = tablesource;
            TableView.ReloadData();
        }
        #endregion

        #region Viewdidload
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            await LoadData();
        }
        #endregion

        #region GetData
        internal void projectlist(ActivityListviewcontroller activityListviewcontroller, IsupportActivity isupportActivity)
        {
            lblprojectnum.Text = isupportActivity.Text;
            lbltransfrmactnum.Text = isupportActivity.Details;
        }
        #endregion

        #region SaveTasktoTaskList
        async Task SaveTask()
        {
           //string SaveMessage = null;

            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.PostAsync<TaskListDTO>(TimeCapServices.ActivityList,activitylist);
            var valu = response.Value;

            if (valu != null)
            {
                new UIAlertView("Saved", "Task Added Sucessfully", null, "OK", null).Show();
                var tasklist = Storyboard.InstantiateViewController("ProjectListViewController") as ProjectListViewController;
				tasklist.setdetails (this, timekprid.ToString(), timekprname.ToString(), wrkdt.ToString());
                NavigationController.PushViewController(tasklist, true);
            }
            else
            {
                new UIAlertView("Error", "Error While Adding Task", null, "OK", null).Show();
            }

        }
        #endregion

        #region LoadPresetActivityList
        async Task LoadActivityList()
        {
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<ActivityListDTO>>(TimeCapServices.ActivityList,
				new Dictionary<string, string>() { { "TimekeeperPersonnelNumber", timekprid.ToString() }, { "workDate", wrkdt.ToString() } });

            foreach (var item in response.Value)
            {
                 //activitylist = item;    
            }
        }
        #endregion
    }
}
