using System;
using System.Collections.Generic;
using Autofac;

using BattleShips.Input;
using BattleShips.Output;
using BattleShips.Models.GameState;
using BattleShips.Game;
using BattleShips.Models.ShipConfig;
using BattleShips.Models.Board;
using BattleShips.Services.ShipPlacement;
using BattleShips.Models.Player;

namespace BattleShips.Container
{
    static class ContinerSetup
    {
        private static ShipSetup CreateShipConfig()
        {
            var destroyerInfo = new ShipInfo()
            {
                Size = 4,
                Quantity = 2
            };

            var cruiserInfo = new ShipInfo()
            {
                Size = 3,
                Quantity = 2
            };

            var shipConfig = new ShipSetup();
            shipConfig.Ships = new Dictionary<ShipType, ShipInfo>()
            {
                { ShipType.Destoryer, destroyerInfo },
                { ShipType.Cruiser, cruiserInfo }
            };

            return shipConfig;
        }

        public static ContainerBuilder CreateContainer()
        {
            var builder = new ContainerBuilder();
            var shipConfig = CreateShipConfig();

            builder.RegisterType<ConsoleInput>().As<IInput>();
            builder.RegisterType<ConsoleOutput>().As<IOutput>();

            builder.RegisterType<Board>().As<IBoard>();
            builder.RegisterType<ShipPlacement>().As<IShipPlacement>();
            builder.Register(c => new Player(c.Resolve<IShipPlacement>(), c.Resolve<IBoard>(), shipConfig)).As<IPlayer>().InstancePerLifetimeScope();

            builder.RegisterType<GameStart>().Keyed<IProcessState>(GameState.Setup).InstancePerLifetimeScope();
            builder.RegisterType<GameInPlay>().Keyed<IProcessState>(GameState.InPlay).InstancePerLifetimeScope();
            builder.RegisterType<GameFinished>().Keyed<IProcessState>(GameState.Complete).InstancePerLifetimeScope();

            builder.Register<Func<GameState, IProcessState>>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return state => context.ResolveKeyed<IProcessState>(state);
            });

            builder.RegisterType<GameStateManager>();
            builder.RegisterType<GameManager>();

            return builder;
        }
    }
}
