using SoftwareDesignExam.DatabaseHandler.Methods;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Items;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoftwareDesignExam.Controller {
	public class ItemController {
		public static void CreateItem(Items.Item item) {
            Entities.Item newItem = new() {
				Item_Name = item.Name,
				Item_Description = item.Description,
				Item_Price = item.Price
			};

			AddItemToItemTable.Add(newItem);
		}
	}
}
