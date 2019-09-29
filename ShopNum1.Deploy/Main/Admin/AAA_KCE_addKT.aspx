<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AAA_KCE_addKT.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.AAA_KCE_addKT" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>增减NEC币种</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="增加数额"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right">
                            用户工号：
                        </th>
                        <td >
                            
                            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                           <span>工号</span>
                        </td>
                        
                    </tr>
                    <tr >
                        <th align="right">
                            选择类型：
                        </th>
                        <td><asp:DropDownList ID="DropdownListSOperateType" runat="server" Width="201px" CssClass="tselect">
                                    <asp:ListItem Value="0">增加NEC</asp:ListItem><%--Score_dv--%>
                                    <asp:ListItem Value="1">减少NEC</asp:ListItem>
                                    <asp:ListItem Value="3">减少USDT</asp:ListItem>
                                    <asp:ListItem Value="5">减少ETH</asp:ListItem>
                                </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <th align="right">
                            数量：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBox3"  class="tinput" runat="server"></asp:TextBox>
                           <span></span>
                        </td>
                    </tr>
                    
                </table>
            </div>
            <div class="tablebtn">
                <%--<asp:Button ID="Button1" class="fanh" runat="server" Text="确定" OnClick="Button1_Click" />--%>
                <span id="msg" runat="server" style="color: Green;"></span>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
