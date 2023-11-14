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
        private List<AbstractItem> _defaultItems;

        public RegularShoppingList(string id, string name) : base(id, name)
        {
            _defaultItems = new List<AbstractItem>();
        }

        public override double GetTotalPrice()
        {
            return base.GetTotalPrice();
        }
    }
}
