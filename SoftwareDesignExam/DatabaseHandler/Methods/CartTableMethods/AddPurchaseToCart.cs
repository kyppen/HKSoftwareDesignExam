using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;

namespace SoftwareDesignExam.DatabaseHandler.Methods.CartTableMethods;

public class AddPurchaseToCart
{
    public static void Add(Cart cart)
    {
        using StoreDbContext db = new StoreDbContext();
        db.Cart.Add(cart);
    }
    
}