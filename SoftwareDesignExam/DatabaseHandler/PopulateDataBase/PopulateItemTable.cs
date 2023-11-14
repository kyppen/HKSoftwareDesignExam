using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.DatabaseHandler.Methods;
using SoftwareDesignExam.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.PopulateDataBase {
	public class PopulateItemTable {

		public static void Populate() {

			ItemController.CreateItem(new Item("", "Jarlsberg", "Yellow Cheese", 99));
			ItemController.CreateItem(new Item("", "Toro Tomatsuppe", "Toro Tomatosoup in bag", 23));
			ItemController.CreateItem(new Item("", "Grandiosa", "Frozen classic Pizza Grandiosa", 45));			
		}
	}
}
