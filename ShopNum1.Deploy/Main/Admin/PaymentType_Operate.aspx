<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="PaymentType_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.PaymentType_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>支付类型</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <style>
        .hidden
        {
            display: none;
        }
        
        .block
        {
            display: block;
        }
    </style>
    <script src="js/jquery-1.3.2.min.js" type="text/javascript"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="编辑支付类型"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelName" runat="server" Text="支付类型名称："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelPaymentType" runat="server" Text="类型："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPaymentType" runat="server" CssClass="tinput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelImageUrl" runat="server" Text="图片："></asp:Label>
                        </th>
                        <td>
                            <asp:Image ID="ImageUrl" runat="server" onerror="javascript:this.src='/ImgUpload/noImage.gif'"
                                Width="120" Height="120" />
                            <asp:FileUpload ID="FileUploadImage" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMemo" runat="server" Text="说明："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemo" runat="server" CssClass="tinput" TextMode="MultiLine"
                                Width="400" Height="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelCharge" runat="server" Text="排序："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" runat="server" CssClass="tinput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelIsShopUse" runat="server" Text="是否用于店铺："></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsShopUse" runat="server" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                    class="fanh" ToolTip="Submit" OnClientClick=" return CheckPass(); " CausesValidation="false" />
                <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh" PostBackUrl="~/Main/Admin/PaymentType_List.aspx"
                    CausesValidation="false" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldImage" runat="server" Value="" />
    </form>
</body>
</html>
