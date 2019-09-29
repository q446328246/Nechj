
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AAA_KCE_addCaiWuTx.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.AAA_KCE_addCaiWuTx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>财务提现</title>
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
                    <asp:Label ID="LabelTitle" runat="server" Text="财务提现"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right">
                            账户总额：
                        </th>
                        
                        <td>
                     
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                           
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            提现数量：
                        </th>
                        <td>
                            
                            <asp:TextBox ID="TextBox3"  class="tinput" runat="server"></asp:TextBox>
                           <span></span>
                        </td>
                    </tr>
                  <%--  <tr>
                        <th align="right">
                            比例：
                        </th>
                        <td>
                            <asp:TextBox ID="TextBox5" maxlength="3"  class="tinput" runat="server"></asp:TextBox>
                            %(<span>提成比例为1-100之间整数</span>)
                        </td>
                    </tr>--%>
                    
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="Button1" class="fanh" runat="server" Text="确定" OnClick="Button1_Click" />
                <span id="msg" runat="server" style="color: Green;"></span>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
