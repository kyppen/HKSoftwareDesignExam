using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.ShoppingList
{
    public class ShoppingListFactory
    {
        public ShoppingList CreateList(string type, string id, string name)
        {
            switch (type)
            {
                case "Regular":
                    return new RegularShoppingList(id, name);
                case "Holiday":
                    return new HolidayShoppingList(id, name);
                default:
                    return null;
            }
        }
    }
}
