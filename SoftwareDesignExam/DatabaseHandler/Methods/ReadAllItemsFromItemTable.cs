using SoftwareDesignExam.DataAccess.SqLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods {
	internal class ReadAllItemsFromItemTable {
		public static void Read() {
			using StoreDbContext dbContext = new StoreDbContext();
			var Items = dbContext.Item;

			foreach (var item in Items) {
                Console.WriteLine(item+"\n");
            }
		}
	}
}
