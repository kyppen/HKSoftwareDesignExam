using Moq;
using NUnit.Framework;
using SoftwareDesignExam.DataAccess;
using System;
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
		public void 
	}
}
