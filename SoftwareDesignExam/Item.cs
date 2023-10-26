namespace SoftwareDesignExam;

public class Item{
    private string _id;
    private string _name;
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