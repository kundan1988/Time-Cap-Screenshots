using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using TimeCap.iOS.Code;
//using Xamarin.Forms.Calendar;
using MyTimecapCalendar;

namespace TimeCap.iOS
{
	partial class IGCalendarViewXamarinViewController : UIViewController
    {
        #region Parameter
        TimeCapCalendar TimecapCalendr = new TimeCapCalendar();
		object Timekprno, Timekprnme;
        #endregion

        #region Delegate
        public Timekeeperlistviewcontroller Delegate { get; set; }
        #endregion

        #region IGCalenderController
        public IGCalendarViewXamarinViewController (IntPtr handle) : base (handle)
		{

		}
        #endregion

        #region TimekeeperDetails
        public void setTimekeeper (Timekeeperlistviewcontroller timekeeperlistviewcontroller, ISupportEmpphotosorce supportEmpphotosorce)
		{
			Timekprno = supportEmpphotosorce.EmployeeNumber.ToString ();
			Timekprnme = supportEmpphotosorce.EmployeeName;
		}
        #endregion

        #region ViewDidLoad
        public override void ViewDidLoad()
        {
            try
            {
                base.ViewDidLoad();
                
                TimecapCalendr.SelectionColor = UIColor.Red;
                TimecapCalendr.MonthFormatString = "MMMM yyyy";
                TimecapCalendr.SundayFirst = false;
                TimecapCalendr.IsDayMarkedDelegate = (date) =>
                {
                    return date.Day % 2 == 0;
                };

                TimecapCalendr.IsDateAvailable = (date) =>
                {
                    return (date >= DateTime.Today);
                };

                TimecapCalendr.MonthChanged = (date) =>
                {
                    Console.WriteLine("Month changed {0}", date.Date);
                };

                TimecapCalendr.DateSelected += (date) =>
                {
                    try
                    {
						string time = date.ToString();
						time = date.ToString("yyyy-MM-dd");
						if (time != null)
                        {
                            var homescreen = Storyboard.InstantiateViewController("HomeViewController") as HomeViewController;
							homescreen.SetLaborList(this,time,Timekprnme.ToString(),Timekprno.ToString());
                            NavigationController.PushViewController(homescreen, true);
                        }
                    }

                    catch (Exception ex)
                    {
                        System.Console.WriteLine(ex.Message);
                    }

                };
                TimecapCalendr.Center = this.View.Center;
                this.View.AddSubview(TimecapCalendr);
				timekeepernumber.Text = Timekprno.ToString();
				timekeepername.Text = Timekprnme.ToString();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
