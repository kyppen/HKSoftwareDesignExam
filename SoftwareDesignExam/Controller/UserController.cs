using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Menu;

namespace SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using System.Xml.Linq;

public class UserController{

    private readonly IUserDataAccess userDataAccess;
    public UserController(IUserDataAccess userDataAccess) { 
        this.userDataAccess = userDataAccess;
    }

	public List<Entities.User> Read(string email, string password) {
        return userDataAccess.Read(email, password);
    }

    public void Remove(long id) { 
        userDataAccess.Remove(id);
    }

		public long CreateUser(string firstname, string lastname, string email, string password)
    {
        User user = new User() {
            User_FName = firstname,
            User_LName = lastname,
            User_Email = email,
            User_Password = password
        };

		userDataAccess.Add(user);
        //AddUserToUserTable UserAdder = new AddUserToUserTable();
        //AddUserToUserTable.Add(firstname, lastname, email, password);
        return user.Id;
    }

    public  Boolean CheckDuplicate(string email)
    {
        return userDataAccess.Check(email);
    }

    public void DeleteUser()
    {
        //not finished
    }

    public UserManagement.User Login()
    {
        Console.WriteLine("Enter Email");
        string email = Console.ReadLine();
        Console.WriteLine();
        Console.WriteLine("Enter Password");
        string password = Console.ReadLine();
        List<User> user = userDataAccess.Read(email, password);
        if (user.Count == 0)
        {
            Console.WriteLine("Login Failed");
            return null;
        }

        UserManagement.User userObject = new UserManagement.User($"{user[0].Id}", user[0].User_Email, user[0].User_FName);
        Console.Clear();
        Console.WriteLine("Logged in");
        return userObject;

    }


}