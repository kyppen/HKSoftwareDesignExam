using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;
using SoftwareDesignExam.Entities;

namespace SoftWareDesignExamTest;

public class Tests
{
    private long _id;
    private string _email = "ladygaga@gmail.com";
    private string _email2 = "ladygaga2@gmail.com";


    [SetUp]
    public void Setup()
    {
        _id = UserController.CreateUser("Lady", "Gaga", "ladygaga@gmail.com", "password");

    }

    [Test]
    public void Test_UserIntegrity()
    {
        List<User> answer = ReadUserFromUserTable.Read("ladygaga@gmail.com", "password");
        Assert.That(answer[0].User_LName, Is.EqualTo("Gaga"));
        Assert.That(answer[0].User_FName, Is.EqualTo("Lady"));
        Assert.That(answer[0].User_Email, Is.EqualTo("ladygaga@gmail.com"));
        Assert.That(answer[0].User_Password, Is.EqualTo("password"));
        RemoveUserFromUserTable.Remove(_id);

    }

    [Test]
    public void Test_RemoveUserFromUserTable()
    {
        // Remove the user from _id
        RemoveUserFromUserTable.Remove(_id);

        // Try to read the removed user from the table
        var userAfterRemove = ReadUserFromUserTable.Read("ladygaga@gmail.com", "password");
        Console.WriteLine(userAfterRemove.Count);

        // Assert that the user is no longer in the table (expecting an empty list)
        Assert.That(userAfterRemove.Count, Is.EqualTo(0));
    }

    [Test]
    public void Test_CheckForDuplicationEmail()
    {
        // Check email exist before
        bool beforeAdd = CheckForDuplicateEmail.Check(_email);

        // Email should not exist before addiing a new user
        Assert.IsFalse(beforeAdd);


        // Check email exist after
        bool afterAdd = CheckForDuplicateEmail.Check(_email2);

        // Email should exist after adding a new user
        Assert.IsTrue(afterAdd);
        RemoveUserFromUserTable.Remove(_id);

    }
}