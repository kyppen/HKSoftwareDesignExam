using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Items.Decorators
{
    public class DiscountedItem : ItemDecorator
    {
        private double _discount;

        public DiscountedItem(AbstractItem item, double discount) : base(item)
        {
            _discount = discount;
        }

        public override double GetPrice()
        {
            return base.GetPrice() * (1 - _discount / 100);
        }

        public override string GetName()
        {
            return $"{base.GetName()} (Discounted by {_discount}%)";
        }

        public override string ToString()

        {
            // Cast the decorated item (_item) to the type "Item"
            // This is to check if the underlying decorated item is of type "Item"
            // so we can directly access its properties like Id and Name
            var item = _item as Item;
            if (item != null)
            {
                return $"Id: {item.Id}, Name: {item.Name}, Price: {GetPrice():0.00} (Discounted by {_discount}%)";
            }
            return base.ToString();

        }
    }
}
