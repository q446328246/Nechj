<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttachMent_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.AttachMent_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>附件添加</title>
        <link href="style/css.css" rel="stylesheet" type="text/css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <div id="right">
                <div class="rhigth">
                    <div class="rl">
                    </div>
                    <div class="rcon">
                        <h3>
                            <asp:Label ID="LabelTitle" runat="server" Text="附件添加"></asp:Label></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="inner_page_list">
                        <table border="0" cellpadding="0" cellspacing="1">
                            <tr>
                                <th align="right" width="150px;">
                                    <asp:Localize ID="LocalizeTitle" runat="server" Text="附件名称："></asp:Localize>
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput"></asp:TextBox>
                                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxTitle"
                                                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                                                    ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="请不要超过50个字符"
                                                                    ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="LocalizeDropDownListAssociatedCategoryGuid" runat="server" Text="附件类别："></asp:Localize>
                                </th>
                                <td>
                                    <asp:DropDownList ID="DropDownListDropDownListAssociatedCategoryGuid" runat="server"
                                                      CssClass="tselect">
                                        <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                                    </asp:DropDownList>
                                    <span style="color: Red">*</span>
                                    <asp:CompareValidator ID="CompareCategoryGuid" runat="server" ControlToValidate="DropDownListDropDownListAssociatedCategoryGuid"
                                                          Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="LocalizeAttachmentURL" runat="server" Text="上传附件："></asp:Localize>
                                </th>
                                <td>
                                    <asp:FileUpload ID="FileUploadAttachmentURL" runat="server" />
                                </td>
                            </tr>
                            <%-- <tr>
                    <th align="right">
                       
                            分类排序：
                       
                    </th>
                    <td>
                       
                            <input type="text" name="txt" class="tinput" /><span>(自动计算)</span>
                       
                    </td>
                </tr>
                <tr>
                    <th align="right">
                      
                            是否前台显示：
                       
                    </th>
                    <td>
                       
                            <input id="Checkbox1" type="checkbox" /><span>是否前台显示。</span>
                      
                    </td>
                </tr>--%>
                            <tr>
                                <th align="right">
                                    <asp:Localize ID="LocalizeDescription" runat="server" Text="简单描述："></asp:Localize>
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxDescription" runat="server" TextMode="MultiLine" CssClass="tinput txtarea"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                                                    ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="请不要超过150个字符"
                                                                    ValidationExpression="^[\s\S]{0,150}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tablebtn">
                        <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" />&nbsp;
                        <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                                    PostBackUrl="~/Main/Admin/AttachMent_list.aspx" Text="返回列表" />
                        <uc1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
        </form>
    </body>
</html>