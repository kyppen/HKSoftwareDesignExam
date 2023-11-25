﻿using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DatabaseHandler.Methods.CartTableMethods {
	internal class ReadCartFromCartTable {
		
		public static List<Cart> Read(int userId) {
			using StoreDbContext db = new StoreDbContext();

			return db.Cart.Where(c => c.User_Id == userId).ToList();
        }
		
		}
	}

