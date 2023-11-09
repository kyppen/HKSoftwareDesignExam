using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DatabaseHandler.Methods.ItemTableMethods;
using SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.PopulateDataBase {
	public class PopulateStockTable {
		public static void Populate() {
            foreach (var item in ReadSingleItemFromItemTable.Read("Jarlsberg")) {
                StockController.CreateStockItem(item, 34);
			}
			foreach (var item in ReadSingleItemFromItemTable.Read("Toro Tomatsuppe")) {
				StockController.CreateStockItem(item, 444);
			}
			foreach (var item in ReadSingleItemFromItemTable.Read("Grandiosa")) {
				StockController.CreateStockItem(item, 999);
			}
		}

	}
}
