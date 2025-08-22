using GoFish.GameCards;

namespace GoFish.Game
{
    public class DeckManager (Random sharedRandom)
    {
        private readonly Random _sharedRandom = sharedRandom;
        public List<Card> deck = new List<Card>();
        public int deckSize;

        public void GenerateDefaultDeck()
        {
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank rank in Enum.GetValues(typeof(Rank)))
                {
                    deck.Add(new Card(suit, rank));
                }
            }
        }

        public void ViewDeck()
        {
            foreach (Card card in deck)
            {
                Console.WriteLine(card);
            }
        }

        public int GetDeckSize()
        {
            return deckSize = deck.Count();
        }

        public Card? DrawRandomCard()
        {
            if (deck.Count == 0) return null;

            int index = _sharedRandom.Next(deck.Count);
            Card card = deck[index];
            deck.RemoveAt(index);
            return card;
        }
    }
}