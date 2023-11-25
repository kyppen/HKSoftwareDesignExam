using SoftwareDesignExam.Controller;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.ShoppingList;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.Menu;
using SoftwareDesignExam.DatabaseHandler.PopulateDataBase;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.UIColor;
using SoftwareDesignExam.Store;
using Microsoft.Extensions.DependencyInjection;
using SoftwareDesignExam.DataAccess;
using Microsoft.Extensions.Logging;

namespace SoftwareDesignExam;
class Program
{
    static public void Main(String[] args)
    {
		using var loggerFactory = LoggerFactory.Create(builder => {
			builder.AddConsole();
		});

		ILogger logger = loggerFactory.CreateLogger<Program>();
		logger.LogInformation("Application has started.");


		StoreController storeController = new StoreController();
		TestRunner testRunner = new TestRunner();
		testRunner.Run(storeController);

		SqLiteUserDataAccess sqlUser = new SqLiteUserDataAccess();
		UserController userController = new UserController(sqlUser);

		PopulateUserTable populateUserTable = new PopulateUserTable();
		populateUserTable.Populate(userController);


	}

}
 