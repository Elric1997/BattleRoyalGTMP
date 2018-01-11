using System;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;

namespace BattleRoyal.Manager.Events
{
    public class onClientEventTrigger : Script
    {
        public onClientEventTrigger()
        {
            API.onClientEventTrigger += OnClientEvent;
        }
        private void OnClientEvent(Client player, string eventName, params object[] arguments)
        {
            if(eventName == "Test")
            {
                API.consoleOutput("Test Event Triggert!");
            }
        }
    }
}
