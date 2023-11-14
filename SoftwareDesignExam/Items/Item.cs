using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Items {
    public class Item : AbstractItem {
        public Item(string name, string description, double price) : base(name, description, price) {
        }
    }
}