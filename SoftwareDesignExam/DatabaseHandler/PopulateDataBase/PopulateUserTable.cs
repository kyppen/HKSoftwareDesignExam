using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.PopulateDataBase {
	public class PopulateUserTable {
		public void Populate(UserController userController) {
			Logger.Instance.LogInformation("[  Starting populating User table with 4 users  ]");
			userController.CreateUser("King", "Harkinian", "harkinian@hyrule.official.co.uk.ru", "123Shipsflakes%");
			userController.CreateUser("Roald", "Troll", "troll@email.com", "ofdshfi74");
			userController.CreateUser("Joe", "Biden", "potus@whitehouse.com", "what11111111111");
			userController.CreateUser("Snåsa", "Mannen", "snaasamannen@yandex.com", "varmehender123");
			Logger.Instance.LogInformation("[  Finished populating User table  ]");
		}
	}
}
