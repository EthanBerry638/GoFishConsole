using GoFish.GameCards;

namespace GoFish.Game
{
    public class GameManager
    {
        public void StartGame()
        {
            DeckManager deckManager = new DeckManager();
            deckManager.GenerateDefaultDeck();
        }
    }
}