<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Top.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Top" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3c.org/TR/1999/REC-html401-19991224/loose.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>ShopNum1商城系统后台管理</title>
    <meta content="text/html; charset=utf-8" http-equiv="Content-Type" />
    <link rel="Stylesheet" type="text/css" href="css/index.css" />
    <script src="js/jquery-1.3.2.min.js" type="text/javascript"> </script>
    <script type="text/javascript">
        function test() {
            var _div = document.getElementById("test");

            var _hiddenImg = document.getElementById("hiddenImg1");

            if (window.top.document.getElementById("box").cols == '180,*') {
                window.top.document.getElementById("box").cols = '*,100%';
                _div.innerHTML = "显示菜单";
                _hiddenImg.setAttribute("src", "images/show_menu.gif");
            } else {
                window.top.document.getElementById("box").cols = '180,*';
                _div.innerHTML = "隐藏菜单";
                _hiddenImg.setAttribute("src", "images/hide_menu.gif");
            }
        }


        $(document).ready(function () {
            $("#Open").toggle(function () {
                $("#Open").html("全部折叠");
                window.top.frames[1].AllOpen(this);
                $("#hiddenImg2").attr("src", "images/anniu1.gif");

            }, function () {
                $("#Open").html("全部展开");
                window.top.frames[1].AllOpen(this);
                $("#hiddenImg2").attr("src", "images/anniu2.gif");
            });

        });

        function TopOpenClose(a) {
            window.top.frames[1].OpenClose(a.id);

        }

        function changeTab(count, index) {
            for (var i = 1; i <= count; i++) {
                document.getElementById('current' + i).className = '';
            }
            document.getElementById('current' + index).className = 'curr1';
        }

    </script>
    <script type="text/javascript">

        function initk() {
            var s = window.screen.width;

            if (s <= 1024) {
                document.getElementById("current8").style.display = "none";
                document.getElementById("current9").style.display = "none";
                document.getElementById("current10").style.display = "none";
            }
        }

    </script>
    <style type="text/css">
        .divTop
        {
            background: url("images/topbg.jpg") repeat-x 0 0;
            clear: both;
            height: 80px;
            width: 100%;
        }
        
        .topMiddle
        {
            clear: both;
            height: 41px;
            width: 100%;
        }
        
        .toplogo
        {
            float: left;
            margin-left: 15px;
            width: 300px;
        }
        
        .topweizi
        {
            color: #FFFFFF;
            float: right;
        }
        
        .topNav
        {
            float: left;
            height: 22px;
            line-height: 22px;
            overflow: hidden;
            padding: 0 7px;
            text-align: center;
            width: auto;
        }
        
        .topNav a
        {
            color: #555555;
            font-size: 12px;
            font-weight: bold;
        }
        
        .topNav a:hover
        {
            color: #FFFFFF;
            font-size: 12px;
        }
        
        .topbottom
        {
            clear: both;
        }
        
        .topleft
        {
            float: left;
            margin-top: 15px;
        }
        
        .topright
        {
            float: right;
        }
        
        .bk
        {
            border: 1px solid #6699CC;
            height: 22px;
            line-height: 22px;
        }
        
        .topseach
        {
            background: url("images/aniu.gif") no-repeat scroll 0 0 transparent;
            border: medium none;
            height: 24px;
            margin-left: 3px;
            margin-right: 7px;
            width: 37px;
        }
        
        .topleft td
        {
            color: #666666;
            font-size: 12px;
            font-weight: bold;
            padding-right: 5px;
        }
        
        .topleft td img
        {
            margin-right: 3px;
        }
        
        .topleft a
        {
            color: #666666;
            font-size: 12px;
            font-weight: bold;
        }
        
        .topleft a:hover
        {
            color: #666666;
            font-size: 12px;
            font-weight: bold;
        }
        
        .topcenter
        {
            float: left;
            overflow: hidden;
        }
        
        ul
        {
            list-style: none outside none;
        }
        
        .topul li
        {
            float: left;
            height: 25px;
            line-height: 25px;
            margin-right: 6px;
            width: 75px;
        }
        
        .topul li a
        {
            background: none repeat scroll 0 0 #F1F1F1;
            color: #000000;
            display: block;
            float: left;
            font-size: 12px;
            height: 25px;
            line-height: 25px;
            margin-right: 6px;
            position: relative;
            text-align: center;
            text-decoration: none;
            width: 75px;
        }
        
        .topul li a:hover
        {
            background: none repeat scroll 0 0 #6699CC;
            color: #FFFFFF;
            display: block;
            float: left;
            font-size: 12px;
            font-weight: bold;
            line-height: 25px;
            margin-right: 6px;
            position: relative;
            text-decoration: none;
        }
        
        .topul .curr1 a
        {
            background: none repeat scroll 0 0 #6699CC;
            color: #FFFFFF;
            display: block;
            float: left;
            font-size: 12px;
            font-weight: bold;
            line-height: 25px;
            margin-right: 6px;
            position: relative;
            text-decoration: none;
        }
        
        .curraaaa
        {
            background: none repeat scroll 0 0 #CCCCCC;
            color: #CCCCCC;
            display: block;
            float: left;
            font-size: 12px;
            font-weight: bold;
            line-height: 25px;
            margin-right: 6px;
            position: relative;
            text-decoration: none;
        }
        
        .currbbbb
        {
            background: none repeat scroll 0 0 #000000;
            color: #000000;
            display: block;
            float: left;
            font-size: 12px;
            font-weight: bold;
            line-height: 25px;
            margin-right: 6px;
            position: relative;
            text-decoration: none;
        }
        
        .orderall
        {
            background: none repeat scroll 0 0 #F1F4F9;
        }
        
        .orderMenu
        {
            list-style: none outside none;
        }
        
        .orderMenu li
        {
            float: left;
            height: 23px;
            line-height: 23px;
            margin-right: 8px;
            width: 80px;
        }
        
        .orderMenu li a
        {
            display: block;
            height: 23px;
            line-height: 23px;
            text-align: center;
            width: 80px;
        }
        
        .orderMenu .curr1 a
        {
            background: url("../images/orderbg2.png") no-repeat scroll 0 0 transparent;
            color: #000000;
            display: block;
            font-size: 12px;
            font-weight: bold;
            height: 23px;
            line-height: 23px;
            width: 80px;
        }
        
        .orderMenu .curr1 a:link
        {
            background: url("../images/orderbg2.png") no-repeat scroll 0 0 transparent;
            color: #000000;
            display: block;
            font-size: 12px;
            font-weight: bold;
            height: 23px;
            line-height: 23px;
            width: 80px;
        }
        
        .orderMenu .curr1 a:hover
        {
            background: url("../images/orderbg2.png") no-repeat scroll 0 0 transparent;
            color: #000000;
            display: block;
            font-size: 12px;
            font-weight: bold;
            height: 23px;
            line-height: 23px;
            width: 80px;
        }
        
        .orderMenu .curr1 a:visited
        {
            background: url("../images/orderbg2.png") no-repeat scroll 0 0 transparent;
            color: #000000;
            display: block;
            font-size: 12px;
            font-weight: bold;
            height: 23px;
            line-height: 23px;
            width: 80px;
        }
        
        .gwk
        {
            color: #B62932;
            text-decoration: underline;
        }
        
        .gwk a
        {
            color: #B62932;
            text-decoration: underline;
        }
        
        .gwk a:hover
        {
            color: #B62932;
            text-decoration: underline;
        }
        
        .gwk a:visited
        {
            color: #B62932;
            text-decoration: underline;
        }
    </style>
</head>
<body onload=" initk() ">
    <form id="ctl00" method="post" name="ctl00" runat="server" action="Top.aspx">
    <div class="divTop">
        <div class="topMiddle">
            <div class="toplogo">
                <img src="images/adminLogo.gif" />
            </div>
            <div class="topweizi">
                <div class="topNav">
                    <a href='AdminWelcome_List.aspx' target="mainFrame" id="top">欢迎页</a></div>
                <div class="topNav ">
                    <a href='Html/AboutShopNum1.htm' target="mainFrame" id="A1">关于ShopNum1</a></div>
                <div class="topNav ">
                    <a href='/Default.aspx' target="_blank" id="A2">浏览商城</a></div>
                <div class="topNav ">
                    <a href='LoginExit.aspx' target="mainFrame" id="A3">退出后台</a></div>
            </div>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" width="100%" class="topbottom">
            <tr>
                <td width="150" height="25">
                    <div class="topleft" id="topleft01">
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <img id="hiddenImg1" src="images/hide_menu.gif" alt="" /><a id="test" href="#" onclick=" test() ">隐藏菜单</a>
                                </td>
                                <td>
                                    <img id="hiddenImg2" src="images/anniu2.gif" alt="" /><a id="Open" href="#">全部展开</a>
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td>
                    <div class="topcenter">
                        <ul class="topul">
                            <li id="current1" class="curr1"><a href="Prouduct_List.aspx" id="3" onclick=" TopOpenClose(this);changeTab(11, 1); "
                                target="mainFrame">商品管理</a> </li>
                            <li id="current2"><a href="Order_List.aspx" id="4" onclick=" TopOpenClose(this);changeTab(11, 2); "
                                target="mainFrame">订单管理</a> </li>
                            <li id="current3"><a href="Member_List.aspx" id="6" onclick=" TopOpenClose(this);changeTab(11, 3); "
                                target="mainFrame">会员管理 </a></li>
                            <li id="current4"><a href="Image_List.aspx" id="12" onclick=" TopOpenClose(this);changeTab(11, 4); "
                                target="mainFrame">图片管理</a> </li>
                            <li id="current5"><a href="ShopInfoList_Manage.aspx" id="2" onclick=" TopOpenClose(this);changeTab(11, 5); "
                                target="mainFrame">店铺管理</a> </li>
                            <li id="current6"><a href="ServiceSite_Settings.aspx" id="0" onclick=" TopOpenClose(this);changeTab(11, 6); "
                                target="mainFrame">平台管理</a> </li>
                            <li id="current7"><a href="ShopNum1_CategoryInfo_List.aspx" id="11" onclick=" TopOpenClose(this);changeTab(11, 7); "
                                target="mainFrame">分类管理</a> </li>
                            <li id="current8"><a href="ShopNum1_SupplyDemand_List.aspx" id="10" onclick=" TopOpenClose(this);changeTab(11, 8); "
                                target="mainFrame">供求管理</a> </li>
                            <li id="current9"><a href="Cache/Global_CacheManage.aspx" id="18" onclick=" TopOpenClose(this);changeTab(11, 9); "
                                target="mainFrame">网站优化</a> </li>
                            <li id="current10"><a href="Payment_List.aspx" id="17" onclick=" TopOpenClose(this);changeTab(11, 10); "
                                target="mainFrame">系统管理</a> </li>
                            <li id="current11"><a href="ProuductChecked_List.aspx" id="20" onclick=" TopOpenClose(this);changeTab(11, 11); "
                                target="mainFrame">信息审核</a> </li>
                        </ul>
                    </div>
                </td>
                <asp:Panel ID="panel" runat="server" Visible="false">
                    <td width="180" height="25">
                        <div class="topright">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxSearch" runat="server" class="bk"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonSearch" OnClick="ButtonSearch_Click" runat="server" OnClientClick=" document.forms[0].target = 'mainFrame';window.location.href = window.location.href; "
                                            class="topseach" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </asp:Panel>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
