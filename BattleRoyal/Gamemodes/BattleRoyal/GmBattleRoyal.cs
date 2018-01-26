using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;


public class GmBattleRoyal : Script
{
    UpdatePlayerDB UpdatePlayerDB = new UpdatePlayerDB();

    private static int _StartetPlayer = 0;
    public static int StartetPlayer
    {
        get { return _StartetPlayer; }
        set { _StartetPlayer = value; }
    }
    private static bool _IsGameRunning;
    public static bool IsGameRunning
    {
        get { return _IsGameRunning; }
        set { _IsGameRunning = value; }
    }
    private static double _Arena = 0;
    public static double Arena
    {
        get { return _Arena; }
        set { _Arena = value; }
    }
    private static bool _StartZone = false;
    public static bool StartZone
    {
        get { return _StartZone; }
        set { _StartZone = value; }
    }

    public GmBattleRoyal()
    {

    }
    NetHandle ZoneMarker;
    public void BattleZoneControl()
    {
        API.consoleOutput("" + StartZone + "");
        if (!StartZone)
        {
            ZoneMarker = API.createMarker(1, new Vector3(1404.715, 3255.175, 30), new Vector3(), new Vector3(), new Vector3(Arena, Arena, 100), 255, 255, 0, 0, 0, true);
            StartZone = true;
        }
        else
        {
            if(Arena <= 50)
            {

            }
            else
            {
                Arena = Arena - 5;
                API.setMarkerScale(ZoneMarker, new Vector3(Arena, Arena, 100));
            }
        }
        Vector3 position = new Vector3(1404.715, 3255.175, 39);
        float radius = 3000;
        List<Client> playerList = API.getPlayersInRadiusOfPosition(radius, position);
        foreach (Client currentPlayer in playerList)
        {
            Vector3 pos = new Vector3(1404.715, 3255.175, 39);
            Vector3 playerpos = currentPlayer.position;
            float distance = pos.DistanceTo(playerpos);
            if (distance <= Arena / 2)
            {
                API.sendChatMessageToPlayer(currentPlayer, playerList.Count + "/" + StartetPlayer + "Alive");
            }
            else
            {
                var health = API.getPlayerHealth(currentPlayer) - 10;
                API.setPlayerHealth(currentPlayer, health);
                API.sendChatMessageToPlayer(currentPlayer, "GO BACK IN ZONE!");
            }
        }
        if (playerList.Count == 1)
        {      
            IsGameRunning = false;
            API.sendChatMessageToAll("The Game is Over! You can Join now!");
            foreach (Client currentPlayer in playerList)
            {
                UpdatePlayerDB.WinCount(currentPlayer);
                API.setEntityPosition(currentPlayer, new Vector3(-1266.848, -3324.198, 13.94505));
                API.sendChatMessageToPlayer(currentPlayer, currentPlayer.name + " you are now in the freerome area!");
            }
        }
    }
}

