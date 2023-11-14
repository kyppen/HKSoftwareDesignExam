using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods {
	public class ReadSingleItemFromStockTable {
		public static List<Stock> Read(String name) {
			using StoreDbContext dbContext = new StoreDbContext();
			return dbContext.Stock.Where(x => EF.Functions.Like(x.Item_Name, $"%{name}%")).ToList();
		}
	}
}
