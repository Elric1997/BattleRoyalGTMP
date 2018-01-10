using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;

namespace BattleRoyal.Manager
{
    public class SpawnManager : Script
    {
        public SpawnManager()
        {
            API.onPlayerFinishedDownload += OnPlayerFinishedDownloadHandler;

        }
        private void OnPlayerFinishedDownloadHandler(Client Player)
        {
            Vector3 SpawnPos = new Vector3(0, 0, 0); // Hier die SpawnPos
        }
    }
}
