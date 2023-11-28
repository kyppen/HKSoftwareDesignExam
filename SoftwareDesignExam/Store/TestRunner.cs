using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.DatabaseHandler.PopulateDataBase;
using SoftwareDesignExam.Items;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.UIColorController;
using Microsoft.Extensions.Logging;

namespace SoftwareDesignExam.Store {
	public class TestRunner {
		public void Run(StoreController storeController) {
			SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
			StockController sc = new StockController(sqlda);
			PopulateStockTable populateStockTable = new PopulateStockTable();
			populateStockTable.Populate(sc);
			
		}
	}
}
