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

    public static Boolean ValidateFirstName(string firstname)
    {
        if (firstname != "") {
            return true;
        }
        return false;
    }

    public static Boolean ValidateLastName(string lastname)
    {
        if (lastname != "") {
            return true;
        }

        return false;
    }

    public static Boolean CheckIfValidZeroAccepted(int options, string input = "")
    {
        int number;
        Boolean accepted = int.TryParse(input, out number);
        //Console.WriteLine("is it a number? " + accepted);
        //Console.WriteLine(something);
        if (!accepted)
        {
            return false;
        }
        if (number <= options && number >= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
    public static Boolean CheckIfValid(int options, string input = "")
    {
        int number;
        Boolean accepted = int.TryParse(input, out number);
        //Console.WriteLine("is it a number? " + accepted);
        //Console.WriteLine(something);
        if (!accepted)
        {
            return false;
        }
        if (number <= options && number != 0)
        {
            return true;
        }
        else
        {
            return false;
        }
        
    }
        
}