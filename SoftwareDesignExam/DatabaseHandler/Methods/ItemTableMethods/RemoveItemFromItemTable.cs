using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;

namespace SoftwareDesignExam.DatabaseHandler.Methods {
	public class RemoveItemFromItemTable {
		public static void Remove(List<Item> items) {
			using StoreDbContext dbContext = new StoreDbContext();
			dbContext.RemoveRange(items);
			dbContext.SaveChanges();
		}
	}
}
