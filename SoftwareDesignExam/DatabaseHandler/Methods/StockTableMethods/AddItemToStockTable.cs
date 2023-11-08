using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods {
	public class AddItemToStockTable {
		public static void Add(Item item, int quantity) {
			using StoreDbContext db = new StoreDbContext();

			if (db.Stock.Find(item.Id) == null) {
                Stock StockItem = new Stock() { 
					Item_Id = item.Id,
					Item_Name = item.Item_Name,
					Item_Quantity = quantity
				};
				
				db.Stock.Add(StockItem);
				db.SaveChanges();
			}
			else {
                Console.WriteLine($"Item {item.Id} allready in stock");
            }
		}
	}
}
