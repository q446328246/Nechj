<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="DelayWxShop_V82.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.DelayWxShop_V82" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>过期微信店铺</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    过期微信店铺</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table cellspacing="0" cellpadding="4" border="0" id="Table1" rules="cols" class="gridview_m">
                <thead>
                    <tr align="center" style="color: White;" class="list_header">
                        <th scope="col">
                            店铺名称
                        </th>
                        <th scope="col">
                            店铺ID
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% if (dt_WxShop.Rows.Count > 0)
                       {
                           for (int i = 0; i < dt_WxShop.Rows.Count; i++)
                           { %>
                    <tr style="cursor: default;">
                        <td align="center" style="">
                            <%= dt_WxShop.Rows[i]["shopname"] %>
                        </td>
                        <td align="center" style="">
                            <%= dt_WxShop.Rows[i]["memloginid"] %>
                        </td>
                    </tr>
                    <% }
                               }
                       else
                       { %>
                    <td height="30" align="center" colspan="2">
                        <strong style="font-size: 13px;">无查询的记录！</strong>
                    </td>
                    <% } %>
                </tbody>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
