using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;


public class GmLobby : Script
{
    public GmLobby()
    {
        
    }
    public void LobbyZoneControl()
    {
        

        Vector3 position = new Vector3(3257.377, -147.1828, 17.27221);
        float radius = 50;
        List<Client> playerList = API.getPlayersInRadiusOfPosition(radius, position);

        if (playerList.Count >= 2)
        {
            GmBattleRoyal.StartetPlayer = playerList.Count;
            GmBattleRoyal.Arena = 2000;
            foreach (Client currentPlayer in playerList)
            {
                API.shared.givePlayerWeapon(currentPlayer, (WeaponHash)(-72657034), 2, true, true);
                API.setEntityPosition(currentPlayer, new Vector3(1404.715, 3255.175, 200));
            }
            API.sendChatMessageToAll("The Game starts now!");
            GmBattleRoyal.IsGameRunning = true;
        }
        else if (!GmBattleRoyal.IsGameRunning)
        {
            //API.sendChatMessageToAll("Waiting for players");
            API.sendChatMessageToAll(playerList.Count + "/10 players ready!");
        }
    }
}

