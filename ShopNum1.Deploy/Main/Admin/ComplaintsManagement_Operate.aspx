<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ComplaintsManagement_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ComplaintsManagement_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看|回复举报</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
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
                    <asp:Label ID="Label2" runat="server" Text="查看|回复举报"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right">
                        <div class="shopth">
                            商品链接：
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:HyperLink ID="HyperLinkProductLink" Target="_blank" runat="server"></asp:HyperLink>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelArticleGuid" runat="server" Text="举报人："></asp:Label>
                        </div>
                    </th>
                    <td valign="middle">
                        <div class="shoptd">
                            <asp:Label ID="LabelMemLoginID" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelRank" runat="server" Text="举报编号："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="Labelguid" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelIPAddress" runat="server" Text="举报证据："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelEvidence" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="height: 200px;">
                            <asp:Label ID="LabelEvidenceImage" runat="server" Text="证据图片："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 200px;">
                            <asp:Image ID="ImageEvidence" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                runat="server" Height="200px" Width="200px" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelTime" runat="server" Text="举报时间："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelReportTime" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label3" runat="server" Text="被举报人："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelShopID" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelReplyUser" runat="server" Text="被举报者申诉内容："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelComplaintContent" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="height: 200px;">
                            <asp:Label ID="LabelReplyImage" runat="server" Text="被举报者申诉证据图片："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 200px;">
                            <img alt="证件图片" src="" height="200" width="200" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                id="ReplyImage" runat="server" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelReplyTime1" runat="server" Text="被举报者申诉时间："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelReplyTime" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Labelstate" runat="server" Text="处理状态："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelProcessingState" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr style="display: none;">
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label5" runat="server" Text="处理结果："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelProcessingResult" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label4" runat="server" Text="处理时间："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelProcessingTime" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth" style="height: 130px;">
                            <asp:Label ID="LabelResult" runat="server" Text="处理结果："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 130px;">
                            <asp:TextBox ID="TextBoxResult" runat="server" CssClass="tinput txtarea" Height="100px"
                                Width="500px" TextMode="MultiLine"></asp:TextBox>
                            <asp:Label ID="Label7" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorResult" runat="server" ControlToValidate="TextBoxResult"
                                ErrorMessage="请输入处理结果"></asp:RequiredFieldValidator>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" CssClass="fanh"
                    Text="确定" ToolTip="Submit" />
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" Text="返回列表" OnClick="ButtonBack_Click"
                    CausesValidation="false" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    </form>
</body>
</html>
