using System;
using CrazyHintFramework.API;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using WelcomPlugin;

namespace WelcomPlugin
{
    public class Plugin : Plugin<Config>
    {
        public override string Name => "WelcomeHintPlugin";
        public override string Author => "MONCEF50G";
        public override Version Version { get; } = new Version(1, 0, 0);
        public override Version RequiredExiledVersion  { get; } =  new Version(9, 6, 1);

        public override void OnEnabled()
        {
            Exiled.Events.Handlers.Player.Verified += OnPlayerJoin;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Exiled.Events.Handlers.Player.Verified -= OnPlayerJoin;
            base.OnDisabled();
        }

        private void OnPlayerJoin(VerifiedEventArgs ev)
        {
            // show hint message in the game with use HintFramework
            string hintId = HintAPI.ShowHint(
                player: ev.Player,
                text: Config.WelcomeMessage.Replace("{player}", ev.Player.Nickname),
                duration: Config.Duration,
                priority: Config.Priority,
                sourcePlugin: Name
            );

            Log.Info($"Displayed welcome hint to {ev.Player.Nickname} (ID: {hintId})");

        }
    }
}