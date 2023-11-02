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

        public override string GetName()
        {
            return $"{base.GetName()} (Expires on {_expiryDate.ToShortDateString()})";
        }

        public override string ToString()
        {
            return base.ToString() + $" Expires on: {_expiryDate.ToShortDateString()}";
        }

    }
}
