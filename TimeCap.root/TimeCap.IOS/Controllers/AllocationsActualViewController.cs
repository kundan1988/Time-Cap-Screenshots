using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;

namespace TimeCap.iOS
{
	partial class AllocationsActualViewController : UIViewController
    {
        #region Parameter
        object timekprnum, timekprname,workdt, pronum, prodesc,tranactnum;
        #endregion

        #region Controller
        public AllocationsActualViewController (IntPtr handle) : base (handle)
		{
        }
        #endregion

        #region SetTimekeeper
        public void settimekprdetls (TaskCaptureViewController taskCaptureViewController, string TimekeeperId, string TimekeeperName, string Workdate)
		{
			timekprnum = TimekeeperId.ToString ();
			timekprname = TimekeeperName.ToString ();
			workdt = Workdate.ToString ();
		}
        #endregion

        #region ViewWillAppear
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            allocEmployeeButton.Layer.CornerRadius = 10;
            allocEmployeeButton.ClipsToBounds = true;
            allocEmployeeButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            allocEmployeeButton.Layer.BorderWidth = 1;

            allocEquipmentButton.Layer.CornerRadius = 10;
            allocEquipmentButton.ClipsToBounds = true;
            allocEquipmentButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            allocEquipmentButton.Layer.BorderWidth = 1;

            allocActivityButton.Layer.CornerRadius = 10;
            allocActivityButton.ClipsToBounds = true;
            allocActivityButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            allocActivityButton.Layer.BorderWidth = 1;

			Timecapwrkdate.Text = workdt.ToString ();
			lbltimekprnum.Text = timekprnum.ToString ();
			lbltimekprname.Text = timekprname.ToString ();
        }
        #endregion

        #region EmployeeAllocbtn
        partial void allocEmployeeButton_TouchUpInside (UIButton sender)
		{
            try
            {
                if (pronum == null && prodesc == null && tranactnum == null)
                {
                    var employeealloc = Storyboard.InstantiateViewController("AllocEmployeeListViewController") as AllocEmployeeListViewController;
                    employeealloc.passtimekeeper(this, timekprnum.ToString(), timekprname.ToString(), workdt.ToString());
                    NavigationController.PushViewController(employeealloc, true);
                }
                else
                {
                    var employeealloc = Storyboard.InstantiateViewController("AllocEmployeeListViewController") as AllocEmployeeListViewController;
                    employeealloc.passdetails(this, timekprnum.ToString(), timekprname.ToString(), workdt.ToString(), pronum.ToString(), prodesc.ToString()
                        , tranactnum.ToString());
                    NavigationController.PushViewController(employeealloc, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
		}
        #endregion

        #region FillTimekeeperDetails
        internal void filltimekeeper(ProjectListViewController projectListViewController, string TimekeeperNumber, string Timekeepname,
            string Workdateee, string ProjectNumber, string ProjectDescription, string Transformedactivitynumber)
        {
            timekprnum = TimekeeperNumber.ToString();
            timekprname = Timekeepname.ToString();
            workdt = Workdateee.ToString();
            pronum = ProjectNumber.ToString();
            prodesc = ProjectDescription.ToString();
            tranactnum = Transformedactivitynumber.ToString();
        }
        #endregion

        #region Equipmentbtn
        partial void allocEquipmentButton_TouchUpInside(UIButton sender)
        {
            var allocequip = Storyboard.InstantiateViewController("AllocEquipmentListViewController") as AllocEquipmentListViewController;
            allocequip.passdetails(this, timekprnum.ToString(), timekprname.ToString(), workdt.ToString());
            NavigationController.PushViewController(allocequip, true);
        }
        #endregion
    
    }
}

