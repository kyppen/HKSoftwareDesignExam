namespace SoftwareDesignExam.Menu;


public class MenuPrintOptions{
    public void GuestMainMenu()
    {
        Console.WriteLine("1: See all wares\n" +
                          "2: Search for item\n" +
                          "3: Login\n" +
                          "4: Sign up");
    }

    public void UserMainMenu()
    {
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
        
        Console.WriteLine("Enter your Email address:\n");
        string email = Console.ReadLine();
        Console.WriteLine($"Email: {email}");
        Console.WriteLine("Enter your password");
        passwords[0] = Console.ReadLine();
        Console.WriteLine("Re-enter your password");
        passwords[1] = Console.ReadLine();
        
        if(MenuUtils.ValidateEmail(email) && MenuUtils.ValidatePassword(passwords))
        {
            Console.WriteLine("User has been created");
            //Function to create user and add it to datebase
        }
        else
        {
            Console.WriteLine("There was an error creating user, Either the passwords didnt match or you had more then one @ in your email");
        }
    }
    
    
}