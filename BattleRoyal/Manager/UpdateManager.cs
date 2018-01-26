using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;


public class UpdateManager : Script
{
    GmFreerome GmFreerome = new GmFreerome();
    GmBattleRoyal GmBattleRoyal = new GmBattleRoyal();
    GmLobby GmLobby = new GmLobby();

    private DateTime LastAnnounce;

    public UpdateManager()
    {
        API.onUpdate += OnUpdateHandler;
    }
    public void OnUpdateHandler()
    {
        if (DateTime.Now.Subtract(LastAnnounce).TotalSeconds >= 5)
        {
            if (!GmBattleRoyal.IsGameRunning)
            {
                GmLobby.LobbyZoneControl();
            }
            else
            {
                GmBattleRoyal.BattleZoneControl();
            }
            GmFreerome.RomeZoneControl();
            LastAnnounce = DateTime.Now;
        }
    }
}

