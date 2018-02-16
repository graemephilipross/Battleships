using Autofac;
using BattleShips.App_Start;
using BattleShips.Services;

namespace BattleShips
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = Container.CreateContainer().Build();
            using (var session = container.BeginLifetimeScope())
            {
                session.Resolve<GameService>().Play();
            }
        }
    }
}
