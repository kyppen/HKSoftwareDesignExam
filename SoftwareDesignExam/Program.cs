namespace SoftwareDesignExam;
class Program{
    static public void Main(String[] args)
    {
        Console.WriteLine("Starting program!");
        Item item = new("0", "bread", 6.1);
        Console.WriteLine(item.ToString());
    }
}