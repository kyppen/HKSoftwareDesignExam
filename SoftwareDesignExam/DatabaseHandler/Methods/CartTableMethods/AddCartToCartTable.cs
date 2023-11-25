using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.DataAccess.SqLite;

namespace SoftwareDesignExam.DatabaseHandler.Methods.CartTableMethods {
	internal class AddCartToCartTable
	{
		public static void Add(Cart cart)
		{
			using StoreDbContext db = new StoreDbContext();
			db.Cart.Add(cart);
			db.SaveChanges();
		}
	}
}
