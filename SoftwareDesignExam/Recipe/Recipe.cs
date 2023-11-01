using SoftwareDesignExam.Items;
using SoftwareDesignExam.ShoppingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareDesignExam.Recipe
{
    public class Recipe
    {
        private string _id;
        private string _name;
        private List<Item> _ingredients;

        public Recipe(string id, string name)
        {
            _id = id;
            _name = name;
            _ingredients = new List<Item>();
        }

        public void Addingredient(Item item)
        {
            _ingredients.Add(item);
        }

        public void AddToList(SoftwareDesignExam.ShoppingList.AbstractShoppingList shoppingList) 
        {
            foreach (var ingredient in _ingredients) 
            {
                shoppingList.AddItem(ingredient);
            }
        }
    }

    
}
