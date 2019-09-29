<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="EmailSetting.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.EmailSetting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>邮件配置页面</title>
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
                            <asp:DropDownList ID="selectSendType" runat="server" Width="200">
                                <asp:ListItem Value="0">-请选择发送方式-</asp:ListItem>
                                <asp:ListItem Value="ASP.NET邮件发送组件">ASP.NET邮件发送组件</asp:ListItem>
                            </asp:DropDownList>
                            <span>必须选择邮件发送方式</span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Localize ID="Localize2" runat="server" Text="SMTP服务器："></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="txtSmtpServer" runat="server" CssClass="tinput" Width="200px"></asp:TextBox><span>SMTP服务器不能为空</span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right" width="150px">
                            <asp:Localize ID="LocalizeEmailServer" runat="server" Text="SMTP服务器端口："></asp:Localize>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxServerPort" runat="server" CssClass="tinput" Width="200px"></asp:TextBox><span>SMTP服务器端口不能为空</span>
                        </td>
                    </tr>
                    <tr>
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
                            <span>SMTP用户名不能为空</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeEmailPassword" runat="server" Text="SMTP用户密码："></asp:Localize>
                        </th>
                        <td>
                            <input type="password" value="0" id="TextBoxEmailPassword" runat="server" class="tinput"
                                style="width: 200px" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="LocalizeRestoreEmail" runat="server" Text="邮件回复地址："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRestoreEmail" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                            <span>邮件回复地址不能为空</span>
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
                            <asp:TextBox ID="TextBoxEmailAddress" runat="server" ValidationGroup="EmailAddress"
                                CssClass="tinput" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxEmailAddress" ValidationGroup="EmailAddress"
                                runat="server" ControlToValidate="TextBoxEmailAddress" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxEmailAddress"
                                runat="server" ControlToValidate="TextBoxEmailAddress" ValidationGroup="EmailAddress"
                                Display="Dynamic" ErrorMessage="邮箱格式不正确！" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                            <asp:Button ID="ButtonSend" runat="server" ValidationGroup="EmailAddress" Text="发送测试邮件"
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
