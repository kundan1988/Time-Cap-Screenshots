using System;
using System.Collections.Generic;
using System.Text;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Drawing;
using XibFree;

namespace TimeCap.iOS.Code
{
    public class AllocEmpRowData
    {
        public int EmployeeNumber { get; set; }
        public decimal Allocated { get; set; }
        public decimal Worked { get; set; }
        public decimal Remaining { get; set; }
        public UILabel _labelPercent { get; set; }
        public string Projectno { get; set; }
    }

    class AllocEmpTableItem : UITableViewCell
    {
        UILabel EmployeePersonnelNumber,ProjectNumber,allocatedLabel, workedLabel, remainingLabel;
        
        public ViewGroup Layout
        {
            get;
            set;
        }

        public AllocEmpTableItem(IntPtr handle)
            : base(handle)
		{
		}

        public AllocEmpTableItem(string cellId)
            : base(UITableViewCellStyle.Default, cellId)
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
                                    View = EmployeePersonnelNumber = new UILabel()
                                    {
                                        Text = "EmployeePersonnelNumber",
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
                                    View = ProjectNumber = new UILabel()
                                    {
                                        Text = "ProjectNumber",
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
                                new NativeView()
                                {
                                    View = allocatedLabel = new UILabel()
                                    {
                                        Text = "Allocated: 10.0",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.BoldSystemFontOfSize(10),
                                        TextColor = UIColor.Black,
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
                                    View = workedLabel = new UILabel()
                                    {
                                        Text = "Worked: 0.0",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.SystemFontOfSize(10),
                                        TextColor = UIColor.Red,
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
                                    View = remainingLabel = new UILabel()
                                    {
                                        Text = "Remaining: 10.0",
                                        BackgroundColor = UIColor.Clear,
                                        Font = UIFont.SystemFontOfSize(10),
                                        TextColor = UIColor.Red,
                                        HighlightedTextColor = UIColor.White,
                                        Lines = 0,
                                    },
                                    LayoutParameters = new LayoutParameters()
                                    {
                                        Width = AutoSize.FillParent,
                                        Height = AutoSize.WrapContent,
                                    }
                                },
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

        public float MeasureHeight(UITableView tableView, AllocEmpRowData rowData)
        {
             UpdateCell(rowData);
             Layout.Measure(tableView.Bounds.Width - 20 - 18, float.MaxValue);

             return Layout.GetMeasuredSize().Height;
        }

        public void UpdateCell(AllocEmpRowData rowData)
        {
            EmployeePersonnelNumber.Text = rowData.EmployeeNumber.ToString();
            ProjectNumber.Text = rowData.Projectno.ToString();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
        }
    }
}
