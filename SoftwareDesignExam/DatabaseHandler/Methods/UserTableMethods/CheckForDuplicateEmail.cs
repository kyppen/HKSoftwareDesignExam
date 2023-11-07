namespace SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;
using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;

public class CheckForDuplicateEmail{
    public static void Check(string email)
    {
        using StoreDbContext dbContext = new StoreDbContext();
        var user = dbContext.User.Where(x => x.User_Email.ToLower() == email.ToLower()).ToList();
        Console.WriteLine("!!!!!!!!!!!!! "+user.Count);
        if (user.Count == 0)
        {
            Console.WriteLine("No copies for that email");
        }
    }
}