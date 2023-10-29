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

        public override double CalculatePrice()
        {
            return _item.GetPrice() * (1 - _discount / 100);
        }

        public override string GetDescription()
        {
            return $"{_item.GetName()} (Discounted by {_discount}%)";
        }
    }
}
