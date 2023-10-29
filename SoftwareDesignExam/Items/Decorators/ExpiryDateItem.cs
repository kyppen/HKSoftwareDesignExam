using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Items.Decorators
{
    public class ExpiryDateItem : ItemDecorator
    {
        private DateTime _expiryDate;

        public ExpiryDateItem(AbstractItem item, DateTime expiryDate) : base(item) 
        {
            _expiryDate = expiryDate;
        }

        public override double CalculatePrice()
        {
            return _item.GetPrice();
        }

        public override string GetDescription()
        {
            return $"{_item.GetName()} (Expires on {_expiryDate.ToShortDateString()})";
        }

    }
}
