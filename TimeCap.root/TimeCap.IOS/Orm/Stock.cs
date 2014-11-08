using System;
using SQLite;

namespace DataAccess 
{

    public class Stock 
    {
		[PrimaryKey, AutoIncrement, Column("_id")]
		public int Id { get; set; }
		
		[MaxLength(8)]
		public string EmployeePersonnelNum { get; set; }

		public string AllocatedHours { get; set; }
	}
}

