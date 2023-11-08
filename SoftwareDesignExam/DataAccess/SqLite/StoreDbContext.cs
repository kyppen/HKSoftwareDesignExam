using Microsoft.EntityFrameworkCore;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.UserManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DataAccess.SqLite {
	internal class StoreDbContext : DbContext {
		public DbSet<Entities.Item> Item => Set<Entities.Item>();

		public DbSet<Entities.Cart> Cart => Set<Entities.Cart>();

		public DbSet<Entities.User> User => Set<Entities.User>();

		public DbSet<Entities.Stock> Stock => Set<Entities.Stock>();

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			//Sondre = /home/fam/RiderProjects/HKSoftwareDesignExam231/SoftwareDesignExam/Resources/Store.db
			optionsBuilder.UseSqlite(@"Data Source = Resources/Store.db");
		}

	}
}
