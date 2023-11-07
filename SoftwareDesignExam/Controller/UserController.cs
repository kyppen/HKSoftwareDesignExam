using SoftwareDesignExam.Entities;

namespace SoftwareDesignExam.Controller;
using DatabaseHandler.Methods.UserTableMethods;

public class UserController{

    public static void CreateUser(string firstname, string lastname, string email, string password)
    {
        
        AddUserToUserTable.Add(firstname, lastname, email, password);
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