﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.UIColorController;


namespace SoftwareDesignExam.Items {
    public class StockItem : AbstractItem{
        public long Id { get; set; }
        public long Quantity { get; set; }

        public StockItem(long id, string name, string description, double price, long quantity) : base(id, name, description, price, quantity) {
            this.Quantity = quantity;
            this.Id = id;
        }

        public double CalculatePrice() {
            return this.Quantity*base.price;
        }
        public void PrintItem()
        {
            UIColor.ColorWriteGreen("Name        : ");
            Console.Write($"{name}\n");
            UIColor.ColorWriteGreen("Description : ");
            Console.Write($"{description}\n");
            UIColor.ColorWriteGreen("Price       : ");
            Console.Write($"{price}\n");
            UIColor.ColorWriteGreen("Quantity    : ");
            Console.WriteLine($"{quantity}\n ");
        }

        public override string ToString()
        {
            return $"name: {name} description: {description} price: {price}";
        }
    }
}