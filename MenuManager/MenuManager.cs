using GoFish.HelperMethods;

namespace GoFish.Menu
{
    public class MenuManager
    {
        public void MainLoop()
        {
            Console.Clear();
            Console.WriteLine("Main Menu\n");
            Utils.Pause(500);
            DisplayMenuOptions();
        }

        public void DisplayMenuOptions()
        {
            Console.WriteLine("1. Play");
            Utils.Pause(200);
            Console.WriteLine("2. Tutorial");
            Utils.Pause(200);
            Console.WriteLine("3. Exit");
            Utils.Pause(200);
            Console.WriteLine("\nPlease enter an option from the list: ");
            Utils.Pause(200);
        }
    }
}