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

namespace TimeCap.iOS
{
	partial class HomeViewController : UIViewController
    {
        #region Parameter
        public IGCalendarViewXamarinViewController Delegate { get; set; }
		object Workdte,Timekeepernumbr, TimekeeperName;
		string Signoutcount, EquipmentCount;
		List<string>Signoutcnt = new List<string>();
		List<string>EquipCount = new List<string>();
		LoadingOverlay loadingOverlay;
        #endregion

        #region Controller
        public HomeViewController (IntPtr handle) : base (handle)
		{
		}
        #endregion
                
        #region TaskCapbtn
        partial void taskCaptureButton_TouchUpInside(MonoTouch.UIKit.UIButton sender)
        {

        }
        #endregion

        #region Employeesignoutbtn
        partial void employeeSignoutButton_TouchUpInside(MonoTouch.UIKit.UIButton sender)
        {
            var signut = Storyboard.InstantiateViewController("EmployeeListSignoutViewController") as EmployeeListSignoutViewController;
			signut.timekeeperdetails(this, Timekeepernumbr.ToString(), Workdte.ToString(),TimekeeperName.ToString());
			NavigationController.PushViewController(signut, true); 
		}
        #endregion

        #region ViewDidAppear
		public override async void ViewDidAppear(bool animate)
        {
            try
            {
				await LoadData();

				lblsignutcnt.Text = Signoutcount.ToString();
				equipmentSignoutCountLabel.Text = EquipmentCount.ToString();
                taskCaptureButton.Layer.CornerRadius = 10;
                taskCaptureButton.ClipsToBounds = true;
                taskCaptureButton.Layer.BorderColor = UIColor.LightGray.CGColor;
                taskCaptureButton.Layer.BorderWidth = 1;

                dailyLogButton.Layer.CornerRadius = 10;
                dailyLogButton.ClipsToBounds = true;
                dailyLogButton.Layer.BorderColor = UIColor.LightGray.CGColor;
                dailyLogButton.Layer.BorderWidth = 1;

                settingsButton.Layer.CornerRadius = 10;
                settingsButton.ClipsToBounds = true;
                settingsButton.Layer.BorderColor = UIColor.LightGray.CGColor;
                settingsButton.Layer.BorderWidth = 1;

                equipmentSignoutButton.Layer.CornerRadius = 10;
                equipmentSignoutButton.ClipsToBounds = true;
                equipmentSignoutButton.Layer.BorderColor = UIColor.LightGray.CGColor;
                equipmentSignoutButton.Layer.BorderWidth = 1;

                employeeSignoutButton.Layer.CornerRadius = 10;
                employeeSignoutButton.ClipsToBounds = true;
                employeeSignoutButton.Layer.BorderColor = UIColor.LightGray.CGColor;
				employeeSignoutButton.Layer.BorderWidth = 1;

                dateLabel.Text = Workdte.ToString();
                lbltimekeppername.Text = TimekeeperName.ToString();
                lbltimekeeperid.Text = Timekeepernumbr.ToString();
                
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region ViewDidLoad
        public override void ViewDidLoad()
        {
            try
            {
                base.ViewDidLoad();
                this.Title = "Home";
            }
            catch(Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        #endregion

        #region ViewDidLayout
        public override void ViewDidLayoutSubviews()
        {
            base.ViewDidLayoutSubviews();

            if (UIDevice.CurrentDevice.CheckSystemVersion(7, 0))
            {
                float displacement_y = this.TopLayoutGuide.Length;
            }
        }
        #endregion

        #region PrepareforSegue
        public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
        {
			try
			{
            base.PrepareForSegue(segue, sender);
            var item = lbltimekeeperid.Text.ToString();
            var lblitmename = lbltimekeppername.Text;
            var workdate = dateLabel.Text.ToString();
            ((TaskCaptureViewController)segue.DestinationViewController).SetDetailItem(item, lblitmename,workdate);
			}
			catch(Exception ex) 
			{
				System.Console.WriteLine (ex.Message);
			}
        }
        #endregion

        #region Equipmntbtn
        partial void equipmentSignoutButton_TouchUpInside (UIButton sender)
		{
			try
			{
			var equip = Storyboard.InstantiateViewController("Equipmentsignoutviewcontroll") as Equipmentsignoutviewcontroll;
			equip.settimekeeperid(this,lbltimekeeperid.Text.ToString(),lbltimekeppername.Text.ToString(),Workdte.ToString());
			NavigationController.PushViewController(equip,true);
			}
			catch(Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
		}
        #endregion

        #region Dailylogbtn
        partial void dailyLogButton_TouchUpInside (UIButton sender)
		{
			var daily = Storyboard.InstantiateViewController("DailyLogDetailviewcontroller") as DailyLogDetailviewcontroller;
			NavigationController.PushViewController(daily,true);
		}
        #endregion

        #region settingbtn
        partial void settingsButton_TouchUpInside (UIButton sender)
		{
			var settng = Storyboard.InstantiateViewController("TimecapSettingviewcontroll") as TimecapSettingviewcontroll;
			NavigationController.PushViewController(settng,true);
		}
        #endregion
        
        #region FetchDetails
        internal void SetLaborList(IGCalendarViewXamarinViewController iGCalendarViewXamarinViewController, string Workdate, string Timekprnme, string Timekprnu)
        {
            try
            {
                Workdte = Workdate.ToString();
				Timekeepernumbr = Timekprnu.ToString();
                TimekeeperName = Timekprnme.ToString();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        #endregion

		#region LoadData
		async Task LoadData()
		{
			loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);
			View.Add(loadingOverlay);
			try
			{
				await DoLoadData();
				await DoLoadDataEquip();
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

				var response = await client.GetAsync<IEnumerable<LaborListDTO>>(TimeCapServices.LaborList,
					new Dictionary<string, string>() { { "timeKeeperPersonnelNumber", Timekeepernumbr.ToString() }, { "workDate", Workdte.ToString()} });
				Signoutcnt.Clear();
				foreach (var item in response.Value)
				{
					Signoutcnt.Add((string)item.EmployeePersonnelNumber.ToString());
					Signoutcount = Signoutcnt.Count().ToString();
				}
			}
			catch (Exception ex)
			{
				new UIAlertView("Oops", "No Record Available",null, "OK", null).Show();
				System.Console.WriteLine(ex.Message);
			}
		}
		#endregion

        #region EquipmentCount
        async Task DoLoadDataEquip()
		{
			ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
			Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
			JsonClient client = new JsonClient(serializer);

			var response = await client.GetAsync<IEnumerable<EquipmentMasterDTO>>(TimeCapServices.EquipList,
				new Dictionary<string, string>() { { "timeKeeperPersonnelNumber", Timekeepernumbr.ToString() }, { "workDate", Workdte.ToString() } });
			EquipCount.Clear ();
			foreach (var item in response.Value)
			{
				EquipCount.Add ((string)item.EquipmentNumber.ToString ());
				EquipmentCount = EquipCount.Count ().ToString ();
			}
        }
        #endregion
    }
}
