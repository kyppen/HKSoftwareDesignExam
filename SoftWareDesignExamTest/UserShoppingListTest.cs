using NUnit.Framework.Internal;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.UserManagement;
using SoftwareDesignExam.Items;
using NUnit.Framework;

namespace SoftWareDesignExamTest;

public class UserShoppingListTest{

    [SetUp]
    public void Setup()
    {
    }

    
    [Test]
    public void CheckingQuantityOnAddingSameItem()
    {
        User TestUser = new ("1", "test@test", "test");
        StockItem testItem1 = new (1, "testItem1", "an shoppinglistTest", 3, 40);
		StockItem testItem2 = new (1, "testItem2", "an shoppinglistTest", 3, 40);
		TestUser.addItem(testItem1, 1);
        TestUser.addItem(testItem2, 1);
        var items = TestUser.getShoppingList();
        Assert.That(items, Has.Count.EqualTo(2));
    }
    
}