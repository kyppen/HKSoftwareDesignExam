using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Items {
	public class ItemFactory {
		public AbstractItem CreateItem(long id, string type, string name, string description, double price, long quantity) {
			switch (type) {
				case "regular":
					return new Item(name, description, price);
				case "stock":
					return new StockItem(id, name, description, price, quantity);
				default:
					return null;

			}
		}
	}
}
