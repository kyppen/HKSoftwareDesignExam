using Microsoft.EntityFrameworkCore;
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
			return dbContext.Stock.Where(x => EF.Functions.Like(x.Item_Name, $"%{name}%")).ToList();
		}

		public static long ReadById(long id) {
			using StoreDbContext dbContext = new StoreDbContext();
			var item = dbContext.Stock.FirstOrDefault(x => x.Id == id);
			return item.Item_Quantity;
		}
	}
}
