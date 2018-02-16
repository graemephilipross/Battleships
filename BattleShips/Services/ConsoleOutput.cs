using System;
using BattleShips.Models.Ships;
using BattleShips.Models;

namespace BattleShips.Services
{
    class ConsoleOutput : IOutput
    {
        public void GameStartMessage()
        {
            Console.WriteLine($"Welcome to Graeme's Battleships. Good Luck!");
        }

        public void PlayerTurnMessage(IBoard battlefield)
        {
            Console.WriteLine($"Please enter a coordinate between 0 - {battlefield.Width - 1}, 0 - {battlefield.Height - 1}");
        }

        public void HitSuccessMessage(IShip ship)
        {
            Console.WriteLine($"You hit a {ship.Name}. This ship has {ship.IntactCoords()} coords left");
        }

        public void HitMissMessage()
        {
            Console.WriteLine($"You missed. Please try again");
        }

        public void GameCompleteMessage()
        {
            Console.WriteLine($"Game complete! You have sunk all ships");
        }

        public void ErrorMessage(ErrorOutput err)
        {
            Console.WriteLine($"{err.Message}");
        }

        public void PlayAgainMessage()
        {
            Console.WriteLine("Play again? Y / N");
        }
    }
}
