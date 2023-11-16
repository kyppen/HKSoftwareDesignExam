using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Query;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.ShoppingList;
using SoftwareDesignExam.UserManagement;

namespace SoftwareDesignExam.Menu;


public static class MainMenu{
    private static Boolean Authenticated = false;
    public static User? Current_user = null;
    private static Boolean running = true;
    static MenuPrintOptions printer = new MenuPrintOptions();
    public static void startMenu()
    {
        while (running)
        {
            if (!Authenticated) // If the user is not logged inn
            {
                Boolean optionSelected = false;
                string input;
                while (optionSelected == false)
                {
                    printer.GuestMainMenu();
                    Console.WriteLine("choose");
                    input = Console.ReadLine();
                    //Console.WriteLine(CheckIfValid(4, input))
                    if (MenuUtils.CheckIfValid(4, input))
                    {
                        GuestSelectOption(input);
                        optionSelected = true;
                    }
                }
            }

            if (Authenticated) //if the user is logged inn
            {
                //var userCart = Current_user.CreateList();
                Boolean optionSelected = false;
                string input;
                while (optionSelected == false)
                {
                    printer.UserMainMenu(Current_user);
                    Console.WriteLine("choose");
                    input = Console.ReadLine();
                    //Takes inn how many options the user has and their input after we've checked if its valid
                    if (MenuUtils.CheckIfValid(8, input))
                    {
                        UserSelectOption(input);
                        optionSelected = true;
                    }
                }
            }
        }
    }

    
    //Select options for Guests
    public static void GuestSelectOption(string input)
    {
        
        //Inn here we will call functions based on what the user has inputted
        switch (input)
        {
            case "1": 
                Console.WriteLine("See all wares option selected");
                printer.PrintAll();
                break;
            case "2":
                Console.WriteLine("Search for item option selected");
                string userSelectItem = Console.ReadLine();
                foreach (var item in StockController.GetByMatchingString(userSelectItem)) {
                    Console.WriteLine(item);
                } 

                break;
            case "3":
                Console.WriteLine("Login option selected");
                var answer = UserController.Login();
                if (answer == null)
                {
                    Console.WriteLine("user is null");
                    return;
                }

                Authenticated = true;
                Current_user = answer;
                Current_user.CreateList();

                
                
                
                
                break;
            case "4":
                Console.WriteLine("Sign up option selected");
                
                //password can be left empty for testing purposes.
                MenuPrintOptions.CreateUser();
                break;
        }
    }

    public static void UserSelectOption(string input)
    {
        
        switch (input)
        {
            case "1":
                Console.WriteLine("See all wares option selected");
                printer.PrintAllLoggedInn();
                break;
            case "2":
                Console.WriteLine("Search for wares option selected");
                var something = printer.ContainsSearch();
                break;
            case "3":
                MenuPrintOptions.RemoveItem(Current_user);
                Console.WriteLine("Remove wares from cart option selected");
                break;
            case "4":
                Console.WriteLine("Add recipe to cart");
                break;
            case "5":
                Console.WriteLine("Remove recipe from cart");
                break;
            case "6":
                Console.WriteLine("View Cart");
                Current_user.printAll();
                break;
            case "7":
                Console.WriteLine("Checkout");
                break;
            case "8":
                Console.WriteLine("Log out");
                Authenticated = false;
                Current_user = null;
                break;
        }
    }
    
    
    //This will verify if the input is a number and that it's a valid number for our menu
    
    
}