using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.Items;

namespace SoftwareDesignExam.ShoppingList
{
    public abstract class ShoppingList
    {
        protected string _id;
        protected string _name;
        protected DateTime _creationDate;
        protected List<Item> _items;

        public ShoppingList(string id, string name) 
        {
            _id = id;
            _name = name;
            _items = new List<Item>();
            _creationDate = DateTime.Now;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            _items.Remove(item);
        }

        public List<Item> GetItems()
        {
            return _items;
        }

    }
}
