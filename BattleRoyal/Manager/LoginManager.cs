using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;

namespace BattleRoyal.Manager
{
    class LoginManager : Script
    {
        public LoginManager()
        {
            API.onPlayerConnected += OnPlayerConnectedHandler;
            API.onPlayerDisconnected += OnPlayerDisconnectedHandler;
        }
        private void OnPlayerConnectedHandler(Client player)
        {
            API.sendNotificationToAll("~g~" + player.name + "~#ffffff~ has joined the Server.");
        }
        private void OnPlayerDisconnectedHandler(Client player, string reason)
        {
            API.sendNotificationToAll("~r~" + player.name + "~#ffffff~ has left the Server. Reason: " + reason);
        }
    }
}
