using Microsoft.VisualBasic.CompilerServices;
using SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.UIColorController;
using System.Diagnostics;
using System.Xml.Linq;
using System.Drawing;

namespace SoftwareDesignExam.Menu;


public class MenuPrintOptions
{
    private User user = null;
    
    
    public void GuestMainMenu()
    {
       
        Console.WriteLine("1: See all wares\n" +
                          "2: Search for item\n" +
                          "3: Login\n" +
                          "4: Sign up\n" +
                          "5: Exit");
    }
    

    public void UserMainMenu(User currentUser)
    {
        //Console.Clear();
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
            UIColor.ColorWriteCyan("Name        : ");
            Console.Write($"{item.name}\n");
            UIColor.ColorWriteCyan("Description : ");
            Console.Write($"{item.description}\n");
            UIColor.ColorWriteCyan("Price       : ");
            Console.WriteLine($"{item.price}\n");
        }
        
    }

    public void PrintAllLoggedInn()
    {
        var allItems = StockController.GetAll();
        //List<Entities.Stock> allitems = ReadAllItemsFromStockTable.Read();
        for (int i = 0; i < allItems.Count; i++)
        {
            Console.WriteLine($"selection number: {i}");
            UIColor.ColorWriteYellow("Id          : ");
            Console.WriteLine($"{allItems[i].id}");
            UIColor.ColorWriteYellow("Name        : ");
            Console.WriteLine($"{allItems[i].name}");
            UIColor.ColorWriteYellow("Description : ");
            Console.WriteLine($"{allItems[i].description}");
            UIColor.ColorWriteYellow("Price       : ");
            Console.WriteLine($"{allItems[i].price}");
            Console.WriteLine();
        }

        Boolean selected = false;
        while (!selected)
        {
            Console.WriteLine("Enter the number you want or type exit");
            string input = Console.ReadLine();
            //Console.Clear();
            if (input.ToLower().Equals("exit"))
            {
                return;
            }
            int index;
            if (int.TryParse(input, out index ) && MenuUtils.CheckIfValidZeroAccepted(allItems.Count, input) && index < allItems.Count)
            {
                allItems[index].ToString();
                StockItem item = allItems[index];
                item.printItem();
                int quantity = SelectQuantity(item);
                if (quantity == -1)
                {
                    return;
                }
                user.addItem(item, quantity);
                Console.WriteLine($"{item.name} has been added to cart!");
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
            Console.WriteLine($"Selected how many of the item you want in stock: {item.quantity}");
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
            Console.WriteLine($"item number: {I}");
            items[I].printItem();
            //Console.WriteLine($"{items[I].price}\n");
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
        if (int.TryParse(input, out number) && MenuUtils.CheckIfValidZeroAccepted(items.Count, input)) 
        {

            Console.WriteLine("number" + number);
            Console.WriteLine("input" + input);

            Console.WriteLine("Select item: valid: true");
            Console.WriteLine("list size " + items.Count);
           
            if (number >= 0 && number < items.Count)
            {
                Console.WriteLine("index attempted " + number);
                var item = items[number];
                Console.WriteLine(item);
                int amount = SelectQuantity(item);
                user.addItem(item, amount);
            }
            else
            {
                Console.WriteLine("Invalid input please try again");
            }
        }
    }

    public static AbstractItem RemoveItemMenu(User user)
    {
        List<AbstractItem> items = user.getShoppingList();
        for (int i = 0; i < items.Count; i++)
        {
            AbstractItem item = items[i];
            Console.WriteLine("Item number " + i);
            item.ToString();
           
        }

        Boolean ItemSelcted = false;
        while (!ItemSelcted)
        {
            Console.WriteLine("Enter the number corresponding to item.");
            string input = Console.ReadLine();
            Console.WriteLine();
            if (input.ToLower() == "exit")
            {
                return null;
            }
            int inputNum;
            if (int.TryParse(input, out inputNum) && inputNum < items.Count && inputNum >= 0)
            {
                Console.WriteLine("Selected: " + items[inputNum]);
                return items[inputNum];
            }
            Console.WriteLine("Input not accepted");
        }
        return null;
    }

    public static void RemoveItem(User user)
    {
        if (user.getShoppingList().Count == 0)
        {
            Console.WriteLine("You have no items in ur cart");
            return;
        }
        AbstractItem item = RemoveItemMenu(user);
        
        Console.WriteLine("0: Edit quantity");
        Console.WriteLine("1: Remove Item from List");
        string input = Console.ReadLine();
        Console.WriteLine();
        if (input.Equals("0")){
            List<StockItem> itemStock = StockController.GetByMatchingString(item.name);
            
            Console.WriteLine("Quantity in stock: " + itemStock[0].quantity);
            Console.WriteLine("Quantity in cart: " + item.quantity);
            Console.WriteLine("Enter new quantity");
            string inputQuantity = Console.ReadLine();
            int intQuantity;
            if (int.TryParse(inputQuantity, out intQuantity))
            {
                if (intQuantity < itemStock[0].quantity)
                {
                    item.quantity = intQuantity;
                    Console.WriteLine($"Quantity has been updated to {item.quantity}");
                    return;
                }
                Console.WriteLine("Cant add more quantity then we have in stock");
            }
            


        }else if (input.Equals("1"))
        {
            user.RemoveItem(item);
            Console.WriteLine(item.name + " has been removed from shoppinglist");
        }
        else
        {
            Console.WriteLine("Input not accepted");
        }
    }
    
    
    public static void CreateUser()
    {
        string[] passwords = {"", ""};
        Console.WriteLine("User Form:");
        Console.WriteLine("Enter firstname");
        string firstname = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter Lastname");
        string lastname = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter your Email address:");
        string email = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine($"Email: {email}");
        Console.WriteLine();
        Console.WriteLine("Enter your password");
        passwords[0] = Console.ReadLine();
        Console.WriteLine();
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
            
            Console.WriteLine("Email does not pass verification [must only contain one @]\n");
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
        //Console.Clear();
        Console.WriteLine("User is being created\n");
        UserController.CreateUser(firstname, lastname, email, password);
        Thread.Sleep(1000);
       // Console.Clear() ;
        //Console.WriteLine(firstname);
        //Console.WriteLine(lastname);
        //Console.WriteLine(email);
        //Console.WriteLine(passwords[0]);
        //Console.WriteLine(passwords[1]);
        
    }
    
    
}