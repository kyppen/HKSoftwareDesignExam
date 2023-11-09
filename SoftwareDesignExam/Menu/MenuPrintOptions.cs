using SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.Entities;

namespace SoftwareDesignExam.Menu;


public class MenuPrintOptions{
    public void GuestMainMenu()
    {
        Console.WriteLine("1: See all wares\n" +
                          "2: Search for item\n" +
                          "3: Login\n" +
                          "4: Sign up");
    }
    

    public void UserMainMenu(User user)
    {
        Console.WriteLine($"Welcome {user.User_FName} {user.User_LName}");
        Console.WriteLine("1: See all wares \n" +
                          "2: Search for item\n" +
                          "3: Add wares to cart\n" +
                          "4: Remove ware from cart\n" +
                          "5: Add recipe to cart\n" +
                          "6: Remove recipe from cart\n" +
                          "7: View cart\n" +
                          "8: Log out");
    }

    
    public static void CreateUser()
    {
        string[] passwords = {"", ""};
        Console.WriteLine("User Form:");
        Console.WriteLine("Enter firstname");
        string firstname = Console.ReadLine();
        Console.WriteLine("Enter Lastname");
        string lastname = Console.ReadLine();
        Console.WriteLine("Enter your Email address:\n");
        string email = Console.ReadLine();
        Console.WriteLine($"Email: {email}");
        Console.WriteLine("Enter your password");
        passwords[0] = Console.ReadLine();
        Console.WriteLine("Re-enter your password");
        passwords[1] = Console.ReadLine();
        string password = passwords[1];

        if (!MenuUtils.ValidateFirstName(firstname))
        {
            Console.WriteLine("Firstname cannot be empty");
            return;
        }

        if (!MenuUtils.ValidateLastName(lastname))
        {
            Console.WriteLine("Lastname cannot be empty");
            return;
        }
        

        if (!MenuUtils.ValidateEmail(email))
        {
            Console.WriteLine("should run after this ");
            
            
            Console.WriteLine("Email does not pass verification [must only contain one @]");
            return;
        }

        if (!MenuUtils.ValidatePassword(passwords))
        {
            Console.WriteLine("Passwords does not match");
            return;
        }

        if (!UserController.CheckDuplicate(email))
        {
            Console.WriteLine("This email is already registered");
            return;
        }
        Console.WriteLine("User is being created");
        UserController.CreateUser(firstname, lastname, email, password);
        
        //Console.WriteLine(firstname);
        //Console.WriteLine(lastname);
        //Console.WriteLine(email);
        //Console.WriteLine(passwords[0]);
        //Console.WriteLine(passwords[1]);
        
    }
    
    
}