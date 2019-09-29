<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdvertisementImg_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.AdvertisementImg_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>图片广告</title>
        <link href="style/css.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
        <script type="text/javascript">
        //选择单图
            function openLogoSingleChild() {
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) {
                    k = window.returnValue;
                }
                if (k != null) {
                    var strLen = k.length;
                    var lastIndex = k.lastIndexOf('/');
                    document.getElementById("TextBoxpath").value = k.split(",")[0].replace("~/", "/");
                    $("#imgshow").attr("src", k.split(",")[1]);
                }
            }
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
                            <asp:Label ID="LabelPageTitle" runat="server" Text="添加图片广告"></asp:Label></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="inner_page_list">
                        <table border="0" cellpadding="0" cellspacing="1">
                            <tr>
                                <th align="right" width="150px">
                                    广告ID：
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxID" CssClass="tinput" runat="server" ReadOnly="true" Enabled="false"></asp:TextBox><span>
                                                                                                                                                   广告ID</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    页面名称：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxPageName" CssClass="tinput" runat="server"></asp:TextBox><span>
                                                                                                                         输入页面名称</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    广告名称：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxName" CssClass="tinput" runat="server"></asp:TextBox>
                                    <span style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorFileName" runat="server" Display="Dynamic"
                                                                ControlToValidate="TextBoxName" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    链接地址：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxHref" CssClass="tinput" runat="server"></asp:TextBox><span>
                                                                                                                     输入链接地址</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    图片地址：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxpath" runat="server" CssClass="tinput"></asp:TextBox><img
                                                                                                                     id="imgshow" runat="server" src="" style="height: 100px; width: 100px;" />
                                    <input id="ButtonSelectSingleImage" type="button" value="添加图片" onclick=" openLogoSingleChild() "
                                           class="selpic" style="position: relative; top: 1px; top: 0px\9; *top: -1px; _top: -1px;" />
                                </td>
                            </tr>
                            <tr id="adwidth" runat="server" style="display: none">
                                <th align="right">
                                    建议宽度：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxWidth" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
                                    <font color="red"></font>
                                    <asp:RegularExpressionValidator ID="RequiredFieldValidatorWidth" runat="server" ControlToValidate="TextBoxWidth"
                                                                    Display="Dynamic" ErrorMessage="输入的格式不正确或者输入的宽度太大" ValidationExpression="^[0-9]{0,6}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr id="adheight" runat="server" style="display: none">
                                <th align="right">
                                    建议高度：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxHeight" CssClass="tinput" runat="server" ReadOnly="true"></asp:TextBox>
                                    <font color="red"></font>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorHeight" runat="server"
                                                                    ControlToValidate="TextBoxHeight" Display="Dynamic" ErrorMessage="输入的格式不正确或高度太高"
                                                                    ValidationExpression="^[0-9]{0,6}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr id="Tr1" runat="server">
                                <th align="right">
                                    描述：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxDes" CssClass="tinput" runat="server" TextMode="MultiLine"></asp:TextBox><span>
                                                                                                                                         广告描述</span>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tablebtn">
                        <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                        <input type="button" value="返回列表" class="fanh" onclick=" window.location.href = 'AdvertisementImg_List.aspx'; " />
                        <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
        </form>
    </body>
</html>