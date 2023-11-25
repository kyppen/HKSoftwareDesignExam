using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DataAccess {
	public interface ICartDataAccess {

		List<Cart> Read(int userId);

		void Add(Cart cart);
	}
}
