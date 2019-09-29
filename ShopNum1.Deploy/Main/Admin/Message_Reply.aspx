<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Message_Reply.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Message_Reply" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>留言回复</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="查看消息"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <th align="right" width="150px" style="display: none">
                        <asp:Localize ID="LocalizeName" runat="server" Text="发送会员："></asp:Localize>
                    </th>
                    <td valign="middle" style="display: none">
                        <font class="font1">
                            <asp:Label ID="LabelMemLoginIDValue" runat="server"></asp:Label></font>
                    </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMeaageType" runat="server" Text="消息类型："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelMeaageTypeValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="消息标题："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelTitleValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSendTime" runat="server" Text="发送时间："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelSendTimeValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelReplyUser" runat="server" Text="接收人："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelReplyUserValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelReplyTime" runat="server" Text="回复时间："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelReplyTimeValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelIsReply" runat="server" Text="是否回复："></asp:Label>
                        </th>
                        <td>
                            <asp:Label ID="LabelIsReplyValue" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelContent" runat="server" Text="消息内容："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxContent" runat="server" Enabled="False" Height="200px" TextMode="MultiLine"
                                Width="490px" CssClass="tinput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelReplyContent" runat="server" Text="回复内容："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxReplyContent" runat="server" CssClass="tinput" Height="60px"
                                TextMode="MultiLine" Width="440px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                    CausesValidation="False" ToolTip="Submit" CssClass="fanh" Visible="false" />
                <asp:Button ID="Button1" runat="server" Text="返回列表" CssClass="fanh" OnClick="Button1_Click" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    </form>
</body>
</html>
