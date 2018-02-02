using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;

namespace BattleShips.Input
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

        public int[] ReadUserInGameInput()
        {
            var input = Console.ReadLine();
            var match = inGameRegex.Match(input);
            if (match.Success)
            {
                return input.Split(',').Select(int.Parse).ToArray();
            }
            throw new ArgumentException("Invalid coordinate");
        }

        public bool ReadUserTryAgainInput()
        {
            var input = Console.ReadLine();
            var match = tryAgainRegex.Match(input);
            if (match.Success)
            {
                return (input.Equals('Y') || input.Equals('y'));
            }
            throw new ArgumentException("Invalid option. Please try again");
        }
    }
}
