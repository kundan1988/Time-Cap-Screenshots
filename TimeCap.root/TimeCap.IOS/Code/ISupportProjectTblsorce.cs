using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Code
{
    public interface ISupportProjectTblsorce
    {
        string text { get; }
        string DetailText { get; }
        string SubDetailsText { get; }
    }
}