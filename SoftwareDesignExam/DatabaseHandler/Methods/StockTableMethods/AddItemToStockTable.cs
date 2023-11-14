using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods {
	public class AddItemToStockTable {
		public static void Add(Stock StockItem) {
			using StoreDbContext db = new StoreDbContext();
			db.Stock.Add(StockItem);
			db.SaveChanges();
		}
	}
}
