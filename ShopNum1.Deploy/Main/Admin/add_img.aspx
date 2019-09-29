<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_img.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.add_img" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
    </head>
    <body>
        <form id="form1" runat="server">
            <t:MessageShow ID="MessageShow" runat="server" Visible="False" />
            <div class="welcon clearfix">
                <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                <asp:Label ID="Label5" runat="server" Text="图片类型："></asp:Label>
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:DropDownList ID="DropDownListImageType" runat="server" Width="180px" AutoPostBack="True"
                                                  OnSelectedIndexChanged="DropDownListImageType_SelectedIndexChanged" CssClass="tselect">
                                </asp:DropDownList>
                                <font color="red">
                                    <asp:Label ID="Label9" runat="server" Text="*"></asp:Label></font>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                <asp:Label ID="Label3" runat="server" Text="图片名称："></asp:Label>
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:TextBox ID="textBoxName" runat="server" Width="175px" CssClass="tinput"></asp:TextBox><font
                                                                                                                               color="red">*</font>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="textBoxName"
                                                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                <asp:Label ID="Label6" runat="server" Text="图片分类："></asp:Label>
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:DropDownList ID="DropDownListImgCategory2" Width="180px" runat="server" CssClass="tselect">
                                </asp:DropDownList>
                                <font color="red">
                                    <asp:Label ID="Label10" runat="server" Text="*"></asp:Label></font>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDropDownListImgCategory2" runat="server"
                                                            ControlToValidate="DropDownListImgCategory2" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                <asp:Label ID="Label8" runat="server" Text="上传图片："></asp:Label>
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:FileUpload ID="FileUploadImage" runat="server" CssClass="tinput" />
                                <font color="red">*</font>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorImage" runat="server" ControlToValidate="FileUploadImage"
                                                            Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth" style="height: 80px;">
                                <asp:Label ID="Label11" runat="server" Text="描述："></asp:Label>
                            </div>
                        </th>
                        <td>
                            <div class="shoptd" style="height: 80px;">
                                <asp:TextBox ID="textBoxDescription" runat="server" Height="60px" CssClass="tinput"
                                             TextMode="MultiLine" Width="440px"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle3" runat="server"
                                                                ControlToValidate="textBoxDescription" Display="Dynamic" ErrorMessage="描述最多100个字符"
                                                                ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                <asp:Label ID="LabelSpec" runat="server" Text="生成缩略图："></asp:Label>
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:CheckBoxList ID="CheckBoxListImageSpec" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                                </asp:CheckBoxList>
                            </div>
                        </td>
                    </tr>
                </table>
                <div class="tablebtn">
                    <asp:Button ID="btnConfirm" runat="server" Text="添加" OnClick="btnConfirm_Click" CssClass="fanh" />
                    <%--<asp:Button ID="ButExit" runat="server" Text="添加并退出" OnClick="butExit_Click" CssClass="fanh"  />--%>
                </div>
            </div>
        </form>
    </body>
</html>