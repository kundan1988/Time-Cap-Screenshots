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
using DataAccess;

namespace TimeCap.iOS
{
	partial class AllocEmployeeListViewController : UITableViewController
    {
        #region Parameter
        LoadingOverlay loadingOverlay;
		object timekprnum, timekprname,workdt,pronum, prodesc,transfractnum,AllocatedHrs, EmployeePerNum;
		UIImageView imageView;
        IEnumerable<Stock> stocks;
        IEnumerable<Stock> items;
        IList<Stock> tableItems;
        NSIndexPath indexpath;
        List<object> AlloHours = new List<object>();
        Stock currentStock { get; set; }
        #endregion

        #region Alloccontroller
        public AllocEmployeeListViewController (IntPtr handle) : base (handle)
		{
          
		}
        #endregion

        #region Passdetails
        public void passdetails (AllocationsActualViewController allocationsActualViewController, string TimekeeperNumber,
            string TimekeeperName, string WorkDate, string ProjectNumber, string Projectdescription, string TransformedActivityNumber)
		{
			timekprnum = TimekeeperNumber.ToString ();
			timekprname = TimekeeperName.ToString ();
			workdt = WorkDate.ToString ();
            pronum = ProjectNumber.ToString();
            prodesc = Projectdescription.ToString();
            transfractnum = TransformedActivityNumber.ToString();
		}
        #endregion

        #region ViewDidLoad
        public override async void ViewDidLoad()
		{
			base.ViewDidLoad();
            if (currentStock == null) currentStock = new Stock();
            stocks = AppDelegate.Database.GetStocks();
            IEnumerable<Stock> stk = stocks.ToList();
           
            string sum = stk.Sum(x => x.AllocatedHours == null ? 0 :
                        Convert.ToInt32(x.AllocatedHours)).ToString();
            AllocatedHrs = sum;
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

		#region DoLoad
		async Task DoLoadData()
		{
			try
			{
			Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
			JsonClient client = new JsonClient(serializer);

				var imageresponse = await client.GetAsync<IEnumerable<LabourListDTO>>(TimeCapServices.LaborMaster,
					new Dictionary<string, string>() { { "username", "test-fe91" }, { "role", "timekeeper" } });

				var response = await client.GetAsync<IEnumerable<LaborListDTO>>(TimeCapServices.LaborList,
					new Dictionary<string, string>() { { "timeKeeperPersonnelNumber", timekprnum.ToString()}, { "workDate", workdt.ToString() } });

                var tableSource = new AllocEmployeeTableSource();
                   var data = new List<IsupportAllocEmployee>();
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
                                if (AllocatedHrs != null)
                                {
                                    data.Add(new AllocEmployeePhoto() { EmployeePersonnelNumber = item.EmployeePersonnelNumber.ToString(), EmployeePersonnelName = item.EmployeePersonnelName, EmployeePhoto = image, AllocHours = AllocatedHrs.ToString() });
                                }
                                else
                                {
                                    data.Add(new AllocEmployeePhoto() { EmployeePersonnelNumber = item.EmployeePersonnelNumber.ToString(), EmployeePersonnelName = item.EmployeePersonnelName, EmployeePhoto = image, });//, AllocHours = item.TimekeeperPersonnelNumber.ToString(), EquipHours = item.TimekeeperPersonnelName.ToString(), WorkdHours = item.WorkDate.ToString() });
                                }
                            }
						}
					}
				}
				tableSource.Data = data;    
				TableView.Source = tableSource;
				TableView.ReloadData();

				tableSource.OnRowSelected += (object sender, AllocEmployeeTableSource.RowSelectedEventArgs e) =>
				{
                    try
                    {
                        if (pronum == null && prodesc == null && transfractnum == null)
                        {
                            var empalloc = Storyboard.InstantiateViewController("AllocationViewcontroller") as AllocationViewcontroller;
                            empalloc.nonprojectnum(this, tableSource.Data[e.indexPath.Row].EmployeeNumber, tableSource, data[e.indexPath.Row].EmployeeName,
                                workdt.ToString(), timekprnum.ToString(), timekprname.ToString(), tableSource.Data[e.indexPath.Row].ImageUri);
                            empalloc.Delegate = this;
                            NavigationController.PushViewController(empalloc, true);
                        }
                        else
                        {
                            var empalloc = Storyboard.InstantiateViewController("AllocationViewcontroller") as AllocationViewcontroller;
                            empalloc.datasorce(this, tableSource.Data[e.indexPath.Row].EmployeeNumber, tableSource, data[e.indexPath.Row].EmployeeName,
                                workdt.ToString(), timekprnum.ToString(), timekprname.ToString(), tableSource.Data[e.indexPath.Row].ImageUri,
                                pronum.ToString(), prodesc.ToString(), transfractnum.ToString());
                            NavigationController.PushViewController(empalloc, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
				};	
			}
			catch(Exception ex) 
			{
				System.Console.WriteLine (ex.Message);
			}
		}
		#endregion

        #region Nonpojectnum
        internal void passtimekeeper(AllocationsActualViewController allocationsActualViewController, string TimekeeperID, string TimekeeperNamee, string Workdtee)
        {
            timekprnum = TimekeeperID.ToString();
            timekprname = TimekeeperNamee.ToString();
            workdt = Workdtee.ToString();
        }
        #endregion

        #region SaveStock
        public void SaveStock(Stock stock)
        {
            try
            {
                Console.WriteLine("Save " + stock.AllocatedHours);
                AllocatedHrs = stock.AllocatedHours.ToString();
                AppDelegate.Database.SaveStock(stock);
                NavigationController.PopViewControllerAnimated(true);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        #endregion
     }
}
