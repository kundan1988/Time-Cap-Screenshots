using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using System.Threading.Tasks;
using TimeCap.iOS.Code;
using TimeCap.iOS.Models;
using System.Collections.Generic;
//using MonoTouch.Dialog;
using MonoTouch.AVFoundation;
using DataAccess;

namespace TimeCap.iOS
{
	partial class AllocationViewcontroller : UIViewController
    {
        #region Parameter
        string saveMessage;
        object Timekprnu, TimekprNme , wrkdt, Employeenma, Employeenumbr,Projnum, Prodescp, transactnum;
        LoadingOverlay loadingOverlay;
        AllocatedLaborDTO allocatedLabor = new AllocatedLaborDTO();
        UIImage empphoto = new UIImage();
        Stock currentStock { get; set; }
        #endregion

        #region Controller
        public AllocationViewcontroller (IntPtr handle) : base (handle)
		{
           
		}
        #endregion

        #region Delegate
        public AllocEmployeeListViewController Delegate { get; set; }
        #endregion

        #region Viewdidload
        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.txtremininghrs.BackgroundColor = UIColor.Cyan;
            this.txttotalhourswrktoday.BackgroundColor = UIColor.Cyan;
            lblempname.Text = Employeenma.ToString();
            empimg.Image = empphoto;
            lblempnumber.Text = Employeenumbr.ToString();
            await SaveData();
            if (transactnum != null)
            {
                lblprojectactivitynum.Text = "Activity:-" + transactnum.ToString();
            }
            this.NavigationItem.SetRightBarButtonItem(null, true);
            btndone.TouchUpInside += btndone_TouchUpInside;
        }
        #endregion

        #region DoneButton
        void btndone_TouchUpInside(object sender, EventArgs e)
        {
            try
            {
                if(this.txtallocatedhrs.Text.Length <= 0 )
                {
                    InvokeOnMainThread(() =>
                    {
                        this.txtallocatedhrs.BackgroundColor = UIColor.Cyan;
                        this.txtallocatedhrs.Layer.BorderColor = UIColor.Blue.CGColor;
                        this.txtallocatedhrs.Layer.BorderWidth = 3;
                        this.txtallocatedhrs.Layer.CornerRadius = 5;
                    });
                }
                if ( lblempnumber.Text != null)
                {
                    currentStock.AllocatedHours = txtallocatedhrs.Text;
                    currentStock.EmployeePersonnelNum = lblempnumber.Text;
                    Delegate.SaveStock(currentStock);
                }
                else
                {
                    new UIAlertView("Oops", "Employeepersonnelnumber not found", null, "OK", null).Show();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
      #endregion

        #region SetAllocatedHours
        public void SetStock(AllocEmployeeListViewController d, Stock Stock)
        {
            Delegate = d;
            currentStock = Stock;
        }
        #endregion

        #region Displaybefore
        // when displaying, set-up the properties
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            if (currentStock == null) currentStock = new Stock();
            txtallocatedhrs.Text = currentStock.AllocatedHours;
            //txtremininghrs.Text = currentStock.Symbol;
        }
        #endregion

        #region EquipmentData
        internal void equipmntdata(AllocEquipmentListViewController allocEquipmentListViewController, System.Collections.Generic.List<Code.EquiplistRowData> list)
        {

        }
        #endregion

        #region LoadData
        async System.Threading.Tasks.Task SaveData()
        {
            loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);
            View.Add(loadingOverlay);

            try
            {
                await Loaddata();
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

        #region Load
        async System.Threading.Tasks.Task Loaddata()
        {
            saveMessage = null;
                       
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<LaborSignoutDTO>>(TimeCapServices.LaborTimeAllocByAct,
				new Dictionary<string, string>() { { "TimekeeperPersonnelNumber", Timekprnu.ToString() }, 
					{ "workDate", wrkdt.ToString() } });

            HashSet<string> EmpNumber = new HashSet<string>();
            Employeenumbr = EmpNumber;
            foreach (var item in response.Value)
            {
                if(EmpNumber.Contains(item.EmployeePersonnelNumber.ToString()))
                {
                    txtremininghrs.Text = item.AllocatedHours.ToString();
                }
            }
        }
        #endregion

        #region EmployeeData
        internal void datasorce(AllocEmployeeListViewController allocEmployeeListViewController, string EmployeeNUmber,
            AllocEmployeeTableSource tableSource, string EmployeeNAme, 
            string WorkDAte, string TimeKeeperNUmber, string Timekeepername, UIImage employeephoto,
            string ProjectNumber, string ProjectDescription, string TransformedActivityNumber)
        {
            Timekprnu = TimeKeeperNUmber.ToString();
            TimekprNme = Timekeepername.ToString();
            Employeenma = EmployeeNAme.ToString();
            Employeenumbr = EmployeeNUmber.ToString();
            wrkdt = WorkDAte.ToString();
            empphoto = employeephoto;
            Projnum = ProjectNumber.ToString();
            Prodescp = ProjectDescription.ToString();
            transactnum = TransformedActivityNumber.ToString();
        }
        #endregion

        #region NonProjectdesc
        internal void nonprojectnum(AllocEmployeeListViewController allocEmployeeListViewController, string p1, AllocEmployeeTableSource tableSource, string p2, string p3, string p4, string p5, UIImage uIImage)
        {
            Timekprnu = p4.ToString();
            TimekprNme = p5.ToString();
            Employeenma = p2.ToString();
            Employeenumbr = p1.ToString();
            wrkdt = p3.ToString();
            empphoto = uIImage;
        }
        #endregion
    }
}
