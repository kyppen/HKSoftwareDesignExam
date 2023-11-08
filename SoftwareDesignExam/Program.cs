using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.ShoppingList;
using SoftwareDesignExam.DatabaseHandler.Methods;
using SoftwareDesignExam.DatabaseHandler.Methods.ItemTableMethods;
using SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;
using SoftwareDesignExam.Menu;
using SoftwareDesignExam.Items.Decorators;

namespace SoftwareDesignExam;
class Program
{
    static public void Main(String[] args)
    {

        AddItemToItemTable.Add("cheese", "yellow", 3);
        AddItemToItemTable.Add("cheese", "yellow", 3);
        AddItemToItemTable.Add("cheese", "yellow", 3);
        AddItemToItemTable.Add("cheese", "yellow", 3);
        /*
        AddUserToUserTable.Add("King", "Harkinian", "harkinian@hyrule.official.co.uk.ru", "123Shipsflakes%");
        foreach (var user in ReadUserFromUserTable.Read("harkinian@hyrule.official.co.uk.ru", "123Shipsflakes%"))
        {
            Console.WriteLine(user);
            
        }
        Console.ReadLine();
        */
        MainMenu.startMenu();


        /*Console.WriteLine("Starting program!");

        AddUserToUserTable.Add("King", "Harkinian", "harkinian@hyrule.official.co.uk.ru", "123Shipsflakes%");


        var factory = new ShoppingListFactory();

        //var regularshoppingList = factory.CreateList("Regular", "list001", $"{user.Username}-RegularList");

        //var holidayshoppingList = factory.CreateList("Holiday", "list002", $"{user.Username}-HolidayList");

        var apple = new Item("001", "Apple", 0.50);
        var orange = new Item("002", "Orange", 0.60);

        // 10 percent discount
        var discountedApple = new DiscountedItem(apple, 10);
        var expiryDecoratedApple = new ExpiryDateItem(discountedApple, DateTime.Now.AddDays(5));

        //regularshoppingList.AddItem(expiryDecoratedApple);
        //regularshoppingList.AddItem(apple);
        //regularshoppingList.AddItem(orange);

        //holidayshoppingList.AddItem(apple);
        //holidayshoppingList.AddItem(orange);


		*//*
        AddItemToItemTable.Add("Jarlsberg", "Yellow Cheese", 99);
        AddItemToItemTable.Add("Toro Tomatsuppe", "Toro Tomatosoup in bag", 23);
        AddItemToItemTable.Add("Grandiosa", "Frozen classic Pizza Grandiosa", 45);
        */
        /*
        foreach (var item in ReadAllItemsFromItemTable.Read()) {
            Console.WriteLine(item);
        }
        *//*

        //DeleteItem(regularshoppingList, apple);

		// RemoveItemFromItemTable.Remove(ReadSingleItemFromItemTable.Read("grandiosa"));

		*//*
        Console.WriteLine();
        foreach (var item in ReadAllItemsFromItemTable.Read()) {
			Console.WriteLine(item);
		}
        *//*
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
    }*/
 }
}