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
	partial class Projectsearchviewcontroller : UITableViewController
    {
        #region Parameter
        LoadingOverlay loadingOverlay;
        object timekprid,timekprname,wrdkt;
        UILabel lbltimekeepernum = new UILabel();
        #endregion

        #region Controller
        public Projectsearchviewcontroller (IntPtr handle) : base (handle)
		{
		}
        #endregion

        #region SetTimekeeperDetails
        public void settimekprdetls (ProjectListViewController projectListViewController, string TimekeeperID, string TimekeeperName, string Workdate)
		{
			timekprid = TimekeeperID.ToString ();
			timekprname = TimekeeperName.ToString ();
			wrdkt = Workdate.ToString ();
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

        #region DoLoadData
        async Task DoLoadData()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<ProjectEmployeeDTO>>(TimeCapServices.AuthorizedProject,
				new Dictionary<string, string>() { { "timekeeperPersonnelNumber", timekprid.ToString() }});

            var tablesource = new ProjectsearchTablesource();

            var data = new List<Isupportsearch>();
            foreach (var item in response.Value)
            {
                data.Add(new Projecctsearch()  { ProjectNumber = item.ProjectNumber, ProjectDescription = item.ProjectDescription,});
            }
            tablesource.Data = data;
            tablesource.OnRowSelected += (object sender, ProjectsearchTablesource.RowSelectedEventArgs e) =>
            {
                var detail = Storyboard.InstantiateViewController("ActivityListviewcontroller") as ActivityListviewcontroller;
                detail.projectlist(this, tablesource.Data[e.indexPath.Row]);
				detail.projecttimekeeperid(this, timekprid.ToString(),timekprname.ToString(),wrdkt.ToString());
                NavigationController.PushViewController(detail, true);
            };
            TableView.Source = tablesource;
            TableView.ReloadData();
        }
        #endregion

        #region ViewDidLoad
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.Title = "Project Search";
            await LoadData();
        }
        #endregion

    }
}
