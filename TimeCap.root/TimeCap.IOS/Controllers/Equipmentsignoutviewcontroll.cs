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
	partial class Equipmentsignoutviewcontroll : UITableViewController
    {
        #region Parameter
        LoadingOverlay loadingOverlay;
		object timekprnum, timekprname,wrkdt;
		UIImageView imageView;
        #endregion

        #region Delegate
        public HomeViewController Delegate { get; set; }
        #endregion

        #region Controller
        public Equipmentsignoutviewcontroll (IntPtr handle) : base (handle)
		{

		}
        #endregion

        #region SetTimekeeperDetails
        internal void settimekeeperid (HomeViewController homeViewController, string Timekeepernum, string Timekeepername, string workdate)
		{
			try
			{
			timekprnum = Timekeepernum.ToString ();
			timekprname = Timekeepername.ToString ();
			wrkdt = workdate.ToString();
			}
			catch(Exception ex) 
			{
				System.Console.WriteLine (ex.Message);
			}
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

            var response = await client.GetAsync<IEnumerable<EquipmentMasterDTO>>(TimeCapServices.EquipList,
				new Dictionary<string, string>() { { "timeKeeperPersonnelNumber", timekprnum.ToString() }, { "workDate", wrkdt.ToString() } });

			var responseimag = await client.GetAsync<IEnumerable<EquipmentMasterDTO>> (TimeCapServices.EquipmentMaster,
				new Dictionary<string, string> () { { "username", "test-fe91" }, { "role", "timekeeper" } });

            var tableSource = new EquipmentListTableSource();
			HashSet<string> equipmentnum = new HashSet<string>();
            var data = new List<EquiplistRowData>();
            foreach (var item in response.Value)
            {
				if (!equipmentnum.Contains (item.EquipmentNumber))
				{
					List<object> Equipmentnumber = new List<object> ();
					Equipmentnumber.Add (item.EquipmentNumber);
					foreach (var items in responseimag.Value) 
					{
						if (Equipmentnumber.Contains (items.EquipmentNumber)) 
						{
							NSData imagedata = new NSData (items.Photo, NSDataBase64DecodingOptions.IgnoreUnknownCharacters);
							UIImage image = new UIImage (imagedata);
							imageView = new UIImageView (image);
							imageView.Image = image;
							data.Add (new EquiplistRowData () 
							{
								EquipmentNumber = item.EquipmentNumber,
								EquipmentDescription = item.EquipmentDescription,
								Equipmentphoto = image
							});
						}
					}
				}
            }
            tableSource.Data = data;
            tableSource.OnRowSelected += (object sender, EquipmentListTableSource.RowSelectedEventArgs e) =>
            {
				new UIAlertView("Selected",tableSource.Data[e.indexPath.Row].ToString(), null, "ok", null).Show();
            };
            TableView.Source = tableSource;
            TableView.ReloadData();
        }
        #endregion

        #region Equipmentmasterbtn
        partial void UIBarButtonItem973_Activated (UIBarButtonItem sender)
		{
			var equipsr = Storyboard.InstantiateViewController("EquipmentMasterViewcontroller") as EquipmentMasterViewcontroller;
			equipsr.settimekeeperdetail(this,timekprnum.ToString(),wrkdt.ToString(),timekprname.ToString());
			NavigationController.PushViewController(equipsr,true);
        }
        #endregion
    }
}
