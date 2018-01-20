function StatsCef(){
	var res = API.getScreenResolution();     
	browser = API.createCefBrowser(500, 499);     
	API.waitUntilCefBrowserInit(browser);     
	API.setCefBrowserPosition(browser, 0, 170);     
	API.loadPageCefBrowser(browser, "GUI/resources/Stats.html");      
	API.showCursor(false);     
	API.setCanOpenChat(false);
}
