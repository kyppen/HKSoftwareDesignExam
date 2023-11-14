using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Entities {
	public class Stock {
		public long Id { get; set; }

		public string Item_Description { get; set; }

		public string Item_Name { get; set; } = "";

		public double Item_Price { get; set; }

		public long Item_Quantity { get; set; }
	}
}
