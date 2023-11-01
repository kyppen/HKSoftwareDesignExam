using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.Items;
using SoftwareDesignExam.Logging;

namespace SoftwareDesignExam.ShoppingList
{
    public abstract class AbstractShoppingList
    {
        
        protected string _id;
        protected string _name;
        protected DateTime _creationDate;
        protected List<Item> _items;
        protected Logger _logger;

        
        public AbstractShoppingList(string id, string name) 
        {
            _id = id;
            _name = name;
            _items = new List<Item>();
            _creationDate = DateTime.Now;
            _logger = Logger.GetInstance();
        }



        public void AddItem(Item item)
        {
            if(item != null)
                _items.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if(_items.Contains(item))
                _items.Remove(item);
            else
            {
                _logger.Log("Item was not in the list.");
            }
                
        }

        public List<Item> GetItems()
        {
            return _items;
        }
        public override string ToString()
        {
            return $"Shopping List: {_name}, Created On: {_creationDate.ToShortDateString()}";
        }

    }
}
