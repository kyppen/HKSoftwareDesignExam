using SoftwareDesignExam.DataAccess.SqLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods {
	public class DecrementQuantityOfItemInStockTable {
		public static void Decrement(long itemId, long ammount) {
			using StoreDbContext db = new StoreDbContext();
			var QuantityAfterDecrement = db.Stock.Find(itemId).Item_Quantity -= ammount;
			if (db.Stock.Find(itemId) != null) {
				if (QuantityAfterDecrement > 0) {
					db.Stock.Find(itemId).Item_Quantity -= ammount;
				}
			}
			else {
				Console.WriteLine($"Item {itemId} is not in stock");
			}
		}
	}
}
