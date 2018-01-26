using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;



public class Commads : Script
{
    public Commads()
    {

    }
    [Command("kill")]
    public void selfkill(Client sender)
    {
        sender.kill();
    }

    [Command("getpos")]
    public void GetPosition(Client player)
    {
        Vector3 PlayerPos = API.getEntityPosition(player);
        Vector3 clientRotation = API.getEntityRotation(player);
        API.sendChatMessageToPlayer(player, "X: " + PlayerPos.X + " Y: " + PlayerPos.Y + " Z: " + PlayerPos.Z + " Heading: " + clientRotation.Z);
    }

    [Command("dimension", "Usage: /dimension <dimension_id>", Alias = "dim")]
    public void SetMyDimension(Client player, int world)
    {
        API.setEntityDimension(player, world);
    }
    [Command("test")]
    public void Test(Client player)
    {
        Vector3 position = player.position;
        NetHandle moneyPickup = API.createPickup(PickupHash.WeaponMinigun, new Vector3(position.X + 3, position.Y, position.Z), new Vector3(0.0, 0.0, 0.0), 0, 0);
    }
    [Command("setpos", "Usage: /setpos x y z")]
    public void setpos(Client player, float x, float y, float z)
    {
        Vector3 setposition = new Vector3(x, y, z);
        API.setEntityPosition(player, setposition);
    }

}


