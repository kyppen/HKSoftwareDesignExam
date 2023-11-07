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
			AddUserToUserTable.Add("King", "Harkinian", "harkinian@hyrule.official.co.uk.ru", "123Shipsflakes%");
			AddUserToUserTable.Add("Roald", "Troll", "troll@email.com", "ofdshfi74");
			AddUserToUserTable.Add("Joe", "Biden", "potus@whitehouse.com", "what11111111111");
			AddUserToUserTable.Add("Snåsa", "Mannen", "snaasamannen@yandex.com", "varmehender123");
		} 
	}
}
