﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.VisualBasic.CompilerServices;
using SoftwareDesignExam.Entities;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.ShoppingList;


namespace SoftwareDesignExam.UserManagement
{
    public class User : IUser
    {
        private string _userId;
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
        

        public void addItem(StockItem item, int quantity)
        {
            StockItem CartItem = item;
            CartItem.quantity = quantity;
            foreach (var i in shoppingList)
            {
                if (i.name == item.name)
                {
                    i.quantity += item.quantity;
                    Console.WriteLine($"new quantity for {i.name} is {i.quantity}");
                    return;
                }
            }
            
            Console.WriteLine("item has been added");
            shoppingList.Add(CartItem);
            
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
            Console.WriteLine("TESTSTETSTSTETETSTS");
            foreach (var item in shoppingList)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine($"Total: {getTotalPrice()} Nok");
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