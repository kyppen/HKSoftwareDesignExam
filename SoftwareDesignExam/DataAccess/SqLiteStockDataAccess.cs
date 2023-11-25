using Microsoft.EntityFrameworkCore;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DataAccess {
	public class SqLiteStockDataAccess : IStockDataAccess{

		public void Add(Stock StockItem) {
			StoreDbContext DbC = new StoreDbContext();

			DbC.Stock.Add(StockItem);
			DbC.SaveChanges();
		}

		public void Decrement(long itemId, long ammount) {
			StoreDbContext DbC = new StoreDbContext();

			long Quantity = ReadQuantity(itemId);
			long QuantityAfterDecrement = Quantity -= ammount;

			if (DbC.Stock.Find(itemId) != null) {
				if (QuantityAfterDecrement > 0) {
					DbC.Stock.Find(itemId).Item_Quantity -= ammount;
					DbC.SaveChanges();
				}
			}
			else {
				Console.WriteLine($"Item {itemId} is not in stock");
			}
		}

		public void Increment(int itemId, int ammount) {
			StoreDbContext DbC = new StoreDbContext();

			if (DbC.Stock.Find(itemId) != null) {
				DbC.Stock.Find(itemId).Item_Quantity += ammount;
			}
			else {
				Console.WriteLine($"Item {itemId} is not in stock");
			}
		}

		public List<Stock> ReadAll() {
			StoreDbContext DbC = new StoreDbContext();

			return DbC.Stock.ToList();
		}

		public long ReadQuantity(long itemId) {
			StoreDbContext DbC = new StoreDbContext();

			try {
				var item = DbC.Stock.FirstOrDefault(x => x.Id == itemId);
				if (item != null) {
					return item.Item_Quantity;
				}
				return 0;
			}
			catch (Exception ex) {
				Console.WriteLine($"An error occurred: {ex.Message}");
				return 0L;
			}
		}

		public List<Stock> ReadAllByMatching(String name) {
			StoreDbContext DbC = new StoreDbContext();

			return DbC.Stock.Where(x => EF.Functions.Like(x.Item_Name, $"%{name}%")).ToList();
		}

		public Stock ReadById(long id) {
			StoreDbContext DbC = new StoreDbContext();
			var item = DbC.Stock.FirstOrDefault(x => x.Id == id);
			return item;
		}
	}
}
