using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public class ElementSearch : ISupportElement
    {
        public string ActivityElementDescription { get; set; }
        public string TransformedActivityElementNumber { get; set; }
        public string ActivityNumber { get; set; }

        public string Transformedactnumber
        {
            get { return TransformedActivityElementNumber; }
        }

        public string ActivityDescription
        {
            get { return ActivityElementDescription; }
        }
        public string Activitynum
        {
            get { return ActivityNumber; }
        }
    }
}