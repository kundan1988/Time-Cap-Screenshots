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
    public class ProjectListRowDta
    {
        public string Projectdescription { get; set; }
        public int Projectno { get; set; }
        public UIImage image { get; set; }
    }

    class ProjectListTableItm: UITableViewCell
    {
        UILabel ProjectDescrip;
        UILabel ProjectNum;
        UILabel imageView;

        public ViewGroup Layout
        {
            get;
            set;
        }

        public ProjectListTableItm(IntPtr handle) : base(handle)
		{
		}

        public ProjectListTableItm(string cellId)
            : base(UITableViewCellStyle.Default, cellId)
        {
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
                                    View = ProjectDescrip = new UILabel()
                                    {
                                        Text = "Project Description",
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
                                    View = ProjectNum = new UILabel()
                                    {
                                        Text = "Project Number",
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

                            }
                        },
                    }
                };
                this.ContentView.Add(new UILayoutHost(Layout, this.ContentView.Bounds));
            }
        }
        public float MeasureHeight(UITableView tableView, ProjectListRowDta rowData)
        {
            // Initialize the view's so they have the correct content for height calculations
           
            UpdateCell(rowData);
            // Remeasure the layout using the tableView width, allowing for grouped table view margins
            // and the disclosure indicator
            Layout.Measure(tableView.Bounds.Width - 20 - 18, float.MaxValue);

            // Grab the measured height
            return Layout.GetMeasuredSize().Height;
        }

        public void UpdateCell(ProjectListRowDta rowData)
        {
            ProjectDescrip.Text = rowData.Projectdescription;
            ProjectNum.Text = rowData.Projectno.ToString();
        }

        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            imageView.Frame = new RectangleF(ContentView.Bounds.Width - 63, 5, 33, 33);
            //headinglabel.frame = new rectanglef(5, 4, contentview.bounds.width - 63, 25);
            //subheadinglabel.frame = new rectanglef(10, 25, 200, 20);
            //activitysubheadinglabel.frame = new rectanglef(10, 45, 200, 20);
        }


        //internal void UpdateCell(ProjectListRowDta projectListRowDta)
        //{
        //    throw new NotImplementedException();
        //}
    }
     //public LaborListTableItem(string cellId) : base(UITableViewCellStyle.Default, cellId)
     //   {
     //   }
}