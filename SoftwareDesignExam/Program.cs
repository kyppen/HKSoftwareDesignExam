using SoftwareDesignExam.Menu;
using SoftwareDesignExam.Store;

namespace SoftwareDesignExam;
class Program
{
    static public void Main(String[] args)
    {
		StoreController storeController = new();
		TestRunner testRunner = new();
		//1
		//if you wanna populate the database with items, you can run testrunner.Run(StoreController).
		testRunner.Run(storeController);

		MainMenu.startMenu();
		
	}

}
 