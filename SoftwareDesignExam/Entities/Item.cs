using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoftwareDesignExam.Entities {
	public class Item {
		public int Id { get; set; }

		[Required]
		public string Item_Name { get; set; } = string.Empty;

		public string Item_Description { get; set; } = string.Empty;

		[Required]
		public double Item_Price { get; set;}

		public override string ToString() {
			return $"Id: {Id}\nName: {Item_Name}\nDescription: {Item_Description}\nPrice: {Item_Price}";
		}
	}
}
