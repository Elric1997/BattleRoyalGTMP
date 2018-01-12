API.onKeyDown.connect(function(Player, args) {
    if (args.KeyCode == Keys.M && !API.isChatOpen())
    {
		MainMenu();            
    }
});

function SpawnMenu(){
    var mainmenu = API.createMenu("G-Net Battle Royal", "Spawn Menu", 0, 0, 6);
    mainmenu.ResetKey(menuControl.Back);
    API.setMenuBannerSprite(mainmenu, "shopui_title_gr_gunmod", "shopui_title_gr_gunmod");
    API.showCursor(true);
    mainmenu.Visible = true;
    
    let item1 = API.createMenuItem("Join a Game", "");
    let item2 = API.createMenuItem("Chance Skin", "");
    let item3 = API.createMenuItem("Freerome", "");
    let item4 = API.createMenuItem("Exit", "");

    // This is how you handle menu item selection
    item1.Activated.connect(function(menu, item) {
        API.setActiveCamera(null);
        API.showCursor(false);
        mainmenu.Visible = false;
		API.triggerServerEvent("JoinBattleRoyal");
    });

	item2.Activated.connect(function(menu, item) {
		resource.SkinManager.ChanceSkinBool();
		mainmenu.Visible = false;
	});

    item3.Activated.connect(function(menu, item) {
        API.setActiveCamera(null);
        API.showCursor(false);
        mainmenu.Visible = false;
		API.triggerServerEvent("JoinFreerome");
    });

    item4.Activated.connect(function(menu, item) {
        mainmenu.Visible  = false;
        API.disconnect("Menu Exit");
    });
        
    mainmenu.AddItem(item1);
    mainmenu.AddItem(item2);
    mainmenu.AddItem(item3);
    mainmenu.AddItem(item4);
}

function MainMenu(){
    var mainmenu = API.createMenu("G-Net Battle Royal", "Main Menu", 0, 0, 6);
    mainmenu.ResetKey(menuControl.Back);
    API.setMenuBannerSprite(mainmenu, "shopui_title_gr_gunmod", "shopui_title_gr_gunmod");
    API.showCursor(true);
    mainmenu.Visible = true;
    
    let item1 = API.createMenuItem("Join a Game", "");
    let item2 = API.createMenuItem("Chance Skin", "");
    let item3 = API.createMenuItem("Freerome", "");
    let item4 = API.createMenuItem("Exit", "");

    // This is how you handle menu item selection
    item1.Activated.connect(function(menu, item) {
        API.setActiveCamera(null);
        API.showCursor(false);
        mainmenu.Visible = false;
		API.triggerServerEvent("JoinBattleRoyal");
    });

    item3.Activated.connect(function(menu, item) {
        API.setActiveCamera(null);
        API.showCursor(false);
        mainmenu.Visible = false;
		API.triggerServerEvent("JoinFreerome");
    });

    item4.Activated.connect(function(menu, item) {
        mainmenu.Visible  = false;
        API.showCursor(false);
    });
        
    mainmenu.AddItem(item1);
    mainmenu.AddItem(item2);
    mainmenu.AddItem(item3);
    mainmenu.AddItem(item4);
}
