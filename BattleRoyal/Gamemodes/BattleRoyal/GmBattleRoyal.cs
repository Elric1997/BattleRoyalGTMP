using System;
using MySql.Data.MySqlClient;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;


public class GmBattleRoyal : Script
{
    private bool _IsGameRunning = false;

    public bool IsGameRunning
    {
        get
        {
            return _IsGameRunning;
        }
        set
        {
            _IsGameRunning = value;
        }
    }

    public GmBattleRoyal()
    {

    }

}

