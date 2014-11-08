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
	partial class EmployeeMasterViewcontroller : UITableViewController
    {
        #region Parameter
        LoadingOverlay loadingOverlay;
		List<string> Employeeexist = new List<string>();
        string saveMessage;
		object timenum, wrkdt, timekprname;
        LabourListDTO labrsignout = new LabourListDTO();
        UIImageView imageView;
		//UISearchBar searchbar;
        #endregion

        #region viewcontroller
        public EmployeeMasterViewcontroller (IntPtr handle) : base (handle)
		{

		}
        #endregion

		#region setkeeperdtls
		public void settimekeeperdtls (EmployeeListSignoutViewController employeeListSignoutViewController, string Timekeepernum, string Workdate, string TimekeeperName)
		{
			timenum = Timekeepernum.ToString ();
			wrkdt = Workdate.ToString ();
			timekprname = TimekeeperName.ToString ();
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
        
        #region CheckExisting_Employees
        async Task CheckExist()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<LaborListDTO>>(TimeCapServices.LaborList,
				new Dictionary<string, string>() { { "timekeeperPersonnelNumber", timenum.ToString() }, { "workDate", wrkdt.ToString() } });

            foreach (var item in response.Value)
            {
				Employeeexist.Add ((string)item.EmployeePersonnelNumber.ToString());
            }
        }
        #endregion

        #region PostSave
        async Task SaveData()
        {
            loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);//, "Saving Data...");
            View.Add(loadingOverlay);

            try
            {
                await DoSaveData();
                if (saveMessage != null)
                {
                    new UIAlertView("Save", "Employee Added", null, "OK", null).Show();
                    var signut = Storyboard.InstantiateViewController("EmployeeListSignoutViewController") as EmployeeListSignoutViewController;
                    NavigationController.PushViewController(signut, true);
                }
                else
                {
                    new UIAlertView("Error", "Error while Saving", null, "Calcel", null).Show();
                }
            }
            catch (Exception ex)
            {
                if (ex != null)
                {
                    saveMessage = "Error occured Saving data";
                }
                System.Console.WriteLine(ex.Message);
            }
            finally
            {
                loadingOverlay.Hide();
            }
        }
        #endregion
        
        #region DoLoad
        async Task DoLoadData()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<LabourListDTO>>(TimeCapServices.LaborMaster,
                new Dictionary<string, string>() { { "username", "test-fe91" }, { "role", "timekeeper" } });

            var tablesource = new EmpPhotoTablesource();

            var data = new List<ISupportEmpphotosorce>();

            foreach (var item in response.Value)
            {
				if(! Employeeexist.Contains(item.EmployeePersonnelNumber.ToString()))
				{
                    NSData imagedata = new NSData(item.EmployeePhoto, NSDataBase64DecodingOptions.IgnoreUnknownCharacters);
                    UIImage image = new UIImage(imagedata);
                    imageView = new UIImageView(image);
                    imageView.Image = image;
					data.Add(new Empphotodata() { EmployeePersonnelName = item.EmployeePersonnelName, EmployeePersonnelNumber = item.EmployeePersonnelNumber.ToString(), EmployeePhoto = image });   
				}
            }
            tablesource.Data = data;
            tablesource.OnRowSelected += (object sender, EmpPhotoTablesource.RowSelectedEventArgs e) =>
            {
                ISupportEmpphotosorce selectedItem = tablesource.Data[e.indexPath.Row];
                labrsignout = new LabourListDTO
                {
					WorkDate = Convert.ToDateTime(wrkdt),
					TimekeeperPersonnelNumber = Convert.ToInt32(timenum),
					TimekeeperPersonnelName = timekprname.ToString(),
					EmployeePersonnelNumber = Convert.ToInt32(selectedItem.EmployeeNumber),
					EmployeePersonnelName = selectedItem.EmployeeName,
					CreateDate = Convert.ToDateTime(wrkdt),
					CreateUser = Convert.ToString(timekprname),
					LastChangeDate = Convert.ToDateTime(wrkdt),
					LastChangeUser = Convert.ToString(timekprname),
                    UpdateFlag = "I",
                };
                var d = DoSaveData();
            };

            TableView.Source = tablesource;
            TableView.ReloadData();
        }
        #endregion

        #region DoSaveData
        async Task DoSaveData()
        {
			try 
			{
            saveMessage = null;
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var request = await client.PostAsync<LabourListDTO>(TimeCapServices.LaborList,labrsignout);
            var value = request.Value;
            if(value !=null)
            {
                new UIAlertView("Saved", "Employee Added", null, "OK", null).Show();
                var laborsignut = Storyboard.InstantiateViewController("EmployeeListSignoutViewController") as EmployeeListSignoutViewController;
				laborsignut.settimekper (this, timenum.ToString (), timekprname.ToString (), wrkdt.ToString ());
				NavigationController.PushViewController(laborsignut, false);
            }
            else
            {
                new UIAlertView("Error", "Error while adding", null, "OK", null).Show();
            }
			} 
			catch (Exception ex) 
			{
				System.Console.WriteLine (ex.Message);
			}
        }
        #endregion
    }
}
