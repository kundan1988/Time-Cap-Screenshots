using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Runtime.Serialization;

namespace TimeCap.iOS.Models
{
    [DataContract]
    public class AbsenceListDTO
    {
        [DataMember]
        public string AbsenceCode { get; set; }

        [DataMember]
        public string AbsenceDescription { get; set; }

        [DataMember]
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}