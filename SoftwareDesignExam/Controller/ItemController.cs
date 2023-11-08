using SoftwareDesignExam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SoftwareDesignExam.Controller
{
    public class ItemController
    {
        public static void printItem()
        {
            List<Item> itemlist = DatabaseHandler.Methods.ReadAllItemsFromItemTable.Read();
            foreach (Item item in itemlist) {
                Console.WriteLine(item.Item_Name);
            }
        }

        public static void printUserSelectItem(string searchItem)
        {
            List<Item> itemlist = DatabaseHandler.Methods.ReadAllItemsFromItemTable.Read();
            foreach (Item item in itemlist)
            {
                if (item.Item_Name.Contains(searchItem))
                {
                    Console.WriteLine(item.Item_Name);
                }
                
            }
        }

    }
}
