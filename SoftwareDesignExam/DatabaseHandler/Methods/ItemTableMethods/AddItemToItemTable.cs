using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;

namespace SoftwareDesignExam.DatabaseHandler.Methods {
	public class AddItemToItemTable {
		public static int Add(string name, string description, int price) {
			Item item = new Item() {
				Item_Name = name,
				Item_Description = description,
				Item_Price = price
			};

			using StoreDbContext db = new StoreDbContext();
			db.Item.Add(item);
			db.SaveChanges();
			return item.Id;
		}
	}
}
