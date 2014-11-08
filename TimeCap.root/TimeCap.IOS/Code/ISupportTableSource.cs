using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public interface ISupportTableSource
    {
        string ProjectNum { get; }
        string ProjectDescrip { get; }
        string Transformedactnumber { get; }
        string Transformedactelemnumber { get; }
        string ImageUri { get; }
    }
}