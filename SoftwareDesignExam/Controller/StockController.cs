using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.UIColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Controller {
	public class StockController {

		public static bool CheckStockQuantityOfItems(List<AbstractItem> listOfItems, StoreDbContext dbc) {
            bool temp = false;
			foreach (AbstractItem item in listOfItems) {
				//UIColorController.ColorWriteRed($"CheckQuantityOfItems foreach\n");
				//UIColorController.ColorWriteRed($"CheckQuantityOfItems item id -> {item.id}\n");
				if (item.quantity > ReadQuantityOfItemInStockTable.Read(item.id, dbc)) {
					//UIColorController.ColorWriteRed($"CheckQuantityOfItems if\n");
					temp = false;
				}
                else {
					//UIColorController.ColorWriteRed($"CheckQuantityOfItems else\n");
					temp = true;
                }
			}
			//UIColorController.ColorWriteRed($"CheckQuantityOfItems end\n");
			return temp;
		}

		
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

        public static List<StockItem> GetAll() {
            List<Stock> DbStock = ReadAllItemsFromStockTable.Read();
            //Console.WriteLine("GetAll()");
            //Console.WriteLine(DbStock.Count);
            return GetBody(DbStock);
        }

        public static List<StockItem> GetByMatchingString(string name) {
            //Console.WriteLine("GetByMatchingString()");
            List<Stock> DbStock = ReadSingleItemFromStockTable.Read(name);
            //Console.WriteLine(DbStock.Count);
            return GetBody(DbStock);
        }

        private static List<StockItem> GetBody(List<Stock> stockList) {
            List<StockItem> Items = new();

            foreach (var stock in stockList) {
                Items.Add(ItemFactory.CreateItem(
                    stock.Id,
                    stock.Item_Name,
                    stock.Item_Description,
                    stock.Item_Price,
                    stock.Item_Quantity
                ));
            }
            return Items;
        }
    }
}