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
//https://wiki.gt-mp.net/index.php?title=Client
// (0, 0, 0) X Y Z
//

namespace BattleRoyal.Manager
{
    public class SpawnManager : Script
    {
        public int conection = -3;

        public SpawnManager()
        {
            API.onPlayerFinishedDownload += OnPlayerFinishedDownloadHandler;
        }
        private void OnPlayerFinishedDownloadHandler(Client Player)
        {
            conection--;

            Vector3 RotationsPositon = new Vector3(0, 0, 0);
            Vector3 SpawnPos = new Vector3(0, 0, 0); // Hier die SpawnPos

            API.setEntityPosition(Player, SpawnPos);
            API.setEntityRotation(Player, RotationsPositon);
            API.setEntityDimension(Player, conection);
        }
    }
}
