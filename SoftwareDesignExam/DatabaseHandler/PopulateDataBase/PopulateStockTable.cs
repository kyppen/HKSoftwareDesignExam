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
                AddItemToStockTable.Add(item, 34);
			}
			foreach (var item in ReadSingleItemFromItemTable.Read("Toro Tomatsuppe")) {
				AddItemToStockTable.Add(item, 444);
			}
			foreach (var item in ReadSingleItemFromItemTable.Read("Grandiosa")) {
				AddItemToStockTable.Add(item, 999);
			}
		}

	}
}
