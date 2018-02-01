using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace BattleShips.Input
{
    class ConsoleInput : IInput
    {
        private static Regex regex;

        static ConsoleInput()
        {
            regex = new Regex(@"^([0-9],)[0-9]$");
        }

        public string ReadUserInput()
        {
            var input = Console.ReadLine();
            var match = regex.Match(input);
            if (match.Success)
            {
                return input;
            }
            throw new ArgumentException("Invalid coordinate");
        }
    }
}
