using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.UIColor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods {
	public class ReadQuantityOfItemInStockTable {

		public static long Read(long itemId, StoreDbContext dbc) {
			//UIColorController.ColorWriteRed($"ReadQuantityOfItemInStockTable\n");
			try {
				//UIColorController.ColorWriteRed($"ReadQuantityOfItemInStockTable db established\n");
				var item = dbc.Stock.FirstOrDefault(x => x.Id == itemId);
				//UIColorController.ColorWriteRed($"ReadQuantityOfItemInStockTable post query\n");
				if (item != null) {
					//UIColorController.ColorWriteRed($"ReadQuantityOfItemInStockTable ->{item.Item_Quantity}\n");
					return item.Item_Quantity;
				}
				return 0;
			}
			catch (Exception ex) {
				Console.WriteLine($"An error occurred: {ex.Message}");
				return 0L;
			}
		}
	}
}


