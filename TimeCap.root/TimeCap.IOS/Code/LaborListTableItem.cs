using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoTouch.ImageIO;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using XibFree;
using SearchDemo;

namespace TimeCap.iOS.Code
{
    public class LaborListRowData
    {
        public int EmployeeNumber { get; set; }
        public string EmployeeName { get; set; }
        public UIImage Employeephotoview { get; set; }
        public decimal Allocated { get; set; }
        public decimal Worked { get; set; }
        public decimal Remaining { get; set; }
        public UILabel _labelPercent { get; set; }
        public string Projectdescription { get; set; }
        public int Projectno { get; set; }
        public string Transformedactno { get; set; }
    }
    class LaborListTableItem : UITableViewCell
	{
        UILabel employeeNumberLabel, employeeNameLabel,projectdescription, transformednumbr;//, allocatedLabel, workedLabel, remainingLabel, projectnum;
        //UILabel _labelPercent;
        UIImage employeephoto;

        public ViewGroup Layout
        {
            get;
            set;
        }

        public LaborListTableItem(IntPtr handle) : base(handle)
		{
		}

        public LaborListTableItem(string cellId) : base(UITableViewCellStyle.Default, cellId)
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
                                    View = employeeNumberLabel = new UILabel()
                                    {
                                        Text = "Employee Number",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.BoldSystemFontOfSize(12),
                                        HighlightedTextColor = UIColor.White,
                                    },
                                    LayoutParameters = new LayoutParameters()
                                    {
                                        Width = AutoSize.FillParent,
                                        Height = AutoSize.WrapContent,
                                    }
                                },

                                new NativeView()
                                {
                                    View = projectdescription = new UILabel()
                                    {
                                        Text = "Project Description",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.BoldSystemFontOfSize(14),
                                        HighlightedTextColor = UIColor.White,
                                    },
                                    LayoutParameters = new LayoutParameters()
                                    {
                                        Width = AutoSize.WrapContent,
                                        Height = AutoSize.WrapContent,
                                    }
                                },

                                new NativeView()
                                {
                                    View = transformednumbr = new UILabel()
                                    {
                                        //Text = "transformed",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.BoldSystemFontOfSize(14),
                                        HighlightedTextColor = UIColor.White,
                                    },
                                    LayoutParameters = new LayoutParameters()
                                    {
                                        Width = AutoSize.WrapContent,
                                        Height = AutoSize.WrapContent,
                                    }
                                },

                                new NativeView()
                                {
                                    View = employeeNameLabel = new UILabel()
                                    {
                                        Text = "Employee Name",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.SystemFontOfSize(13),
                                        TextColor = UIColor.DarkGray,
                                        HighlightedTextColor = UIColor.White,
                                    },
                                    LayoutParameters = new LayoutParameters()
                                    {
                                        Width = AutoSize.FillParent,
                                        Height = AutoSize.WrapContent,
                                    }
                                },
                            }
                        },
                        new LinearLayout(Orientation.Horizontal)
                        {
                            LayoutParameters = new LayoutParameters()
                            {
                                Width = AutoSize.FillParent,
                                Height = AutoSize.WrapContent,
                            },
                            SubViews = new View[]
                            {
                                //new NativeView()
                                //{
                                //    View = allocatedLabel = new UILabel()
                                //    {
                                //        Text = "Allocated: 10.0",
                                //        BackgroundColor = UIColor.Clear,
                                //        Font = UIFont.BoldSystemFontOfSize(10),
                                //        TextColor = UIColor.Black,
                                //        HighlightedTextColor = UIColor.White,
                                //    },
                                //    LayoutParameters = new LayoutParameters()
                                //    {
                                //        Width = AutoSize.FillParent,
                                //        Height = AutoSize.WrapContent,
                                //    }
                                //},
                                //new NativeView()
                                //{
                                //    View = workedLabel = new UILabel()
                                //    {
                                //        Text = "Worked: 0.0",
                                //        BackgroundColor = UIColor.Clear,
                                //        Font = UIFont.SystemFontOfSize(10),
                                //        TextColor = UIColor.Red,
                                //        HighlightedTextColor = UIColor.White,
                                //    },
                                //    LayoutParameters = new LayoutParameters()
                                //    {
                                //        Width = AutoSize.FillParent,
                                //        Height = AutoSize.WrapContent,
                                //    }
                                //},
                                //new NativeView()
                                //{
                                //    View = remainingLabel = new UILabel()
                                //    {
                                //        Text = "Remaining: 10.0",
                                //        BackgroundColor = UIColor.Clear,
                                //        Font = UIFont.SystemFontOfSize(10),
                                //        TextColor = UIColor.Red,
                                //        HighlightedTextColor = UIColor.White,
                                //        Lines = 0,
                                //    },
                                //    LayoutParameters = new LayoutParameters()
                                //    {
                                //        Width = AutoSize.FillParent,
                                //        Height = AutoSize.WrapContent,
                                //    }
                                //},
                                // new NativeView()
                                //{
                                //    View = projectnum = new UILabel()
                                //    {
                                //        Text = "Project Number",
                                //        BackgroundColor = UIColor.Clear,
                                //        Font = UIFont.BoldSystemFontOfSize(10),
                                //        TextColor = UIColor.Red,
                                //        HighlightedTextColor = UIColor.White,
                                //    },
                                //    LayoutParameters = new LayoutParameters()
                                //    {
                                //        Width = AutoSize.FillParent,
                                //        Height = AutoSize.WrapContent,
                                //    }
                                //}
                            }
                        }
                        //new NativeView()
                        //{
                        //    View = _labelPercent = new UILabel()
                        //    {
                        //        Text = "20%",
                        //        BackgroundColor = UIColor.Clear,
                        //        TextColor = UIColor.FromRGB(51,102,153),
                        //        HighlightedTextColor = UIColor.White,
                        //        Font = UIFont.BoldSystemFontOfSize(24),
                        //        TextAlignment = UITextAlignment.Right,
                        //    },
                        //    LayoutParameters = new LayoutParameters()
                        //    {
                        //        Width = 50,
                        //        Height = AutoSize.FillParent,
                        //        Margins = new UIEdgeInsets(0, 10, 0, 0),
                        //    }
                        //}
                    }
            };
            this.ContentView.Add(new UILayoutHost(Layout, this.ContentView.Bounds));
        }

        public float MeasureHeight(UITableView tableView, LaborListRowData rowData)
        {
            // Initialize the view's so they have the correct content for height calculations
            UpdateCell(rowData);

            // Remeasure the layout using the tableView width, allowing for grouped table view margins
            // and the disclosure indicator
            Layout.Measure(tableView.Bounds.Width - 20 - 18, float.MaxValue);

            // Grab the measured height
            return Layout.GetMeasuredSize().Height;
        }

        public void UpdateCell(LaborListRowData rowData)
        {
            employeeNumberLabel.Text = rowData.EmployeeNumber.ToString();
            employeeNameLabel.Text = rowData.EmployeeName;
            projectdescription.Text = rowData.Projectdescription;
			employeephoto = rowData.Employeephotoview;
        }

        public override void LayoutSubviews ()
        {
            base.LayoutSubviews ();
           // ImageView.Frame = new RectangleF(ContentView.Bounds.Width - 63, 5, 33, 33);
            //headinglabel.frame = new rectanglef(5, 4, contentview.bounds.width - 63, 25);
            //subheadinglabel.frame = new rectanglef(10, 25, 200, 20);
            //activitysubheadinglabel.frame = new rectanglef(10, 45, 200, 20);
        }



        //internal void UpdateCell(int p1, string p2, UIImageView uIImageView)
        //{
        //    //throw new NotImplementedException();
        //    employeeNumberLabel.Text = p1.ToString();
        //    employeeNameLabel.Text = p2;
        //    employeephoto = ImageView.Image;
        //}
    }
}