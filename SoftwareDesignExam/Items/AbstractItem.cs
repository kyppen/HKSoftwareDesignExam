using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Items
{
    public abstract class AbstractItem
    {
        protected string _name;
        protected double _price;

        public abstract string GetName();

        public abstract double GetPrice();

    }
}
