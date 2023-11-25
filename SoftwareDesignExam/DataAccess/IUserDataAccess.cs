using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.DataAccess {
	public interface IUserDataAccess {

		long Add(Entities.User user);

		Boolean Check(string email);

		List<Entities.User> Read(string email, string password);

		void Remove(long id);
	}
}
