using NUnit.Framework;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.DatabaseHandler.PopulateDataBase;
using SoftwareDesignExam.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftWareDesignExamTest {
	public class PopulateStockTableTest {
		private List<StockItem> stock;

		[SetUp]
		public void Setup() {
			SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
			StockController sc = new StockController(sqlda);
			PopulateStockTable populateStockTable = new PopulateStockTable();
			populateStockTable.Populate(sc);
			stock = sc.GetAll();
		}

		[Test]
		public void Test_Populate() {
			Assert.Multiple(() => {
				Assert.That(stock[0].name, Is.EqualTo("Jarlsberg"));
				Assert.That(stock[0].description, Is.EqualTo("Block of yellow cheese"));
				Assert.That(stock[0].price, Is.EqualTo(109));
				Assert.That(stock[0].quantity, Is.EqualTo(140));
			});
		}
	}
}
