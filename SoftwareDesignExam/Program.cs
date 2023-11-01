using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.ShoppingList;

namespace SoftwareDesignExam;
class Program 
{
    static public void Main(String[] args)
    {
        Console.WriteLine("Starting program!");

        var user = new User("123abc", "JohnDoe", "johndoe@example.com");
        //var shoppingList = user.CreateList();

        var factory = new ShoppingListFactory();
        var shoppingList = factory.CreateList("Regular", "list001", $"{user.Username}-List");

        var item1 = new Item("001", "Apple", 0.50);
        var item2 = new Item("002", "Orange", 0.60);

        //shoppingList = new RegularShoppingList("1","2");
        shoppingList.AddItem(item1);
        shoppingList.AddItem(item2);

        Console.WriteLine("Items before remove:");
        DisplayItems(shoppingList);

        // Remove item
        shoppingList.RemoveItem(item1);

        Console.WriteLine("\nItems after remove of Apple:");
        DisplayItems(shoppingList);

    }

    private static void DisplayItems(AbstractShoppingList shoppingList)
    {
        foreach (var item in shoppingList.GetItems())
        {
            Console.WriteLine(item.ToString());
        }
    }
}