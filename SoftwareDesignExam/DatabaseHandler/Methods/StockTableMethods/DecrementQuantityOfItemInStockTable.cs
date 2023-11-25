using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods {
	public class DecrementQuantityOfItemInStockTable {
		public static void Decrement(long itemId, long ammount, StoreDbContext dbc) {
			//UIColorController.ColorWriteRed($"DecrementQuantityOfItemInStockTable item id ->{itemId}\n");
			using StoreDbContext db = new StoreDbContext();
			long Quantity = ReadQuantityOfItemInStockTable.Read(itemId, dbc);
			//UIColorController.ColorWriteRed($"DecrementQuantityOfItemInStockTable ->{Quantity}\n");
			long QuantityAfterDecrement = Quantity -= ammount;
			//UIColorController.ColorWriteRed($"DecrementQuantityOfItemInStockTable ->{QuantityAfterDecrement}\n");
			if (db.Stock.Find(itemId) != null) {
			//	UIColorController.ColorWriteRed($"DecrementQuantityOfItemInStockTable if item in stock\n");
				if (QuantityAfterDecrement > 0) {
			//		UIColorController.ColorWriteRed($"DecrementQuantityOfItemInStockTable quantity > 0\n");
					db.Stock.Find(itemId).Item_Quantity -= ammount;
					db.SaveChanges();
			//		UIColorController.ColorWriteRed($"DecrementQuantityOfItemInStockTable quantity after decrement >{db.Stock.Find(itemId).Item_Quantity}\n");
				}
			}
			else {
				Console.WriteLine($"Item {itemId} is not in stock");
			}
		}
	}
}
