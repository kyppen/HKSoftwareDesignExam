using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods {
	public class AddUserToUserTable {
		public static long Add(User user) {
			using StoreDbContext db = new StoreDbContext();
			db.User.Add(user);
			db.SaveChanges();
			return user.Id;
		}
	}
}
