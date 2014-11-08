using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Threading.Tasks;
using TimeCap.iOS.Code;
using System.Collections.Generic;
using TimeCap.iOS.Models;

namespace TimeCap.iOS
{
	partial class EmployeeListSignoutViewController : UITableViewController
    {
        #region Parameter
        LoadingOverlay loadingOverlay;
        object workdt, timekprname,timekpnumb;
		UIImageView imageView;
		#endregion

        #region Employeecontroller
        public EmployeeListSignoutViewController (IntPtr handle) : base (handle)
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

        #region SetTimekeeperdetails
        public void settimekper (EmployeeMasterViewcontroller employeeMasterViewcontroller, string Timekpno, string TimekpNme, string Wrkdtee)
		{
			timekpnumb = Timekpno.ToString ();
			workdt = Wrkdtee.ToString();
			timekprname = TimekpNme.ToString ();
		}
        #endregion

        #region ViewDidAppear
        public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
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
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

			var imageresponse = await client.GetAsync<IEnumerable<LabourListDTO>>(TimeCapServices.LaborMaster,
				new Dictionary<string, string>() { { "username", "test-fe91" }, { "role", "timekeeper" } });

            var response = await client.GetAsync<IEnumerable<LaborListDTO>>(TimeCapServices.LaborList,
				new Dictionary<string, string>() { { "timeKeeperPersonnelNumber", timekpnumb.ToString() }, { "workDate", workdt.ToString() } });
			
			var tableSource = new EmpPhotoTablesource();
			var data = new List<ISupportEmpphotosorce> ();

			HashSet<string> employeename = new HashSet<string>();
            foreach (var item in response.Value)
            {
				if (!employeename.Contains(item.EmployeePersonnelName))
				{
					List<object> Timekeeperno = new List<object> ();
					Timekeeperno.Add (item.EmployeePersonnelNumber);
					foreach (var newitem in  imageresponse.Value)
					{
						if (Timekeeperno.Contains(newitem.EmployeePersonnelNumber)) 
						{
							NSData imagedata = new NSData(newitem.EmployeePhoto, NSDataBase64DecodingOptions.IgnoreUnknownCharacters);
							UIImage image = new UIImage(imagedata);
							imageView = new UIImageView(image);
							imageView.Image = image;
							data.Add (new Empphotodata () { EmployeePersonnelNumber = item.EmployeePersonnelNumber.ToString(), EmployeePersonnelName = item.EmployeePersonnelName, EmployeePhoto = image });
						}
					}
				}
            }
			tableSource.Data = data;
			tableSource.OnRowSelected += (object sender, EmpPhotoTablesource.RowSelectedEventArgs e) =>
            {
                var detail = Storyboard.InstantiateViewController("EmployeeSignoutController") as EmployeeSignoutController;
				detail.SetLaborList(this, tableSource.Data[e.indexPath.Row], workdt.ToString());
                NavigationController.PushViewController(detail, true);
            };
            TableView.Source = tableSource;
            TableView.ReloadData();
        }
        #endregion

		#region Fetch
		public void timekeeperdetails (HomeViewController homeViewController, string TimekeeperNUmber, string workdate, string TimekeeperName)
		{
			timekpnumb = TimekeeperNUmber.ToString ();
			workdt = workdate.ToString();
			timekprname = TimekeeperName.ToString ();
		}
		#endregion

        #region EmployeemasterBtn
        partial void UIBarButtonItem938_Activated (UIBarButtonItem sender)
		{
			var empsearch = Storyboard.InstantiateViewController("EmployeeMasterViewcontroller") as EmployeeMasterViewcontroller;
			empsearch.settimekeeperdtls(this,timekpnumb.ToString(), workdt.ToString(), timekprname.ToString());
			NavigationController.PushViewController(empsearch,true);
        }
        #endregion

    }
}
