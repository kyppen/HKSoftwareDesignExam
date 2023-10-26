namespace SoftwareDesignExam;

public class Recipe{
    private string _id;
    private string _name;
    public List<Item> ItemList = new List<Item>();

    public Recipe(string id, string name)
    {
        _id = id;
        _name = name;
    }

    public void addItem(Item item) //takes inn a shoppinglist and add the item
    {
        if (item != null)
        {
            ItemList.Add(item);
            Console.WriteLine("Item has been added");
        }
    }

    public void ToString()
    {
        //Console.WriteLine(name);
        foreach (var item in ItemList)
        {
               Console.WriteLine(item.ToString());
        }
    }
}