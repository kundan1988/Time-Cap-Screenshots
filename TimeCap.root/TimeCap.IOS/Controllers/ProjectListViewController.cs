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
using FontList.Code;
using DataAccess;

namespace TimeCap.iOS
{
	partial class ProjectListViewController : UITableViewController
    {
		#region Parameter
        LoadingOverlay loadingOverlay;
        object timekprid, timekprname, wrkdt, AllocatedHrs;
        List<NavItemGroup> navItems = new List<NavItemGroup>();
        NavItemTableSource tableSource;
        NavItemGroup navGroup;
		NavItemGroup newnavGroup;
        NavItem navItem;
        List<object> AlloHours = new List<object>();
        Stock currentStock { get; set; }
        IEnumerable<Stock> stocks;
        #endregion

        #region TImekeeperDetails
        public void settimekprdetails (TaskCaptureViewController taskCaptureViewController, string TimekeeperId, string TimekeeperName, string Workdate)
		{
			timekprid = TimekeeperId.ToString ();
			timekprname = TimekeeperName.ToString ();
			wrkdt = Workdate.ToString ();
		}
        #endregion

        #region Controller
        public ProjectListViewController (IntPtr handle) : base (handle)
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
            try
            {
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                JsonClient client = new JsonClient(serializer);

                var response = await client.GetAsync<IEnumerable<ProjectEmployeeDTO>>(TimeCapServices.ActivityList,
                        new Dictionary<string, string>() { { "timekeeperPersonnelNumber", timekprid.ToString() }, { "workDate", wrkdt.ToString() } });

                navItems.Clear();
				foreach (var item in response.Value.Select(x =>  new { pronum = x.ProjectNumber, prodesc = x.ProjectDescription }).Distinct().ToList())
                {
					navGroup = new NavItemGroup(item.pronum, item.prodesc);
					if(navGroup.Name.Distinct().Count()!= navGroup.Name.Count())
					{
						navItems.Add(navGroup);
						foreach (var newitem in response.Value.Select(x =>  new { Transforactnum = x.TransformedActivityNumber,
						                        activitydesc = x.ActivityDescription}).Distinct().ToList())
		                {
                            navItem = new NavItem(newitem.Transforactnum, newitem.activitydesc, AllocatedHrs.ToString());
                           navGroup.Items.Add(navItem);
		                }
					}
                }
				tableSource = new NavItemTableSource(NavigationController,navItems);
                base.TableView.Source = tableSource;
                
                //TableView.SeparatorColor = UIColor.Blue;
                //TableView.SeparatorStyle = UITableViewCellSeparatorStyle.DoubleLineEtched;
                //TableView.SeparatorColor = UIColor.Black;
				TableView.ReloadData();

                #region OnRowSelected
                tableSource.OnRowSelected += (object sender, NavItemTableSource.RowSelectedEventArgs e) =>
                {
                    var allocation = Storyboard.InstantiateViewController("AllocationsActualViewController") as AllocationsActualViewController;
                    allocation.filltimekeeper(this, timekprid.ToString(), timekprname.ToString(), wrkdt.ToString(), navGroup.Name, navGroup.Description
                        ,navItem.Name);
                    NavigationController.PushViewController(allocation, true);
                };
                #endregion
            }
            catch (Exception ex)
            {
                new UIAlertView("Oops", "No Record Available", null, "OK", null).Show();
                System.Console.WriteLine(ex.Message);
            }
        }
        #endregion

		#region Fetchelementlist
		public void setdetails (Elementlistviewcontroller elementlistviewcontroller, string TimekeeperNo, string TimekeeperNme, string Wrkdate)
		 {
			timekprid = TimekeeperNo.ToString ();
			timekprname = TimekeeperNme.ToString ();
			wrkdt = Wrkdate.ToString ();
		}
		#endregion

        #region ViewDidLoad
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            if (currentStock == null) currentStock = new Stock();
            stocks = AppDelegate.Database.GetStocks();
            IEnumerable<Stock> stk = stocks.ToList();

            string sum = stk.Sum(x => x.AllocatedHours == null ? 0 : Convert.ToInt32(x.AllocatedHours)).ToString();
            AllocatedHrs = sum;
        }
        #endregion

        #region DidAppear
        public override async void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			await LoadData();
		}
        #endregion

        #region GoProjectSearch
        partial void btnadd_Activated (UIBarButtonItem sender)
		{
			var projectsrc = Storyboard.InstantiateViewController("Projectsearchviewcontroller") as Projectsearchviewcontroller;
			projectsrc.settimekprdetls(this, timekprid.ToString(),timekprname.ToString(),wrkdt.ToString());
			NavigationController.PushViewController(projectsrc,true);
		}
        #endregion

        #region AddAllocatedHours
        internal void addallohrs(string AllocatedHrs)
        {

        }
        #endregion
    }
}
