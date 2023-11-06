using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Entities {
	public class Stock {
		public int Id { get; set; }

		public int Item_Id { get; set; } 

		public String Item_Name { get; set; } = "";

		public int? Item_Quantity { get; set; }
	}
}
