/// <reference path="types-gt-mp/Declarations.d.ts" />

API.onPlayerPickup.connect(function (pickup) {
    API.triggerServerEvent("pickup", pickup);
});