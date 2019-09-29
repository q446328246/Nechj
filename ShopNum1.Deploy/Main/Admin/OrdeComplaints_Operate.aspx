<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="OrdeComplaints_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.OrdeComplaints_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>投诉管理评论</title>
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
                    <asp:Label ID="Label1" runat="server" Text="查看/回复投诉"></asp:Label>
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                <tr>
                    <th align="right" width="150px">
                        <div class="shopth">
                            <asp:Label ID="LabelTitle" runat="server" Text="投诉订单："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:HyperLink ID="HyperLinkOrderDetail" Target="_self" runat="server">
                                <asp:Label ID="LabelName" runat="server"></asp:Label>
                            </asp:HyperLink>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelArticleGuid" runat="server" Text="投诉人："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelMemLoginID" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelRank" runat="server" Text="投诉编号："></asp:Label>
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
                            <asp:Label ID="LabelIPAddress" runat="server" Text="投诉证据："></asp:Label>
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
                        <div class="shopth" style="height: 230px;">
                            <asp:Label ID="Label3" runat="server" Text="证据图片："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 230px;">
                            <asp:Image ID="ImageEvidence" CssClass="allinput3" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                runat="server" Height="200px" Width="200px" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="LabelTime" runat="server" Text="投诉时间："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd">
                            <asp:Label ID="LabelComplaintTime" runat="server"></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label4" runat="server" Text="申诉人："></asp:Label>
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
                            <asp:Label ID="LabelReplyUser" runat="server" Text="申诉内容："></asp:Label>
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
                        <div class="shopth" style="height: 230px;">
                            <asp:Label ID="Label6" runat="server" Text="申诉证据图片："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 230px;">
                            <asp:Image ID="ComplaintImage" CssClass="allinput3" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                runat="server" Height="200px" Width="200px" />
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
                <tr>
                    <th align="right">
                        <div class="shopth">
                            <asp:Label ID="Label5" runat="server" Text="处理时间："></asp:Label>
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
                            <asp:Label ID="Label7" runat="server" Text="处理结果："></asp:Label>
                        </div>
                    </th>
                    <td>
                        <div class="shoptd" style="height: 130px;">
                            <asp:TextBox ID="TextBoxProcessingResult" CssClass="tinput txtarea" runat="server"
                                Height="100" Width="500" TextMode="MultiLine"></asp:TextBox>
                            <asp:Label ID="Label8" runat="server" ForeColor="Red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorResult" runat="server" ControlToValidate="TextBoxProcessingResult"
                                ErrorMessage="请输入处理结果"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                ControlToValidate="TextBoxProcessingResult" Display="Dynamic" ErrorMessage="处理结果请不要超过100字"
                                ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                        </div>
                    </td>
                </tr>
            </table>
            <div class="tablebtn">
                <asp:Button ID="ButtonSure" runat="server" CssClass="fanh" OnClick="ButtonSure_Click"
                    Text="确定" />
                <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh" CausesValidation="false"
                    OnClick="ButtonBack_Click" />
                <ShopNum1:MessageShow ID="MessageShow1" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    </form>
</body>
</html>
