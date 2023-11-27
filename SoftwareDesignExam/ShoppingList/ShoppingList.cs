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
        protected List<AbstractItem> _items;
        
        public AbstractShoppingList(string id, string name) 
        {
            _id = id;
            _name = name;
            _items = new List<AbstractItem>();
            _creationDate = DateTime.Now;
        }



        public void AddItem(AbstractItem item)
        {
            if(item != null)
                _items.Add(item);
        }

        public void RemoveItem(AbstractItem item)
        {
            if(_items.Contains(item))
                _items.Remove(item);
            else {
				Logger.Instance.LogError("[  Item was not in the list.  ]", new Exception("No item in list exception"));
            }
                
        }

        public List<AbstractItem>? GetItems()
        {
            if (_items == null) {
				Logger.Instance.LogError($"[  Shoppinglist.GetItems _items is NULL ]", new Exception("_items is NULL exeption"));
			}
            else {
				Logger.Instance.LogInformation($"[  Shoppinglist.GetItems _items.Count {_items.Count}  ]");
				return _items;
			}
            return null;
        }

        public virtual double GetTotalPrice()
        {
            return _items.Sum(item => item.price);
        }
        public override string ToString()
        {
            return $"Shopping List: {_name}, Created On: {_creationDate.ToShortDateString()}";
        }

    }
}
