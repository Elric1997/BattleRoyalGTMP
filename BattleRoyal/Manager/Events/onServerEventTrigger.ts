/// <reference path="types-gt-mp/Declarations.d.ts" />

API.onServerEventTrigger.connect(function (eventName, args) {
    switch (eventName) {

        case 'SpawnCam':
            resource.MenuManager.SpawnMenu();
            let newCamera = API.createCamera(new Vector3(-556.7838, 284.1952, 82.97662), new Vector3(0, 0, -95));
            API.setActiveCamera(newCamera);
            //resource.Stats.StatsCef();
            break;
        case 'DBSkin':
            API.setPlayerSkin(args[0]);
            break;
        case 'delpickup':
            API.deleteEntity(args[0]);
            break;
    }
});