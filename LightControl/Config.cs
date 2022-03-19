// -----------------------------------------------------------------------
// <copyright file="Config.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LightControl
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using Exiled.API.Interfaces;
    using LightControl.Models;

    /// <inheritdoc />
    public sealed class Config : IConfig
    {
        /// <inheritdoc />
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets what rooms should have what color.
        /// </summary>
        [Description("What Rooms should have what Color, See Room Example Config for the Format (If empty it will be ignored)")]
        public List<RoomSettings> Rooms { get; set; } = new List<RoomSettings>();

        /// <summary>
        /// Gets or sets what zones should have what color.
        /// </summary>
        [Description("What Zones should have what Color, See Zone Example Config for the Format (If empty it will be ignored)")]
        public List<ZoneSettings> Zones { get; set; } = new List<ZoneSettings>();
    }
}
