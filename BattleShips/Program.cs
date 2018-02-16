using Autofac;
using BattleShips.Container;
using BattleShips.Services;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContinerSetup.CreateContainer().Build();
            using (var session = container.BeginLifetimeScope())
            {
                session.Resolve<GameService>().Play();
            }
        }
    }
}
