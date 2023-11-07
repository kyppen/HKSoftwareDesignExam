using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.DatabaseHandler.Methods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.PopulateDataBase {
	public class PopulateItemTable {

		public static void Populate() {
			AddItemToItemTable.Add("Jarlsberg", "Yellow Cheese", 99);
			AddItemToItemTable.Add("Toro Tomatsuppe", "Toro Tomatosoup in bag", 23);
			AddItemToItemTable.Add("Grandiosa", "Frozen classic Pizza Grandiosa", 45);
		}
	}
}
