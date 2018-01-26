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

        public SpawnManager()
        {
            API.onPlayerFinishedDownload += OnPlayerFinishedDownloadHandler;
        }
        private void OnPlayerFinishedDownloadHandler(Client Player)
        {
            Vector3 RotationsPositon = new Vector3(0, 0, 90);
            Vector3 SpawnPos = new Vector3(-551.7838, 284.1952, 82.97662);

            API.setEntityPosition(Player, SpawnPos);
            API.setEntityRotation(Player, RotationsPositon);

            var ourDim = DimensionManager.RequestPrivateDimension(Player);

            API.freezePlayer(Player, true);

            API.setEntityDimension(Player, ourDim);

            API.triggerClientEvent(Player, "SpawnCam");
        }
    }
}
