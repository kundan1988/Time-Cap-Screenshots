using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public interface ISupportElement
    {
        string Transformedactnumber { get; }
        string ActivityDescription { get; }
        string Activitynum { get; }
    }
}