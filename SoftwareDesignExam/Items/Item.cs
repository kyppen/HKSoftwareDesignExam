namespace SoftwareDesignExam.Items;

public class Item
{
    private string _id;
    private string _name;

    // Not sure we need this variable or not yet
    private string _category;
    private double _price;

    public Item(string id, string name, double price)
    {
        _id = id;
        _name = name;
        _price = price;
    }

    public string ToString()
    {
        return $"price: {_price}, Name: {_name}, Id: {_id}";
    }
}