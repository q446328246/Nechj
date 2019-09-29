<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addpic.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.addpic" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>添加修改图片</title>
        <script type="text/javascript" language="javascript" src="js/jquery-1.9.1.js"> </script>
        <link rel='stylesheet' type='text/css' href='style/css.css' />
        <script type="text/javascript" language="javascript"> </script>
    </head>
    <body style="background: none;">
        <form id="form1" runat="server">
            <div style="padding: 20px;">
                <table border="0" cellpadding="0" cellspacing="0" class="shoptable" width="100%">
                    <tr>
                        <th align="right" width="150">
                            <div class="shopth">
                                图片类型：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:DropDownList ID="DropDownListImageType" runat="server" CssClass="tselect" AutoPostBack="true">
                                </asp:DropDownList>
                                <font color="red">*</font>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                图片名称：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:TextBox ID="textBoxName" runat="server" CssClass="tinput" MaxLength="50" Style="width: 195px;"></asp:TextBox><font
                                                                                                                                                      color="red">*</font>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                图片分类：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:DropDownList ID="DropDownListImgCategory2" AutoPostBack="false" CssClass="tselect"
                                                  runat="server">
                                </asp:DropDownList>
                                <font color="red">*</font>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth" style="height: 120px; line-height: 120px;">
                                上传图片：</div>
                        </th>
                        <td>
                            <div class="shoptd" style="height: 120px; line-height: 120px;">
                                <asp:FileUpload ID="FileUploadImage" runat="server" onchange="fun(this)" />
                                <font color="red">*</font>
                                <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                生成缩略图：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:CheckBoxList ID="CheckBoxListImageSpec" runat="server" RepeatColumns="4" RepeatDirection="Horizontal"
                                                  Enabled="true">
                                </asp:CheckBoxList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth" style="height: 115px;">
                                描述：
                            </div>
                        </th>
                        <td>
                            <div class="shoptd" style="height: 115px;">
                                <asp:TextBox ID="textBoxDescription" runat="server" TextMode="MultiLine" CssClass="tinput txtarea"></asp:TextBox>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td>
                            <div class="bottomLine" style="padding: 15px 0;">
                                <asp:Button ID="btnConfirm" ValidationGroup="addImage" runat="server" Text="确定" OnClick="btnConfirm_Click"
                                            CssClass="fanh" />
                                &nbsp;<ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </form>
    </body>
</html>