using BlackJack.view;
using BlackJack.model;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame: IHitObserver
    {
        private model.Game _a_game;
        private view.IView _a_view;
        public bool Play()
        {
            _a_game.Subscribe(this);

            DealtCard();

            if (_a_game.IsGameOver())
            {
                _a_view.DisplayGameOver(_a_game.IsDealerWinner());
            }

            Input input = _a_view.GetInput();

            switch(input)
            {
                case Input.Play:
                    _a_game.NewGame();
                    break;
                case Input.Hit:
                    _a_game.Hit();
                    break;
                case Input.Stand:
                    _a_game.Stand();
                    break;
            }
            return input != Input.Quit;;
        }

        public void DealtCard()
        {
            Thread.Sleep(1000); //Wait for one second
            _a_view.DisplayWelcomeMessage();

            _a_view.DisplayDealerHand(_a_game.GetDealerHand(), _a_game.GetDealerScore());
            _a_view.DisplayPlayerHand(_a_game.GetPlayerHand(), _a_game.GetPlayerScore());
        }

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            _a_game = a_game;
            _a_view = a_view;
        }
    }
}
