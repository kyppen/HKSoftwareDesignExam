using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.DatabaseHandler.PopulateDataBase;
using SoftwareDesignExam.Items;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.UIColorController;
using Microsoft.Extensions.Logging;

namespace SoftwareDesignExam.Store {
	public class TestRunner {
		public void PopulateStock(StoreController storeController)
		{
			SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
			StockController sc = new StockController(sqlda);
			PopulateStockTable populateStockTable = new PopulateStockTable();
			populateStockTable.Populate(sc);
		}
		public void Run(StoreController storeController) {
			SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
			StockController sc = new StockController(sqlda);
			PopulateStockTable populateStockTable = new PopulateStockTable();
			populateStockTable.Populate(sc);

			List<AbstractItem> shoppingList = new List<AbstractItem>() {
				new StockItem(1, "Jarlsberg", "Block of yellow cheese", 109, 5),
				new StockItem(2, "Grandiosa", "Frozen Pizza", 59, 10),
				new StockItem(3, "Ali Kaffe 500g", "500g bag of coffee beans", 89, 25)
			};

			foreach (var item in sc.GetAll()) {
				UIColor.ColorWriteYellow("Id          : ");
				Console.Write($"{item.id}\n");
				UIColor.ColorWriteYellow("Name        : ");
				Console.Write($"{item.name}\n");
				UIColor.ColorWriteYellow("Quantity    : ");
				Console.Write($"{item.quantity}\n\n");
			}

			storeController.CheckOut(shoppingList, 1);

			foreach (var item in sc.GetAll()) {
				UIColor.ColorWriteGreen("Id          : ");
				Console.Write($"{item.id}\n");
				UIColor.ColorWriteGreen("Name        : ");
				Console.Write($"{item.name}\n");
				UIColor.ColorWriteGreen("Quantity    : ");
				Console.Write($"{item.quantity}\n\n");
			}
		}
	}
}
