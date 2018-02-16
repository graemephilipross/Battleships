using BattleShips.Models.Ships;
using BattleShips.Models.Board;

namespace BattleShips.Output
{
    interface IOutput
    {
        void GameStartMessage();
        void PlayerTurnMessage(IBoard battlefield);
        void HitSuccessMessage(IShip ship);
        void HitMissMessage();
        void GameCompleteMessage();
        void PlayAgainMessage();
        void ErrorMessage(ErrorOutput err);
    }
}
