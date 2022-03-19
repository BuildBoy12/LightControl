// -----------------------------------------------------------------------
// <copyright file="ZoneSettings.cs" company="Build">
// Copyright (c) Build. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace LightControl.Models
{
    using Exiled.API.Enums;

    public class ZoneSettings
    {
        public ZoneType Zone { get; set; }

        public Colors Color { get; set; }

        public void Deconstruct(out ZoneType type, out Colors color)
        {
            type = Zone;
            color = Color;
        }
    }
}