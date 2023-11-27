using Moq;
using NUnit.Framework;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftWareDesignExamTest {
	public class SqLiteCartDataAccessTest {
		readonly Mock<ICartDataAccess> _CartDataAccessMock;

		public SqLiteCartDataAccessTest() {
			_CartDataAccessMock = new(MockBehavior.Strict);
		}

		[Test]
		public void ReadCartFromCartTable_ReturnsTheValuesOfACart() {
			DateTime dateTime = DateTime.Now;
			Cart ExpectedCart = new() {
				Id = 1,
				Cart_Id = 2,
				User_Id = 1,
				Item_Id = 4,
				Item_Quantity = 23,
				Item_Price = 109,
				PurchaceDate = dateTime
			};

			_CartDataAccessMock.Setup(C => C.Read(1))
				.Returns(new List<Cart>() { ExpectedCart });
			CartController cartController = new(_CartDataAccessMock.Object);

			List<Cart> ActualCart = cartController.ReadCart(1);

			foreach(Cart cart in ActualCart) {
				Assert.Multiple(() => {
					Assert.That(ExpectedCart.Id, Is.EqualTo(cart.Id));
					Assert.That(ExpectedCart.Cart_Id, Is.EqualTo(cart.Cart_Id));
					Assert.That(ExpectedCart.User_Id, Is.EqualTo(cart.User_Id));
					Assert.That(ExpectedCart.Item_Id, Is.EqualTo(cart.Item_Id));
					Assert.That(ExpectedCart.Item_Quantity, Is.EqualTo(cart.Item_Quantity));
					Assert.That(ExpectedCart.Item_Price, Is.EqualTo(cart.Item_Price));
					Assert.That(ExpectedCart.PurchaceDate, Is.EqualTo(cart.PurchaceDate));
				});
			}
		}
	}
}
