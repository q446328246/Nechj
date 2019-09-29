<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ServiceSite_EmailSetting.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ServiceSite_EmailSetting" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>邮件接口设置</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script src="js/CommonJS.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript" src="js/jquery.emailmatch.js"> </script>
    <link rel="stylesheet" type="text/css" href="style/email.css" />
    <script type="text/javascript">
        var lock = 0;
        //选择单图

        function EmailCheck() {
            if ($("#selectSendType option:selected").val() == "0") {
                alert("请选择邮件发送方式！");
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
                document.getElementById("Msg").innerHTML = "请输入正确格式的邮件地址";
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
                    邮件接口设置</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Localize ID="Localize1" runat="server" Text="发送方式："></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="selectSendType" runat="server" Width="210">
                                <asp:ListItem Value="0">-请选择发送方式-</asp:ListItem>
                                <asp:ListItem Value="ASP.NET邮件发送组件">ASP.NET邮件发送组件</asp:ListItem>
                            </asp:DropDownList>
                            <span>必须选择邮件发送方式(<font color="red">*</font>)</span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Localize ID="Localize2" runat="server" Text="SMTP服务器："></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="txtSmtpServer" runat="server" CssClass="tinput" Width="200px"></asp:TextBox><span>SMTP服务器不能为空(<font
                                color="red">*</font>)</span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeEmailServer" runat="server" Text="SMTP服务器端口："></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxServerPort" runat="server" CssClass="tinput" Width="200px"></asp:TextBox><span>SMTP服务器端口不能为空(<font
                                color="red">*</font>)</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Localize ID="Localize3" runat="server" Text="安全连接(SSL)："></asp:Localize>
                        </th>
                        <td>
                            <asp:CheckBox ID="cbSSL" runat="server" Text="" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeEmailAccount" runat="server" Text="SMTP用户名："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxEmailAccount" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeEmailPassword" runat="server" Text="SMTP用户密码："></asp:Localize>
                        </th>
                        <td>
                            <input type="password" value="0" id="TextBoxEmailPassword" runat="server" class="tinput"
                                style="width: 200px" />
                            <span>SMTP密码填写后将修改原登录密码</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeRestoreEmail" runat="server" Text="邮件回复地址："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRestoreEmail" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                            <span>邮件回复地址不能为空(<font color="red">*</font>)</span>
                        </td>
                    </tr>
                    <tr class="radiobtn" style="display: none">
                        <th align="right">
                            <asp:Localize ID="LocalizeEmailCode" runat="server" Text="邮件编码："></asp:Localize>
                        </th>
                        <td>
                            <asp:CheckBoxList ID="CheckBoxListEmailCode" runat="server" RepeatDirection="Horizontal"
                                RepeatLayout="Flow">
                            </asp:CheckBoxList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeEmailAddress" runat="server" Text="邮件地址："></asp:Localize>
                        </th>
                        <td>
                            <input type="text" runat="server" id="TextBoxEmailAddress" class="tinput" style="width: 200px;" />
                            <font color="red" id="Msg"></font>
                            <asp:Button ID="ButtonSend" runat="server" ValidationGroup="EmailAddress" Text="邮件测试"
                                CssClass="fanh" OnClientClick=" return checkRate('TextBoxEmailAddress') " OnClick="ButtonSend_Click" />&nbsp;&nbsp;(注意：测试前请先保存配置，第一次保存后，下一次就不需要输入密码相关的信息了。)
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonEdit" runat="server" Text="确定" CssClass="fanh" OnClientClick=" return EmailCheck() "
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
