using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DataAccess {
	public class SqLiteCartDataAccess : ICartDataAccess{
		public List<Cart> Read(int userId) {
			using StoreDbContext db = new StoreDbContext();

			return db.Cart.Where(c => c.User_Id == userId).ToList();
		}

		public void Add(Cart cart) {
			using StoreDbContext db = new StoreDbContext();
			db.Cart.Add(cart);
			db.SaveChanges();
		}
	}
}
