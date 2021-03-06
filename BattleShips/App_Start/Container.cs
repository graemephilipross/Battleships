﻿using System;
using System.Collections.Generic;
using Autofac;

using BattleShips.Models;
using BattleShips.Services;
using BattleShips.Game;

namespace BattleShips.App_Start
{
    static class Container
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

            builder.RegisterType<ConsoleInput>().As<IInput>().InstancePerLifetimeScope(); ;
            builder.RegisterType<ConsoleOutput>().As<IOutput>().InstancePerLifetimeScope(); ;

            builder.Register(c => new Board(c.Resolve<IShipPlacement>(), shipConfig)).As<IBoard>().InstancePerLifetimeScope(); ;
            builder.RegisterType<ShipPlacement>().As<IShipPlacement>().InstancePerLifetimeScope(); ;
            builder.RegisterType<Player>().As<IPlayer>().InstancePerLifetimeScope().InstancePerLifetimeScope(); ;

            builder.RegisterType<Start>().Keyed<IProcessState>(GameState.Setup).InstancePerLifetimeScope();
            builder.RegisterType<InPlay>().Keyed<IProcessState>(GameState.InPlay).InstancePerLifetimeScope();
            builder.RegisterType<Complete>().Keyed<IProcessState>(GameState.Complete).InstancePerLifetimeScope();

            builder.Register<Func<GameState, IProcessState>>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return state => context.ResolveKeyed<IProcessState>(state);
            });

            builder.RegisterType<GameService>().InstancePerLifetimeScope();

            return builder;
        }
    }
}
