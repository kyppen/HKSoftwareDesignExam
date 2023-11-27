using Microsoft.VisualBasic.CompilerServices;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.UIColorController;
namespace SoftwareDesignExam.Menu;



public class MenuPrintOptions
{
    private User? _User;
    
    
    public void GuestMainMenu()
    {
       
        Console.WriteLine("1: See all wares\n" +
                          "2: Search for item\n" +
                          "3: Login\n" +
                          "4: Sign up\n" +
                          "5: Exit");
    }
    

    public void UserMainMenu(User CurrentUser)
    {
        //Console.Clear();
        _User = CurrentUser;
        Console.WriteLine("1: See all wares \n" +
                          "2: Search for item\n" +
                          "3: Remove ware from cart\n" +
                          "4: View cart\n" +
                          "5: Checkout\n" +
                          "6: Log out");
    }

    public void PrintAll(StockController stockController)
    {
        var allItems = stockController.GetAll();
        //List<Entities.Stock> allitems = ReadAllItemsFromStockTable.Read();
        foreach (var item in allItems)
        {
            item.printItem();
        }
    }

    public void PrintAllLoggedInn(StockController stockController)
    {
        var AllItems = stockController.GetAll();
        //List<Entities.Stock> allitems = ReadAllItemsFromStockTable.Read();
        for (int i = 0; i < AllItems.Count; i++)
        {
            Console.WriteLine($"Select: {i}");
            AllItems[i].printItem();
        }

        Boolean Selected = false;
        while (!Selected)
        {
            Console.WriteLine("Enter the number you want, or type exit");
            string Input = Console.ReadLine();
            //Console.Clear();
            if (Input.ToLower().Equals("exit"))
            {
                return;
            }
            int Index;
            if (int.TryParse(Input, out Index ) && MenuUtils.CheckIfValidZeroAccepted(AllItems.Count, Input) && Index < AllItems.Count)
            {
                AllItems[Index].ToString();
                StockItem Item = AllItems[Index];
                Item.printItem();
                int Quantity = SelectQuantity(Item);
                if (Quantity == -1)
                {
                    return;
                }
                _User.addItem(Item, Quantity);
                Console.WriteLine($"{Item.name} has been added to cart!");
                Selected = true;
            };
            
        }
    }

    public int SelectQuantity(StockItem item)
    {
        Boolean QuantitySelected = false;
        int Amount;
        
        while (!QuantitySelected)
        {
            Console.WriteLine($"Select how many of the item you want. Max: {item.quantity}");
            string input = Console.ReadLine();
            if (int.TryParse(input, out Amount))
            {
                if (Amount > 0 && Amount <= item.quantity)
                {
                    return Amount;
                }
                Console.WriteLine("Invalid quantity selected");
                
            }
        }

        //returns -1 if quantity selected is invalid
        return -1;
    } 
    public void ContainsSearch(StockController stockController)
    {
        Console.WriteLine("Enter an item name");
        string Search = Console.ReadLine();
        List<StockItem> Items = stockController.GetByMatchingString(Search);
        if (Items.Count == 0)
        {
            Console.WriteLine("No items matches search");
            return;
        }
        if (Items.Count == 1)
        {
            var item = Items[0];
            item.printItem();
            int quantity = SelectQuantity(item);
            if (quantity == -1)
            {
                return;
            }
            _User.addItem(item, quantity);
            return;

        }
        for (int I = 0; I < Items.Count; I++)
        {
            Console.WriteLine($"Select: {I}");
            Items[I].printItem();
            //Console.WriteLine($"{items[I].price}\n");
        }  
        SelectItem(Items);
    }

    public void SelectItem(List<StockItem> items)
    {
        Console.WriteLine("Enter the number corresponding to desired item, Enter exit to return");
        string Input = Console.ReadLine();
        if (Input.ToLower().Equals("exit"))
        {
            return;
        }

        int Number;
        if (int.TryParse(Input, out Number) && MenuUtils.CheckIfValidZeroAccepted(items.Count, Input)) 
        {
            
           
            if (Number >= 0 && Number < items.Count)
            {
                var item = items[Number];
                Console.WriteLine(item);
                int amount = SelectQuantity(item);
                if (amount == -1)
                {
                    return;
                }
                _User.addItem(item, amount);
            }
            else
            {
                Console.WriteLine("Invalid input please try again");
            }
        }
        Console.WriteLine("Invalid input please try again");
    }
    
    public static AbstractItem RemoveItemMenu(User user)
    {
        List<AbstractItem> items = user.getShoppingList();
        for (int i = 0; i < items.Count; i++)
        {
            AbstractItem item = items[i];
            Console.WriteLine("Select: " + i);
            item.printItem();
        }

        Boolean ItemSelcted = false;
        while (!ItemSelcted)
        {
            Console.WriteLine("Select an item");
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

    public static void RemoveItem(User user, StockController stockController)
    {
        if (user.getShoppingList().Count == 0)
        {
            Console.WriteLine("Cart is currently empty");
            return;
        }
        AbstractItem item = RemoveItemMenu(user);
        
        Console.WriteLine("0: Edit quantity");
        Console.WriteLine("1: Remove Item from Cart");
        string input = Console.ReadLine();
        Console.WriteLine();
        if (input.Equals("0")){
            
            List<StockItem> itemStock = stockController.GetByMatchingString(item.name);
            Console.WriteLine("Quantity in stock: " + itemStock[0].quantity);
            Console.WriteLine("Quantity in cart: " + item.quantity);
            Console.WriteLine("Enter new quantity");
            string inputQuantity = Console.ReadLine();
            int intQuantity;
            if (int.TryParse(inputQuantity, out intQuantity))
            {
                
                if (intQuantity < itemStock[0].quantity && intQuantity > 0)
                {
                    item.quantity = intQuantity;
                    Console.WriteLine($"Quantity has been updated to {item.quantity}");
                    return;
                }
                Console.WriteLine("There seems to be an issue");
                Console.WriteLine("You cannot change quantity to less than 1");
                Console.WriteLine("And you cannot add more than there is in stock");
            }
            


        }else if (input.Equals("1"))
        {
            user.RemoveItem(item);
            Console.WriteLine(item.name + " has been removed from shoppingcart");
        }
        else
        {
            Console.WriteLine("Input not accepted");
        }
    }
    
    
    public static void CreateUser()
    {
		SqLiteUserDataAccess sqlUser = new SqLiteUserDataAccess();
		UserController userController = new UserController(sqlUser);

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

        if (!userController.CheckDuplicate(email))
        {
            Console.WriteLine("This email is already registered");
            return;
        }
        userController.CreateUser(firstname, lastname, email, password);
        Console.WriteLine("Account creation success!");
        Console.WriteLine("You can now login");
        //Console.WriteLine(firstname);
        //Console.WriteLine(lastname);
        //Console.WriteLine(email);
        //Console.WriteLine(passwords[0]);
        //Console.WriteLine(passwords[1]);

    }
    
    
}