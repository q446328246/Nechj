<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ZtcGoodsDetal.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ZtcGoodsDetal" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ֱͨ����Ʒ��ϸ</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <link rel="stylesheet" href="/kindeditor/plugins/code/prettify.css" />
    <script type="text/javascript" charset="utf-8" src="/kindeditor/kindeditor.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/lang/zh_CN.js"> </script>
    <script type="text/javascript" charset="utf-8" src="/kindeditor/plugins/code/prettify.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="ֱͨ����Ʒ��ϸ"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <asp:Repeater ID="RepeaterShow" runat="server">
                    <HeaderTemplate>
                        <table border="0" cellpadding="0" cellspacing="1">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <th align="right">
                                ��ƷͼƬ��
                            </th>
                            <td>
                                <asp:Image ID="ImageProduct" runat="server" ImageUrl='<%#Eval("ZtcImg") %>' Width="300"
                                    Height="260" />
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                ֱͨ�����ƣ�
                            </th>
                            <td>
                                <%#Eval("ZtcName") %><span>(������ǰֱ̨ͨ����ʾ����һ������ʵ����Ʒ���ƣ��û��ɸ���)</span>
                            </td>
                        </tr>
                        <tr>
                            <th align="right" width="150px">
                                ��Ʒ�۸�
                            </th>
                            <td valign="middle">
                                <%#Eval("ProductPrice") %>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                ���ۼ۸�
                            </th>
                            <td>
                                <%#Eval("SellPrice") %><span>(������ǰֱ̨ͨ����ʾ����һ������ʵ�ļ۸��û��ɸ���)</span>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                ����������
                            </th>
                            <td>
                                <%#Eval("SellCount") %><span>(������ǰֱ̨ͨ����ʾ����һ������ʵ�������������û��ɸ���)</span>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                ��ң�BV����
                            </th>
                            <td>
                                <%#Eval("Ztc_Money") %>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                �������ƣ�
                            </th>
                            <td>
                                <%#Eval("ShopName") %>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                ��ʼʱ�䣺
                            </th>
                            <td>
                                <%#Eval("StartTime") %>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                ״̬��
                            </th>
                            <td>
                                <%#Eval("State").ToString() == "1" ? "����" : "�ر�" %>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" CausesValidation="false"
                    Text="�����б�" OnClick="ButtonBack_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldMemLoginID" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldType" runat="server" Value="0" />
    </form>
</body>
</html>
