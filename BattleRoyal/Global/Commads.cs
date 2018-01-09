using System;
using MySql.Data.MySqlClient;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;

namespace BattleRoyal.Global
{
    class Commads
    {
        [Command("kill")]
        public void selfkill(Client sender)
        {
            sender.kill();
        }
    }
}
