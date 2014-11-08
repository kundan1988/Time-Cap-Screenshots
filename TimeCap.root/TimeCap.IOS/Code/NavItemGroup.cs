using System;
using System.Collections.Generic;

namespace FontList.Code {
	/// <summary>
	/// A group that contains table items
    /// Created by Kundan Sakpal 
    /// dated 22nd Oct 2014
	/// </summary>
	public class NavItemGroup
	{
		public string Name { get; set; }
        public string Description { get; set; }
        public string ActivityDescription { get; set; }
        public string AllocatedHours { get; set; }
		public string Footer { get; set; }

		public List<NavItem> Items { get; set; }

		public NavItemGroup ()
		{
			Items = new List<NavItem> ();
		}

		public NavItemGroup (string name, string descrip)
		{
			Name = name;
            Description = descrip;
			Items = new List<NavItem> ();
		}

        public bool Done { get; set; }
    }
}