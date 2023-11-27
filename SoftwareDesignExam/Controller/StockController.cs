using Microsoft.Extensions.Logging;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Controller {
	public class StockController {
        private readonly IStockDataAccess Sda;
        public StockController(IStockDataAccess stockDataAccess) {
            Sda = stockDataAccess;
        }

		public void Decrement(long itemId, long ammount) {
            Sda.Decrement(itemId, ammount);
        }

		public bool CheckStockQuantityOfItems(List<AbstractItem> listOfItems) {
            bool temp = false;
			foreach (AbstractItem item in listOfItems) {
			
				if (item.quantity > Sda.ReadQuantity(item.id)) {
					temp = false;
				}
                else {
					temp = true;
                }
			}
			return temp;
		}
		
        public void CreateStockItem(AbstractItem item, int quantity) {
            Stock StockItem = new Stock() {
                Item_Name = item.name,
                Item_Quantity = quantity,
                Item_Description = item.description,
                Item_Price = item.price
            };
            Sda.Add(StockItem);
        }

        public List<StockItem> GetAll() {
            List<Stock> DbStock = Sda.ReadAll();
            return GetBody(DbStock);
        }

        public List<StockItem> GetByMatchingString(string name) {
            List<Stock> DbStock = Sda.ReadAllByMatching(name);
            return GetBody(DbStock);
        }

        public AbstractItem ReadById(long id) {
            Stock stock = Sda.ReadById(id);
            return ItemFactory.CreateItem(
					stock.Id,
					stock.Item_Name,
					stock.Item_Description,
					stock.Item_Price,
					stock.Item_Quantity
				);
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