using Exiled.API.Enums;
using Exiled.API.Features;
using System;

using Server = Exiled.Events.Handlers.Server;
using Warhead = Exiled.Events.Handlers.Warhead;

namespace LightControl
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Light Control";
        public override string Author => "Marco15453";
        public override Version Version => new Version(1, 3, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        private EventHandler eventHandler;

        public override void OnEnabled()
        {
            if(!checkConfig())
            {
                Log.Error("ZoneType Surface detected! This plugin will not be enabled due to Exiled or Base Game bug.");
                return;
            }

            eventHandler = new EventHandler(this);
            Server.RoundStarted += eventHandler.OnRoundStarted;
            Warhead.Stopping += eventHandler.OnWarheadStopping;
            Warhead.Detonated += eventHandler.OnWarheadDetonated;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            if (!checkConfig()) return;
            Server.RoundStarted -= eventHandler.OnRoundStarted;
            Warhead.Stopping -= eventHandler.OnWarheadStopping;
            Warhead.Detonated -= eventHandler.OnWarheadDetonated;
            eventHandler = null;
            base.OnDisabled();
        }

        private bool checkConfig()
        {
            foreach((ZoneType type, Colors color) in Config.Zones)
                if (type == ZoneType.Surface) return false;
            return true;
        }
    }
}
