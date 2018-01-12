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

                var dimension = element.getElementData<int>("dim");

                var car = API.createVehicle(hash,
                    spawnPos,
                    new Vector3(0, 0, heading), 160, 160, dimension);

                API.setEntityData(car, "RESPAWNABLE", true);

                API.setEntityData(car, "SPAWN_POS", spawnPos);
                API.setEntityData(car, "SPAWN_ROT", heading);
                API.setEntityData(car, "SPAWN_DIM", dimension);
            }
            foreach (var element in cars.getElementsByType("battle_vehicle"))
            {
                var hash = element.getElementData<int>("model");

                var spawnPos = new Vector3(element.getElementData<float>("posX"), element.getElementData<float>("posY"),
                    element.getElementData<float>("posZ"));
                var heading = element.getElementData<float>("heading");

                var dimension = element.getElementData<int>("dim");

                var car = API.createVehicle(hash,
                    spawnPos,
                    new Vector3(0, 0, heading), 160, 160, dimension);

                API.setEntityData(car, "BATTLE_CAR", true);

                API.setEntityData(car, "SPAWN_POS", spawnPos);
                API.setEntityData(car, "SPAWN_ROT", heading);
                API.setEntityData(car, "SPAWN_DIM", dimension);
            }
        }
        public void OnVehicleDeathHandler(NetHandle car)
        {
            if (API.getEntityData(car, "RESPAWNABLE") == true)
            {

                var color1 = API.getVehiclePrimaryColor(car);
                var color2 = API.getVehicleSecondaryColor(car);
                var model = API.getEntityModel(car);

                var spawnPos = API.getEntityData(car, "SPAWN_POS");
                var heading = API.getEntityData(car, "SPAWN_ROT");
                var dimension = API.getEntityData(car, "SPAWN_DIM");

                API.deleteEntity(car);

                var respawnCar = API.createVehicle((VehicleHash)model, spawnPos, new Vector3(0, 0, heading), color1, color2, dimension);
                // You can also add more things, like vehicle modifications, number plate, etc.	
                API.setEntityData(respawnCar, "RESPAWNABLE", true);
                API.setEntityData(respawnCar, "SPAWN_POS", spawnPos);
                API.setEntityData(respawnCar, "SPAWN_ROT", heading);
                API.setEntityData(respawnCar, "SPAWN_DIM", dimension);

            }
            if (API.getEntityData(car, "BATTLE_CAR") == true && !GmBattleRoyal.IsGameRunning)
            {
                API.consoleOutput("False");

                var color1 = API.getVehiclePrimaryColor(car);
                var color2 = API.getVehicleSecondaryColor(car);
                var model = API.getEntityModel(car);

                var spawnPos = API.getEntityData(car, "SPAWN_POS");
                var heading = API.getEntityData(car, "SPAWN_ROT");
                var dimension = API.getEntityData(car, "SPAWN_DIM");

                API.deleteEntity(car);

                var respawnCar = API.createVehicle((VehicleHash)model, spawnPos, new Vector3(0, 0, heading), color1, color2, dimension);
                // You can also add more things, like vehicle modifications, number plate, etc.	
                API.setEntityData(respawnCar, "BATTLE_CAR", true);
                API.setEntityData(respawnCar, "SPAWN_POS", spawnPos);
                API.setEntityData(respawnCar, "SPAWN_ROT", heading);
                API.setEntityData(respawnCar, "SPAWN_DIM", dimension);

            }
        }
    }
}
