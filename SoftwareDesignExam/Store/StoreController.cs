using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.Menu;
using SoftwareDesignExam.UIColor;


namespace SoftwareDesignExam.Store
{
	public class StoreController {
		public static void CheckOut(List<AbstractItem> shoppingList, long userId) {
			MultiThreadBuy(shoppingList, userId);
		}

		private static void MultiThreadBuy(List<AbstractItem> shoppingList, long userId) {
			Parallel.ForEach(shoppingList, item => {
				using var context = new StoreDbContext();
				if (StockController.CheckStockQuantityOfItems(new List<AbstractItem> { item }, context)) {
					DecrementQuantityOfItemInStockTable.Decrement(item.id, item.quantity, context);

				}
			});
		}
	}

}
