using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.UserManagement {
	public interface IUser {
		string ToString();
		SoftwareDesignExam.ShoppingList.AbstractShoppingList CreateList();
	}
}
