using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.DatabaseHandler.PopulateDataBase;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SoftWareDesignExamTest
{
    public class StockTableTest
    {
        [SetUp]
        public void Setup()
        {
			SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
			StockController sc = new StockController(sqlda);
			sc.CreateStockItem(ItemFactory.CreateItem("Ali Kaffe 500g", "500g bag of coffee beans", 89), 435);
        }


        [Test]
        public void Test_Stock_Checking()
        {
			SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
			StockController sc = new StockController(sqlda);
			List<StockItem> stocks = sc.GetByMatchingString("Ali Kaffe 500g");
            foreach (StockItem stock in stocks)
            {
                Assert.That(stock.name, Is.EqualTo("Ali Kaffe 500g"));
                Assert.That(stock.description, Is.EqualTo("500g bag of coffee beans"));
                Assert.That(stock.price, Is.EqualTo(89));
                Assert.That(stock.quantity, Is.EqualTo(435));
            }
        }
       
    }

    public class TestPopulate
    {
        private List<StockItem> stock;

        [SetUp]
        public void Setup()
        {
			SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
			StockController sc = new StockController(sqlda);
            PopulateStockTable populateStockTable = new PopulateStockTable();
			populateStockTable.Populate(sc);
            stock = sc.GetAll();
        }

        [Test]
        public void Test_Populate()
        {
            AbstractItem item = stock[0];
            
            Assert.That(stock[0].name, Is.EqualTo("Jarlsberg"));
            Assert.That(stock[0].description, Is.EqualTo("Block of yellow cheese"));
            Assert.That(stock[0].price, Is.EqualTo(109));
            Assert.That(stock[0].quantity, Is.EqualTo(140));
        }
    }
}

