var dragapproved = false;
var minrestore = 0;
//该变量表示窗口目前的状态，0表示初始化状态，1表示最大化状态
var initialwidth, initialheight;
//若Client浏览器为IE5.0以上版本的
var ie5 = document.all && document.getElementById;
//若Client浏览器为NetsCape6。0版本以上的
var ns6 = document.getElementById && !document.all;

function iecompattest() {
    return (!window.opera && document.compatMode && document.compatMode != "BackCompat") ? document.documentElement : document.body;
}

function drag_drop2(e) {
    if (ie5 && dragapproved && event.button == 1) {
        document.getElementById("Divfahuo").style.left = tempx + event.clientX - offsetx + "px";
        document.getElementById("Divfahuo").style.top = tempy + event.clientY - offsety + "px";
    } else if (ns6 && dragapproved) {
        document.getElementById("Divfahuo").style.left = tempx + e.clientX - offsetx + "px";
        document.getElementById("Divfahuo").style.top = tempy + e.clientY - offsety + "px";
    }
}

function initializedrag2(e) {
    offsetx = ie5 ? event.clientX : e.clientX;
    offsety = ie5 ? event.clientY : e.clientY; //document.getElementById("dwindowcontent").style.display="none" //此句代码可不要
    tempx = parseInt(document.getElementById("Divfahuo").style.left);
    tempy = parseInt(document.getElementById("Divfahuo").style.top);
    dragapproved = true;
    document.getElementById("Divfahuo").onmousemove = drag_drop2;
}

function loadwindow2(width, height) {
    if (!ie5 && !ns6)  //若不为IE或Netscpae浏览器，则使用一般的Window.open进行弹出窗口处理
    {
    } else {
        $("#zhezhao").show();
        $("#zhezhao").attr("class", "zhezhao");

        document.getElementById("Divfahuo").style.display = '';
    }
}

function maximize2() {
    if (minrestore == 0) {
        minrestore = 1; //maximize window
        document.getElementById("Divfahuo").setAttribute("src", "layout.png");
        document.getElementById("Divfahuo").style.width = ns6 ? window.innerWidth - 20 + "px" : iecompattest().clientWidth + "px";
        document.getElementById("Divfahuo").style.height = ns6 ? window.innerHeight - 20 + "px" : iecompattest().clientHeight + "px";
    } else {
        minrestore = 0; //restore window
        document.getElementById("Divfahuo").setAttribute("src", "layout.png");
        document.getElementById("Divfahuo").style.width = initialwidth;
        document.getElementById("Divfahuo").style.height = initialheight;
    }
    document.getElementById("Divfahuo").style.left = ns6 ? window.pageXOffset + "px" : iecompattest().scrollLeft + "px";
    document.getElementById("Divfahuo").style.top = ns6 ? window.pageYOffset + "px" : iecompattest().scrollTop + "px";
}

function closeit2() {
    document.getElementById("Divfahuo").style.display = "none";
    $("#zhezhao").hide();
    $("#textBoxName").val("");
    $("#Image1").attr("src", "");
    $("#textBoxDescription").val("");
    $('#DropDownListImgCategory2').val("");
}

function stopdrag2() {
    dragapproved = false;
    document.getElementById("Divfahuo").onmousemove = null;
//document.getElementById("Divfahuocontent").style.display="" //extra
}