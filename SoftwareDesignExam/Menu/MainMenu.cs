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

namespace SoftwareDesignExam.Menu;


public static class MainMenu{
    private static Boolean Authenticated = false;
    public static User? CurrentUser;
    private static Boolean Running = true;
    static MenuPrintOptions Printer = new MenuPrintOptions();
    public static void startMenu()
    {
		SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
		StockController sc = new StockController(sqlda);

		//While will run until program is exited
		while (Running)
        {
            if (!Authenticated) // If the user is not logged inn
            {
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
                foreach (var item in stockController.GetByMatchingString(userSelectItem)) {
                    Console.WriteLine(item);
                } 

                break;
            case "3":
                //sends the user to a login menu
                Console.Clear();
                Console.WriteLine("Login option selected");
                var LoginUser = userController.Login();
                if (LoginUser == null)
                {
                    return;
                }

                Authenticated = true;
                CurrentUser = LoginUser;
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

    public static void UserSelectOption(string input)
    {
		StoreController storeController = new StoreController();
		SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
		StockController sc = new StockController(sqlda);
        Console.WriteLine($"Welcome {CurrentUser.Username}");

		switch (input)
        {
            
            //prints all items, user can add items and item quantity here
            case "1":
                Console.WriteLine("See all wares option selected");
                Printer.PrintAllLoggedInn(sc);
                break;
            case "2":
                Console.Clear();
                //Same as the above but give the user a list based on search term
                Console.WriteLine("Search for wares option selected");
                Printer.ContainsSearch(sc);
                break;
            case "3":
                Console.Clear();
                //Controls removal of items from usercart and editing quantity
                MenuPrintOptions.RemoveItem(CurrentUser, sc);
                Console.WriteLine("Remove wares from cart option selected");
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
                Console.WriteLine("Checkout");
				storeController.CheckOut(CurrentUser.getShoppingList(), CurrentUser.getId());
                CurrentUser.emptyCart();
                break;
            case "6":
                //Console.Clear();
                Console.WriteLine("Log out");
                Authenticated = false;
                CurrentUser = null;
                Console.WriteLine(CurrentUser);
                break;
        }
    }
    
    
    //This will verify if the input is a number and that it's a valid number for our menu
    
    
}