<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleComment_Reply.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ArticleComment_Reply" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>查看|回复评论</title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
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
                            <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="查看|回复评论"></asp:Label></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                        <tr style="display: none">
                            <th align="right">
                                <div class="shopth">
                                    <asp:Label ID="LabelTitle" runat="server" Text="评论标题："></asp:Label>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd">
                                    <asp:TextBox ID="TextBoxTitleValue" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox><span
                                                                                                                                           style="color: Red;">*</span>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <div class="shopth">
                                    <asp:Label ID="LabelArticleGuid" runat="server" Text="评论资讯："></asp:Label>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd">
                                    <asp:TextBox ID="TextBoxArticleGuidValue" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <th align="right">
                                <div class="shopth">
                                    <asp:Label ID="LabelRank" runat="server" Text="评论等级："></asp:Label>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd">
                                    <asp:TextBox ID="TextBoxRankValue" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <div class="shopth">
                                    <asp:Label ID="LabelMemLoginID" runat="server" Text="评论人："></asp:Label>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd">
                                    <asp:TextBox ID="TextBoxMemLoginIDValue" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <div class="shopth">
                                    <asp:Label ID="LabelSendTime" runat="server" Text="评论时间："></asp:Label>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd">
                                    <asp:TextBox ID="TextBoxSendTimeValue" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <div class="shopth">
                                    <asp:Label ID="LabelIPAddress" runat="server" Text="评论人IP："></asp:Label>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd">
                                    <asp:TextBox ID="TextBoxIPAddressValue" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <th align="right">
                                <div class="shopth">
                                    <asp:Label ID="LabelReplyUser" runat="server" Text="回复人："></asp:Label>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd">
                                    <asp:TextBox ID="TextBoxReplyUserValue" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr style="display: none">
                            <th align="right">
                                <div class="shopth">
                                    <asp:Label ID="LabelReplyTime" runat="server" Text="回复时间："></asp:Label>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd">
                                    <asp:TextBox ID="TextBoxReplyTimeValue" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <div class="shopth">
                                    <asp:Label ID="LabelIsReply" runat="server" Text="回复状态："></asp:Label>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd">
                                    <asp:TextBox ID="TextBoxIsReplyValue" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <div class="shopth">
                                    <asp:Label ID="LabelIsAudit" runat="server" Text="审核状态："></asp:Label>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd">
                                    <asp:TextBox ID="TextBoxIsAuditValue" ReadOnly="true" runat="server" CssClass="tinput"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <div class="shopth" style="height: 115px;">
                                    <asp:Label ID="LabelContent" runat="server" Text="评论内容："></asp:Label>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd" style="height: 115px;">
                                    <asp:TextBox ID="TextBoxContent" ReadOnly="true" CssClass="tinput txtarea" runat="server"
                                                 TextMode="MultiLine"></asp:TextBox>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <div class="shopth" style="height: 115px;">
                                    <asp:Label ID="LabelReplyContent" runat="server" Text="回复内容："></asp:Label>
                                    <span style="color: Red;">*</span>
                                </div>
                            </th>
                            <td>
                                <div class="shoptd" style="border-bottom: none; height: 115px;">
                                    <asp:TextBox ID="TextBoxReplyContent" CssClass="tinput txtarea" runat="server" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBoxReplyContent"
                                                                runat="server" ErrorMessage="回复内容必填！"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                    </table>
                    <div class="tablebtn">
                        <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                                    CssClass="fanh" ToolTip="Submit" />
                        <input id="inputReset" class="bt2" runat="server" type="reset" value="重置" visible="false" />
                        <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh" OnClick="ButtonBack_Click"
                                    ValidationGroup="fh" />
                        <ShopNum1:MessageShow ID="MessageShow" CssClass="bt2" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
        </form>
    </body>
</html>