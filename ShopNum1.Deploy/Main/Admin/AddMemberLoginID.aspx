<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddMemberLoginID.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.AddMemberLoginID" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
      输入会员编号：  <asp:TextBox ID="TextBoxMemLoginID" runat="server"></asp:TextBox>

        <asp:Button ID="Button1" runat="server" Text="确定" onclick="Button1_Click" />
        
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
