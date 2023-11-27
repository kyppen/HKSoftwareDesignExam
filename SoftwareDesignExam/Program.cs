using SoftwareDesignExam.Menu;
using SoftwareDesignExam.Store;

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
 