using BlackJack.view;
using BlackJack.model;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame: IHitObserver
    {
        private model.Game m_game;
        private view.IView m_view;
        public bool Play()
        {
            m_game.Subscribe(this);

            DealtCard();

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }

            Input input = m_view.GetInput();

            switch(input)
            {
                case Input.Play:
                    m_game.NewGame();
                    break;
                case Input.Hit:
                    m_game.Hit();
                    break;
                case Input.Stand:
                    m_game.Stand();
                    break;
            }
            return input != Input.Quit;;
        }

        public void DealtCard()
        {
            Thread.Sleep(2000); //Wait for two seconds
            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
        }

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;
        }
    }
}
