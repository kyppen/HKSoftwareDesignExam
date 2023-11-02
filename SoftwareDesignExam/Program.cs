using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.ShoppingList;
using SoftwareDesignExam.DatabaseHandler.Methods;

namespace SoftwareDesignExam;
class Program 
{
    static public void Main(String[] args)
    {
        AddItemToItemTable.Add("Jarlsberg", "Yellow Cheese", 99);
        AddItemToItemTable.Add("Toro Tomatsuppe", "Toro Tomatosoup in bag", 23);
        AddItemToItemTable.Add("Grandiosa", "Frozen classic Pizza Grandiosa", 45);

        ReadAllItemsFromItemTable.Read();
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