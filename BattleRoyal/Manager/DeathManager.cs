using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;

namespace BattleRoyal.Global
{
    class DeathManager : Script
    {
        public DeathManager()
        {
            API.onPlayerDeath += onPlayerDeathHandler;
            API.onPlayerRespawn += onPlayerRespawnHandler;
        }
        private void onPlayerDeathHandler(Client player, NetHandle entityKiller, int weapon)
        {
            Client killer = API.getPlayerFromHandle(entityKiller);
            if (killer != null)
            {
                API.sendNotificationToAll(killer.name + " has killed " + player.name);
            }
            else
            {
                API.sendNotificationToAll(player.name + " died");
            }
        }
        private void onPlayerRespawnHandler(Client player)
        {
            API.setEntityPosition(player, new Vector3(-1266.848, -3324.198, 13.94505));
            API.sendChatMessageToPlayer(player, " You are Dead.");
            API.sendChatMessageToPlayer(player, player.name + " you are now in the freerome area!");
            API.setEntityDimension(player, 0);
        }
    }
}
