using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.PopulateDataBase {
	public class PopulateUserTable {
		public static void Populate() {
			UserController.CreateUser("King", "Harkinian", "harkinian@hyrule.official.co.uk.ru", "123Shipsflakes%");
			UserController.CreateUser("Roald", "Troll", "troll@email.com", "ofdshfi74");
			UserController.CreateUser("Joe", "Biden", "potus@whitehouse.com", "what11111111111");
			UserController.CreateUser("Snåsa", "Mannen", "snaasamannen@yandex.com", "varmehender123");
		} 
	}
}
