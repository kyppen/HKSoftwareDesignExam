using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Items
{
    public class AbstractItem
    {
        protected string _name;
        protected double _price;

        public string GetName()
        {
            return _name;
        }

        public double GetPrice()
        {
            return _price;
        }
    }
}
