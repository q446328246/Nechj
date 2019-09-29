<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advertisement_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Advertisement_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>广告管理</title>
        <link href="style/css.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" language="javascript" src="../js/CommonJS.js"> </script>
        <script type="text/javascript">
            lock = 0;
            //选择单图

            function openLogoSingleChild() {
                if (lock == 0) {
                    lock = 1;
                    var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                    lock = 0;
                    if (k == undefined) {
                        k = window.returnValue;

                    }
                    if (k != null) {
                        var strLen = k.length;
                        document.getElementById("TextBoxpath").value = k.split(',')[0];
                    }
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
                            <asp:Label ID="LabelPageTitle" runat="server" Text="添加广告"></asp:Label>
                        </h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="inner_page_list">
                        <table border="0" cellpadding="0" cellspacing="1">
                            <tr style="display: none">
                                <th align="right" width="180px;">
                                    页面名：
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxPageName" runat="server" CssClass="tinput"></asp:TextBox>
                                    <span style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxPageName" runat="server"
                                                                ControlToValidate="TextBoxPageName" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <th align="right">
                                    文件名：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxFileName" runat="server" CssClass="tinput"></asp:TextBox>
                                    <span style="color: Red">*</span>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxFileName" runat="server"
                                                                ControlToValidate="TextBoxFileName" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    广告位ID：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxDivID" runat="server" CssClass="tinput" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    说明：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxExplain" runat="server" CssClass="tinput"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <th align="right">
                                    广告类型：
                                </th>
                                <td>
                                    <asp:DropDownList ID="DropDownListAdType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListAdType_SelectedIndexChanged"
                                                      Width="151px" CssClass="tselect">
                                        <%--<asp:ListItem Value="0">文字</asp:ListItem>--%>
                                        <asp:ListItem Value="1">图片</asp:ListItem>
                                        <asp:ListItem Value="2">幻灯片</asp:ListItem>
                                        <%--  <asp:ListItem Value="3">falsh</asp:ListItem>--%>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListPathType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownListPathType_SelectedIndexChanged"
                                                      Width="148px" CssClass="tselect">
                                        <asp:ListItem Value="0">路径</asp:ListItem>
                                        <asp:ListItem Value="1">上传</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    链接地址：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxHref" runat="server" Width="260" CssClass="tinput"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    内容：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxContent" runat="server" TextMode="MultiLine" Height="129px"
                                                 CssClass="tinput" Width="400px"></asp:TextBox>
                                    <asp:TextBox ID="TextBoxpath" runat="server" Visible="false" Width="260px" CssClass="tinput"></asp:TextBox>
                                    <asp:FileUpload ID="FileUploadpath" runat="server" Visible="false" />
                                    <input id="ButtonSelectSingleImage" runat="server" type="button" value="插入图片" visible="false"
                                           onclick="openLogoSingleChild()" class="selpic" style="position: relative; top: 0px; top: 0px\9; *top: -1px; _top: -1px;" />
                                </td>
                            </tr>
                            <tr id="adheight" runat="server" style="display: none">
                                <th align="right">
                                    高度：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxHeight" runat="server" CssClass="tinput"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionHeight" runat="server" ControlToValidate="TextBoxHeight"
                                                                    ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr id="adwidth" runat="server" style="display: none">
                                <th align="right">
                                    宽度：
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxWidth" runat="server" CssClass="tinput"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionWidth" runat="server" ControlToValidate="TextBoxWidth"
                                                                    ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tablebtn">
                        <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                        <input id="inputReset" type="reset" value="重置" class="bt2" style="display: none;" />
                        <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh" CausesValidation="false"
                                    OnClick="ButtonBack_Click" />
                        <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
        </form>
    </body>
</html>