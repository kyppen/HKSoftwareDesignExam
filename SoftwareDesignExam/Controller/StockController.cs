using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Controller {
	public class StockController {
		
		public static void CreateStockItem(AbstractItem item, int quantity) {
			Stock StockItem = new Stock() {
				Item_Name = item.name,
				Item_Quantity = quantity,
				Item_Description = item.description,
				Item_Price = item.price
			};
			AddItemToStockTable.Add(StockItem);
		}
		/*
		public static Boolean CheckIfExists(Item item) {
			using StoreDbContext db = new StoreDbContext();
			return (db.Stock.Find(item.Id) == null);
		}
		*/

		public static List<AbstractItem> GetAll() {
			List<AbstractItem> Items = new ();
			List<Stock> DbStock = ReadAllItemsFromStockTable.Read();

            foreach (var stock in DbStock)
            {
				AbstractItem StockItem = new StockItem(
					stock.Id, 
					stock.Item_Name, 
					stock.Item_Description, 
					stock.Item_Price, 
					stock.Item_Quantity
					);

				Items.Add( StockItem );
            }
			return Items;
        }

		public static List<AbstractItem> GetByMatchingString(string name) {
			List<AbstractItem> Items = new();
			List<Stock> DbStock = ReadSingleItemFromStockTable.Read(name);

			foreach (var stock in DbStock) {
				AbstractItem StockItem = new StockItem(
					stock.Id,
					stock.Item_Name,
					stock.Item_Description,
					stock.Item_Price,
					stock.Item_Quantity
					);

				Items.Add(StockItem);
			}
			return Items;
		}
	}
}
