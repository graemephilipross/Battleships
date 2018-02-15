using System;
using System.Linq;
using System.Collections.Generic;
using Autofac;
using BattleShips.Container;
using BattleShips.Game;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var container = ContinerSetup.CreateContainer().Build())
            {
                container.Resolve<GameManager>().GameDriver();
            }
        }
    }
}
