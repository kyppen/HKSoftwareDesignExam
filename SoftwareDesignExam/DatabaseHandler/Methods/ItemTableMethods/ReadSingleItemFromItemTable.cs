using SoftwareDesignExam.DataAccess.SqLite;
using SoftwareDesignExam.Entities;

namespace SoftwareDesignExam.DatabaseHandler.Methods.ItemTableMethods
{
    public class ReadSingleItemFromItemTable
    {
        public static List<Item> Read(String name) {
			using StoreDbContext dbContext = new StoreDbContext();
			var Items = dbContext.Item.Where(x => x.Item_Name.ToLower() == name.ToLower()).ToList();

			return Items;
		}
	}
}
