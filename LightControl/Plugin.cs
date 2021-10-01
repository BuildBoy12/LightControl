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
        public override Version Version => new Version(1, 2, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        private EventHandler eventHandler;

        public override void OnEnabled()
        {
            eventHandler = new EventHandler(this);
            Server.RoundStarted += eventHandler.OnRoundStarted;
            Warhead.Stopping += eventHandler.OnWarheadStopping;
            Warhead.Detonated += eventHandler.OnWarheadDetonated;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Server.RoundStarted -= eventHandler.OnRoundStarted;
            Warhead.Stopping -= eventHandler.OnWarheadStopping;
            Warhead.Detonated -= eventHandler.OnWarheadDetonated;
            eventHandler = null;
            base.OnDisabled();
        }
    }
}
