// -----------------------------------------------------------------------
// <copyright file="Plugin.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LightControl
{
    using System;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using ServerHandlers = Exiled.Events.Handlers.Server;
    using WarheadHandlers = Exiled.Events.Handlers.Warhead;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandler eventHandler;

        /// <inheritdoc />
        public override string Author => "Build";

        /// <inheritdoc />
        public override Version RequiredExiledVersion { get; } = new Version(5, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            if (!CheckConfig())
            {
                Log.Error("ZoneType Surface detected! This plugin will not be enabled due to Exiled or Base Game bug.");
                return;
            }

            eventHandler = new EventHandler(this);

            ServerHandlers.RoundStarted += eventHandler.OnRoundStarted;

            WarheadHandlers.Stopping += eventHandler.OnStopping;
            WarheadHandlers.Detonated += eventHandler.OnDetonated;

            base.OnEnabled();
        }

        /// <inheritdoc />
        public override void OnDisabled()
        {
            ServerHandlers.RoundStarted += eventHandler.OnRoundStarted;

            WarheadHandlers.Stopping += eventHandler.OnStopping;
            WarheadHandlers.Detonated += eventHandler.OnDetonated;

            eventHandler = null;

            base.OnDisabled();
        }

        private bool CheckConfig()
        {
            foreach ((ZoneType type, _) in Config.Zones)
            {
                if (type == ZoneType.Surface)
                    return false;
            }

            return true;
        }
    }
}
