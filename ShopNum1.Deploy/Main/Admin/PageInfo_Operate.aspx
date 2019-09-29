<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="PageInfo_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.PageInfo_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>ҳ�����</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/CommonJS.js"> </script>
    <script type="text/javascript" language="javascript">
            function ad(str) {
                if (str.length > 0) {
                    var tc = document.getElementById("TextBoxContent");
                    var tclen = tc.value.length;
                    tc.focus();
                    if (typeof document.selection != "undefined") {
                        document.selection.createRange().text = str;
                    } else {
                        tc.value = tc.value.substr(0, tc.selectionStart) + str + tc.value.substring(tc.selectionStart, tclen);
                    }
                }
            }

            function CallServer2() {
                context = "";
                arg = "GetstrAd";
                <%= ClientScript.GetCallbackEventReference(this, "arg", "ReceiveServerData2", "context") %>;
            }

            function ReceiveServerData2(result, context) {
                var strs = result.split('|');

                var hid = document.getElementById("HiddenFieldADCount");

                if (hid.value == "0") {
                    hid.value = strs[1];

                    ad(strs[0]);
                } else {
                    alert('ÿ��ֻ�����һ�����ݣ�');
                }
            }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="ҳ�����"></asp:Label>
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px;">
                            ҳ������
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxPageName" runat="server" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxPageName" runat="server"
                                ControlToValidate="TextBoxPageName" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            �ļ�����
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListFileName" runat="server" AutoPostBack="true" Width="260"
                                OnSelectedIndexChanged="DropDownListFileName_SelectedIndexChanged" CssClass="tselect">
                            </asp:DropDownList>
                            <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListFileName"
                                Display="Dynamic" ErrorMessage="��ֵ����ѡ��" Operator="NotEqual" ValueToCompare="-

1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ˵����
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPageNote" runat="server" CssClass="tinput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            ���룺
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxContent" runat="server" TextMode="MultiLine" Height="300px"
                                CssClass="tinput" Width="550"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <input id="ButtonAdd" type="button" value="��ӹ��λ" class="fanh" onclick=" CallServer2() " />
                <asp:Button ID="ButtonBack" runat="server" Text="�����б�" CssClass="fanh" CausesValidation="false"
                    OnClick="ButtonBack_Click" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldADCount" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldADGuid" runat="server" Value="0" />
    </form>
</body>
</html>
