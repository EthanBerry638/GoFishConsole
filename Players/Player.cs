using GoFish.Game;
using GoFish.GameCards;

namespace GoFish.Players
{
    public class Player (DeckManager deckManager)
    {
        private readonly DeckManager _deckManager = deckManager;
        private List<Card> PlayerHand = new List<Card>();

        public void CreateStartingHand()
        {
            _deckManager.GetDeckSize();
        }
    }
}