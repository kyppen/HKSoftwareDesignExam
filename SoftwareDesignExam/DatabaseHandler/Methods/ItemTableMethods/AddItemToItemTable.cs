using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;

namespace SoftwareDesignExam.DatabaseHandler.Methods {
	public class AddItemToItemTable {
		public static int Add(Item item) {
			using StoreDbContext db = new StoreDbContext();
			db.Item.Add(item);
			db.SaveChanges();
			return item.Id;
		}
	}
}
