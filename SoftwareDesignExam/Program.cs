using SoftwareDesignExam.Controller;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.ShoppingList;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.Menu;
using SoftwareDesignExam.DatabaseHandler.PopulateDataBase;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.UIColorController;
using SoftwareDesignExam.Store;
using Microsoft.Extensions.DependencyInjection;
using SoftwareDesignExam.DataAccess;
using Microsoft.Extensions.Logging;

namespace SoftwareDesignExam;
class Program
{
    static public void Main(String[] args)
    {
		StoreController storeController = new();

		MainMenu.startMenu();

		TestRunner testRunner = new();
		testRunner.Run(storeController);
	}

}
 