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
		public static AbstractItem Jarlsberg = new Item("Jarlsberg", "Block of yellow cheese", 109);
		public static AbstractItem Grandiosa = new Item("Grandiosa", "Frozen Pizza", 59);
		public static AbstractItem AliKaffeBønner = new Item("Ali Kaffe 500g", "500g bag of coffee beans", 89);
		public static void Populate() {
			StockController.CreateStockItem(item: Jarlsberg, quantity: 40);
			StockController.CreateStockItem(item: Grandiosa, quantity: 34);
			StockController.CreateStockItem(item: AliKaffeBønner, quantity: 99);
		}
	}
}
