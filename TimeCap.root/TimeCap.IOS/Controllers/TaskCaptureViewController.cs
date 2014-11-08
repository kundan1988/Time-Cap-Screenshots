#region Namespace
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
using System.Linq;
using System.Linq.Expressions;
#endregion

namespace TimeCap.iOS
{
	partial class TaskCaptureViewController : UIViewController
    {
        #region Parameter
        object detailItem, detailtimekeerpname, workdt;
		string ProjectCount;
		List<object> objectNumbers = new List<object>();
		List<string>ProjectCnt= new List<string>();
		LoadingOverlay loadingOverlay;
        #endregion

        #region TaskcapController
        public TaskCaptureViewController (IntPtr handle) : base (handle)
		{
		}
        #endregion

        #region Viewdidappear
        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
			await LoadData();

			lblprojectcnt.Text = ProjectCount.ToString ();
            projectMasterButton.Layer.CornerRadius = 10;
            projectMasterButton.ClipsToBounds = true;
            projectMasterButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            projectMasterButton.Layer.BorderWidth = 1;

            employeeListButton.Layer.CornerRadius = 10;
            employeeListButton.ClipsToBounds = true;
            employeeListButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            employeeListButton.Layer.BorderWidth = 1;

            actualAllocationsButton.Layer.CornerRadius = 10;
            actualAllocationsButton.ClipsToBounds = true;
            actualAllocationsButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            actualAllocationsButton.Layer.BorderWidth = 1;
        }
        #endregion

        #region setdetails
        public void SetDetailItem(string newDetailItem, string name, string workdate)
        {
            if (detailItem != newDetailItem)
            {
                detailItem = newDetailItem;
                detailtimekeerpname = name;
                workdt = workdate;
            }
            ConfigureView();
        }
        #endregion

        #region Configureview
        void ConfigureView()
        {
            if (IsViewLoaded && detailItem != null)
            {
                lbltimekeepernumbr.Text = detailItem.ToString();
                lbltimekeepername.Text = detailtimekeerpname.ToString();
                lbldate.Text = workdt.ToString();
            }
        }
        #endregion

        #region Viewdidload
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            ConfigureView();
            UIViewController tab1 = new UIViewController();
            tab1.Title = "Test";
            tab1.View.BackgroundColor = UIColor.FromRGB(75, 0, 130);
        }
        #endregion

        #region Actualallocbtn
        partial void actualAllocationsButton_TouchUpInside (UIButton sender)
		{
			var alloc = Storyboard.InstantiateViewController("AllocationsActualViewController") as AllocationsActualViewController;
			alloc.settimekprdetls(this,lbltimekeepernumbr.Text.ToString(), lbltimekeepername.Text.ToString(),workdt.ToString());
			NavigationController.PushViewController(alloc,true);
		}
        #endregion

        #region ProjectMasterbtn
        partial void projectMasterButton_TouchUpInside (UIButton sender)
		{
			var tasklist = Storyboard.InstantiateViewController("ProjectListViewController") as ProjectListViewController;
			tasklist.settimekprdetails(this, lbltimekeepernumbr.Text.ToString(), lbltimekeepername.Text.ToString(),workdt.ToString());
			NavigationController.PushViewController(tasklist,true);
		}
        #endregion

        #region LoadData
        async Task LoadData()
		{
			loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);
			View.Add(loadingOverlay);
			try
			{
				ProjectCount = null;
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

		#region DoLoadData
		async Task DoLoadData()
		{
			try
			{
				ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
				Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
				JsonClient client = new JsonClient(serializer);

				var response = await client.GetAsync<IEnumerable<ProjectEmployeeDTO>>(TimeCapServices.AuthorizedProject,
					new Dictionary<string, string>() { { "timekeeperPersonnelNumber", lbltimekeepernumbr.Text.ToString() }});
				ProjectCnt.Clear();
				foreach (var item in response.Value)
				{
					ProjectCnt.Add((string)item.ProjectNumber.ToString());
					ProjectCount = ProjectCnt.Count().ToString();
				}
			}
			catch (Exception ex)
			{
				new UIAlertView("Oops", "No Record Available",null, "OK", null).Show();
				System.Console.WriteLine(ex.Message);
			}
		}
		#endregion
    }
}
