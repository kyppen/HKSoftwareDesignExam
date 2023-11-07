namespace SoftwareDesignExam.Entities {
	internal class Cart {

		public int Id { get; set; }

		public int Cart_Id { get; set; }

		public User User { get; set; }

		public Item Item { get; set; }

		public DateTime PurchaceDate { get; set; }

		public int Cart_Item_Quantity { get; set; }

	}
}
