<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateCommunity.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.UpdateCommunity" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
        <script src="/Main/js/location.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
     <br /> <br />
    <div>
    没有区代（社区）的换成区代（社区）
     <br />
    </div>
    <div>
     <br />
        原区代或社区(填写编号)：<asp:TextBox ID="TextBox1"  runat="server"></asp:TextBox>
        新区代或社区(填写编号):<asp:TextBox ID="TextBox2"    runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="修改" onclick="Button1_Click" />
        <br />
        <asp:Label Text="" runat="server" id="xianshi"/>
    </div>
    <br />
    <div>
    区代（社区）和区代（社区）互换 <br />
    </div>
     <br />
    <div>
        原区代或社区(填写编号)：<asp:TextBox ID="TextBox3"  runat="server"></asp:TextBox>
        新区代或社区(填写编号):<asp:TextBox ID="TextBox4"    runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="修改" onclick="Button2_Click"  />
        <br />
        <asp:Label Text="" runat="server" id="Label1"/>
    </div>
    </form>
</body>
</html>
