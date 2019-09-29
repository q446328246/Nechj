<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Left.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="js/jquery-1.3.2.min.js" type="text/javascript"> </script>
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
    <style type="text/css">
        body
        {
            background-image: url(images/Bg_left.gif);
            background-repeat: repeat;
        }
        
        #left
        {
        }
        
        .iconChange
        {
            cursor: pointer;
        }
        
        .btt2
        {
            background: url("images/Bt_background.gif") no-repeat scroll 0 0 transparent;
            background: none;
            border: none;
            border-color: inherit;
            border-style: none;
            border-width: 0;
            color: #555555;
            cursor: pointer;
            font-size: 13px;
            font-weight: bold;
            height: 32px;
            line-height: 32px;
            position: relative;
            text-align: center;
            width: 100%;
        }
        
        .btt2_bg
        {
            background: url("images/openclose.png") repeat;
            background-image: url("images/openclose.png");
            color: #5555555;
            font-weight: bold;
            height: 32px;
        }
    </style>
    <script type="text/javascript">
        var status = "true";
        var status1 = true;

        function OpenClose(a) {

            var imageId = -1;
            var dts = document.getElementsByTagName("dt");

            for (var j = 0; j < dts.length; j++) {

                if ("dtMenu_" + j == "dtMenu_" + a) {
                    imageId = "dtMenu_" + j;
                    if (status1 == true) {

                        $("#" + imageId).parent().siblings().children("dt").children("img").attr("src", "images/icon_list_up.gif");
                        $("#" + imageId).parent().siblings().children("dd").hide();
                        $("#" + imageId).siblings().show();
                        $("#" + imageId).children("img").attr("src", "images/icon_list_down.gif");
                        //             
                        $("#" + imageId).parent().siblings().children("dt img:first").attr("src", "images/icon_list_down_first_add.gif");
                        $("#" + imageId).parent().siblings().children("dt img:last").attr("src", "images/icon_list_down_first_add.gif");
                        //              window.top.frames[2].


                        //           <a href='<%# Eval("PagePath") %>' target="mainFrame">
                        //                                        <%# Eval("Name") %></div>

                    } else {
                        $("#" + imageId).siblings().hide();
                    }
                }
            }
        }
    </script>
    <script type="text/javascript">
        var flag = true;

        function AllOpen(a) {

            var dds = document.getElementsByTagName("dd");

            if (flag) {
                for (var j = 0; j < dds.length; j++) {

                    dds[j].style.display = "block";
                    flag = false;
                    a.value = "ȫ���۵�";

                }
                var imgs = document.getElementsByTagName("img");
                for (var i = 0; i < imgs.length; i++) {
                    //src="images/icon_list_up.gif"
                    // var imspath=imgs[i].src.replace("/","//")
                    var lastIndex = imgs[i].src.lastIndexOf('/');
                    var imgname = imgs[i].src.substring(lastIndex + 1);

                    if (imgname == "icon_list_down_first_add.gif") {

                        imgs[i].setAttribute("src", "images/icon_list_down_first_down.gif");
                    }
                    if (imgname == "icon_list_down_last_add.gif") {
                        imgs[i].setAttribute("src", "images/icon_list_down_last_down.gif");
                    }
                    if (imgname == "icon_list_up.gif") {
                        imgs[i].setAttribute("src", "images/icon_list_down.gif");
                    }
                }

            } else {
                for (var j = 0; j < dds.length; j++) {

                    dds[j].style.display = "none";
                    flag = true;
                    a.value = "ȫ��չ��";
                }
                var imgs = document.getElementsByTagName("img");
                for (var i = 0; i < imgs.length; i++) {
                    var lastIndex = imgs[i].src.lastIndexOf('/');
                    var imgname = imgs[i].src.substring(lastIndex + 1);

                    if (imgname == "icon_list_down_first_down.gif") {
                        imgs[i].setAttribute("src", "images/icon_list_down_first_add.gif");
                    }
                    if (imgname == "icon_list_down_last_down.gif") {
                        imgs[i].setAttribute("src", "images/icon_list_down_last_add.gif");
                    }
                    if (imgname == "icon_list_down.gif") {


                        imgs[i].setAttribute("src", "images/icon_list_up.gif");
                    }
                }
            }
        }


        //left��չЧ��
        $(function () {

            $("dt:first").children("img").attr("src", "images/icon_list_down_first_add.gif");
            $("dt:last").children("img").attr("src", "images/icon_list_down_last_add.gif");
            $("dt").bind('click', function () {

                if (status == "true") {

                    $(this).siblings().show();

                    if ($(this).attr("id") == $("dt:first").attr("id")) {
                        $(this).children("img").attr("src", "images/icon_list_down_first_down.gif");

                    } else if ($(this).attr("id") == $("dt:last").attr("id")) {
                        $(this).children("img").attr("src", "images/icon_list_down_last_down.gif");

                    } else {
                        $(this).children("img").attr("src", "images/icon_list_down.gif");
                    }
                    status = "false";
                } else {

                    $(this).siblings().hide();

                    if ($(this).attr("id") == $("dt:first").attr("id")) {
                        $(this).children("img").attr("src", "images/icon_list_down_first_add.gif");

                    } else if ($(this).attr("id") == $("dt:last").attr("id")) {

                        $(this).children("img").attr("src", "images/icon_list_down_last_add.gif");
                    } else {

                        $(this).children("img").attr("src", "images/icon_list_up.gif");


                    }
                    status = "true";

                }
            });
        });

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="left">
        <asp:Repeater ID="RepeaterMenu" runat="server" OnItemDataBound="RepeaterMenu_ItemDataBound">
            <ItemTemplate>
                <dl class="category clearfix" style="margin: 0px; padding: 0px;">
                    <dt id='<%#"dtMenu_" + RepeaterMenu.Items.Count %>' style="color: #555555; font-size: 13px;
                        font-weight: bold; padding-bottom: 2px;">
                        <img src="images/icon_list_up.gif" class="iconChange" />
                        <span style="display: inline; position: relative; top: -5px;">
                            <%# Eval("Name") %></span>
                        <asp:HiddenField ID="HiddenFieldOneID" runat="server" Value='<%# Eval("OneID") %>' />
                    </dt>
                    <asp:Repeater ID="RepeaterChild" runat="server">
                        <ItemTemplate>
                            <dd id="Dd1" runat="server" style="display: none; height: 20px; left: -40px; margin-bottom: 0px;
                                margin-top: 0px; padding: 0px; position: relative; top: -5px; width: 180px;">
                                <asp:Localize ID="LocalizeImgLeft" runat="server" Text="<img src='images/icon_Leftline.gif'/>"> </asp:Localize>
                                <asp:Localize ID="Localizeimg" runat="server" Text="<img src='images/icon_line.gif' id='img_Line' runat ='server' style='border-width:0;'/>"></asp:Localize>
                                <div class="Event" style="display: inline; left: -2px; position: relative; top: -7px;
                                    white-space: nowrap;">
                                    <a href='<%# Eval("PagePath") %>' target="mainFrame">
                                        <%# Eval("Name") %></div>
                                <input id="Hidden1" type="hidden" value='<%# Eval("PagePath") %>' /></a>
                            </dd>
                        </ItemTemplate>
                    </asp:Repeater>
                </dl>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" />
    </form>
</body>
</html>
