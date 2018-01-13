var selectingSkin = false;
var currentSkinIndex = 0;

var skins = [
    1813637474,
	-840346158,
	1596003233,
	1641334641,
	-407694286,
	-927261102,
	1530648845,
	 808859815,
	-52268862,
	-636391810,
	1413662315,
	-664053099,
	-1244692252,
	1684083350,
	1125994524
];

API.onKeyDown.connect(function(sender, args) {
    if (!selectingSkin) return;

    if (args.KeyCode == Keys.Left) {
        if (currentSkinIndex == 0){
			currentSkinIndex = skins.length - 1;
		}
        else 
		{
		currentSkinIndex = (currentSkinIndex - 1) % skins.length;
		}
        API.setPlayerSkin(skins[currentSkinIndex]);
    }
    else if (args.KeyCode == Keys.Right) 
	{
        currentSkinIndex = (currentSkinIndex + 1) % skins.length;

        API.setPlayerSkin(skins[currentSkinIndex]);
    }
    else if (args.KeyCode == Keys.Enter) 
	{
        selectingSkin = false;
		API.setPlayerSkin(skins[currentSkinIndex]);
		resource.MenuManager.SpawnMenu();
		API.triggerServerEvent("UpDateSkinDB", skins[currentSkinIndex]);
    }
});  

function ChanceSkinBool(){
	if(selectingSkin){
		selectingSkin = false
	} else {
		selectingSkin = true
	}
}