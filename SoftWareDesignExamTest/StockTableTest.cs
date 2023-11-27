using NUnit.Framework;
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
                Assert.Multiple(() => {
					Assert.That(stock.name, Is.EqualTo("Ali Kaffe 500g"));
					Assert.That(stock.description, Is.EqualTo("500g bag of coffee beans"));
					Assert.That(stock.price, Is.EqualTo(89));
					Assert.That(stock.quantity, Is.EqualTo(435));
				});
            }
        }  
    }
}

