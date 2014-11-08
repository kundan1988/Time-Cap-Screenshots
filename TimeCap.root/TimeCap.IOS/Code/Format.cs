using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS.Code
{
    /// <summary>
    /// The format.
    /// </summary>
    public enum Format
    {
        /// <summary>
        /// XML format
        /// </summary>
        Xml,

        /// <summary>
        /// JSON format
        /// </summary>
        Json,

        /// <summary>
        /// Protocol Buffer format
        /// </summary>
        ProtoBuf,

        /// <summary>
        /// Comma-separated format
        /// </summary>
        Csv,

        CustomBinary
    }
}