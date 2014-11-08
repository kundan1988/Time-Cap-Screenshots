using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public interface IsupportActivity
    {
        string Text { get; }
        string Details { get; }
        string Subdetail { get; }
        //UIImage imageurl { get; }
    }
}