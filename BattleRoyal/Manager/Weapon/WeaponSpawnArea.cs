using System;
using GrandTheftMultiplayer.Server;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Constant;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Shared.Math;


public class WeaponSpawnArea : Script
{
    public WeaponSpawnArea()
    {

    }
    public void CreateArea(double x, double y, double z, int maxWeapon, int maxRange, int maxAmmo)
    {
        PickupHash[] Weapons = new PickupHash[]
        {
            PickupHash.WeaponAssaultShotgun,
            PickupHash.WeaponBattleaxe,
            PickupHash.WeaponMicroSMG,
            PickupHash.WeaponPetrolCan,
            PickupHash.WeaponPipebomb,
            PickupHash.WeaponSniperRifle
        };

        Vector3 CenterPos = new Vector3(x, y, z);

        var Random = new Random();


        for (int i = 0; i < maxWeapon; i++)
        {
            int ranWeapon = Random.Next(0, Weapons.Length);
            int ranAmmo = Random.Next(0, maxAmmo);
            int ranX = Random.Next(-10, 10);
            int ranY = Random.Next(-10, 10);
            Vector3 CreatePos = CenterPos;
            CreatePos.X = CenterPos.X + ranX;
            CreatePos.Y = CenterPos.Y + ranY;

            API.createPickup(Weapons[ranWeapon], new Vector3(CreatePos.X, CreatePos.Y, CenterPos.Z), new Vector3(0, 0, 0), ranAmmo, 99999999);

            CreatePos.ToString();

            API.consoleOutput("Weapon Spawn Pos: "+ CreatePos + " Ran X: " + ranX + "Ran Y: " + ranY + " Spawned Weapon: " + Weapons[ranWeapon]);
        }
    }
}

