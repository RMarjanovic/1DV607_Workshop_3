namespace BlackJack.model.rules
{
    interface IWinCondition
    {
        bool IsDealerWinner(Player a_player, Dealer a_dealer, int g_maxScore);
    }
}
