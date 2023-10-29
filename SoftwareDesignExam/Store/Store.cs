using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareDesignExam.Items;

namespace SoftwareDesignExam.Store
{
    public class Store
    {
        private string _id;
        private string _name;
        private string _location;
        private List<Item> _itemAvailable;

        public Store(string id, string name, string location) 
        {
            _id = id;
            _name = name;
            _location = location;
            _itemAvailable = new List<Item>();
        }

        public List<Item> GetAvailableItems()
        {
            return _itemAvailable;
        }
    }
}
