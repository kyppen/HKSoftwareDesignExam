namespace SoftwareDesignExam.Entities {
	internal class Cart {

		public long Id { get; set; }

		public long Cart_Id { get; set; }

		public long User_Id { get; set; }

		public long Item_Id { get; set; }

		public long Item_Quantity { get; set; }

		public double Item_Price { get; set; }

		public DateTime PurchaceDate { get; set; }
	}
}
