using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.CodeDom.Compiler;
using TimeCap.iOS.Models;
using System.Threading.Tasks;
using TimeCap.iOS.Code;
using System.Collections.Generic;
using System.Drawing;

namespace TimeCap.iOS
{
	partial class EmployeeSignatureViewController : UIViewController
    {
        #region Parameter
        public EmployeeSignoutController Delegate { get; set; } // will be used to Save, Delete later
        LaborSignoutDTO currentSignout;
        LaborSignatureDTO currentSignature; 
        string saveMessage;
        LoadingOverlay loadingOverlay;
        UIImageView imageView;
        UIButton btnLoad;
        PointF[] points;
        #endregion

        #region Controller
        public EmployeeSignatureViewController (IntPtr handle) : base (handle)
		{
		}
        #endregion

        #region SetEmployeesignature
        public void SetEmployeeSignature(EmployeeSignoutController d, LaborSignoutDTO laborSignout)
        {
            Delegate = d;
            currentSignout = laborSignout;
        }
        #endregion

        #region ViewDidLoad
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            saveButton.Layer.CornerRadius = 10;
            saveButton.ClipsToBounds = true;
            saveButton.Layer.BorderColor = UIColor.LightGray.CGColor;
            saveButton.Layer.BorderWidth = 1;
            saveButton.TouchUpInside += saveButton_TouchUpInside;

            btnLoad = UIButton.FromType(UIButtonType.RoundedRect);
            btnLoad.SetTitle("Load Last", UIControlState.Normal);
            btnLoad.TouchUpInside += (sender, e) =>
            {
                if (points != null)
                    signaturePad.LoadPoints(points);
            };
            imageView = new UIImageView();
            View.AddSubview(imageView);
            imageView.Frame = new RectangleF(84, signaturePad.Frame.Height + 168,View.Frame.Width - 168, View.Frame.Width / 2);
        }
        #endregion

        #region ViewDidAppear
        public override async void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            await LoadData();
        }
        #endregion

        #region Savebtn
        private async void saveButton_TouchUpInside(object sender, EventArgs e)
        {
            await SaveData();

            if (saveMessage != null)
            {
                new UIAlertView("Error", saveMessage, null, "OK", null).Show();
            }
            else
            {
                new UIAlertView("Save", "Signature Saved", null, "OK", null).Show();
                //NavigationController.PopToRootViewController(true);
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

            UIImage image = signaturePad.GetImage();
            NSData imageData = image.AsPNG();
            string signatureString = Convert.ToBase64String(imageData.ToArray());
            currentSignature.SignatureScreen = signatureString;

            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.PostAsync<LaborSignatureDTO>(TimeCapServices.LaborSignature, currentSignature);
            var value = response.Value;
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

        #region DoLoad
        async Task DoLoadData()
        {
            ModernHttpClient.NativeMessageHandler m = new ModernHttpClient.NativeMessageHandler();
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            JsonClient client = new JsonClient(serializer);

            var response = await client.GetAsync<IEnumerable<LaborSignatureDTO>>(TimeCapServices.LaborSignature,
                new Dictionary<string, string>() { { "employeePersonnelNumber","167955" },
                                                     { "workDate", "2014-03-31" } });

            foreach (var item in response.Value)
            {
                System.Console.WriteLine(item.EmployeePersonnelNumber);
                if (item.SignatureScreen != null)
                {
                    currentSignature = item;
                    NSData imageData = new NSData(item.SignatureScreen, NSDataBase64DecodingOptions.IgnoreUnknownCharacters);
                    UIImage image = new UIImage(imageData);
                    imageView = new UIImageView(image);
                    imageView.Frame = new RectangleF(84, signaturePad.Frame.Height + 168,
                       View.Frame.Width - 168, View.Frame.Width / 2);

                    imageView.Image = image;
                    //signView.Frame = new RectangleF(84, signaturePad.Frame.Height + 168,
                    //   View.Frame.Width - 168, View.Frame.Width / 2);
                    //signaturePad..LoadPoints(image.)
                    break;
                }
                //if (currentLaborList.EmployeeNumber == item.EmployeePersonnelNumber)
                {
                    break;
                }
            }
        }
        #endregion

    }
}
