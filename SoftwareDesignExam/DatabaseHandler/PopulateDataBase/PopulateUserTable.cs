using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess.SqLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.PopulateDataBase {
	public class PopulateUserTable {
		public void Populate(UserController userController) {
			userController.CreateUser("King", "Harkinian", "harkinian@hyrule.official.co.uk.ru", "123Shipsflakes%");
			userController.CreateUser("Roald", "Troll", "troll@email.com", "ofdshfi74");
			userController.CreateUser("Joe", "Biden", "potus@whitehouse.com", "what11111111111");
			userController.CreateUser("Snåsa", "Mannen", "snaasamannen@yandex.com", "varmehender123");
		} 
	}
}
