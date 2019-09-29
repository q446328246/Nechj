<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopRank_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopRank_Operate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增店铺等级</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript">
        function Banding() {
            var checkedBoxValues = GetCheckedBoxValues();
            document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,', '');
        }

        function GetCheckedBoxValues() {
            var checkedBoxValues = "0";
            var inputs = document.getElementsByTagName("input");
            for (var j = 0; j < inputs.length; j++) {
                if (inputs[j].type == "checkbox" && inputs[j].id != "checkboxAll") {
                    if (inputs[j].checked == true) {
                        checkedBoxValues += ("," + "'" + inputs[j].value + "'");
                    }
                }
            }
            return checkedBoxValues;
        }

        //选择单图

        function openLogoSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k == undefined) {
                k = window.returnValue;
            }
            if (k != null) {
                var allSplit = new Array();
                allSplit = k.split(",");
                document.getElementById("HiddenFieldPic").value = allSplit[0];
                document.getElementById("image").src = allSplit[1];
            }
        }

        function checkBoxall() {
            var all = document.getElementById("checkboxAll");
            var check = document.getElementsByTagName("input");
            for (var i = 0; i < check.length; i++) {
                if (check[i].type == "checkbox") {
                    check[i].checked = all.checked;
                }
            }
        }
    </script>
    <style type="text/css">
        #CalendarExtender4_daysBody td
        {
            height: 15px;
            line-height: 15px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div style="left: -1000px; top: 377px; visibility: hidden;" id="dhtmltooltip">
        <img src="" height="200" width="200px"></div>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="新增店铺等级"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelName" runat="server" Text="店铺等级名称："></asp:Label>
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
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="Label8" runat="server" Text="店铺等级值："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxRankValue" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label9" runat="server" ForeColor="red" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxRankValue"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxRankValue"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator><br />
                            (店铺等级值是为了区分等级之间的差距，等级值越高，那么表示等级越高，请不要设置和其他等级相同的等级值，请输入0到100之间的任意整数。)
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMaxProduct" runat="server" Text="可添加最大商品数："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMaxProduct" CssClass="tinput" MaxLength="9" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxMinScore"
                                runat="server" ControlToValidate="TextBoxMaxProduct" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMinScore" runat="server"
                                ControlToValidate="TextBoxMaxProduct" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelMaxFileCount" runat="server" Text="添加最大文件空间（M）："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMaxFileCount" MaxLength="5" CssClass="tinput" runat="server"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxMaxFileCount"
                                runat="server" ControlToValidate="TextBoxMaxFileCount" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMaxFileCount" runat="server"
                                ControlToValidate="TextBoxMaxFileCount" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label6" runat="server" Text="等级图片："></asp:Label>
                        </th>
                        <td>
                            <%--<asp:TextBox ID="TextBoxPic" CssClass="tinput" runat="server"></asp:TextBox>--%>
                            <asp:HiddenField ID="HiddenFieldPic" runat="server" />
                            <input id="input" type="button" value="选择图片" class="selpic" onclick=" openLogoSingleChild() " />
                            <img id="image" src="" runat="server" alt="" width="20" height="20" />
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="能否使用独立域名："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsOverrideDomain" runat="server" CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                                <asp:ListItem Value="0">不可以</asp:ListItem>
                                <asp:ListItem Value="1">可以</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                            <asp:CompareValidator ID="CompareDropDownListIsOverrideDomain" runat="server" ControlToValidate="DropDownListIsOverrideDomain"
                                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label7" runat="server" Text="是否允许设置店铺SEO："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsSetSEO" runat="server" CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                                <asp:ListItem Value="1">允许</asp:ListItem>
                                <asp:ListItem Value="0">不允许</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="DropDownListIsSetSEO"
                                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="Label2" runat="server" Text="是否默认："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsDefault" runat="server" AutoPostBack="true" CssClass="tselect" OnSelectedIndexChanged="DropDownListIsDefault_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                                <asp:ListItem Value="0">默认</asp:ListItem>
                                <asp:ListItem Value="1">非默认</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                            <asp:CompareValidator ID="CompareDropDownListIsDefault" runat="server" ControlToValidate="DropDownListIsDefault"
                                Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>--%>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelStartTime" runat="server" Text="开始使用时间："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxStartTime" CssClass="tinput" runat="server"></asp:TextBox><span
                                style="color: Red">*</span>
                            <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 4px; width: 16px;" />
                            <t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxStartTime"
                                PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                            <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                                ControlToValidate="TextBoxStartTime" Display="Dynamic" ErrorMessage="时间格式不正确"
                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxStartTime" runat="server"
                                ControlToValidate="TextBoxStartTime" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>--%>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelPrice" runat="server" Text="开店费用："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxPrice" CssClass="tinput" runat="server" MaxLength="9"></asp:TextBox><span
                                style="color: Red">*</span>元/年
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorCostPrice1" runat="server"
                                ControlToValidate="TextBoxPrice" Display="Dynamic" ErrorMessage="价格格式不正确" ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxPrice" runat="server"
                                ControlToValidate="TextBoxPrice" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelMaxPanicBuyCount" runat="server" Text="添加最大抢购商品数量："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMaxPanicBuyCount" CssClass="tinput" runat="server" MaxLength="9"></asp:TextBox><span
                                style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxMaxPanicBuyCount"
                                runat="server" ControlToValidate="TextBoxMaxPanicBuyCount" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMaxPanicBuyCount" runat="server"
                                ControlToValidate="TextBoxMaxPanicBuyCount" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelMaxSpellBuyCount" runat="server" Text="添加最大团购商品数量："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMaxSpellBuyCount" MaxLength="9" CssClass="tinput" runat="server"></asp:TextBox><span
                                style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorMaxSpellBuyCount" runat="server"
                                ControlToValidate="TextBoxMaxSpellBuyCount" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorMaxSpellBuyCount" runat="server"
                                ControlToValidate="TextBoxMaxSpellBuyCount" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMaxArticleCout" runat="server" Text="可添加资讯数："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMaxArticleCout" MaxLength="9" CssClass="tinput" runat="server"></asp:TextBox><span
                                style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxMaxArticleCout"
                                runat="server" ControlToValidate="TextBoxMaxArticleCout" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMaxArticleCout" runat="server"
                                ControlToValidate="TextBoxMaxArticleCout" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMaxVedioCount" runat="server" Text="可添加视频数："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMaxVedioCount" MaxLength="9" CssClass="tinput" runat="server"></asp:TextBox><span
                                style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxMaxVedioCount"
                                runat="server" ControlToValidate="TextBoxMaxVedioCount" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMaxVedioCount" runat="server"
                                ControlToValidate="TextBoxMaxVedioCount" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelshopTemplate" runat="server" Text="可以使用的模板："></asp:Label>
                        </th>
                        <td>
                            <table border="0" cellpadding="0" cellspacing="0" class="mobantab">
                                <tr>
                                    <td>
                                        <input type="checkbox" onclick=" checkBoxall() " id="checkboxAll" />
                                    </td>
                                    <td>
                                        ID
                                    </td>
                                    <td>
                                        模板名称
                                    </td>
                                    <td>
                                        模板效果图
                                    </td>
                                </tr>
                                <asp:Repeater ID="RepeatershopTemplate" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td>
                                                <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="Label4" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label5" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </td>
                                            <td align="center">
                                                <img src='<%# Page.ResolveUrl("~/Template/ShopTemplate/" + Eval("TemplateImg")) %>'
                                                    onmouseover=" javascript:ddrivetip('<img width=200px height=200 src=<%# Page.ResolveUrl("~/Template/ShopTemplate/" + Eval("TemplateImg")) %> >', '#ffffff'); "
                                                    onmouseout=" hideddrivetip() " height="20" width="20" />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" OnClientClick=" if (Page_ClientValidate()) {return Banding();} else {return false;} "
                    CssClass="fanh" OnClick="ButtonConfirm_Click" />
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/ShopRank_List.aspx" Text="返回列表" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldIsDefault" runat="server" Value="1" />
    </form>
    <script type="text/javascript" src="js/showimg.js"> </script>
    <script type="text/javascript" src="/JS/dcommon.js"> </script>
</body>
</html>
