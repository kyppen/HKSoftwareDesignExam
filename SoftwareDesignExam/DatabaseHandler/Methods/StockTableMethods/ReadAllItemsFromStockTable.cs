using Microsoft.EntityFrameworkCore;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods {
	public class ReadAllItemsFromStockTable {
		public static List<Stock> Read() {
			using StoreDbContext db = new StoreDbContext();
			return db.Stock.ToList();
		}
	}
}
