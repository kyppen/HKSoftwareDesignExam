using SoftwareDesignExam.DataAccess.SqLite;

namespace SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods {
	public class RemoveUserFromUserTable {

		public static void Remove(long id) {
			using StoreDbContext db = new StoreDbContext();
			var user = db.User.Find(id);
			if (user != null) {
				db.User.Remove(user);
			}
			db.SaveChanges();
		}
	}
}
