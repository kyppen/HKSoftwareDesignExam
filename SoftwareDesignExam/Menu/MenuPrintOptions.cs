namespace SoftwareDesignExam.Menu;

public class MenuPrintOptions{
    public void GuestMainMenu()
    {
        Console.WriteLine("1: See all wares\n" +
                          "2: Search for item\n" +
                          "3: Login\n" +
                          "4: Sign up");
    }

    public void UserMainMenu()
    {
        Console.WriteLine("1: See all wares \n" +
                          "2: Search for item\n" +
                          "3: Add wares to cart\n" +
                          "4: Remove ware from cart\n" +
                          "5: Add recipe to cart\n" +
                          "6: Remove recipe from cart\n" +
                          "7: View cart\n" +
                          "8: Log out");
    }
    
}