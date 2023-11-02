using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.ShoppingList;
using SoftwareDesignExam.Items.Decorators;

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

        var apple = new Item("001", "Apple", 0.50);
        var orange = new Item("002", "Orange", 0.60);

        // 10 percent discount
        var discountedApple = new DiscountedItem(apple, 10);
        var expiryDecoratedApple = new ExpiryDateItem(discountedApple, DateTime.Now.AddDays(5));

        regularshoppingList.AddItem(expiryDecoratedApple);
        regularshoppingList.AddItem(apple);
        regularshoppingList.AddItem(orange);

        holidayshoppingList.AddItem(apple);
        holidayshoppingList.AddItem(orange);

        Console.WriteLine("Before delte item");
        DisplayItems(regularshoppingList);
        Console.WriteLine($"Total price for Regular Shopping List before delete: ${Math.Round(regularshoppingList.GetTotalPrice(), 2):0.00}\n");

        DeleteItem(regularshoppingList, apple);

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

    private static void DeleteItem(AbstractShoppingList shoppingList, AbstractItem item)
    {
        shoppingList.RemoveItem(item);
        Console.WriteLine($"Item {item.GetName()} removed from the list.\n");
    }
}