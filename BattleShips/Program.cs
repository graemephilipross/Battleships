using Autofac;
using BattleShips.Container;
using BattleShips.Game;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContinerSetup.CreateContainer().Build();
            using (var session = container.BeginLifetimeScope())
            {
                session.Resolve<GameManager>().GameDriver();
            }
        }
    }
}
