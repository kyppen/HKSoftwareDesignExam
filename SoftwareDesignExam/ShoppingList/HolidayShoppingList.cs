using SoftwareDesignExam.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SoftwareDesignExam.ShoppingList
{
    public class HolidayShoppingList : AbstractShoppingList
    {
        private List<Item> _defaultItems;

        public HolidayShoppingList(string id, string name) : base(id, name)
        {
            _defaultItems = new List<Item>();
        }
    }
}
