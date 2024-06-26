﻿﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic.CompilerServices;
using SoftwareDesignExam.Controller;
using SoftwareDesignExam.DataAccess;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.ShoppingList;


namespace SoftwareDesignExam.UserManagement
{
    public class User : IUser
    {
        private string _userId { get; }
        private string _userName;
        private string _email;
        private string _password;
        private List<SoftwareDesignExam.Items.AbstractItem> shoppingList;
        public string Username => _userName;

        public User(string userId, string userName, string email)
        {
            _userId = userId;
            _userName = userName;
            _email = email;
            shoppingList = new List<AbstractItem>();

        }

        public long getId()
        {
            var id = long.Parse(_userId);
            return id;
        }

        public SoftwareDesignExam.ShoppingList.AbstractShoppingList CreateList()
        {
            var id = Guid.NewGuid().ToString();
            var name = $"{_userName}-List";
            return new RegularShoppingList(id, name);
        }

        public override string ToString() {
            return $"User Id: {_userId}\n" +
                $"User Name: {_userName}\n" +
                $"User Email: {_email}\n" ;
        }

        public void emptyCart()
        {
            shoppingList.Clear();
        }
        

        public void addItem(StockItem item, int quantity)
        {
			SqLiteStockDataAccess sqlda = new SqLiteStockDataAccess();
			StockController sc = new StockController(sqlda);
			StockItem CartItem = item;
            CartItem.quantity = quantity;
            foreach (var i in shoppingList)
            {
                if (i.name == item.name)
                {
                    var something = sc.GetByMatchingString(item.name);
                    var wantedQuantity = i.quantity + item.quantity;
                    Console.WriteLine("wanted quantity : " + wantedQuantity);
                    if (wantedQuantity < something[0].Quantity)
                    {
                        i.quantity = wantedQuantity;
                        Console.Clear();
                        Console.WriteLine($"new quantity for {i.name} is {i.quantity}");
                        return;
                    }
                    Console.WriteLine("Not enough in stock");
                    return;
                }
            }
            
            shoppingList.Add(CartItem);
            Console.Clear();
            Console.WriteLine(CartItem.name + " has been added to cart");
            
        }

        public void RemoveItem(AbstractItem item)
        {
            shoppingList.Remove(item);
        }

        public List<AbstractItem> getShoppingList()
        {
            return shoppingList;
        }

        public void printAll(){
            if (shoppingList.Count == 0)
            {
                Console.WriteLine("Shoppinglist is currently empty, add an item!");
                return;
            }
            foreach (var item in shoppingList)
            {
                item.PrintItem();
            }
            Console.WriteLine($"Total: {getTotalPrice()} Nok\n");
        }

        public double getTotalPrice()
        {
            double totalPrice = 0;
            foreach (var item in shoppingList)
            {
                totalPrice += item.price * item.quantity;
            }

            return totalPrice;
        }
    }
   
}