using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Menu;

namespace SoftwareDesignExam.Controller;
using DatabaseHandler.Methods.UserTableMethods;

public class UserController{

    public static void CreateUser(string firstname, string lastname, string email, string password)
    {

        AddUserToUserTable.Add(firstname, lastname, email, password);
        //AddUserToUserTable UserAdder = new AddUserToUserTable();
        //AddUserToUserTable.Add(firstname, lastname, email, password);
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