using GoFish.HelperMethods;

namespace GoFish.Menu
{
    enum MenuChoices
    {
        Play,
        Tutorial,
        Exit
    }
    public class MenuManager
    {
        public void MainLoop()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu\n");
                Utils.Pause(500);
                DisplayMenuOptions();
                GetMenuChoice();
            }
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

        public void GetMenuChoice()
        {
            while (true)
            {
                string? input = Console.ReadLine();

                if (!int.TryParse(input, out int menuChoice) || menuChoice < 1 || menuChoice > 3)
                {
                    Console.WriteLine("Please enter a number from the list...");
                    continue;
                }

                MenuChoices choice = (MenuChoices)(menuChoice - 1);

                switch (choice)
                {
                    case MenuChoices.Play:
                        Console.WriteLine("Starting game...");
                        Utils.Pause(200);
                        // Play();
                        break;

                    case MenuChoices.Tutorial:
                        Console.WriteLine("Launching tutorial...");
                        Utils.Pause(200);
                        // ShowTutorial();
                        break;

                    case MenuChoices.Exit:
                        Console.WriteLine("Exiting game thank you for playing...");
                        Utils.Pause(200);
                        Environment.Exit(0);
                        break;
                }

                break;
            }
        }
    }
}
