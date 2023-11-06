using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods {
	public class ReadSingleItemFromStockTable {
		public static List<Stock> Read(String name) {
			using StoreDbContext dbContext = new StoreDbContext();
			return dbContext.Stock.Where(x => x.Item_Name.ToLower() == name.ToLower()).ToList();
		}
	}
}
