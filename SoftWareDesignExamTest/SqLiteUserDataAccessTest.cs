using Microsoft.EntityFrameworkCore.ChangeTracking;
using Moq;
using NUnit.Framework;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftWareDesignExamTest {
	public class SqLiteUserDataAccessTest {
		readonly Mock<IUserDataAccess> _userDataAccessMock;

		public SqLiteUserDataAccessTest() {
			_userDataAccessMock = new(MockBehavior.Strict);
		}

		[Test]
		public void GetUserByUserNameAndPassword_ReturnsCorrectUserFromDatabase() {
			User ExpectedUser = new() {
				User_FName = "King",
				User_LName = "Harkinian",
				User_Email = "harkinian@hyrule.official.co.uk.ru",
				User_Password = "123Shipsflakes%"
			};

			string eMail = "harkinian@hyrule.official.co.uk.ru";
			string password = "123Shipsflakes";
			_userDataAccessMock.Setup(U => U.Read(eMail, password))
				.Returns(new List<User>() { ExpectedUser });
			UserController userController = new(_userDataAccessMock.Object);

			List<User> ActualUser = userController.Read(eMail, password);

			Assert.Multiple(() => {
				foreach (var user in ActualUser) {
					Assert.NotNull(user);
					Assert.That(ExpectedUser.User_FName, Is.EqualTo(user.User_FName));
					Assert.That(ExpectedUser.User_LName, Is.EqualTo(user.User_LName));
					Assert.That(ExpectedUser.User_Email, Is.EqualTo(user.User_Email));
					Assert.That(ExpectedUser.User_Password, Is.EqualTo(user.User_Password));
				}
			});
		}
	}
}
