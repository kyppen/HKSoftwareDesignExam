using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Entities {
	public class User {
		public int Id { get; set; }

		[Required]
		public string User_FName { get; set; } = string.Empty;

		[Required]
		public string User_LName { get; set; } = string.Empty;

		[Required]
		public string User_Email { get; set; } = string.Empty;

		[Required]
		public string User_Password { get; set;} = string.Empty;

		public override string ToString() {
			return $"ID: {Id}\nName: {User_FName} {User_LName}\nEmail: {User_Email}";
		}
	}
}
