using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Shared;

namespace BattleRoyal.Global
{
    class DeathHandler : Script
    {
        public DeathHandler()
        {
            API.onPlayerDeath += onPlayerDeathHandler;
        }
        private void onPlayerDeathHandler(Client p, NetHandle entityKiller, int weapon)
        {
            Client killer = API.getPlayerFromHandle(entityKiller);
            if (killer != null)
            {
                API.sendNotificationToAll(killer.name + " has killed " + p.name);
            }
            else
            {
                API.sendNotificationToAll(p.name + " died");
            }
        }
    }
}
