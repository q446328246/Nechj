<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="EmailSetting.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.EmailSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ʼ�����ҳ��</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript">
        var ajaxurl = "/Main/Admin/ajaxop/OpEmail.ashx?op=getdata";
        $(function () {
            $.get(ajaxurl, null, function (data) {
                alert(data);
                data = data.toString().substr(0, data.toString().indexOf("<!")).replace(/(^\s*)|(\s*$)/g, "");
                //document.write (data);
                var dataj = eval('(' + data + ')');
                alert(data);
                //                 for(var i=0;i<data.length;i++)
                //                 {
                //                     alert(data[i]);return false;
                //                 }
            });
        });
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
                    �ʼ��ӿ�����</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Localize ID="Localize1" runat="server" Text="���ͷ�ʽ��"></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="selectSendType" runat="server" Width="200">
                                <asp:ListItem Value="0">-��ѡ���ͷ�ʽ-</asp:ListItem>
                                <asp:ListItem Value="ASP.NET�ʼ��������">ASP.NET�ʼ��������</asp:ListItem>
                            </asp:DropDownList>
                            <span>����ѡ���ʼ����ͷ�ʽ</span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Localize ID="Localize2" runat="server" Text="SMTP��������"></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="txtSmtpServer" runat="server" CssClass="tinput" Width="200px"></asp:TextBox><span>SMTP����������Ϊ��</span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeEmailServer" runat="server" Text="SMTP�������˿ڣ�"></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxServerPort" runat="server" CssClass="tinput" Width="200px"></asp:TextBox><span>SMTP�������˿ڲ���Ϊ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize3" runat="server" Text="��ȫ����(SSL)��"></asp:Localize>
                        </th>
                        <td>
                            <asp:CheckBox ID="cbSSL" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeEmailAccount" runat="server" Text="SMTP�û�����"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmailAccount" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                            <span>SMTP�û�������Ϊ��</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeEmailPassword" runat="server" Text="SMTP�û����룺"></asp:Localize>
                        </th>
                        <td>
                            <input type="password" value="0" id="TextBoxEmailPassword" runat="server" class="tinput"
                                style="width: 200px" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeRestoreEmail" runat="server" Text="�ʼ��ظ���ַ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRestoreEmail" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                            <span>�ʼ��ظ���ַ����Ϊ��</span>
                        </td>
                    </tr>
                    <tr class="radiobtn" style="display: none">
                        <th align="right">
                            <asp:Localize ID="LocalizeEmailCode" runat="server" Text="�ʼ����룺"></asp:Localize>
                        </th>
                        <td>
                            <asp:CheckBoxList ID="CheckBoxListEmailCode" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeEmailAddress" runat="server" Text="�ʼ���ַ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmailAddress" runat="server" ValidationGroup="EmailAddress"
                                CssClass="tinput" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxEmailAddress" ValidationGroup="EmailAddress"
                                runat="server" ControlToValidate="TextBoxEmailAddress" Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxEmailAddress"
                                runat="server" ControlToValidate="TextBoxEmailAddress" ValidationGroup="EmailAddress"
                                Display="Dynamic" ErrorMessage="�����ʽ����ȷ��" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                            <asp:Button ID="ButtonSend" runat="server" ValidationGroup="EmailAddress" Text="���Ͳ����ʼ�"
                                CssClass="selpic" OnClick="ButtonSend_Click" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
    </form>
</body>
</html>
