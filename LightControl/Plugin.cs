using Exiled.API.Features;
using System;

using Server = Exiled.Events.Handlers.Server;

namespace LightControl
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "Light Control";
        public override string Author => "Marco15453";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        private EventHandler eventHandler;

        public override void OnEnabled()
        {
            eventHandler = new EventHandler(this);
            Server.RoundStarted += eventHandler.onRoundStarted;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Server.RoundStarted -= eventHandler.onRoundStarted;
            eventHandler = null;
            base.OnDisabled();
        }
    }
}
