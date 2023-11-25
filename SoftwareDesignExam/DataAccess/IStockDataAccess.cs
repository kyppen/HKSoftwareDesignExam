using Microsoft.EntityFrameworkCore;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DataAccess {
	public interface IStockDataAccess {

		void Add(Stock StockItem);

		void Decrement(long itemId, long ammount);

		void Increment(int itemId, int ammount);

		List<Stock> ReadAll();

		long ReadQuantity(long itemId);

		List<Stock> ReadAllByMatching(string name);

		Stock ReadById(long id);
	}
}
