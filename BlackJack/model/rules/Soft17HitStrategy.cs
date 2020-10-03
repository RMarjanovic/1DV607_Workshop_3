using System.Collections.Generic;

namespace BlackJack.model.rules
{
    class Soft17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            if(a_dealer.CalcScore() == g_hitLimit)
            {
                List<Card> handOfCards = (List<Card>)a_dealer.GetHand();
                bool dealerHasAce = false;

                handOfCards.ForEach(card => {
                    if(card.GetValue() == Card.Value.Ace)
                    {
                        dealerHasAce = true;
                    }
                });

                if(dealerHasAce) return true;
            }
            return a_dealer.CalcScore() < g_hitLimit;
        }
    }
}