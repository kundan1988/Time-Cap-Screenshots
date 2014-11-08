using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using TimeCap.iOS.Code;
using TimeCap.iOS.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Drawing;

namespace TimeCap.iOS
{
	partial class EmployeeSignoutController : UIViewController
	{
		#region Parameter
        object workdt,employeenum,employeename;
        LaborSignoutDTO currentSignout;
        string saveMessage;
        LoadingOverlay loadingOverlay;
		#endregion

        #region Controller
        public EmployeeSignoutController(IntPtr handle)
            : base(handle)
		{
		}
        #endregion

        #region Employeelistdelegate
        public EmployeeListSignoutViewController Delegate { get; set; }
        #endregion

        #region ViewWillAppear
        public override async void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);
            await LoadData();
        }
        #endregion

        #region SetTimeKeeperDetails
        public void SetLaborList (EmployeeListSignoutViewController employeeListSignoutViewController, ISupportEmpphotosorce supportEmpphotosorce, string Workdate)
		{
			employeenum = supportEmpphotosorce.EmployeeNumber.ToString ();
			employeename = supportEmpphotosorce.EmployeeName.ToString ();
			workdt = Workdate.ToString ();
		}
        #endregion

        #region ViewDidLoad
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            notesTextView.Layer.CornerRadius = 5;
            notesTextView.Layer.BorderColor = new MonoTouch.CoreGraphics.CGColor(UIColor.Gray.CGColor, 0.5f);
            notesTextView.Layer.BorderWidth = 2;
            notesTextView.ClipsToBounds = true;

            submitButton.Layer.CornerRadius = 10;
            submitButton.ClipsToBounds = true;
            submitButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            submitButton.Layer.BorderWidth = 1;
            submitButton.TouchUpInside += submitButton_TouchUpInside;

            cancelButton.Layer.CornerRadius = 10;
            cancelButton.ClipsToBounds = true;
            cancelButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            cancelButton.Layer.BorderWidth = 1;
            cancelButton.TouchUpInside += cancelButton_TouchUpInside;
        }
        #endregion

        #region SubmitButton
        private async void submitButton_TouchUpInside(object sender, EventArgs e)
        {
            await SaveData();

            if (saveMessage != null)
            {
                new UIAlertView("Error", saveMessage, null, "OK", null).Show();
            }
            else
            {
                UIStoryboard board = UIStoryboard.FromName("MainStoryboard", null);
                EmployeeSignatureViewController ctrl = (EmployeeSignatureViewController)board.InstantiateViewController("EmployeeSignatureViewController");
                ctrl.SetEmployeeSignature(this, currentSignout);
                NavigationController.PushViewController(ctrl, true);
            }
            this.actualHoursWorkedTextbox.ShouldReturn += (UITextField) =>
            {
                UITextField.ResignFirstResponder();
                return true;
            };
        }
        #endregion

        #region CancelButton
        private void cancelButton_TouchUpInside(object sender, EventArgs e)
        {
            NavigationController.PopViewControllerAnimated(true);
        }
        #endregion

        #region LoadData
        async Task LoadData()
        {
            loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);
            View.Add(loadingOverlay);

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
            }
        }
        #endregion

        #region DoLoadData
        async Task DoLoadData()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<LaborSignoutDTO>>(TimeCapServices.LaborSignout,
				new Dictionary<string, string>() { { "employeePersonnelNumber", employeenum.ToString() }, 
					{ "workDate", workdt.ToString() } });

            actualHoursWorkedTextbox.Text = "0.0";
            notesTextView.Text = string.Empty;
			employeeNameLabel.Text = employeename.ToString ();
			employeeNumberLabel.Text = employeenum.ToString ();

            foreach (var item in response.Value)
            {
                System.Console.WriteLine(item.EmployeePersonnelNumber);
                {
                    currentSignout = item;
                    actualHoursWorkedTextbox.Text = currentSignout.TotalAdjustedHours.GetValueOrDefault(0).ToString("#.#");
                    notesTextView.Text = currentSignout.Notes;
                    break;
                }
            }
        }
        #endregion

        #region SaveData
        async Task SaveData()
        {
            loadingOverlay = new LoadingOverlay(UIScreen.MainScreen.Bounds);//, "Saving Data...");
            View.Add(loadingOverlay);

            try
            {
                await DoSaveData();
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

            #region DoSave
            async Task DoSaveData()
            {
                saveMessage = null;

                currentSignout.TotalAdjustedHours = Convert.ToDecimal(actualHoursWorkedTextbox.Text);
                currentSignout.Notes = notesTextView.Text;

                ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
                Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
                JsonClient client = new JsonClient(serializer);

                var response = await client.PostAsync<LaborSignoutDTO>(TimeCapServices.LaborSignout, currentSignout);
                var value = response.Value;

                if (value != null)
                {
                    new UIAlertView("Saved", "Record Added Sucessfully", null, "OK", null).Show();
                }
                else
                {
                    new UIAlertView("Error", saveMessage, null, "OK", null).Show();
                }
            }
            #endregion
    }
}
