using Microsoft.VisualBasic.CompilerServices;
using SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
namespace SoftwareDesignExam.Menu;


public class MenuPrintOptions
{
    private User user = null;
    
    
    public void GuestMainMenu()
    {
        Console.WriteLine("1: See all wares\n" +
                          "2: Search for item\n" +
                          "3: Login\n" +
                          "4: Sign up");
    }
    

    public void UserMainMenu(User currentUser)
    {
        user = currentUser;
        Console.WriteLine($"Welcome {user.Username}");
        Console.WriteLine("1: See all wares \n" +
                          "2: Search for item\n" +
                          "3: Remove ware from cart\n" +
                          "4: Add recipe to cart\n" +
                          "5: Remove recipe from cart\n" +
                          "6: View cart\n" +
                          "7: Checkout\n" +
                          "8: Log out");
    }

    public void PrintAll()
    {
        var allItems = StockController.GetAll();
        //List<Entities.Stock> allitems = ReadAllItemsFromStockTable.Read();
        foreach (var item in allItems)
        {
            Console.WriteLine($"name: {item.name}, price: {item.price}, quanitity: {item.quantity}");
        }
        
    }

    public void PrintAllLoggedInn()
    {
        var allItems = StockController.GetAll();
        //List<Entities.Stock> allitems = ReadAllItemsFromStockTable.Read();
        for (int i = 0; i < allItems.Count; i++)
        {
            Console.WriteLine($"Select : {i} | Name: {allItems[i].name} | Quantity: {allItems[i].quantity}"); 
        }

        System.Boolean selected = false;
        while (!selected)
        {
            Console.WriteLine("Enter the number you want or type exit");
            string input = Console.ReadLine();
            if (input.ToLower().Equals("exit"))
            {
                return;
            }
            int index;
            if (int.TryParse(input, out index))
            {
                Console.WriteLine(allItems[index].ToString());
                StockItem item = allItems[index];    
                Console.WriteLine("item name " + item.name);
                int quantity = SelectQuantity(item);
                if (quantity == -1)
                {
                    return;
                }
                user.addItem(item, quantity);
                selected = true;
            };
            
        }
    }

    public int SelectQuantity(StockItem item)
    {
        Boolean QuantitySelected = false;
        int amount = 0;
        while (!QuantitySelected)
        {
            Console.WriteLine($"Selected how many of the item you want | in stock: {item.quantity}");
            string input = Console.ReadLine();
            if (int.TryParse(input, out amount))
            {
                if (amount != 0 && amount < item.quantity)
                {
                    return amount;
                }
            }
        }

        return -1;
    } 
    public List<StockItem> ContainsSearch()
    {
        Console.WriteLine("Enter an item name");
        string search = Console.ReadLine();
        List<StockItem> items = StockController.GetByMatchingString(search);
        for (int I = 0; I < items.Count; I++)
        {
            Console.WriteLine($"{I} | {items[I].name} | {items[I].quantity}");
        }  
        SelectItem(items);

        return items;
    }

    public void SelectItem(List<StockItem> items)
    {
        Console.WriteLine("Enter the number corresponding to desired item, Enter exit to return");
        string input = Console.ReadLine();
        if (input.ToLower().Equals("exit"))
        {
            return;
        }

        int number;
        if (int.TryParse(input, out number))
        {
            
            Console.WriteLine("Select item: valid: true");
            Console.WriteLine("list size " + items.Count);
            var num = int.Parse(input);
            Console.WriteLine("index attempted " + num);
            var item = items[num];
            Console.WriteLine(item);
            int amount = SelectQuantity(item);
            if (amount == -1)
            {
                Console.WriteLine("Quantity was not accepted");
                return;
            }
            user.addItem(item, amount);
        }
        
        
    }
    
    public static void CreateUser()
    {
        string[] passwords = {"", ""};
        Console.WriteLine("User Form:");
        Console.WriteLine("Enter firstname");
        string firstname = Console.ReadLine();
        Console.WriteLine("Enter Lastname");
        string lastname = Console.ReadLine();
        Console.WriteLine("Enter your Email address:\n");
        string email = Console.ReadLine();
        Console.WriteLine($"Email: {email}");
        Console.WriteLine("Enter your password");
        passwords[0] = Console.ReadLine();
        Console.WriteLine("Re-enter your password");
        passwords[1] = Console.ReadLine();
        string password = passwords[1];

        if (!MenuUtils.ValidateFirstName(firstname))
        {
            Console.WriteLine("Firstname cannot be empty");
            return;
        }

        if (!MenuUtils.ValidateLastName(lastname))
        {
            Console.WriteLine("Lastname cannot be empty");
            return;
        }
        

        if (!MenuUtils.ValidateEmail(email))
        {
            Console.WriteLine("should run after this ");
            
            
            Console.WriteLine("Email does not pass verification [must only contain one @]");
            return;
        }

        if (!MenuUtils.ValidatePassword(passwords))
        {
            Console.WriteLine("Passwords does not match");
            return;
        }

        if (!UserController.CheckDuplicate(email))
        {
            Console.WriteLine("This email is already registered");
            return;
        }
        Console.WriteLine("User is being created");
        UserController.CreateUser(firstname, lastname, email, password);
        
        //Console.WriteLine(firstname);
        //Console.WriteLine(lastname);
        //Console.WriteLine(email);
        //Console.WriteLine(passwords[0]);
        //Console.WriteLine(passwords[1]);
        
    }
    
    
}