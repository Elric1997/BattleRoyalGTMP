using System;
using MySql.Data.MySqlClient;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;

namespace BattleRoyal.Database
{
    class NewPlayerDB : Script
    {
        InitDatabase initdb = new InitDatabase();
        LoadPlayerDB loadPlayerDB = new LoadPlayerDB();
        UpdatePlayerDB UpdatePlayerDB = new UpdatePlayerDB();

        public NewPlayerDB()
        {
            API.onPlayerConnected += OnPlayerConnectedHandler;
        }
        private void OnPlayerConnectedHandler(Client player)
        {
            this.JoinNewUserDB(player);
        }  
        private void JoinNewUserDB(Client player)
        {
           
        }
    }
}
