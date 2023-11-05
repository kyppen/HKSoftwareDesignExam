using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods {
	public class AddUserToUserTable {
		public static int Add(string fName, string lName, string email, string password) {
			User user = new User() {
				User_FName = fName,
				User_LName = lName,
				User_Email = email,
				User_Password = password
			};

			using StoreDbContext db = new StoreDbContext();
			db.User.Add(user);
			db.SaveChanges();
			return user.Id;
		}
	}
}
