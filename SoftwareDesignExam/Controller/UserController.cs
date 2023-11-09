using SoftwareDesignExam.Entities;

namespace SoftwareDesignExam.Controller;
using DatabaseHandler.Methods.UserTableMethods;
using System.Xml.Linq;

public class UserController{

    public static void CreateUser(string firstname, string lastname, string email, string password)
    {
		User user = new User() {
			User_FName = firstname,
			User_LName = lastname,
			User_Email = email,
			User_Password = password
		};

		AddUserToUserTable.Add(user);
        //AddUserToUserTable UserAdder = new AddUserToUserTable();
        //AddUserToUserTable.Add(firstname, lastname, email, password);
    }

    public static void CheckDuplicate(string email)
    {
        CheckForDuplicateEmail.Check(email);
    }

    public static void DeleteUser()
    {
        //not finished
    }
    
    
}