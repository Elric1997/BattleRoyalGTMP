using System;
using MySql.Data.MySqlClient;
using GrandTheftMultiplayer.Server.API;



class InitDatabase : Script
{
    public MySqlConnection connDB = new MySqlConnection("server=localhost;user=BattleRoyal;database=BattleRoyal;port=3306;password=;");
    public InitDatabase()
    {
        API.onResourceStart += StartUpHandler;
    }
    public void StartUpHandler()
    {
        this.OpenConnection();
        this.CloseConnection();
        ;
    }
    public bool OpenConnection()
    {
        try
        {
            connDB.Open();
            API.consoleOutput("Connection Succsess");
            return true;
        }
        catch (MySqlException ex)
        {
            API.consoleOutput("Connection failed" + ex);
            return false;
        }
    }
    public bool CloseConnection()
    {
        try
        {
            connDB.Close();
            API.consoleOutput("Disconnection Succsess");
            return true;
        }
        catch (MySqlException ex)
        {
            API.consoleOutput("Disconnection failed" + ex);
            return false;
        }
    }
}

