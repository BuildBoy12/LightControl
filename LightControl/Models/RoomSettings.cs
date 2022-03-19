// -----------------------------------------------------------------------
// <copyright file="RoomSettings.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LightControl.Models
{
    using Exiled.API.Enums;

    public class RoomSettings
    {
        public RoomType Room { get; set; }

        public Colors Color { get; set; }

        public void Deconstruct(out RoomType type, out Colors color)
        {
            type = Room;
            color = Color;
        }
    }
}