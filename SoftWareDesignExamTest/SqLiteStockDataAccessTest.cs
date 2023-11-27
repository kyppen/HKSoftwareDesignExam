using Moq;
using NUnit.Framework;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftWareDesignExamTest {
	public class SqLiteStockDataAccessTest {
		readonly Mock<IStockDataAccess> _dataAccessMock;

		public SqLiteStockDataAccessTest() {
			_dataAccessMock = new(MockBehavior.Strict);
		}

		[Test]
		public void GetStockItemById_ReturnsCorrectStockItem() {
			Stock ExpectedStockItem = new () {
				Id = 1,
				Item_Name = "Jarlsberg",
				Item_Description = "Block of yellow cheese",
				Item_Price = 109,
				Item_Quantity = 40,
			};

			_dataAccessMock.Setup(S => S.ReadAllByMatching("jarl"))
				.Returns(new List<Stock>() { ExpectedStockItem });
			StockController stockController = new(_dataAccessMock.Object);

			string name = "jarl";
			List<StockItem> ActualStockItem = stockController.GetByMatchingString(name);

			foreach(StockItem item in ActualStockItem) {
				Assert.Multiple(() => {
					Assert.That(ExpectedStockItem.Id, Is.EqualTo(item.id));
					Assert.That(ExpectedStockItem.Item_Name, Is.EqualTo(item.name));
					Assert.That(ExpectedStockItem.Item_Description, Is.EqualTo(item.description));
					Assert.That(ExpectedStockItem.Item_Price, Is.EqualTo(item.price));
					Assert.That(ExpectedStockItem.Item_Quantity, Is.EqualTo(item.quantity));
				});
			}
		}
	}
}
