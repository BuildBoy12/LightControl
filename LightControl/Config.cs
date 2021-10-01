using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace LightControl
{
    public sealed class Config : IConfig
    {
        [Description("Should the plugin be enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("What Rooms should have what Color, See Room Example Config for the Format (If empty it will be ignored)")]
        public List<RoomSettings> Rooms { get; set; } = new List<RoomSettings>();

        [Description("What Zones should have what Color, See Zone Example Config for the Format (If empty it will be ignored)")]
        public List<ZoneSettings> Zones { get; set; } = new List<ZoneSettings>();
    }
}
