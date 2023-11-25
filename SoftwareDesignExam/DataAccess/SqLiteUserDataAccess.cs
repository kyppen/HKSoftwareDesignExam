using SoftwareDesignExam.DataAccess.SqLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DataAccess {
	public class SqLiteUserDataAccess : IUserDataAccess{
		public long Add(Entities.User user) {
			using StoreDbContext dbContext = new StoreDbContext();
			dbContext.User.Add(user);
			dbContext.SaveChanges();
			return user.Id;
		}
		public Boolean Check(string email) {
			using StoreDbContext dbContext = new StoreDbContext();
			var user = dbContext.User.Where(x => x.User_Email.ToLower() == email.ToLower()).ToList();
			if (user.Count == 0) {
				Console.WriteLine("True");
				return true;
			}
			Console.WriteLine("False");
			return false;
		}

		public List<Entities.User> Read(string email, string password) {
			using StoreDbContext dbContext = new StoreDbContext();
			var user = dbContext.User.Where(x => x.User_Email.ToLower() == email.ToLower() && x.User_Password == password).ToList();
			return user;
		}

		public void Remove(long id) {
			using StoreDbContext dbContext = new StoreDbContext();
			var user = dbContext.User.Find(id);
			if (user != null) {
				dbContext.User.Remove(user);
			}
			dbContext.SaveChanges();
		}
	}
}
