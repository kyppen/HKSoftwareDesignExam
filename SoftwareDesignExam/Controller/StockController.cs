using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Controller {
	public class StockController {
		public static void CreateStockItem(Item item, int quantity) {
			if (CheckIfExists(item)) {
				Stock StockItem = new Stock() {
					Item_Id = item.Id,
					Item_Name = item.Item_Name,
					Item_Quantity = quantity
				};
				AddItemToStockTable.Add(StockItem);
			}
		}

		public static Boolean CheckIfExists(Item item) {
			using StoreDbContext db = new StoreDbContext();
			return (db.Stock.Find(item.Id) == null);
		}
	}
}
