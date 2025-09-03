using System.Runtime.CompilerServices;
using GoFish.Game;
using GoFish.HelperMethods;
using LeaderBoardManager;

namespace GoFish.Menu
{
    enum MenuChoices
    {
        Play,
        Tutorial,
        LeaderBoard,
        Exit
    }
    public class MenuManager(GameManager gameManager, LeaderBoards leaderBoard)
    {
        private readonly GameManager _gameManager = gameManager;
        private readonly LeaderBoards _leaderBoard = leaderBoard;
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

        private static void DisplayMenuOptions()
        {
            Console.WriteLine("1. Play");
            Utils.Pause(200);
            Console.WriteLine("2. Tutorial");
            Utils.Pause(200);
            Console.WriteLine("3. Leaderboard");
            Utils.Pause(200);
            Console.WriteLine("4. Exit");
            Utils.Pause(200);
            Console.Write("\nPlease enter an option from the list: ");
            Utils.Pause(200);
        }

        private void GetMenuChoice()
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
                        Console.WriteLine("\nStarting game...\n");
                        Utils.Pause(200);
                        _gameManager.StartGame();
                        break;

                    case MenuChoices.Tutorial:
                        Console.WriteLine("\nLaunching tutorial...");
                        Utils.Pause(1500);
                        ShowTutorial();
                        break;
                    case MenuChoices.LeaderBoard:
                        Console.WriteLine("\nLoading leaderboard...");
                        Utils.Pause(2000);
                        Console.Clear();
                        ShowLeaderBoard();
                        break;
                    case MenuChoices.Exit:
                        Console.WriteLine("\nExiting game thank you for playing...\n");
                        Utils.Pause(2000);
                        Environment.Exit(0);
                        break;
                }

                break;
            }
        }

        private static void ShowTutorial()
        {
            Console.Clear();
            Console.WriteLine("In go fish a standard deck of 52 playing cards is used.");
            Utils.Pause(200);
            Console.WriteLine("Each player is dealt a hand of cards, in this version a starting hand is 7 cards.");
            Utils.Pause(200);
            Console.WriteLine("The remaining cards are known as the 'fish pile'.");
            Utils.Pause(200);
            Console.WriteLine("Players take turns asking other players for cards.");
            Utils.Pause(200);
            Console.WriteLine("The player asking must have at least one card of the rank they are asking for in their hand.");
            Utils.Pause(200);
            Console.WriteLine("For example if a player wants to ask for 'tens' they need to have at least one ten in their hand.");
            Utils.Pause(200);
            Console.WriteLine("If the player asked has the card, they must give all cards of that rank to the asking player. They also get another turn!");
            Utils.Pause(200);
            Console.WriteLine("If the player asked does not have the card they say 'Go fish!' and then the asking player draws a card from the 'fish pile'.");
            Utils.Pause(200);
            Console.WriteLine("If the drawn card is one they were asking for, they get another turn!");
            Utils.Pause(200);
            Console.WriteLine("\nWhen a player collects a set of four matching cards (a book) they score a point.");
            Utils.Pause(200);
            Console.WriteLine("The game ends when all cards have been collected into books or when the fish pile is empty and no one can make any more matches.");
            Utils.Pause(200);
            Console.WriteLine("The player with the most books(points) wins the game!");
            Console.WriteLine("\nPress the enter key to return to the main menu: ");
            Console.ReadLine();
        }

        public void ShowLeaderBoard()
        {
            Array.Sort(_leaderBoard.lines);
            foreach (string line in _leaderBoard.lines)
            {
                Console.WriteLine(line);
                Utils.Pause(300);
            }
            Console.WriteLine("\nPress the enter key to return to the main menu; ");
            Console.ReadLine();
        }
    }
}