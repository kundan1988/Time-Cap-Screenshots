using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TimeCap.iOS
{
    public class TimeCapServices
    {
        #region Declaration
        static string url = "http://mobile.e5sol.com/timecaprestservice/api/";
        private static string laborMaster;
        private static string timekeeper;
        private static string activityList;
        private static string laborList;
        private static string equipList;
        private static string authorizedProject;
        private static string authorizedProjectActivity;
        private static string laborAllocation;
        private static string activityMaster;
        private static string laborSignature;
        private static string laborSignout;
        private static string equipmentMaster;
        private static string laborTimeAllocByAct;
		private static string dailyLog;
        #endregion

        #region Property
		public static string DailyLog
		{
			get { return dailyLog; }
			set { dailyLog = value; }
		}
        public static string LaborMaster
        {
            get { return laborMaster; }
            set { laborMaster = value; }
        }
        public static string Timekeeper
        {
            get { return timekeeper; }
            set { timekeeper = value; }
        }

        public static string ActivityList
        {
            get { return activityList; }
            set { activityList = value; }
        }

        public static string LaborList
        {
            get { return laborList; }
            set { laborList = value; }
        }

        public static string EquipList
        {
            get { return equipList; }
            set { equipList = value; }
        }

        public static string AuthorizedProject
        {
            get { return authorizedProject; }
            set { authorizedProject = value; }
        }

        public static string AuthorizedProjectActivity
        {
            get { return authorizedProjectActivity; }
            set { authorizedProjectActivity = value; }
        }

        public static string LaborAllocation
        {
            get { return laborAllocation; }
            set { laborAllocation = value; }
        }

        public static string ActivityMaster
        {
            get { return activityMaster; }
            set { activityMaster = value; }
        }
        public static string LaborSignature
        {
            get { return laborSignature; }
            set { laborSignature = value; }
        }

        public static string LaborSignout
        {
            get { return laborSignout; }
            set { laborSignout = value; }
        }

        public static string EquipmentMaster
        {
            get { return equipmentMaster; }
            set { equipmentMaster = value; }
        }

        public static string LaborTimeAllocByAct
        {
            get { return laborTimeAllocByAct; }
            set { laborTimeAllocByAct = value; }
        }
        #endregion

        #region Timecapservice_Constructor
        static TimeCapServices()
        {
			url = NSBundle.MainBundle.InfoDictionary [new NSString ("TimeCapRestServiceUrl")].ToString ();
            LaborMaster = url + "LaborMaster";
            Timekeeper = url + "Rolecheck";
            ActivityList = url + "ActivityList";
            LaborList = url + "LaborList";
            EquipList = url + "EquipList";
            AuthorizedProject = url + "AuthorizedProject";
            AuthorizedProjectActivity = url + "AuthorizedProjectActivity";
            LaborAllocation = url + "LaborAllocation";
            ActivityMaster = url + "ActivityMaster";
            LaborSignature = url + "LaborSignature";
            LaborSignout = url + "LaborSignout";
            EquipmentMaster = url + "EquipmentMaster";
            LaborTimeAllocByAct = url + "LaborTimeAllocByAct";
			DailyLog = url + "DailyLog";
        }
        #endregion
    }
}