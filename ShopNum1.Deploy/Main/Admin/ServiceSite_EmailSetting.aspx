<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ServiceSite_EmailSetting.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ServiceSite_EmailSetting" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ʼ��ӿ�����</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript" src="js/jquery.emailmatch.js"> </script>
    <link rel="stylesheet" type="text/css" href="style/email.css" />
    <script type="text/javascript">
        var lock = 0;
        //ѡ��ͼ

        function EmailCheck() {
            if ($("#selectSendType option:selected").val() == "0") {
                alert("��ѡ���ʼ����ͷ�ʽ��");
                return false;
            }
            return true;
        }

        $(function () {
            //$("#TextBoxEmailAddress").emailMatch();
        });

        function checkRate(input) {
            var nubmer = document.getElementById(input).value + "@qq.com";
            if (document.getElementById(input).value == "") {
                document.getElementById("Msg").innerHTML = "��������ȷ��ʽ���ʼ���ַ";
                document.getElementById(input).value = "";
                return false;
            }
        }
    </script>
    <style type="text/css">
        .fanht
        {
            background: url(images/btn2.jpg) no-repeat;
            border: none;
            color: #333;
            cursor: pointer;
            font-size: 13px;
            height: 28px;
            line-height: 28px;
            text-align: center;
            width: 105px;
        }
    </style>
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
                            <asp:DropDownList ID="selectSendType" runat="server" Width="210">
                                <asp:ListItem Value="0">-��ѡ���ͷ�ʽ-</asp:ListItem>
                                <asp:ListItem Value="ASP.NET�ʼ��������">ASP.NET�ʼ��������</asp:ListItem>
                            </asp:DropDownList>
                            <span>����ѡ���ʼ����ͷ�ʽ(<font color="red">*</font>)</span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Localize ID="Localize2" runat="server" Text="SMTP��������"></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="txtSmtpServer" runat="server" CssClass="tinput" Width="200px"></asp:TextBox><span>SMTP����������Ϊ��(<font
                                color="red">*</font>)</span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeEmailServer" runat="server" Text="SMTP�������˿ڣ�"></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxServerPort" runat="server" CssClass="tinput" Width="200px"></asp:TextBox><span>SMTP�������˿ڲ���Ϊ��(<font
                                color="red">*</font>)</span>
                        </td>
                    </tr>
                    <tr style="display: none">
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
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeEmailPassword" runat="server" Text="SMTP�û����룺"></asp:Localize>
                        </th>
                        <td>
                            <input type="password" value="0" id="TextBoxEmailPassword" runat="server" class="tinput"
                                style="width: 200px" />
                            <span>SMTP������д���޸�ԭ��¼����</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeRestoreEmail" runat="server" Text="�ʼ��ظ���ַ��"></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRestoreEmail" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                            <span>�ʼ��ظ���ַ����Ϊ��(<font color="red">*</font>)</span>
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
                            <input type="text" runat="server" id="TextBoxEmailAddress" class="tinput" style="width: 200px;" />
                            <font color="red" id="Msg"></font>
                            <asp:Button ID="ButtonSend" runat="server" ValidationGroup="EmailAddress" Text="�ʼ�����"
                                CssClass="fanh" OnClientClick=" return checkRate('TextBoxEmailAddress') " OnClick="ButtonSend_Click" />&nbsp;&nbsp;(ע�⣺����ǰ���ȱ������ã���һ�α������һ�ξͲ���Ҫ����������ص���Ϣ�ˡ�)
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonEdit" runat="server" Text="ȷ��" CssClass="fanh" OnClientClick=" return EmailCheck() "
                    OnClick="ButtonEdit_Click" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
                <asp:HiddenField ID="HidPassword" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
