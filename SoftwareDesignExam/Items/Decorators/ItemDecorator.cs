using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Items.Decorators
{
    public abstract class ItemDecorator : AbstractItem
    {
        protected AbstractItem _item;

        public ItemDecorator(AbstractItem item)
        {
            _item = item;
        }

        public override double GetPrice()
        {
            return _item.GetPrice();
        }
        public override string GetName()
        {
            return _item.GetName();
        }

        public override string ToString()
        {
            return _item.ToString();
        }
    }
}
