﻿using System.Collections.Generic;

namespace BlackJack.view
{
    interface IView
    {
        void DisplayWelcomeMessage();
        Input GetInput();
        void DisplayCard(model.Card a_card);
        void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score);
        void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score);
        void DisplayGameOver(bool a_dealerIsWinner);
    }
}
