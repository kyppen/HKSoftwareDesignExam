﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Entities {
	internal class Stock {
		public int Id { get; set; }

		public Item Item { get; set; }

		public int Quantity { get; set; }
	}
}
