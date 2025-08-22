using GoFish.Game;
using GoFish.GameCards;

namespace GoFish.Players
{
    public class Player(DeckManager deckManager, Random sharedRandom)
    {
        private readonly DeckManager _deckManager = deckManager;
        private readonly Random _sharedRandom = sharedRandom;
        private List<Card> PlayerHand = new List<Card>();

        public void CreateStartingHand()
        {
            for (int i = 0; i < 7; i++)
            {
                Card card = _deckManager.DrawRandomCard();
                if (card != null)
                {
                    PlayerHand.Add(card);
                }
            }
        }

        public void ViewHand()
        {
            foreach (Card card in PlayerHand)
            {
                Console.WriteLine(card);
            }
        }
    }
}