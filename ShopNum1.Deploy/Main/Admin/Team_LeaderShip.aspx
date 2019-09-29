<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Team_LeaderShip.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Team_LeaderShip" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CTC团队领导</title>
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
                    <asp:Label ID="LabelTitle" runat="server" Text="CTC团队领导"></asp:Label></h3>
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
                        <td>
                            <asp:TextBox ID="TextBox1"  class="tinput" runat="server"></asp:TextBox>
                           <span></span>
                        </td>
                    </tr>
                    
                    
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="Button1" class="fanh" runat="server" Text="确定修改" OnClick="Button1_Click" />
                <span id="msg" runat="server" style="color: Green;"></span>
            </div>
        </div>
    </div>
    </form>
</body>
</html>