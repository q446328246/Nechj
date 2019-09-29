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
        document.getElementById("lmf_Divfahuo").style.left = tempx + event.clientX - offsetx + "px";
        document.getElementById("lmf_Divfahuo").style.top = tempy + event.clientY - offsety + "px";
    } else if (ns6 && dragapproved) {
        document.getElementById("lmf_Divfahuo").style.left = tempx + e.clientX - offsetx + "px";
        document.getElementById("lmf_Divfahuo").style.top = tempy + e.clientY - offsety + "px";
    }
}

function initializedrag2(e) {
    offsetx = ie5 ? event.clientX : e.clientX;
    offsety = ie5 ? event.clientY : e.clientY; //document.getElementById("dwindowcontent").style.display="none" //此句代码可不要
    tempx = parseInt(document.getElementById("lmf_Divfahuo").style.left);
    tempy = parseInt(document.getElementById("lmf_Divfahuo").style.top);
    dragapproved = true;
    document.getElementById("lmf_Divfahuo").onmousemove = drag_drop2;
}

function loadwindow2(width, height) {
    if (!ie5 && !ns6)  //若不为IE或Netscpae浏览器，则使用一般的Window.open进行弹出窗口处理
    {
    } else {
        $("#lmf_zhezhao").show();
        var oDiv = document.getElementById("lmf_Divfahuo");
        document.getElementById("lmf_Divfahuo").style.left = "100px";
//        $("#zhezhao").attr("class","zhezhao");
        oDiv.style.MozUserSelect = "-moz-all";
        document.getElementById("lmf_Divfahuo").style.display = '';


        var dargX = 0;
        var dargY = 0;
        oDiv.onmousedown = function(ev) {
            var oEvent = ev || event;
            dargX = oEvent.clientX - oDiv.offsetLeft; //获取鼠标与div左边的距离
            dargY = oEvent.clientY - oDiv.offsetTop; //获取鼠标与div头部的距离
            document.onmousemove = function(ev) {
                var oEvent = ev || event;
                var Left = oEvent.clientX - dargX;
                var Top = oEvent.clientY - dargY;
                if (Left < 0) {
                    Left = 0;
                }
                if (Left > document.documentElement.clientWidth - oDiv.offsetWidth) {
                    Left = document.documentElement.clientWidth - oDiv.offsetWidth;
                }
                if (Top < 0) {
                    Top = 0;
                }
                if (Top > document.documentElement.clientHeight - oDiv.offsetHeight) {
                    Top = document.documentElement.clientHeight - oDiv.offsetHeight;
                }
                oDiv.style.left = Left + "px";
                oDiv.style.top = Top + "px";

            };
            document.onmouseup = function() {

                document.onmousemove = null;

                document.onmouseup = null;

            };

            return false;

        };
    }

}

function maximize2() {
    if (minrestore == 0) {
        minrestore = 1; //maximize window
        document.getElementById("lmf_Divfahuo").setAttribute("src", "layout.png");
        document.getElementById("lmf_Divfahuo").style.width = ns6 ? window.innerWidth - 20 + "px" : iecompattest().clientWidth + "px";
        document.getElementById("lmf_Divfahuo").style.height = ns6 ? window.innerHeight - 20 + "px" : iecompattest().clientHeight + "px";
    } else {
        minrestore = 0; //restore window
        document.getElementById("lmf_Divfahuo").setAttribute("src", "layout.png");
        document.getElementById("lmf_Divfahuo").style.width = initialwidth;
        document.getElementById("lmf_Divfahuo").style.height = initialheight;
    }
    document.getElementById("lmf_Divfahuo").style.left = ns6 ? window.pageXOffset + "px" : iecompattest().scrollLeft + "px";
    document.getElementById("lmf_Divfahuo").style.top = ns6 ? window.pageYOffset + "px" : iecompattest().scrollTop + "px";
}

function closeit2() {
    document.getElementById("lmf_Divfahuo").style.display = "none";
    $("#lmf_zhezhao").hide();
    $("#textBoxName").val("");
    $("#Image1").attr("src", "");
    $("#textBoxDescription").val("");
    $('#DropDownListImgCategory2').val("");
}

function stopdrag2() {
    dragapproved = false;
    document.getElementById("lmf_Divfahuo").onmousemove = null;
//document.getElementById("Divfahuocontent").style.display="" //extra
}