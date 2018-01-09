using System;
using System.Collections.Generic;
using GrandTheftMultiplayer.Server.API;
using GrandTheftMultiplayer.Shared;
using GrandTheftMultiplayer.Server.Elements;
using GrandTheftMultiplayer.Server.Managers;
using GrandTheftMultiplayer.Shared.Math;

namespace Main
{
    public class Main : Script
    {
        public Main()
        {
            API.onResourceStart += StartUpHandler;
        }
        public void StartUpHandler()
        {
            API.consoleOutput("*----------------------------------*");
            API.consoleOutput("*   Starting Battle Royal modus	  *");
            API.consoleOutput("*         Developt by Elric	      *");
            API.consoleOutput("*           Version 0.0.9	      *");
            API.consoleOutput("*----------------------------------*");
        }
    }
}
