using SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;
using SoftwareDesignExam.Entities;

namespace SoftWareDesignExamTest;

public class Tests
{
    private long id;

    [SetUp]
    public void Setup()
    {
        id = AddUserToUserTable.Add("Lady", "Gaga", "ladygaga@gmail.com", "password");
    }

    [Test]
    public void Test_AddUserToUserTable()
    {
        List<User> answer = ReadUserFromUserTable.Read("ladygaga@gmail.com", "password");
        Assert.That(answer[0].User_LName, Is.EqualTo("Gaga"));
        Assert.That(answer[0].User_FName, Is.EqualTo("Lady"));
        Assert.That(answer[0].User_Email, Is.EqualTo("ladygaga@gmail.com"));
        Assert.That(answer[0].User_Password, Is.EqualTo("password"));

    }

    [Test]
    public void Test_RemoveUserFromUserTable()
    {
        RemoveUserFromUserTable.Remove(id);
        RemoveUserFromUserTable.Remove(123);


    }
}