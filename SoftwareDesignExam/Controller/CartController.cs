using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Controller {
	
	public class CartController {
		ICartDataAccess _cartDataAccess;
		public CartController(ICartDataAccess cartDataAccess) {
			_cartDataAccess = cartDataAccess;
		}

		public void CreateCart(long id, long cartId, long userId, long itemId, long itemQuantity, double itemPrice, DateTime purchaseDate) {
			Cart cart = new() {
				Id = id,
				Cart_Id = cartId,
				User_Id = userId,
				Item_Id = itemId,
				Item_Quantity = itemQuantity,
				Item_Price = itemPrice,
				PurchaceDate = purchaseDate
			};
			_cartDataAccess.Add(cart);
		}

		public List<Cart> ReadCart(int userId) {
			return _cartDataAccess.Read(userId);
		}

	}
}
