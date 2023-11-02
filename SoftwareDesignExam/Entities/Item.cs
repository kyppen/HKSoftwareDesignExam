using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Entities {
	internal class Item {
		public int Id { get; set; }

		[Required]
		public string Item_Name { get; set; }

		public string Item_Description { get; set; }

		[Required]
		public int Item_Price { get; set;}
	}
}
