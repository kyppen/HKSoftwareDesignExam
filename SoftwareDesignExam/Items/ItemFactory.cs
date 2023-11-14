using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Items {
	public class ItemFactory {
		public static AbstractItem CreateItem(long id, string name, string description, double price, long quantity) {
			return new StockItem(id, name, description, price, quantity);
		}

		public static AbstractItem CreateItem(string name, string description, double price) {
			return new Item(name, description, price);
		}
	}
}
