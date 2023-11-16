using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.Menu;

namespace SoftwareDesignExam.Store
{
    public class StoreController
    {
		private static readonly object CheckOutLock = new ();

		public static async void CheckOut(List<AbstractItem> shoppingList, long userId) {
			var tasks = new Task[1];

			for (int i = 0; i < tasks.Length; i++) {
				tasks[i] = Task.Run(() => MultiThreadBuy(shoppingList, userId));
			}
			await Task.WhenAll(tasks);
			
		}

		public static void MultiThreadBuy(List<AbstractItem> shoppingList, long userId) {
			lock (CheckOutLock) {
				if (StockController.CheckStockQuantityOfItems(shoppingList)) {
					foreach (AbstractItem item in shoppingList) {
						DecrementQuantityOfItemInStockTable.Decrement(item.quantity, item.id);

					}

				}
			}
		}
	}
}
