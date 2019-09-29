<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="VideoCategory_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.VideoCategory_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript">
        var lock = 0;
        //选择背景图片

        function openSingleChild() {
            //如果没有锁定
            if (lock == 0) {
                /// 锁定
                lock = 1;
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k != null) {

                    var lastIndex = k.lastIndexOf('/');
                    document.getElementById("TextBoxBackgroundImage").value = k.split(",")[0];
                    $("#ImageBackgroundImage").attr("src", k.split(",")[1]);
                }
            }
            //解锁
            lock = 0;
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
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="新增视频分类"></asp:Label>
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px;">
                            <asp:Label ID="LabelName" runat="server" Text="分类名称："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="名称最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelFatherID" runat="server" Text="上级分类："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListFatherID" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelKeywords" runat="server" Text="分类关键字："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxKeywords" runat="server" Height="60px" TextMode="MultiLine"
                                CssClass="tinput" Width="440"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorKeywords" runat="server"
                                ControlToValidate="TextBoxKeywords" Display="Dynamic" ErrorMessage="关键字最多200个字符"
                                ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelDescription" runat="server" Text="分类描述："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDescription" runat="server" Height="60px" TextMode="MultiLine"
                                CssClass="tinput" Width="440"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorDescription" runat="server"
                                ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="支付方式最多150个字符"
                                ValidationExpression="^[\s\S]{0,150}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelBackgroundImage" runat="server" Text="背景图片："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBackgroundImage" runat="server" CssClass="tinput"></asp:TextBox>
                            <input id="ButtonBackgroundImage" type="button" value="选择图片" onclick=" openSingleChild() "
                                class="selpic" style="position: relative; top: 1px; top: 0px\9; *top: -3px; _top: -3px;" />
                            <img id="ImageBackgroundImage" alt="" src="~/images/noImage.gif" runat="server" width="20"
                                height="20" /><asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                    ControlToValidate="TextBoxBackgroundImage" Display="Dynamic" ErrorMessage="图片链接地址最多250个字符"
                                    ValidationExpression="^[\s\S]{0,250}$" ValidationGroup="one"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOrderID" runat="server" Text="分类排序："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label4" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="TextBoxOrderID"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelIsShow" runat="server" Text="是否前台显示："></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsShow" runat="server" Text="前台显示" Checked="True" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                    ToolTip="Submit" CssClass="fanh" />
                <input id="inputReset" runat="server" type="reset" value="重置" class="bt2" style="display: none;" />
                <asp:Button ID="ButtonBack" runat="server" Text="返回列表" CssClass="fanh" PostBackUrl="VideoCategory_List.aspx"
                    CausesValidation="false" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenGuid" runat="server" Value="0" />
    </form>
</body>
</html>
