<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopReputation_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopReputation_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增店铺信誉等级</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript">
        //选择单图
        function openLogoSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k == undefined) {
                k = window.returnValue;
            }
            if (k != null) {
                var allSplit = new Array();
                allSplit = k.split(",");
                document.getElementById("HiddenFieldpath").value = allSplit[0];
                document.getElementById("RankImage").src = allSplit[1];
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
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="新增店铺信誉等级"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelName" runat="server" Text="信誉等级名称："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelRankType" Visible="false" runat="server" Text="店铺等级类型："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListRankType" Visible="false" Width="180px" runat="server"
                                CssClass="tselect">
                                <asp:ListItem Value="1">店铺信誉等级</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMinScore" runat="server" Text="最小信誉值："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMinScore" MaxLength="9" CssClass="tinput" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxMinScore"
                                runat="server" ControlToValidate="TextBoxMinScore" ErrorMessage="只能是整数" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMinScore" runat="server"
                                ControlToValidate="TextBoxMinScore" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMaxScore" runat="server" Text="最大信誉值："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMaxScore" MaxLength="9" CssClass="tinput" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxMaxScore"
                                ErrorMessage="只能是整数" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMaxScore" runat="server"
                                ControlToValidate="TextBoxMaxScore" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareDataTime" runat="server" ControlToValidate="TextBoxMinScore"
                                Display="Dynamic" ErrorMessage="最大信誉值必需大于最小信誉值" Operator="LessThan" Type="Double"
                                ControlToCompare="TextBoxMaxScore"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelPic" runat="server" Text="信誉等级图片："></asp:Label>
                        </th>
                        <td>
                            <%--<asp:TextBox ID="TextBoxpath" CssClass="tinput" runat="server"></asp:TextBox>--%>
                            <asp:HiddenField ID="HiddenFieldpath" runat="server" />
                            <input id="ButtonSelectSingleImage" runat="server" type="button" value="插入图片" onclick="openLogoSingleChild()"
                                class="selpic" style="position: relative; top: 1px; top: 0px\9; *top: -1px; _top: -1px;" />
                            <asp:Image ID="RankImage" runat="server" Width="20" Height="20" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMemo" runat="server" Text="备注："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMemo" CssClass="tinput txtarea" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/ShopReputation_List.aspx" Text="返回列表" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </form>
</body>
</html>
