using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;


public class GmFreerome : Script
{
    bool _firststart = false;
    WeaponSpawnArea WeaponSpawnArea = new WeaponSpawnArea();
    public GmFreerome()
    { 

    }
    public void RomeZoneControl()
    {
        if (!_firststart)
        {
            API.createMarker(1, new Vector3(-1266.848, -3324.198, 0), new Vector3(), new Vector3(), new Vector3(1000, 1000, 100), 150, 0, 0, 255, 0, false);
            API.consoleOutput("Freerome zone created!");
            _firststart = true;
            WeaponSpawnArea.CreateArea(-1266.848, -3324.198, 13.94505, 5, 20, 50);
        }
        else
        {
            Vector3 position = new Vector3(-1266.848, -3324.198, 13.94505);
            float radius = 1000;
            List<Client> playerList = API.getPlayersInRadiusOfPosition(radius, position);
            foreach (Client currentPlayer in playerList)
            {
                Vector3 pos = new Vector3(-1266.848, -3324.198, 13.94505);
                Vector3 playerpos = currentPlayer.position;
                float distance = pos.DistanceTo(playerpos);
                if (distance >= 500)
                {
                    API.sendChatMessageToPlayer(currentPlayer, "Please stay in the freerome area");
                    currentPlayer.kill();
                }
            }
        }
    }
}

