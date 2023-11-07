using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;

namespace SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods {
	public class ReadUserFromUserTable {

		public static List<User> Read(string email, string password) {
			using StoreDbContext dbContext = new StoreDbContext();
			var user = dbContext.User.Where(x => x.User_Email.ToLower() == email.ToLower() && x.User_Password == password).ToList();
			return user;
		}
	}
}
