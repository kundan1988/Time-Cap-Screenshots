using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public class Projecctsearch : Isupportsearch
    {
        public string ProjectNumber { get; set; }
        public string ProjectDescription { get; set; }
        public string Transformedactnum { get; set; }
        public string ActivityElementDescription { get; set; }

        public string text
        {
            get { return ProjectNumber; }
        }
        public string DetailText
        {
            get { return ProjectDescription; }
        }
        public string SubDetailsText
        {
            get { return Transformedactnum; }
        }
        public string AllSubdetailText
        {
            get { return ActivityElementDescription; }
        }
    }
}