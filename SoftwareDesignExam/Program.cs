using SoftwareDesignExam.Menu;
using SoftwareDesignExam.Store;

namespace SoftwareDesignExam;
class Program
{
    static public void Main(String[] args)
    {
		MainMenu.startMenu();

		StoreController storeController = new();
		TestRunner testRunner = new();
		testRunner.Run(storeController);
	}

}
 