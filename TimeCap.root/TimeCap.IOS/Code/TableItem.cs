using System;
using MonoTouch.UIKit;

namespace TableEditing.Code {
	/// <summary>
	/// Represents our item in the table
	/// </summary>
	public class TableItem
	{
		public string Heading { get; set; }
		
		public int SubHeading { get; set; }
		
		public UIImage ImageName { get; set; }
		
		public UITableViewCellStyle CellStyle {
			get { return cellStyle; }
			set { cellStyle = value; }
		}
		UITableViewCellStyle cellStyle = UITableViewCellStyle.Default;
		
		public UITableViewCellAccessory CellAccessory {
			get { return cellAccessory; }
			set { cellAccessory = value; }
		}
		UITableViewCellAccessory cellAccessory = UITableViewCellAccessory.None;

        public TableItem() { }
		
		public TableItem (string heading)
		{ this.Heading = heading; }

        //public object imagename { get; set; }

        public object imagename { get; set; }
    }
}