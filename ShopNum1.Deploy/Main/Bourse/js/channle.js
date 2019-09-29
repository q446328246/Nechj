function channelkey(j) 
{
	for (var i = 1; i < 4; i++)
	{
	    document.getElementById("channel"+i).style.color = "";//字体变颜色
		document.getElementById("channel"+i).style.backgroundPosition = "-83px 0";
		document.getElementById("menucontent"+i).style.display = "none";
	}
	document.getElementById("channel"+j).style.color = "#CC0000";//字体变颜色
	document.getElementById("channel"+j).style.backgroundPosition = "0 0";
	document.getElementById("menucontent"+j).style.display = "block";
}