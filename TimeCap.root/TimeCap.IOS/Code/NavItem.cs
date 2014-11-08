using System;
using MonoTouch.UIKit;

namespace FontList.Code {

	public class NavItem
	{
        private string p1;
        private string p2;
        private decimal? nullable;
        private object AllocatedHrs;

		/// <summary>
		/// The name of the nav item, shows up as the label
		/// </summary>
		public string Name { get; set; }
        public string Description { get; set; }
        public string ActivityDescription { get; set; }
        public string Footer { get; set; }
        public string Middle { get; set; }
        public string Allocated { get; set; }
        public bool Done { get; set; }
		/// <summary>
		/// The UIViewController that the nav item opens. Use this property if you 
		/// wanted to early instantiate the controller when the nav table is built out,
		/// otherwise just set the Type property and it will lazy-instantiate when the 
		/// nav item is clicked on.
		/// </summary>
		public UIViewController Controller { get; set; }

        #region Commented
        /// <summary>
		/// Path to the image to show in the nav item
		/// </summary>
		//public string ImagePath { get; set; }
		
		/// <summary>
		/// The Type of the UIViewController. Set this to the type and leave the Controller 
		/// property empty to lazy-instantiate the ViewController when the nav item is 
		/// clicked.
		/// </summary>
		//public Type ControllerType { get; set; }

		/// <summary>
		/// The font used to display the item.
		/// </summary>
		//public UIFont Font { get; set; }
		
		/// <summary>
		/// a list of the constructor args (if neccesary) for the controller. use this in 
		/// conjunction with ControllerType if lazy-creating controllers.
		/// </summary>
		//public object[] ControllerConstructorArgs
        //{
        //    get { return controllerConstructorArgs; }
        //    set
        //    {
        //        controllerConstructorArgs = value;
				
        //        controllerConstructorTypes = new Type[this.controllerConstructorArgs.Length];
        //        for(int i = 0; i < this.controllerConstructorArgs.Length; i++)
        //        {
        //            controllerConstructorTypes[i] = controllerConstructorArgs[i].GetType();
        //        }
        //    }
        //}
		//protected object[] controllerConstructorArgs = new object[] {};
		
        //public Type[] ControllerConstructorTypes
        //{
        //    get { return this.controllerConstructorTypes; }
        //}
        //protected Type[] controllerConstructorTypes = Type.EmptyTypes;
        #endregion

        public NavItem ()
		{
		}
		
		public NavItem (string name, string descrip) : this()
		{
			Name = name;
            Description = descrip;
		}
		
        public NavItem(string name,string descrip, string Newfooter): this(name,descrip)
        {
            Middle = name;
            Footer = Newfooter;
            ActivityDescription = descrip;
        }

        //public NavItem(string p1, string p2, decimal? nullable)
        //{
        //    // TODO: Complete member initialization
        //    this.p1 = p1;
        //    this.p2 = p2;
        //    this.nullable = nullable;
        //}

        public NavItem(string p1, string p2, object AllocatedHrs)
        {
            // TODO: Complete member initialization
            this.p1 = p1;
            this.p2 = p2;
            this.AllocatedHrs = AllocatedHrs;
        }
	}
}