﻿using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;

namespace SoftwareDesignExam.DatabaseHandler.Methods {
	public class ReadAllItemsFromItemTable {
		public static List<Item> Read() {
			using StoreDbContext dbContext = new StoreDbContext();
			return dbContext.Item.ToList();
		}
	}
}