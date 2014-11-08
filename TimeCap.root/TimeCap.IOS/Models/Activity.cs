using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public class Activity : IsupportActivity
    {
        public string ProjectNumber { get; set; }
        public string TransformedActivityElementNum { get; set; }
        public string ActivityDescrip { get; set; }
        public UIImage Employeephoto { get; set; }

        public string Text
        {
            get { return ProjectNumber; }
        }
        public string  Details
        {
            get { return TransformedActivityElementNum; }
        }
        public string Subdetail     
        {
            get { return ActivityDescrip; }
        }
        public UIImage imageurl
        {
            get { return Employeephoto; }
        }
    }
}