<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>详细信息</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Cache-Control" content="no-cache" />
    <meta http-equiv="Expires" content="0" />
    <link rel='stylesheet' type='text/css' href='style/style.css' />
    <script src="js/jquery.pack.js" type="text/javascript"> </script>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="containe_bg">
        <!--头部Top-->
        <ShopNum1ShopAdmin:S_Head ID="S_Head" runat="server" SkinFilename="Skin/S_Head.ascx" />
        <!--内容部分Content-->
        <div id="content_bg">
            <div class="con_order">
                <!--步骤-->
                <div class="buzho">
                    <ul>
                        <li>
                            <img src="images/buzho01.jpg" width="317" height="51" /></li>
                        <li>
                            <img src="images/buzho02_1.jpg" width="388" height="51" /></li>
                        <li>
                            <img src="images/buzho03.jpg" width="295" height="51" /></li>
                    </ul>
                </div>
                <div class="tisc_light" style="border-bottom: solid 1px #e8e8e8;">
                    <p>
                        商品基本信息</p>
                    <ShopNum1ShopAdmin:S_OpGoods1 ID="S_OpGoods1" runat="server" SkinFilename="Skin/S_OpGoods1.ascx" />
                    <ShopNum1ShopAdmin:S_OpGoods1 ID="S_OpGoods1C2C" runat="server" SkinFilename="Skin/S_OpGoods1C2C.ascx" />
                    <script type="text/javascript" language="javascript" src="/js/DatePicker/WdatePicker.js"> </script>
                    <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
                    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
                    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
                    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
                    <script type="text/javascript" language="javascript" src="js/S_OpGoods1.js"> </script>
                    <script type="text/javascript" language="javascript" src="js/S_OpGoods2.js"> </script>
                    <link rel='stylesheet' type='text/css' href='style/dshow.css' />
                    <script type="text/javascript" src="js/dshow.js"> </script>
                    <ShopNum1ShopAdmin:S_OpGoods2 ID="S_OpGoods2" runat="server" SkinFilename="Skin/S_OpGoods2.ascx" />
                </div>
            </div>
        </div>
        <!--页面底部Bottom-->
        <div style="clear: both;">
        </div>
        <!--页面底部Bottom-->
        <ShopNum1ShopAdmin:S_Bottom ID="S_Bottom" runat="server" SkinFilename="Skin/S_Bottom.ascx"
            class="foot_bg" />
    </div>
    <script type="text/javascript" language="javascript" src="js/jquery.form.js"> </script>
    <script type="text/javascript" src="/main/js/location.js"> </script>
    <script type="text/javascript" language="javascript" src="/main/js/areas.js"> </script>
    </form>
</body>
</html>
