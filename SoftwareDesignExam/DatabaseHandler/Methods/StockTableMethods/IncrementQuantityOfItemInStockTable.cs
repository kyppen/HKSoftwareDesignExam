using SoftwareDesignExam.DataAccess.SqLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods {
	public class IncrementQuantityOfItemInStockTable {
		public static void Increment(int itemId, int ammount) {
			using StoreDbContext db = new StoreDbContext();
			if (db.Stock.Find(itemId) != null) {
				db.Stock.Find(itemId).Item_Quantity += ammount;
			}
			else {
                Console.WriteLine($"Item {itemId} is not in stock");
            }
		}
	}
}
