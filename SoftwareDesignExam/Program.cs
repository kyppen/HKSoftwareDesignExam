using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.ShoppingList;

namespace SoftwareDesignExam;
class Program 
{
    static public void Main(String[] args)
    {
        Console.WriteLine("Starting program!");

        var user = new User("123abc", "Alex", "alex@example.com");

        var factory = new ShoppingListFactory();

        var regularshoppingList = factory.CreateList("Regular", "list001", $"{user.Username}-RegularList");

        var holidayshoppingList = factory.CreateList("Holiday", "list002", $"{user.Username}-HolidayList");

        var item1 = new Item("001", "Apple", 0.50);
        var item2 = new Item("002", "Orange", 0.60);

        regularshoppingList.AddItem(item1);
        regularshoppingList.AddItem(item2);

        holidayshoppingList.AddItem(item1);
        holidayshoppingList.AddItem(item2);

        Console.WriteLine("Before delte item");
        DisplayItems(regularshoppingList);
        Console.WriteLine($"Total price for Regular Shopping List before delete: ${Math.Round(regularshoppingList.GetTotalPrice(), 2):0.00}\n");

        DeleteItem(regularshoppingList, item1);

        Console.WriteLine("After delete item");
        // Math.Round method to round the total price to 2 decimal places
        DisplayItems(regularshoppingList);
        Console.WriteLine($"Total price for Regular Shopping List: ${Math.Round(regularshoppingList.GetTotalPrice(), 2):0.00}\n");

        DisplayItems(holidayshoppingList);
        Console.WriteLine($"Total price for Holiday Shopping List: ${Math.Round(holidayshoppingList.GetTotalPrice(), 2):0.00}");
    }

    private static void DisplayItems(AbstractShoppingList shoppingList)
    {
        foreach (var item in shoppingList.GetItems())
        {
            Console.WriteLine(item.ToString());
        }
    }

    private static void DeleteItem(AbstractShoppingList shoppingList, Item item)
    {
        shoppingList.RemoveItem(item);
        Console.WriteLine($"Item {item.Name} removed from the list.\n");
    }
}