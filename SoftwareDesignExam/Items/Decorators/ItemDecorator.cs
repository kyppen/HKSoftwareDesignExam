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

        public abstract double CalculatePrice();
        public abstract string GetDescription();
    }
}
