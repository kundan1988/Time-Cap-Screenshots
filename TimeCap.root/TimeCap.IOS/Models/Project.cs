using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public class Project : ISupportTableSource
    {
        public string ProjectNumber { get; set; }
        public string ProjectDescription { get; set; }
        public int ActivityCount { get; set; }
        public string Transformedactnum { get; set; }
        public string TransformedActivityElementNum { get; set; }
        public string ActivityDescrip { get; set; }

		public string ProjectNum
        {
            get { return ProjectNumber; }
        }

		public string ProjectDescrip
        {
            get { return ProjectDescription; }
        }

		public string Transformedactnumber
        {
            get { return TransformedActivityElementNum; }
        }

		public string Transformedactelemnumber
        {
            get { return ActivityDescrip; }
        }

        public string ImageUri
        {
            get { return Activityelementdescr; }
        }
        //public string ImageUri
        //{
        //    get { return null; }
        //}

        public string Activityelementdescr { get; set; }
    }
}