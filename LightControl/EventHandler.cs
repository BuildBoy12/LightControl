// -----------------------------------------------------------------------
// <copyright file="EventHandler.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LightControl
{
    using System.Linq;
    using Exiled.API.Enums;
    using Exiled.API.Features;
    using Exiled.Events.EventArgs;
    using LightControl.Models;
    using UnityEngine;

    /// <summary>
    /// Handles events derived from <see cref="Exiled.Events.Handlers"/>.
    /// </summary>
    public class EventHandler
    {
        private readonly Plugin plugin;

        /// <summary>
        /// Initializes a new instance of the <see cref="EventHandler"/> class.
        /// </summary>
        /// <param name="plugin">An instance of the <see cref="Plugin"/> class.</param>
        public EventHandler(Plugin plugin) => this.plugin = plugin;

        /// <inheritdoc cref="Exiled.Events.Handlers.Server.OnRoundStarted"/>
        public void OnRoundStarted()
        {
            SetRoomColors();
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Warhead.OnStopping(StoppingEventArgs)"/>
        public void OnStopping(StoppingEventArgs ev)
        {
            SetRoomColors();
        }

        /// <inheritdoc cref="Exiled.Events.Handlers.Warhead.OnDetonated"/>
        public void OnDetonated()
        {
            SetRoomColors();
        }

        private void SetRoomColors()
        {
            if (plugin.Config.Zones.Count > 0)
            {
                foreach ((ZoneType type, Colors color) in plugin.Config.Zones)
                    foreach (Room room in Room.Get(type))
                        room.Color = new Color(color.Red / 255f, color.Green / 255f, color.Blue / 255f);
            }

            if (plugin.Config.Rooms.Count > 0)
            {
                foreach ((RoomType type, Colors color) in plugin.Config.Rooms)
                    foreach (Room room in Room.List.Where(x => x.Type == type))
                        room.Color = new Color(color.Red / 255f, color.Green / 255f, color.Blue / 255f);
            }
        }
    }
}
