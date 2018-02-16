namespace BattleShips.Input
{
    interface IInput
    {
        int[] ReadUserInGameInput();
        bool ReadUserTryAgainInput();
    }
}
