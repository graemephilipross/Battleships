using System;
using System.Linq;
using System.Text.RegularExpressions;
using BattleShips.Models;

namespace BattleShips.Services
{
    class ConsoleInput : IInput
    {
        private static Regex inGameRegex;
        private static Regex tryAgainRegex;

        static ConsoleInput()
        {
            inGameRegex = new Regex(@"^([0-9],)[0-9]$");
            tryAgainRegex = new Regex(@"^[YyNn]$");
        }

        public Coord ReadUserInGameInput()
        {
            var input = Console.ReadLine();
            var match = inGameRegex.Match(input);
            if (match.Success)
            {
                var coords = input.Split(',').Select(int.Parse).ToArray();
                return new Coord(coords[0], coords[1]);
            }
            throw new ArgumentException("Invalid coordinate");
        }

        public bool ReadUserTryAgainInput()
        {
            var input = Console.ReadLine();
            var match = tryAgainRegex.Match(input);
            if (match.Success)
            {
                return (input.Equals("Y") || input.Equals("y"));
            }
            throw new ArgumentException("Invalid option. Please try again");
        }
    }
}
