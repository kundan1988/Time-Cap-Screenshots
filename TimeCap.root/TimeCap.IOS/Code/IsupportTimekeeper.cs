using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public interface IsupportTimekeeper
    {
        string Timekeepername { get; }
        string Timekeepernumber { get; }
        UIImage Timekeeperphoto { get; }
    }
}