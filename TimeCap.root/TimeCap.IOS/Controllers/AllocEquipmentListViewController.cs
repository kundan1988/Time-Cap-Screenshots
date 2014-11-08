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
	partial class AllocEquipmentListViewController : UITableViewController
    {
        #region Parameter
        LoadingOverlay loadingOverlay;
        object Timekprnum, Timekprname, Wrkdt;
        UIImageView imageView;
        #endregion

        #region AllocEquipcontroller
        public AllocEquipmentListViewController (IntPtr handle) : base (handle)
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

            var response = await client.GetAsync<IEnumerable<EquipmentMasterDTO>>(TimeCapServices.EquipList,
                new Dictionary<string, string>() { { "timeKeeperPersonnelNumber", Timekprnum.ToString() }, { "workDate", Wrkdt.ToString() } });

            var responseimag = await client.GetAsync<IEnumerable<EquipmentMasterDTO>>(TimeCapServices.EquipmentMaster,
                new Dictionary<string, string>() { { "username", "test-fe91" }, { "role", "timekeeper" } });

            var tableSource = new EquipmentListTableSource();
            HashSet<string> equipmentnum = new HashSet<string>();
            var data = new List<EquiplistRowData>();
            foreach (var item in response.Value)
            {
                if (!equipmentnum.Contains(item.EquipmentNumber))
                {
                    List<object> Equipmentnumber = new List<object>();
                    Equipmentnumber.Add(item.EquipmentNumber);
                    foreach (var items in responseimag.Value)
                    {
                        if (Equipmentnumber.Contains(items.EquipmentNumber))
                        {
                            NSData imagedata = new NSData(items.Photo, NSDataBase64DecodingOptions.IgnoreUnknownCharacters);
                            UIImage image = new UIImage(imagedata);
                            imageView = new UIImageView(image);
                            imageView.Image = image;
                            data.Add(new EquiplistRowData()
                            {
                                EquipmentNumber = item.EquipmentNumber,
                                EquipmentDescription = item.EquipmentDescription,
                                Equipmentphoto = image, 
                                AllocatedHours = item.EquipmentSerialNumber
                            });
                        }
                    }
                }
            }
            tableSource.Data = data;
            tableSource.OnRowSelected += (object sender, EquipmentListTableSource.RowSelectedEventArgs e) =>
            {
                var empalloc = Storyboard.InstantiateViewController("AllocationViewcontroller") as AllocationViewcontroller;
                empalloc.equipmntdata(this, tableSource.Data);
                NavigationController.PushViewController(empalloc, true);
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

        #region GetTimekeeperDetails
        internal void passdetails(AllocationsActualViewController allocationsActualViewController, string TimeKeeperNumber, string TimeKeeperName, string Workdate)
        {
            Timekprnum = TimeKeeperNumber.ToString();
            Timekprname = TimeKeeperName.ToString();
            Wrkdt = Workdate.ToString();
        }
        #endregion
    }
}
