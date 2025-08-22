using GoFish.GameCards;
using GoFish.Players;

namespace GoFish.Game
{
    public class GameManager(DeckManager deckManager, Player player, AI ai)
    {
        private readonly Player _player = player;
        private readonly AI _ai = ai;
        private readonly DeckManager _deckManager = deckManager;
        public void StartGame()
        {
            _deckManager.GenerateDefaultDeck();
            _player.CreateStartingHand();
            _ai.CreateStartingHand();

            _player.GetPlayerName();
        }
    }
}