﻿using SoftwareDesignExam.Controller;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.ShoppingList;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.DatabaseHandler.Methods;
using SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;
using SoftwareDesignExam.Menu;
using SoftwareDesignExam.DatabaseHandler.PopulateDataBase;
using SoftwareDesignExam.DatabaseHandler.Methods.StockTableMethods;
using SoftwareDesignExam.UIColorController;

namespace SoftwareDesignExam;
class Program
{
    static public void Main(String[] args)
    {

        /*
        AddUserToUserTable.Add("King", "Harkinian", "harkinian@hyrule.official.co.uk.ru", "123Shipsflakes%");
        foreach (var user in ReadUserFromUserTable.Read("harkinian@hyrule.official.co.uk.ru", "123Shipsflakes%"))
        {
            Console.WriteLine(user);
            
        }
        Console.ReadLine();
       
        */
        Console.WriteLine("Starting program!");
        Console.WriteLine();
        //PopulateStockTable.Populate();


        //Run these only once!
        PopulateStockTable.Populate();
        PopulateUserTable.Populate();
        //PopulateUserTable.Populate();
        MainMenu.startMenu();

    }
}
 