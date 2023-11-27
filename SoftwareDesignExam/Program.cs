using SoftwareDesignExam.Menu;
using SoftwareDesignExam.Store;

namespace SoftwareDesignExam;
class Program
{
    static public void Main(String[] args)
    {
	    StoreController storeController = new();
	    TestRunner testRunner = new();
	    
	    //Populates database
	    //testRunner.PopulateStock(storeController);
		MainMenu.startMenu();
		
		//testRunner.Run(storeController);
	}

}
 