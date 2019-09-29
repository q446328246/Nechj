/***************************************************
<Shopnum1后台管理JS类> william 2010年7月19日
***************************************************/
var offsetxpoint = -60;
var offsetypoint = 20;
var ie = document.all;
var ns6 = document.getElementById && !document.all;
var enabletip = false;
if (ie || ns6)
    var tipobj = document.all ? document.all["dhtmltooltip"] : document.getElementById ? document.getElementById("dhtmltooltip") : "";
var tipimg = document.all ? document.all["tipimg"] : document.getElementById ? document.getElementById("tipimg") : "";
var tmpimg;

function ietruebody() {
    return (document.compatMode && document.compatMode != "BackCompat") ? document.documentElement : document.body;
}

function ddrivetip(thetext, thecolor, thewidth, imgid, src) {
    if (ns6 || ie) {
        if (typeof thewidth != "undefined" && thewidth != "") {
            tipobj.style.width = thewidth + "px";
            tipobj.style.width = "180px";
        }
        if (typeof thecolor != "undefined" && thecolor != "") {
            tipobj.style.backgroundColor = thecolor;
        }

        if (tipimg) {
            tipimg.src = "images/loadimg.gif";
            tipimg.src = thetext;
        } else {
            tipobj.innerHTML = thetext;
            if (typeof imgid != "undefined" && imgid != "") {
                tmpimg = document.getElementById(imgid);
                tmpimg.src = "images/loadimg.gif";
                tmpimg.src = src;
            }
        }
        enabletip = true;
        return false;
    }
}

function positiontip(e) {
    if (enabletip) {
        var curX = (ns6) ? e.pageX : event.x + ietruebody().scrollLeft;
        var curY = (ns6) ? e.pageY : event.y + ietruebody().scrollTop;
//Find out how close the mouse is to the corner of the window
        var rightedge = ie && !window.opera ? ietruebody().clientWidth - event.clientX - offsetxpoint : window.innerWidth - e.clientX - offsetxpoint - 20;
        var bottomedge = ie && !window.opera ? ietruebody().clientHeight - event.clientY - offsetypoint : window.innerHeight - e.clientY - offsetypoint - 20;
        var leftedge = (offsetxpoint < 0) ? offsetxpoint * (-1) : -1000; //if the horizontal distance isn't enough to accomodate the width of the context menu
        if (rightedge < tipobj.offsetWidth)
//move the horizontal position of the menu to the left by it's width
            tipobj.style.left = ie ? ietruebody().scrollLeft + event.clientX - tipobj.offsetWidth + "px" : window.pageXOffset + e.clientX - tipobj.offsetWidth + "px";
        else if (curX < leftedge)
            tipobj.style.left = "5px";
        else
//position the horizontal position of the menu where the mouse is positioned
            tipobj.style.left = curX + offsetxpoint + "px"; //same concept with the vertical position
        if (bottomedge < tipobj.offsetHeight)
            tipobj.style.top = ie ? ietruebody().scrollTop + event.clientY - tipobj.offsetHeight - offsetypoint + "px" : window.pageYOffset + e.clientY - tipobj.offsetHeight - offsetypoint + "px";
        else
            tipobj.style.top = curY + offsetypoint + "px";
        tipobj.style.visibility = "visible";
    }
}

function hideddrivetip() {
    if (ns6 || ie) {
        enabletip = false;
        tipobj.style.visibility = "hidden";
        tipobj.style.left = "-1000px";
        tipobj.style.backgroundColor = '';
        tipobj.style.width = '';
    }
}

document.onmousemove = positiontip;