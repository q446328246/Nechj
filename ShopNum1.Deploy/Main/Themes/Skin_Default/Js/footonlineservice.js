window.onerror = function () { return true; }

function moveAlong(layerName, paceLeft, paceTop, fromLeft, fromTop) {
    clearTimeout(master.timer)
    if (master.curLeft != fromLeft) {
        if ((Math.max(master.curLeft, fromLeft) - Math.min(master.curLeft, fromLeft)) < paceLeft) { master.curLeft = fromLeft; }
        else if (master.curLeft < fromLeft) { master.curLeft = master.curLeft + paceLeft; }
        else if (master.curLeft > fromLeft) { master.curLeft = master.curLeft - paceLeft; }
        masterDiv.style.left = master.curLeft + "px";

    }
    if (master.curTop != fromTop) {
        if ((Math.max(master.curTop, fromTop) - Math.min(master.curTop, fromTop)) < paceTop)
        { master.curTop = fromTop }
        else if (master.curTop < fromTop) { master.curTop = master.curTop + paceTop; }
        else if (master.curTop > fromTop) { master.curTop = master.curTop - paceTop; }
        masterDiv.style.top = master.curTop + "px";

    }
    master.timer = setTimeout(function () { moveAlong(layerName, paceLeft, paceTop, fromLeft, fromTop); }, 30)
}

function setPace(layerName, fromLeft, fromTop, motionSpeed) {

    master.gapLeft = (Math.max(master.curLeft, fromLeft) - Math.min(master.curLeft, fromLeft)) / motionSpeed
    master.gapTop = (Math.max(master.curTop, fromTop) - Math.min(master.curTop, fromTop)) / motionSpeed
    moveAlong(layerName, master.gapLeft, master.gapTop, fromLeft, fromTop)
}
function FixY() {
    var masterDiv = document.getElementById("master");
    if(masterDiv != null)
    {
        masterDiv.style.top = (window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop) + 150 + "px";
    }
}

var expandState = 0;

function expand() {
    if (expandState == 0) {
        setPace('master', 0, 10, 10);
        if (!window.XMLHttpRequest) {
            if (document.body.offsetWidth < 1400 && document.documentElement.scrollTop < 72)
                if (document.getElementById("search_ctl00_DropDownListType") != null) {
                    document.getElementById("search_ctl00_DropDownListType").style.visibility = "hidden";
                }
        }

        expandState = 1;
    }
    else {
        setPace('master', -150, 10, 10);
        if (document.getElementById("search_ctl00_DropDownListType") != null) {
            document.getElementById("search_ctl00_DropDownListType").style.visibility = "visible";
        }
        //document.menutop.src='/Main/Themes/Skin_Default/Images/kefu_1.gif';
        expandState = 0;
    }
}

var ie = !!document.all;
var master = {};
master.curLeft = -186; master.curTop = 10;
master.gapLeft = 0; master.gapTop = 0;
master.timer = null;
var masterDiv = null;
(function () {
    masterDiv = document.getElementById("master");
    setInterval('FixY()', 100);
})();


