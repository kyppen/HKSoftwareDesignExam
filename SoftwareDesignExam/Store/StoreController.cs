using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.Logging;
using SoftwareDesignExam.Menu;


namespace SoftwareDesignExam.Store
{
	public class StoreController {

		public void CheckOut(List<AbstractItem> shoppingList, long userId) {
			Logger.Instance.LogInformation($"[  Starting checkout for user {userId} with {shoppingList.Count} items.  ]");
			foreach (var item in shoppingList) {
				Logger.Instance.LogDebug($"[  Item in shopping list: {item.id}, Quantity: {item.quantity}  ]");
			}

			SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
			StockController sc = new StockController(sqlda);
			MultiThreadBuy(shoppingList, userId, sc);

			Logger.Instance.LogInformation($"[  Completed checkout for user {userId}.  ]");
		}

		public void MultiThreadBuy(List<AbstractItem> shoppingList, long userId, StockController stockController) {
			Logger.Instance.LogInformation($"[  Starting MultiThreadBuy for user {userId}.  ]");

			Parallel.ForEach(shoppingList, item => {
				if (stockController.CheckStockQuantityOfItems(new List<AbstractItem> { item })) {
					stockController.Decrement(item.id, item.quantity);
				}
			});
			Logger.Instance.LogInformation($"[  Completed MultiThreadBuy for user {userId}.  ]");
		}
	}

}
