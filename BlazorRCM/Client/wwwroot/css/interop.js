window.gridfn = function(){
	sfBlazor.Grid.printGrid = function(e){
		var printWind = window.open('', 'print', 'height=' + window.outerHeight + ',width=' + window.outerWidth + ',tabbar=no');
		printWind.moveTo(0, 0);
		//create the elements
		var img = document.createElement("img");
		img.src = 'https://upload.wikimedia.org/wikipedia/commons/f/f9/Phoenicopterus_ruber_in_S%C3%A3o_Paulo_Zoo.jpg';
		img.width = "500";
		img.height = "500";
		//append content for the elements
		addPrintImg = img.cloneNode(true);
		//append the created elements to the print window
		e.insertBefore(addPrintImg, e.childNodes[0]);
		printWind.resizeTo(screen.availWidth, screen.availHeight);
		sf.base.print(e, printWind);
	 };
}