using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.ShoppingList;

namespace SoftwareDesignExam;
class Program{
    static public void Main(String[] args)
    {
        Console.WriteLine("Starting program!");

        var user = new User("123abc", "JohnDoe", "johndoe@example.com");
        var shoppingList = user.CreateList();

        var item1 = new Item("001", "Apple", 0.50);
        var item2 = new Item("002", "Orange", 0.60);

        shoppingList.AddItem(item1);
        shoppingList.AddItem(item2);

        Console.WriteLine("Shopping List:");
        foreach (var item in shoppingList.GetItems())
        {
            Console.WriteLine(item.ToString());
        }
    }
    //Item item = new("0", "bread", 6.1);
    //Console.WriteLine(item.ToString());
}