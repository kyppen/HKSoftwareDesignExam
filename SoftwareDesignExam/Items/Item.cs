namespace SoftwareDesignExam.Items;

public class Item : AbstractItem
{
    private string _id;
    private string _name;

    // Not sure we need this variable or not yet
    private string _category;
    private double _price;

    public string Id => _id;
    public string Name => _name;
    public double Price => _price;

    public Item(string id, string name, double price)
    {
        _id = id;
        _name = name;
        _price = price;
    }

    public override string GetName() => _name;

    public override double GetPrice() => _price;

    public override string ToString()
    {
        return $"Id: {_id}, Name: {_name}, Price: {GetPrice(): 0.00}";
    }
}