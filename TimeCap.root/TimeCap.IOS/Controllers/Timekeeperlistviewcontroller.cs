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
	partial class Timekeeperlistviewcontroller : UITableViewController
    {
        #region Parameter
        LoadingOverlay loadingOverlay;
		UIImageView imageView;
        #endregion

        #region Controller
        public Timekeeperlistviewcontroller (IntPtr handle) : base (handle)
		{

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

            var response = await client.GetAsync<IEnumerable<LaborListDTO>>(TimeCapServices.Timekeeper,
               new Dictionary<string, string>() { { "username", "test-fe91" }, { "role", "fieldengineer" } });

            var imageresponse = await client.GetAsync<IEnumerable<LabourListDTO>>(TimeCapServices.LaborMaster,
                new Dictionary<string, string>() { { "username", "test-fe91" }, { "role", "timekeeper" } });


            var tablesource = new EmpPhotoTablesource();
			var data = new List<ISupportEmpphotosorce>();

            HashSet<string> employeename = new HashSet<string>();
            foreach (var item in response.Value)
            {
                if (!employeename.Contains(item.TimekeeperPersonnelName))
                {
					List<object> Timekeeperno = new List<object> ();
					Timekeeperno.Add (item.TimekeeperPersonnelNumber);
					foreach (var newitem in  imageresponse.Value)
					{
						if (Timekeeperno.Contains(newitem.EmployeePersonnelNumber)) 
						{
							NSData imagedata = new NSData(newitem.EmployeePhoto, NSDataBase64DecodingOptions.IgnoreUnknownCharacters);
							UIImage image = new UIImage(imagedata);
							imageView = new UIImageView(image);
							imageView.Image = image;
							data.Add (new Empphotodata () { EmployeePersonnelNumber = item.TimekeeperPersonnelNumber.ToString(), EmployeePersonnelName = item.TimekeeperPersonnelName, EmployeePhoto = image });
						}
					}
                }
            }
			tablesource.Data = data;
			tablesource.OnRowSelected += (object sender, EmpPhotoTablesource.RowSelectedEventArgs e) =>
           {
               var detail = Storyboard.InstantiateViewController("IGCalendarViewXamarinViewController") as IGCalendarViewXamarinViewController;
				detail.setTimekeeper(this, tablesource.Data[e.indexPath.Row]);
               NavigationController.PushViewController(detail, true);
            };
            //Xamarin.Themes.IndustrialTheme.Apply(TableView);
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
    }
}
