using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods;
using SoftwareDesignExam.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.PopulateDataBase {
	public class PopulateStockTable {
		
		public static void Populate() {
			StockController.CreateStockItem(ItemFactory.CreateItem("Jarlsberg", "Block of yellow cheese", 109), 40);
			StockController.CreateStockItem(ItemFactory.CreateItem("Grandiosa", "Frozen Pizza", 59), 40);
			StockController.CreateStockItem(ItemFactory.CreateItem("Ali Kaffe 500g", "500g bag of coffee beans", 89), 40);
			StockController.CreateStockItem(ItemFactory.CreateItem("Colgate", "Medium tube of toothpase", 23), 132);
			StockController.CreateStockItem(ItemFactory.CreateItem("Head and Shoulders", "neutral unisex shampoo", 54), 666);
			StockController.CreateStockItem(ItemFactory.CreateItem("Mutti", "500g can of crushed tomatoes", 18), 321);
			StockController.CreateStockItem(ItemFactory.CreateItem("Ajax bathroom", "Bathroom cleaning supplies", 45), 76);
		}
	}
}
