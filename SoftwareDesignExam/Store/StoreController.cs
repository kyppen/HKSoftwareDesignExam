using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.Menu;


namespace SoftwareDesignExam.Store
{
	public class StoreController {
		public void CheckOut(List<AbstractItem> shoppingList, long userId) {
			SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
			StockController sc = new StockController(sqlda);
			MultiThreadBuy(shoppingList, userId, sc);
		}

		public void MultiThreadBuy(List<AbstractItem> shoppingList, long userId, StockController stockController) {
			Parallel.ForEach(shoppingList, item => {
				if (stockController.CheckStockQuantityOfItems(new List<AbstractItem> { item })) {
					stockController.Decrement(item.id, item.quantity);
				}
			});
		}
	}

}
