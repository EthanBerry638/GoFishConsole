using GoFish.GameCards;
using GoFish.Players;

namespace GoFish.Game
{
    public class GameManager(DeckManager deckManager, Player player)
    {
        private readonly Player _player = player;
        private readonly DeckManager _deckManager = deckManager;
        public void StartGame()
        {
            _deckManager.GenerateDefaultDeck();
            Console.WriteLine(_deckManager.GetDeckSize());
            _player.CreateStartingHand();
        }
    }
}