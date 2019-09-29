<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="IisManager.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.IisManager" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>IISվ�����</title>
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body style="background-image: url(images/Bg_right.gif); background-repeat: repeat;
    font-size: 12px; padding: 0;">
    <form id="form1" runat="server">
    <div>
        <div class="navigator">
            <asp:Label ID="LabelPageTitle" runat="server" Text="�� ����IIS ��"></asp:Label>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td align="right" width="25%">
                    ������վ��IIS��
                </td>
                <td>
                    <asp:Button ID="ButtonIISRest" runat="server" Text="����" CssClass="bt2" OnClientClick=" return confirm('��ȷ��Ҫ������?�����Ӱ�쵽���ڷ���վ����û�') "
                        OnClick="ButtonIISRest_Click" />
                </td>
            </tr>
            <tr>
                <td align="right" width="25%">
                    ���ձ�վ���ڴ棺
                </td>
                <td>
                    <asp:Button ID="ButtonIisRecycle" runat="server" Text="����" CssClass="bt2" OnClientClick=" return confirm('��ȷ��Ҫ������?�����Ӱ�쵽���ڷ���վ����û�') "
                        OnClick="ButtonIisRecycle_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
