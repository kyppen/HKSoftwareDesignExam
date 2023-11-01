using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.ShoppingList;


namespace SoftwareDesignExam.UserManagement
{
    public class User
    {
        private string _userId;
        private string _userName;
        private string _email;
        private string _password;
        private List<SoftwareDesignExam.ShoppingList.AbstractShoppingList> _shoppingLists;
        public string Username => _userName;

        public User(string userId, string userName, string email)
        {
            _userId = userId;
            _userName = userName;
            _email = email;
            _shoppingLists = new List<SoftwareDesignExam.ShoppingList.AbstractShoppingList>();
        }

        public SoftwareDesignExam.ShoppingList.AbstractShoppingList CreateList()
        {
            var id = Guid.NewGuid().ToString();
            var name = $"{_userName}-List";
            return new RegularShoppingList(id, name);
        }


    }

   
}
