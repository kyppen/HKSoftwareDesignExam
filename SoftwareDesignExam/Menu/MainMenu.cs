using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Query;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.ShoppingList;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.UIColorController;
using System.Data;
using SoftwareDesignExam.Store;
using Microsoft.Extensions.Logging;
using SoftwareDesignExam.Logging;

namespace SoftwareDesignExam.Menu;


public static class MainMenu{

    private static Boolean Authenticated = false;
    public static User? CurrentUser;
    private static Boolean Running = true;
    static MenuPrintOptions Printer = new MenuPrintOptions();
    public static void startMenu()
    {
		Logger.Instance.LogInformation("[  startMenu()  ]");
		SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
		StockController sc = new StockController(sqlda);

		//While will run until program is exited
		while (Running)
        {
            if (!Authenticated) // If the user is not logged inn
            {
				Logger.Instance.LogInformation("[  startMenu not Authenticated  ]");
				Boolean OptionSelected = false;
                string Input;
                while (OptionSelected == false)
                {
                    Printer.GuestMainMenu();
                    Console.WriteLine();
                    Console.WriteLine("Choose options!");
                    Input = Console.ReadLine();
                    //Console.WriteLine(CheckIfValid(4, input))
                    if (MenuUtils.CheckIfValid(5, Input))
                    {
                        GuestSelectOption(Input, sc);
                        OptionSelected = true;
                    }
                }
            }

            if (Authenticated) //if the user is logged inn
            {
                //var userCart = Current_user.CreateList();
                Boolean OptionSelected = false;
                string Input;
                while (OptionSelected == false)
                {
                    
                    Printer.UserMainMenu(CurrentUser);
                    Console.WriteLine("Choose options!");
                    Input = Console.ReadLine();
                    //Takes inn how many options the user has and their input after we've checked if its valid
                    if (MenuUtils.CheckIfValid(6, Input))
                    {
                        UserSelectOption(Input);
                        OptionSelected = true;
                    }
                }
            }
        }
    }

    
    //Select options for Guests
    public static void GuestSelectOption(string input, StockController stockController)
    {
		SqLiteUserDataAccess sqlUser = new SqLiteUserDataAccess();
		UserController userController = new UserController(sqlUser);

		//Inn here we will call functions based on what the user has inputted
		switch (input)
        {
            case "1":
                //Gets all items from db and prints them for the user
                Console.Clear();
                Console.WriteLine("See all wares option selected");
                Printer.PrintAll(stockController);
                break;
            case "2":
                Console.Clear();
                //Gets spesific items based on entered term
                Console.WriteLine("Search for item option selected");
                string userSelectItem = Console.ReadLine();
                var items = stockController.GetByMatchingString(userSelectItem);
                if (items.Count == 0)
                {
                    Console.WriteLine("No items matches search");
                    return;
                }
                foreach (var item in items) {
                    item.printItem();
                } 

                break;
            case "3":
                //sends the user to a login menu
                Console.Clear();
                Console.WriteLine("Login: ");
                var LoginUser = userController.Login();
                if (LoginUser == null)
                {
                    return;
                }

                
                Authenticated = true;
                CurrentUser = LoginUser;
                Console.WriteLine("Welcome! " + CurrentUser.Username);
                CurrentUser.CreateList();
                break;
            case "4":
                //Allows user to sign up
                Console.Clear();
                
                //password can be left empty for testing purposes.
                MenuPrintOptions.CreateUser();
                break;
            case "5":
                Console.Clear();
                Console.WriteLine("Program is exiting");
                Running = false;
                break;
        }
    }
    
    
    //Activated if the user is logged inn

    public static void UserSelectOption(string input)
    {
		StoreController storeController = new StoreController();
		SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
		StockController sc = new StockController(sqlda);
        //Console.WriteLine($"Welcome {CurrentUser.Username}");

		switch (input)
        {
            
            //prints all items, user can add items and item quantity here
            case "1":
                Console.Clear();
                Printer.PrintAllLoggedInn(sc);
                break;
            case "2":
                Console.Clear();
                //Same as the above but give the user a list based on search term
                Printer.ContainsSearch(sc);
                break;
            case "3":
                Console.Clear();
                //Controls removal of items from usercart and editing quantity
                MenuPrintOptions.RemoveItem(CurrentUser, sc);
                break;
            /*
            case "4":
                Console.Clear();
                Console.WriteLine("Add recipe to cart");
                break;
            case "5":
                //Console.Clear();
                Console.WriteLine("Remove recipe from cart");
                break;
                */
            case "4":
                Console.Clear();
                //prints the users cart
                CurrentUser.printAll();
                break;
            case "5":
                //Console.Clear();
                if (CurrentUser.getShoppingList().Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Add something to your cart before trying to checkout");
                    return;
                }
				storeController.CheckOut(CurrentUser.getShoppingList(), CurrentUser.getId());
                Console.Clear();
                Console.WriteLine("Checked out");
                Console.WriteLine($"Total: {CurrentUser.getTotalPrice()} NOK");
                CurrentUser.emptyCart();
                break;
            case "6":
                //Console.Clear();
                Console.WriteLine("Log out");
                Authenticated = false;
                CurrentUser = null;
                //Console.WriteLine(CurrentUser);
                break;
        }
    }
    
    
    
}