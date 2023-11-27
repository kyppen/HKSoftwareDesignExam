using SoftwareDesignExam.Controller;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.PopulateDataBase {
    public class PopulateStockTable {
		public void Populate(StockController stockController) {
			Logger.Instance.LogInformation("[  Starting populating Stock table with 7 items  ]");
			stockController.CreateStockItem(ItemFactory.CreateItem("Jarlsberg", "Block of yellow cheese", 109), 140);
			stockController.CreateStockItem(ItemFactory.CreateItem("Grandiosa", "Frozen Pizza", 59), 324);
			stockController.CreateStockItem(ItemFactory.CreateItem("Ali Kaffe 500g", "500g bag of coffee beans", 89), 435);
			stockController.CreateStockItem(ItemFactory.CreateItem("Colgate", "Medium tube of toothpase", 23), 132);
			stockController.CreateStockItem(ItemFactory.CreateItem("Head and Shoulders", "neutral unisex shampoo", 54), 666);
			stockController.CreateStockItem(ItemFactory.CreateItem("Mutti", "500g can of crushed tomatoes", 18), 321);
			stockController.CreateStockItem(ItemFactory.CreateItem("Ajax bathroom", "Bathroom cleaning supplies", 45), 76);
			Logger.Instance.LogInformation("[  Finished populating Stock table  ]");
		}
	}
}
