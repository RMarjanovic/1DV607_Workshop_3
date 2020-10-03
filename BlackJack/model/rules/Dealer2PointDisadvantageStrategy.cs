namespace BlackJack.model.rules
{
    class Dealer2PointDisadvantageStrategy : IWinCondition
    {
        public bool IsDealerWinner(Player a_player, Dealer a_dealer, int g_maxScore)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (a_dealer.CalcScore() > g_maxScore)
            {
                return false;
            }
            return a_dealer.CalcScore() -2 > a_player.CalcScore();
        }
    }
}
