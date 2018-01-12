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
            GmBattleRoyal GmBattleRoyal = new GmBattleRoyal();
            switch (eventName)
            {
                case "JoinBattleRoyal":
                    if (!GmBattleRoyal.IsGameRunning)
                    {
                        API.freezePlayer(player, false);
                        API.setEntityPosition(player, new Vector3(3257.377, -147.1828, 17.27221));
                        API.sendNotificationToPlayer(player, player.name + " you are now in the lobby area!");
                        API.sendNotificationToPlayer(player, "Please wait until the game starts!");
                        API.setEntityDimension(player, -2);
                    }
                    else
                    {
                        API.freezePlayer(player, false);
                        API.setEntityPosition(player, new Vector3(-1266.848, -3324.198, 13.94505));
                        API.sendNotificationToPlayer(player, "A Game is already running!");
                        API.sendNotificationToPlayer(player, player.name + " you are now in the freerome area!");
                        API.setEntityDimension(player, -1);
                    }
                    break;
                case "JoinFreerome":
                    API.freezePlayer(player, false);
                    API.setEntityPosition(player, new Vector3(-1266.848, -3324.198, 13.94505));
                    API.sendChatMessageToPlayer(player, player.name + " you are now in the freerome area!");
                    API.setEntityDimension(player, -1);
                    break;
            }
        }
    }
}
