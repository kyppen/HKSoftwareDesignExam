using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.DatabaseHandler.Methods.CartTableMethods;
using SoftwareDesignExam.Entities;

namespace SoftwareDesignExam.Controller;

public class CartController
{
        public static void CreateCart(long id, long cartId, long userId, long itemId, long itemQuantity, double itemPrice, DateTime purchaseDate ) {
            Cart cart = new() {
                Id = id,
                Cart_Id = cartId, 
                User_Id = userId,
                Item_Id = itemId,
                Item_Quantity = itemQuantity,
                Item_Price = itemPrice,
                PurchaceDate = purchaseDate
            };
            AddCartToCartTable.Add(cart);
        }

        
}