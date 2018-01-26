using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;

namespace BattleRoyal.Manager.Vehicle
{
    class VehicleSpawner : Script
    {
        GmBattleRoyal GmBattleRoyal = new GmBattleRoyal();
        public VehicleSpawner()
        {
            API.onResourceStart += onResStart;
        }
        public void onResStart()
        {
            var cars = API.loadConfig("Manager/Vehicle/Vehicles.xml");

            foreach (var element in cars.getElementsByType("rome_vehicle"))
            {
                var hash = element.getElementData<int>("model");

                var spawnPos = new Vector3(element.getElementData<float>("posX"), element.getElementData<float>("posY"),
                    element.getElementData<float>("posZ"));
                var heading = element.getElementData<float>("heading");


                var car = API.createVehicle(hash,
                    spawnPos,
                    new Vector3(0, 0, heading), 160, 160, 0);

                API.setEntityData(car, "RESPAWNABLE", true);

                API.setEntityData(car, "SPAWN_POS", spawnPos);
                API.setEntityData(car, "SPAWN_ROT", heading);
            }
            foreach (var element in cars.getElementsByType("battle_vehicle"))
            {
                var hash = element.getElementData<int>("model");

                var spawnPos = new Vector3(element.getElementData<float>("posX"), element.getElementData<float>("posY"),
                    element.getElementData<float>("posZ"));
                var heading = element.getElementData<float>("heading");


                var car = API.createVehicle(hash,
                    spawnPos,
                    new Vector3(0, 0, heading), 160, 160, 0);

                API.setEntityData(car, "BATTLE_CAR", true);

                API.setEntityData(car, "SPAWN_POS", spawnPos);
                API.setEntityData(car, "SPAWN_ROT", heading);
            }
        }   
    }
}
