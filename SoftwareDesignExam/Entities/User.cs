using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Entities {
	internal class User {
		public int Id { get; set; }

		[Required]
		public string User_FName { get; set; } = string.Empty;

		[Required]
		public string User_LName { get; set; } = string.Empty;

		[Required]
		public string User_Email { get; set; } = string.Empty;

		[Required]
		public string User_Password { get; set;} = string.Empty;
	}
}
