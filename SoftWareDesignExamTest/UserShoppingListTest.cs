using NUnit.Framework.Internal;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.DatabaseHandler.Methods;
using SoftwareDesignExam.DatabaseHandler.Methods.UserTableMethods;
using SoftwareDesignExam.Items;

namespace SoftWareDesignExamTest;

public class UserShoppingListTest{
    [SetUp]
    public void Setup()
    {
        //UserController.CreateUser("test", "test", "test@test", "test");
    }

    
    [Test]
    public void CheckingQuantityOnAddingSameItem()
    {
        User TestUser = new("1", "test@test", "test");
        StockItem stockItem = new StockItem(1,"test","an shoppinglistTest", 3, 40);
        TestUser.addItem(stockItem,10);
        TestUser.addItem(stockItem, 10);
        var items = TestUser.getShoppingList();
        Assert.That(items.Count, Is.EqualTo(1));
    }
    
}