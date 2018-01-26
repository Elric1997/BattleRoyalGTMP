using System;
using MySql.Data.MySqlClient;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;


public class UpdatePlayerDB : Script
{
    public int SkinID { get; set; }

    InitDatabase initdb = new InitDatabase();

    public bool exist;

    public UpdatePlayerDB()
    {
        API.onPlayerDeath += OnPlayerDeathHandler;
    }
    private void OnPlayerDeathHandler(Client player, NetHandle entityKiller, int weapon)
    {
        this.DeathCount(player, entityKiller);
    }
    public void WinCount(Client player)
    {

        if (initdb.OpenConnection() == true)
        {
            if (this.PlayerExist(player))
            {
                API.sendChatMessageToPlayer(player, "Glückwunsch! Du hast diese Runde gewonnen!");

                string szQuery = "SELECT wins from player WHERE socialclubname='" + player.socialClubName + "'";

                int StringToInt = 0;

                MySqlCommand sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
                MySqlDataReader sqlred = sqlcmd.ExecuteReader();

                while (sqlred.Read())
                {
                    string deathsDB = sqlred.GetString("wins");
                    StringToInt = Int32.Parse(deathsDB);

                    StringToInt++;
                }

                sqlred.Close();

                szQuery = "UPDATE player SET wins='" + StringToInt + "' WHERE socialclubname='" + player.socialClubName + "'";
                sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
                sqlcmd.ExecuteReader();

                sqlred.Close();

                initdb.CloseConnection();

            }
            else
            {
                API.sendChatMessageToPlayer(player, "Glückwunsch! Du hast diese Runde gewonnen! Aber wir können dir den Win leider nicht Gutschreiben!");
            }
        }
        else
        {
            API.sendChatMessageToPlayer(player, "Dein Win konnte nicht gespeichert werden! Bitte Registriere dich!");
        }
    }
    public void UpdateSkin(Client player)
    {
        if (initdb.OpenConnection() == true)
        {
            if (!this.PlayerExist(player))
            {
                API.sendChatMessageToPlayer(player, "Dein Skin konnte nicht gespeichert werden!");
            }
            else
            {

                string szQuery = "UPDATE player SET skin='" + SkinID + "' WHERE socialclubname='" + player.socialClubName + "'";

                MySqlCommand sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
                MySqlDataReader sqlred = sqlcmd.ExecuteReader();

                API.sendChatMessageToPlayer(player, player.socialClubName + " dein Skin wurde geändert und gespeichert");

                sqlred.Close();
            }

            initdb.CloseConnection();
        }
    }
    private void DeathCount(Client player, NetHandle entityKiller)
    {

        if (initdb.OpenConnection() == true)
        {
            if (this.PlayerExist(player))
            {
                string szQuery = "SELECT deaths from player WHERE socialclubname='" + player.socialClubName + "'";

                int StringToInt = 0;

                MySqlCommand sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
                MySqlDataReader sqlred = sqlcmd.ExecuteReader();

                while (sqlred.Read())
                {
                    string deathsDB = sqlred.GetString("deaths");
                    StringToInt = Int32.Parse(deathsDB);

                    StringToInt++;
                }

                sqlred.Close();

                szQuery = "UPDATE player SET deaths='" + StringToInt + "' WHERE socialclubname='" + player.socialClubName + "'";
                sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
                sqlcmd.ExecuteReader();

                sqlred.Close();       

            }
            initdb.CloseConnection();
        }

        Client killer = API.getPlayerFromHandle(entityKiller);

        if (killer != null)
        {

            if (initdb.OpenConnection() == true)
            {
                if (this.PlayerExist(player))
                {
                    string szQuery = "SELECT kills from player WHERE socialclubname='" + killer.socialClubName + "'";

                    int StringToInt = 0;

                    MySqlCommand sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
                    MySqlDataReader sqlred = sqlcmd.ExecuteReader();

                    while (sqlred.Read())
                    {
                        string deathsDB = sqlred.GetString("kills");
                        StringToInt = Int32.Parse(deathsDB);

                        StringToInt++;
                    }

                    sqlred.Close();

                    szQuery = "UPDATE player SET kills='" + StringToInt + "' WHERE socialclubname='" + killer.socialClubName + "'";
                    sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
                    sqlcmd.ExecuteReader();

                    sqlred.Close();

                }
                initdb.CloseConnection();
            }
        }
    }
    public bool PlayerExist(Client player)
    {

        string szQuery = "SELECT socialclubname from player WHERE socialclubname='" + player.socialClubName + "'";

        MySqlCommand sqlcmd = new MySqlCommand(szQuery, initdb.connDB);
        MySqlDataReader sqlred = sqlcmd.ExecuteReader();

        if (sqlred.Read())
        {
            exist = true;
        }
        else
        {
            exist = false;
        }
        sqlred.Close();




        return exist;
    }
}

