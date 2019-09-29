<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SetWxInfo_V82.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.SetWxInfo_V82" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>����΢����Ϣ</title>
    <link type="text/css" rel="Stylesheet" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
</head>
<style type="text/css">
    .guige_text label
    {
        color: #333333;
        display: inline-block;
        padding-left: 4px;
    }
    .guige_text input
    {
        position: relative;
        top: 3px;
        display: inline-block;
        margin-left: 10px;
    }
</style>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="΢�ŵ��̷�������"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table cellspacing="1" cellpadding="0" border="0">
                    <tr>
                        <th align="right" width="150px">
                            ΢��ʱ��Σ�
                        </th>
                        <td align="left" class="guige_text">
                            &nbsp;
                            <select id="selectpart" runat="server">
                                <option value="0">��ѡ��</option>
                                <option value="1">һ����</option>
                                <option value="3">������</option>
                                <option value="6">������</option>
                                <option value="12">һ��</option>
                                <option value="24">����</option>
                            </select>
                        </td>
                    </tr>
                    <tr>
                        <script type="text/javascript" language="javascript">
                            function NumTxt_Int(o) {
                                o.value = o.value.replace(/\D/g, '');
                            }

                            $(function () {
                                $("#selectpart").find("option[value='" + $("#hidDepart").val() + "']").attr("selected", true);
                            });
                        </script>
                        <th align="right" width="150px">
                            ΢�ŷ��ã�
                        </th>
                        <td align="left" class="guige_text">
                            <input type="text" id="txtWxPay" onkeyup="NumTxt_Int(this)" runat="server" class="tinput" />
                        </td>
                    </tr>
                </table>
                <div style="margin: 10px 125px; margin-top: 20px;">
                    <asp:Button ID="btnPaySub" runat="server" ValidationGroup="shopurl" Text="����" CssClass="fanh"
                        OnClick="btnPaySub_Click" />&nbsp;
                    <asp:Button ID="btnPayReturn" runat="server" Text="�����б�" CssClass="fanh" OnClick="btnPayReturn_Click" />
                    <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                </div>
            </div>
            <input type="hidden" id="hidDepart" runat="server" />
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        </div>
    </div>
    </form>
</body>
</html>
