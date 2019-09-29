<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopTemplate_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopTemplate_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" 

"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增模板</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="新增模板"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelName" runat="server" Text="模板名称："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="ShopTemplate">
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="店铺模板："></asp:Label>
                        </th>
                        <td>
                            <asp:FileUpload ID="FileUploadShopTemplate" runat="server" CssClass="tinput" />
                            <span style="color: Red">*</span>(请上传标准的zip格式。)
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="Label4" runat="server" Text="是否禁用："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsForbid" CssClass="tselect" runat="server">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                                <asp:ListItem Value="0">未禁用</asp:ListItem>
                                <asp:ListItem Value="1">禁用</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                            <asp:CompareValidator ID="CompareDropDownListIsForbid" runat="server" ControlToValidate="DropDownListIsForbid"
                                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>--%>
                    <tr runat="server" id="ShopTemplateImg">
                        <th align="right">
                            <asp:Label ID="LabelShopTemplateImg" runat="server" Text="模板样式图："></asp:Label>
                        </th>
                        <td valign="top">
                            <asp:FileUpload ID="FileUploadTemplateImg" runat="server" CssClass="tinput" />
                            <span style="color: Red">*</span> (支持png、jpg、gif、bmp格式图片。)<a id="ImageLink" runat="server"
                                target="_blank">
                                <asp:Image ID="ImageTemplate" Height="100px" Width="100px" onerror="javascript:this.src='/imgupload/noimage.gif'"
                                    runat="server" /></a>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMeto" runat="server" Text="备注："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMeto" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/ShopTemplate_List.aspx" Text="返回列表" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
