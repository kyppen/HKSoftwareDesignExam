using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Items {
	public class StockItem : AbstractItem{
		public long Id { get; set; }
		public long Quantity { get; set; }

		public StockItem(long id, string name, string description, double price, long quantity) : base(id, name, description, price, quantity) {
			this.Quantity = quantity;
			this.Id = id;
		}

		public double CalculatePrice() {
			return this.Quantity*base.price;
		}

		public override string ToString()
		{
			return $"name: {name} price: {price} quantity: {quantity}";
		}
	}
}
