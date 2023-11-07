namespace SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;

public class CheckForDuplicateEmail{
    public static Boolean Check(string email)
    {
        using StoreDbContext dbContext = new StoreDbContext();
        Console.WriteLine("it did something");
        var user = dbContext.User.Where(x => x.User_Email.ToLower() == email.ToLower()).ToList();
        Console.WriteLine("!!!!!!!!!!!!! "+user.Count);
        if (user.Count == 0)
        {
            Console.WriteLine("True");
            return true;
        }
        Console.WriteLine("False");
        return false;
    }
}