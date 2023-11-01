using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.Items;

namespace SoftwareDesignExam.ShoppingList
{
    public class RegularShoppingList : AbstractShoppingList
    {
        private List<Item> _defaultItems;

        public RegularShoppingList(string id, string name) : base(id, name)
        {
            _defaultItems = new List<Item>();
        }

        public override double GetTotalPrice()
        {
            return base.GetTotalPrice();
        }
    }
}
