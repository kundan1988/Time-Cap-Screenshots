using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XibFree;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;

namespace TimeCap.iOS.Code
{
    public class EquiplistRowData
    {
        public string EquipmentNumber { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
        public string ShiftStart { get; set; }
        public string ShiftEnd { get; set; }
        public string AllocatedHours { get; set; }
        public string TotalMeterHours { get; set; }
        public string Notes { get; set; }
        public string EquipmentDescription { get; set; }
        public string EquipmentSerialNumber { get; set; }
        public string EquipmentClassCode { get; set; }
        public DateTime Workdate { get; set; }
		public UIImage Equipmentphoto { get; set; }
    }

    class EquipmentListTableItem : UITableViewCell
    {
		UILabel equipmentnum, longitu, latitude,equipdescri,Euiphrs;
		UIImageView imageview = new UIImageView ();

        public ViewGroup Layout
        {
            get;
            set;
        }

        public EquipmentListTableItem (IntPtr handle): base(handle)
        {

        }

        public EquipmentListTableItem(string cellId) : base(UITableViewCellStyle.Default, cellId)
        {
            Layout = new LinearLayout(Orientation.Vertical)
            {
                Padding = new UIEdgeInsets(5, 5, 5, 5),
                LayoutParameters = new LayoutParameters()
                {
                    Width = AutoSize.FillParent,
                    Height = AutoSize.WrapContent,
                },

                SubViews = new View[]
                    {
                        new LinearLayout(Orientation.Horizontal)
                        {
                           LayoutParameters = new LayoutParameters()
                           {
                                Width = AutoSize.FillParent,
                                Height = AutoSize.WrapContent,
                            },
                            SubViews = new View[]
                            {
                                new NativeView()
                                {
                                    View = equipmentnum = new UILabel()
                                    {
                                        Text = "Equipment Number",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.BoldSystemFontOfSize(10),
                                        HighlightedTextColor = UIColor.White,
                                    },
                                },

                                new NativeView()
                                {
                                    View = equipdescri = new UILabel()
                                    {
                                        Text = "Equipment Description",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.BoldSystemFontOfSize(10),
                                        HighlightedTextColor = UIColor.White,
                                    },
                                },
							new NativeView()
							{
								View = imageview = new UIImageView()
								{

								},
							},
                            }
                        },
                         new NativeView()
                                {
                                    View = Euiphrs = new UILabel()
                                    {
                                        Text = " Equip Hrs 10.0",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.BoldSystemFontOfSize(10),
                                        TextColor = UIColor.Red,
                                        HighlightedTextColor = UIColor.White,
                                    },
								   LayoutParameters = new LayoutParameters()
									{
									  Width = AutoSize.FillParent,
									  Height = AutoSize.WrapContent,
									},
                                },
                        new LinearLayout(Orientation.Horizontal)
                        {
                            //LayoutParameters = new LayoutParameters()
                            //{
                              //  Width = AutoSize.FillParent,
                                //Height = AutoSize.WrapContent,
                            //},
                            SubViews = new View[]
                            {
                                //longitu, latitude, shiftstart, shiftend
                                new NativeView()
                                {
                                    View = longitu = new UILabel()
                                    {
                                        Text = " 10.0",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.BoldSystemFontOfSize(10),
                                        TextColor = UIColor.Red,
                                        HighlightedTextColor = UIColor.White,
                                    },
								   LayoutParameters = new LayoutParameters()
									{
									  Width = AutoSize.FillParent,
									  Height = AutoSize.WrapContent,
									},
                                },
                                new NativeView()
                                {
                                    View = latitude = new UILabel()
                                    {
                                        Text = " 0.0",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.SystemFontOfSize(10),
                                        TextColor = UIColor.Red,
                                        HighlightedTextColor = UIColor.White,
                                    }, 
									LayoutParameters = new LayoutParameters()
									{
										Width = AutoSize.FillParent,
										Height = AutoSize.WrapContent,
									},
                                },
                            }
                        }
                    }
            };
            //this.ContentView.Add(new UILayoutHost(Layout, this.ContentView.Bounds));
			this.ContentView.AddSubviews (new UIView[] { equipmentnum, equipdescri, imageview, latitude, longitu, Euiphrs });
        }
        //public float MeasureHeight(UITableView tableView, EquiplistRowData rowData)
        //{
          //  UpdateCell(rowData);
			//Layout.Measure(tableView.Bounds.Width - 10 - 1, float.MaxValue);
			//return Layout.GetMeasuredSize().Height;
        //}

        public void UpdateCell(EquiplistRowData rowData)
        {
            equipmentnum.Text = rowData.EquipmentNumber.ToString();
            equipdescri.Text = rowData.EquipmentDescription.ToString();
			imageview.Image = rowData.Equipmentphoto;
            Euiphrs.Text = "Equip Hrs 0.0";
            longitu.Text = "Longitude 0.0";
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
			imageview.Frame = new RectangleF (40, 10, ContentView.Bounds.Left - 30, 33);
            equipmentnum.Frame = new RectangleF(17, 12, 420, 35);
            equipdescri.Frame = new RectangleF(15, 12, 700, 15);
            Euiphrs.Frame = new RectangleF(20, 24, 150, 15);
            longitu.Frame = new RectangleF(40, 10, ContentView.Bounds.Left - 250, 100);
        }
    }
}