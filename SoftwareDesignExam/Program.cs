using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.ShoppingList;
using SoftwareDesignExam.DatabaseHandler.Methods;
using SoftwareDesignExam.DatabaseHandler.Methods.ItemTableMethods;
using SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;

namespace SoftwareDesignExam;
class Program 
{
    static public void Main(String[] args)
    {

        AddUserToUserTable.Add("King", "Harkinian", "harkinian@hyrule.official.co.uk.ru", "123Shipsflakes%");

        foreach (var user in ReadUserFromUserTable.Read("harkinian@hyrule.official.co.uk.ru", "123Shipsflakes%")) {
            Console.WriteLine(user);
        }

        /*
        AddItemToItemTable.Add("Jarlsberg", "Yellow Cheese", 99);
        AddItemToItemTable.Add("Toro Tomatsuppe", "Toro Tomatosoup in bag", 23);
        AddItemToItemTable.Add("Grandiosa", "Frozen classic Pizza Grandiosa", 45);
        */
        /*
        foreach (var item in ReadAllItemsFromItemTable.Read()) {
            Console.WriteLine(item);
        }
        */

        /*
        foreach(var item in ReadSingleItemFromItemTable.Read("grandiosa")) {
            Console.WriteLine(item);
        }
        */

        // RemoveItemFromItemTable.Remove(ReadSingleItemFromItemTable.Read("grandiosa"));

        /*
        Console.WriteLine();
        foreach (var item in ReadAllItemsFromItemTable.Read()) {
			Console.WriteLine(item);
		}
        */
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