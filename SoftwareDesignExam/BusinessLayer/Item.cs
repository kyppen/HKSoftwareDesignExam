namespace SoftwareDesignExam;

public class Item{
    private string _id;
    private string _name;
    private string _category;
    private double _price;

    public Item(string id, string name, string category, double price)
    {
        _id = id;
        _name = name;
        _category = category;
        _price = price;
    }

    public string ToString()
    {
        return $"price: {_price}\nName: {_name}\nCategory: {_category}\nId: {_id}";
    }
}