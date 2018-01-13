using System;
using MySql.Data.MySqlClient;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;


class LoadPlayerDB : Script
{
    InitDatabase initdb = new InitDatabase();

    public LoadPlayerDB()
    {
        API.onPlayerFinishedDownload += onPlayerFinishedDownloadHandler;
    }

    private void onPlayerFinishedDownloadHandler(Client player)
    {
        this.LoadSkin(player);
    }
    public void LoadSkin(Client player)
    {
        if (initdb.OpenConnection() == true)
        {
            string szQuery = "SELECT skin from player WHERE socialclubname='" + player.socialClubName + "'";

            MySqlCommand sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
            MySqlDataReader sqlred = sqlcmd.ExecuteReader();

            while (sqlred.Read())
            {
                string skin = sqlred.GetString("skin");
                int skinid = 0;
                skinid = Int32.Parse(skin);

                API.triggerClientEvent(player, "DBSkin", skinid);
            }
            sqlred.Close();

            initdb.CloseConnection();
        }
    }
}
