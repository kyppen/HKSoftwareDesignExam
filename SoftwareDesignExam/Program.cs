namespace SoftwareDesignExam;
class Program{
    static public void Main(String[] args)
    {
        //
        
        Console.WriteLine("Starting program!");
        Item item0 = new("0", "bread","baked wares", 6.1);
        Item item1 = new("0", "bread","baked wares", 6.1);
        Item item2 = new("0", "bread","baked wares", 6.1);
        Item item3 = new("0", "bread","baked wares", 6.1);
        
        Console.WriteLine(item0.ToString());

        Recipe recipe = new("3", "myList");
        recipe.addItem(item0);
        recipe.addItem(item1);
        recipe.addItem(item2);
        recipe.addItem(item3);
        recipe.ToString();
    }
}