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
    UpdatePlayerDB UpdatePlayerDB = new UpdatePlayerDB();

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
            string szQuery = "SELECT socialclubname from player WHERE socialclubname='" + player.socialClubName + "'";

            MySqlCommand sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
            MySqlDataReader sqlred = sqlcmd.ExecuteReader();

            if (sqlred.Read())
            {
                API.sendChatMessageToPlayer(player, player.socialClubName + " deine Daten wurden geladen!");
                sqlred.Close();

                szQuery = "SELECT skin from player WHERE socialclubname='" + player.socialClubName + "'";

                sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
                sqlred = sqlcmd.ExecuteReader();

                while (sqlred.Read())
                {
                    string skin = sqlred.GetString("skin");
                    int skinid = 0;
                    skinid = Int32.Parse(skin);

                    API.triggerClientEvent(player, "DBSkin", skinid);
                }
                sqlred.Close();
            }
            else
            {
                sqlred.Close();
                API.sendChatMessageToPlayer(player, player.socialClubName + " Dein Name existiert noch nicht! Bitte Registriere dich!");
            }
            initdb.CloseConnection();
        }
    }
}
