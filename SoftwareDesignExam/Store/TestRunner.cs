using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DatabaseHandler.PopulateDataBase;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.UIColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Store {
	public class TestRunner {

		public static void Run() {
			PopulateStockTable.Populate();

			List<AbstractItem> shoppingList = new List<AbstractItem>() {
				new StockItem(1, "Jarlsberg", "Block of yellow cheese", 109, 5),
				new StockItem(2, "Grandiosa", "Frozen Pizza", 59, 10),
				new StockItem(3, "Ali Kaffe 500g", "500g bag of coffee beans", 89, 25)
			};

			foreach (var item in StockController.GetAll()) {
				UIColorController.ColorWriteYellow("Id          : ");
				Console.Write($"{item.id}\n");
				UIColorController.ColorWriteYellow("Name        : ");
				Console.Write($"{item.name}\n");
				UIColorController.ColorWriteYellow("Quantity    : ");
				Console.Write($"{item.quantity}\n\n");
			}

			StoreController.CheckOut(shoppingList, 1);

			foreach (var item in StockController.GetAll()) {
				UIColorController.ColorWriteGreen("Id          : ");
				Console.Write($"{item.id}\n");
				UIColorController.ColorWriteGreen("Name        : ");
				Console.Write($"{item.name}\n");
				UIColorController.ColorWriteGreen("Quantity    : ");
				Console.Write($"{item.quantity}\n\n");
			}
		}
	}
}
