namespace SoftwareDesignExam.Menu;

public static class MenuUtils{

    public static Boolean ValidateEmail(string email)
    {
        string[] words = email.Split("@");
        if (words.Length == 2)
        {
            Console.WriteLine("accepted");
            return true;
        }
        else
        {
            Console.WriteLine("Denied");
            return false;
        }
    }

    public static Boolean ValidatePassword(string[] passwords)
    {
        if (passwords[0] == passwords[1])
        {
            Console.WriteLine("Accepted");
            return true;
        }
        Console.WriteLine("Denied");
        return false;


    }
        
}