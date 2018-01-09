using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;

namespace BattleRoyal.Manager
{
    class SpawnManager : Script
    {
        public SpawnManager()
        {
            API.onPlayerFinishedDownload += OnPlayerFinishedDownloadHandler;
            API.onPlayerConnected += OnPlayerConnectedHandler;
            API.onPlayerDisconnected += OnPlayerDisconnectedHandler;
        }
        public void OnPlayerFinishedDownloadHandler(Client player)
        {
            
        }
        public void OnPlayerConnectedHandler(Client player)
        {
            API.sendNotificationToAll("~g~" + player.name + "~#ffffff~ has joined the Server.");
        }
        public void OnPlayerDisconnectedHandler(Client player, string reason)
        {
            API.sendNotificationToAll("~r~" + player.name + "~#ffffff~ has left the Server. Reason: " + reason);
        }
    }
}
