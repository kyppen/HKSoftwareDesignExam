using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Menu;

namespace SoftwareDesignExam.Controller;
using DatabaseHandler.Methods.UserTableMethods;
using System.Xml.Linq;

public class UserController{

    public static long CreateUser(string firstname, string lastname, string email, string password)
    {
  		User user = new User() {
			User_FName = firstname,
			User_LName = lastname,
			User_Email = email,
			User_Password = password
		};

		AddUserToUserTable.Add(user);
        return user.Id;
    }

    public static Boolean CheckDuplicate(string email)
    {
        return CheckForDuplicateEmail.Check(email);
    }

    public static void DeleteUser()
    {
        //not finished
    }

    public static User Login()
    {
        Console.WriteLine("Enter Email");
        string email = Console.ReadLine();
        Console.WriteLine("Enter Password");
        string password = Console.ReadLine();
        List<User> user = ReadUserFromUserTable.Read(email, password);
        if (user.Count == 0)
        {
            Console.WriteLine("Login Failed");
            return null;
        }

        return user[0];

    }


}