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
            if (initdb.OpenConnection() == true)
            {
                string szQuery = "SELECT socialclubname from player WHERE socialclubname='" + player.socialClubName + "'";

                MySqlCommand sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
                MySqlDataReader sqlred = sqlcmd.ExecuteReader();

                if (!sqlred.Read())
                {
                    sqlred.Close();
                    szQuery = "INSERT INTO player (socialclubname) VALUES('" + player.socialClubName + "'" + ")";
                    sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
                    sqlcmd.ExecuteReader();
                }
                sqlred.Close();

                initdb.CloseConnection();
            }
        }
    }
}
