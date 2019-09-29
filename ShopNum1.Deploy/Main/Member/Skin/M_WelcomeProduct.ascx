<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_WelcomeProduct.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_WelcomeProduct" %>
<script>
    function funNextB() {
        var f1 = $("#<%=HiddenFieldPageIndex.ClientID %>").val();
        var newpage1 = parseInt(f1) + 4;
        var newpage2 = parseInt(f1) + 7;
        $.get("/Api/Main/Member/GetJson.ashx?type=GetShopProductBrowse&start=" + newpage1 + "&end=" + newpage2 + "", null, function (data) {
            if (data != "[object XMLDocument]" && data != "") {
                $("#<%=HiddenFieldPageIndex.ClientID %>").val(parseInt(f1) + 4);
                funBrowseProduct(parseInt($("#<%=HiddenFieldPageIndex.ClientID %>").val()), parseInt($("#<%=HiddenFieldPageIndex.ClientID %>").val()) + 3);
            } else {
                alert("已经是最后一页了！");
            }
        });
    }

    function funShangB() {
        var f1 = $("#<%=HiddenFieldPageIndex.ClientID %>").val();
        if (f1 >= 5) {
            $("#<%=HiddenFieldPageIndex.ClientID %>").val(parseInt(f1) - 4);
            funBrowseProduct(parseInt(f1) - 4, parseInt(f1) - 1);

        }
        else {
            alert("已经是首页了！");
        }
    }

    function funBrowseProduct(val1, val2) {
        $.get("/Api/Main/Member/GetJson.ashx?type=GetShopProductBrowse&start=" + val1 + "&end=" + val2 + "", null, function (data) {
            if (data != "") {
                if (data != "[object XMLDocument]" && data != "") {
                    var vdata = eval('(' + data + ')');
                    var Str = "";
                    $.each(vdata, function (m, n) {
                        Str += "<dl><dt><a target=\"_blank\" href=\"" + n.ahref + "\"><img src=\"" + n.productimage + "\" width=\"130\" height=\"130\"  onerror=\"javascript:this.src='/ImgUpload/noImg.jpg'\"  /></a></dt><dd>" + n.name + "</dd><dd style=\"padding-top:10px;\"><strong style=\"font-size:16px;\" class=\"red\">￥" + n.shopprice + "</strong></dd></dl>";
                    });
                    $("#yllsp").html(Str);
                }
                else {
                    $("#shangImage1").hide();
                    $("#xiaImage1").hide(); $("#menucontent3").hide();
                }
            }
            else {
                $("#shangImage1").hide();
                $("#xiaImage1").hide(); $("#menucontent3").hide();
            }
        });
    }

    //团购
    function funGroupProduct(val1, val2) {
        $.get("/Api/Main/Member/GetJson.ashx?type=GroupProduct&start1=" + val1 + "&end1=" + val2 + "", null, function (data) {
            if (data != "") {

                if (data != "[object XMLDocument]" && data != "") {
                    var vdata = eval('(' + data + ')');
                    var Str = "";
                    $.each(vdata, function (m, n) {
                        Str += "<dl><dt><a target=\"_blank\" href=\"" + n.ahref + "\"><img src=\"" + n.groupimg + "\" width=\"130\" height=\"130\"  onerror=\"javascript:this.src='/ImgUpload/noImg.jpg'\"  /></a></dt><dd>" + n.name + "</dd><dd style=\"padding-top:10px;\"><strong style=\"font-size:16px;\" class=\"red\">￥" + n.groupprice + "</strong></dd></dl>";
                    });
                    $("#zxtg").html(Str);
                }
                else {
                    $("#shangImage2").hide();
                    $("#xiaImage2").hide(); $("#menucontent1").hide();
                }
            } else {
                $("#shangImage2").hide();
                $("#xiaImage2").hide(); $("#menucontent1").hide();
            }
        });
    }


    function funNextC() {
        var f1 = $("#<%=HiddenFieldTgPageIndex.ClientID %>").val();
        var newpage3 = parseInt(f1) + 4;
        var newpage4 = parseInt(f1) + 7;
        $.get("/Api/Main/Member/GetJson.ashx?type=GroupProduct&start1=" + newpage3 + "&end1=" + newpage4 + "", null, function (data) {
            if (data != "[object XMLDocument]" && data != "") {
                $("#<%=HiddenFieldTgPageIndex.ClientID %>").val(parseInt(f1) + 4)
                funGroupProduct(parseInt($("#<%=HiddenFieldTgPageIndex.ClientID %>").val()), parseInt($("#<%=HiddenFieldTgPageIndex.ClientID %>").val()) + 3);
            } else {
                alert("已经是最后一页了");
            }
        });


    }

    function funShangC() {
        var f1 = $("#<%=HiddenFieldTgPageIndex.ClientID %>").val();
        if (f1 >= 5) {
            $("#<%=HiddenFieldTgPageIndex.ClientID %>").val(parseInt(f1) - 4);
            funGroupProduct(parseInt(f1) - 4, parseInt(f1) - 1);

        }
        else {
            alert("已经是首页了！");
        }
    }


    //----------------------------------------------------
    //抢购
    function funQgProduct(val1, val2) {
        $.get("/Api/Main/Member/GetJson.ashx?type=GetShopQgProduct&start2=" + val1 + "&end2=" + val2 + "", null, function (data) {
            if (data != "") {
                if (data != "[object XMLDocument]" && data != "") {
                    var vdata = eval('(' + data + ')');
                    var Str = "";
                    $.each(vdata, function (m, n) {
                        Str += "<dl><dt><a target=\"_blank\" href=\"" + n.ahref + "\"><img src=\"" + n.originalimage + "\" width=\"130\" height=\"130\"  onerror=\"javascript:this.src='/ImgUpload/noImg.jpg'\"  /></a></dt><dd>" + n.name.substring(0, 22) + "</dd><dd style=\"padding-top:10px;\"><strong style=\"font-size:16px;\" class=\"red\">￥" + n.shopprice + "</strong></dd></dl>";
                    });
                    $("#zxqg").html(Str);
                }
                else {
                    $("#shangImage3").hide();
                    $("#xiaImage3").hide(); $("#menucontent2").hide();
                }
            }
            else {
                $("#shangImage3").hide();
                $("#xiaImage3").hide(); $("#menucontent2").hide();
            }
        });
    }


    function funNextD() {
        var f1 = $("#<%=HiddenFieldQgPageIndex.ClientID %>").val()
        var newpage5 = parseInt(f1) + 4;
        var newpage6 = parseInt(f1) + 7;
        $.get("/Api/Main/Member/GetJson.ashx?type=GetShopQgProduct&start2=" + newpage5 + "&end2=" + newpage6 + "", null, function (data) {
            if (data != "[object XMLDocument]" && data != "") {
                $("#<%=HiddenFieldQgPageIndex.ClientID %>").val(parseInt(f1) + 4)
                funQgProduct(parseInt($("#<%=HiddenFieldQgPageIndex.ClientID %>").val()), parseInt($("#<%=HiddenFieldQgPageIndex.ClientID %>").val()) + 3);
            } else {
                alert("已经是最后一页了！");
            }
        });


    }

    function funShangD() {
        var f1 = $("#<%=HiddenFieldQgPageIndex.ClientID %>").val()
        if (f1 >= 5) {
            $("#<%=HiddenFieldQgPageIndex.ClientID %>").val(parseInt(f1) - 4);
            funQgProduct(parseInt(f1) - 4, parseInt(f1) - 1);

        }
        else {
            alert("已经是首页了！");
        }
    }
    
</script>
<div class="huadong">
    <div id="channel">
        <h1>
            <ul>
                <li id="channel1" onmouseover="channelkey(1)" style="color: #CC0000;">最新团购</li>
                <li style="text-indent: 4px;" id="channel2" onmouseover="channelkey(2)">最新抢购</li>
                <li style="text-indent: 4px;" id="channel3" onmouseover="channelkey(3)">已浏览商品</li>
            </ul>
        </h1>
        <div id="menucontent1" class="menu" style="display: block;">
            <div class="me_l">
                <img src="images/jiantouzxl.jpg" width="21" height="125" onclick="funShangC()" id="shangImage2"
                    style="cursor: pointer" />
            </div>
            <div style="width: 540px; float: left;" id="zxtg">
            </div>
            <div class="me_r">
                <img src="images/jiantouzxr.jpg" width="21" height="125" onclick="funNextC()" id="xiaImage2"
                    style="cursor: pointer" />
            </div>
        </div>
        <div id="menucontent2" class="menu" style="display: none;">
            <div class="me_l">
                <img src="images/jiantouzxl.jpg" width="21" height="125" onclick="funShangD()" id="shangImage3"
                    style="cursor: pointer" />
            </div>
            <div style="width: 540px; float: left;" id="zxqg">
            </div>
            <div class="me_r">
                <img src="images/jiantouzxr.jpg" width="21" height="125" onclick="funNextD()" id="xiaImage3"
                    style="cursor: pointer" />
            </div>
        </div>
        <div id="menucontent3" class="menu" style="display: none;">
            <div class="me_l">
                <img src="images/jiantouzxl.jpg" width="21" height="125" onclick="funShangB()" id="shangImage1"
                    style="cursor: pointer" />
            </div>
            <div style="width: 540px; float: left;" id="yllsp">
            </div>
            <div class="me_r">
                <img src="images/jiantouzxr.jpg" width="21" height="125" onclick="funNextB()" id="xiaImage1"
                    style="cursor: pointer" />
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="HiddenFieldPageIndex" runat="server" Value="1" />
<asp:HiddenField ID="HiddenFieldTgPageIndex" runat="server" Value="1" />
<asp:HiddenField ID="HiddenFieldQgPageIndex" runat="server" Value="1" />
