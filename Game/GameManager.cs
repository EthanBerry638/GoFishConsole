using GoFish.GameCards;

namespace GoFish.Game
{
    public class GameManager(DeckManager deckManager)
    {
        private readonly DeckManager _deckManager = deckManager;
        public void StartGame()
        {
            _deckManager.GenerateDefaultDeck();
        }
    }
}