<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1MessageBoard_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1MessageBoard_Operate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�������</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/validate.js"> </script>
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="��Ա������ϸ"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeMemLoginID" runat="server" Text=" �����ˣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:Label ID="LabelMemLoginID" runat="server" ForeColor="Gray" Text="��ʾ��Ϣ"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ��ϵ��ʽ��
                        </th>
                        <td>
                            <asp:Label ID="Label2" runat="server" ForeColor="Gray" Text="��ʾ��Ϣ"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeSendTime" runat="server" Text="����ʱ�䣺"></asp:Localize>
                        </th>
                        <td>
                            <asp:Label ID="LabelSendTime" runat="server" ForeColor="Gray" Text="��ʾ��Ϣ"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeContent" runat="server" Text="�������ݣ�"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxContent" runat="server" TextMode="MultiLine" ReadOnly="True"
                                CssClass="tinput txtarea"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <input type="button" value="�����б�" class="fanh" onclick=" window.history.go(-1) " />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
