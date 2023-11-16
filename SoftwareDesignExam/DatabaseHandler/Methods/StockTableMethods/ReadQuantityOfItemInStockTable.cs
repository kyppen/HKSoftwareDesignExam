using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods {
	public class ReadQuantityOfItemInStockTable {
		public static long Read(long itemId) {
			using StoreDbContext db = new StoreDbContext();
			Stock item = (Stock)db.Stock.Where(x => x.Id == itemId);
			return item.Item_Quantity;
		}
	}
}
