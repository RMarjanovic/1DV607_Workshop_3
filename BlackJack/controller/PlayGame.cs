using BlackJack.view;

namespace BlackJack.controller
{
    class PlayGame
    {
        public bool Play(model.Game a_game, view.IView a_view)
        {
            a_view.DisplayWelcomeMessage();
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            Input input = a_view.GetInput();

            switch(input)
            {
                case Input.Play:
                    a_game.NewGame();
                    break;
                case Input.Hit:
                    a_game.Hit();
                    break;
                case Input.Stand:
                    a_game.Stand();
                    break;
            }
            return input != Input.Quit;;
        }
    }
}
