using GoFish.Game;
using GoFish.GameCards;

namespace GoFish.Players
{
    public class Player (DeckManager deckManager, Random sharedRandom)
    {
        private readonly DeckManager _deckManager = deckManager;
        private readonly Random _sharedRandom = sharedRandom;
        private List<Card> PlayerHand = new List<Card>();

        public void CreateStartingHand()
        {
            _deckManager.GetDeckSize();
        }
    }
}