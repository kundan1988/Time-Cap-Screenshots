using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using TimeCap.iOS.Code;
using TimeCap.iOS.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;

namespace TimeCap.iOS
{
	partial class ActivityListviewcontroller : UITableViewController
    {
        #region Parameter
        UILabel lblprojectnum = new UILabel();
        LoadingOverlay loadingOverlay;
        object timekprid, timekprname, wrkdt;
        List<object> objectNumbers = new List<object>();
        #endregion

        #region ProjSearchDele
        public Projectsearchviewcontroller Delegate { get; set; }
        #endregion

        #region ActivityContrl
        public ActivityListviewcontroller (IntPtr handle) : base (handle)
		{

		}
        #endregion

        #region LoadMain
        async Task LoadData()
        {
            loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);
            View.Add(loadingOverlay);
            TableView.UserInteractionEnabled = false;
            try
            {
                await CheckExist();
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

        #region CheckExisting Project
        async Task CheckExist()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<ActivityListDTO>>(TimeCapServices.ActivityList,
				new Dictionary<string, string>() { { "timekeeperPersonnelNumber", timekprid.ToString() }, { "workDate", wrkdt.ToString() } });
            
            foreach (var item in response.Value)
            {
               objectNumbers.Add((object)item.TransformedActivityNumber);
            }
        }
        #endregion

        #region LoadData
        async Task DoLoadData()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<ProjectEmployeeDTO>>(TimeCapServices.AuthorizedProjectActivity,
				new Dictionary<string, string>() { { "timekeeperPersonnelNumber", timekprid.ToString() }});
            
            var tableSource = new ActivityListTablesource();

            var data = new List<IsupportActivity>();
            foreach (var item in response.Value)
            {
                if(! objectNumbers.Contains(item.TransformedActivityNumber))
                {
                    data.Add(new Activity() { TransformedActivityElementNum = item.TransformedActivityNumber, ActivityDescrip = item.ActivityDescription, ProjectNumber = item.ProjectNumber,});
                }
            }
            tableSource.Data = data;
            tableSource.OnRowSelected += (object sender, ActivityListTablesource.RowSelectedEventArgs e) =>
            {
                var detail = Storyboard.InstantiateViewController("Elementlistviewcontroller") as Elementlistviewcontroller;
                detail.projectlist(this, tableSource.Data[e.indexPath.Row]);
				detail.settimekeeperdetls(this, timekprid.ToString(),timekprname.ToString(),wrkdt.ToString());
                NavigationController.PushViewController(detail, true);
            };
            TableView.Source = tableSource;
            TableView.ReloadData();
        }
        #endregion

        #region ViewDidLoad
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            await LoadData();
        }
        #endregion

        #region ProjectList
        internal void projectlist(Projectsearchviewcontroller projectsearchviewcontroller, Isupportsearch isupportsearch)
        {
            lblprojectnum.Text = isupportsearch.text;
        }
        #endregion

        #region ProjectTimekeeperid
        internal void projecttimekeeperid(Projectsearchviewcontroller projectsearchviewcontroller, string TimekeeperID, string TimekeeperName, string Workdate)
        {
			timekprid = TimekeeperID.ToString ();
			timekprname = TimekeeperName.ToString ();
			wrkdt = Workdate.ToString ();
        }
        #endregion
    }
}
