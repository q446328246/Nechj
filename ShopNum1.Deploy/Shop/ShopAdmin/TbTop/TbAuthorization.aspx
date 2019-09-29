<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbAuthorization.aspx.cs"
         Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbAuthorization" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
    </head>
    <body class="right_body">
        <form id="form1" runat="server">
            <div class="dpsc_mian">
                <p class="ptitle">
                    <a href="S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span class="breadcrume_text">淘宝同步授权</span></p>
                <div style="padding: 10px 0px 10px 5px;">
                    <div class="taobaomain">
                        <asp:Button ID="btnAuthorization" runat="server" Text=" " OnClick="btnAuthorization_Click"
                                    CssClass="sqaniu" />
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>