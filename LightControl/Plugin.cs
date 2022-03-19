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
    using Server = Exiled.Events.Handlers.Server;
    using Warhead = Exiled.Events.Handlers.Warhead;

    /// <summary>
    /// The main plugin class.
    /// </summary>
    public class Plugin : Plugin<Config>
    {
        private EventHandler eventHandler;

        /// <inheritdoc />
        public override string Name => "Light Control";

        /// <inheritdoc />
        public override string Author => "Marco15453";

        /// <inheritdoc />
        public override Version Version => new Version(1, 4, 0);

        /// <inheritdoc />
        public override Version RequiredExiledVersion => new Version(5, 0, 0);

        /// <inheritdoc />
        public override void OnEnabled()
        {
            if (!CheckConfig())
            {
                Log.Error("ZoneType Surface detected! This plugin will not be enabled due to Exiled or Base Game bug.");
                return;
            }

            eventHandler = new EventHandler(this);

            // Server
            Server.RoundStarted += eventHandler.OnRoundStarted;

            // Warhead
            Warhead.Stopping += eventHandler.OnStopping;
            Warhead.Detonated += eventHandler.OnDetonated;

            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            // Server
            Server.RoundStarted += eventHandler.OnRoundStarted;

            // Warhead
            Warhead.Stopping += eventHandler.OnStopping;
            Warhead.Detonated += eventHandler.OnDetonated;

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
