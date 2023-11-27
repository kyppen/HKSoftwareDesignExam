using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.UIColorController;

namespace SoftwareDesignExam.Items {
    public abstract class AbstractItem {
        public long id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public long quantity { get; set; }

        public AbstractItem(long id, string name, string description, double price, long quantity) {
            this.id = id;
            this.name = name;
            this.description = description;
            this.price = price;
            this.quantity = quantity;
        }

        protected AbstractItem(string name, string description, double price) {
            this.name = name;
            this.description = description;
            this.price = price;
        }
        public void printItem()
        {
            UIColor.ColorWriteGreen("Name        : ");
            Console.Write($"{name}\n");
            UIColor.ColorWriteGreen("Description : ");
            Console.Write($"{description}\n");
            UIColor.ColorWriteGreen("Price       : ");
            Console.Write($"{price}\n");
            UIColor.ColorWriteGreen("Quantity    : ");
            Console.Write($"{quantity}\n");
            Console.WriteLine();
        }
    }
}