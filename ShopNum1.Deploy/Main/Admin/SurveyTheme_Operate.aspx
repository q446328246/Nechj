<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="SurveyTheme_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.SurveyTheme_Operate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增商城调查</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <style type="text/css">
        #CalendarExtender4_daysBody tr td
        {
            height: 15px;
            line-height: 15px;
        }
        
        #CalendarExtender1_daysBody tr td
        {
            height: 15px;
            line-height: 15px;
        }
    </style>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle" runat="server" Text="新增商城调查"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="LabelTitle" runat="server" Text="调查主题："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="textBoxTitle" runat="server" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red;">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="textBoxTitle"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                ControlToValidate="textBoxTitle" Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelStartTime" runat="server" Text="开始日期："></asp:Label>
                        </th>
                        <td>
                            <%-- <ShopNum1:Calendar ID="CalendarStartTime" runat="server"  />--%>
                            <asp:TextBox ID="textBoxStartTime" runat="server" CssClass="tinput"></asp:TextBox>
                            <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 4px; width: 16px;" />
                            <t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="textBoxStartTime"
                                PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" Format="yyyy-MM-dd" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTime1" runat="server"
                                ControlToValidate="textBoxStartTime" Display="Dynamic" ErrorMessage="时间格式不正确"
                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelEndTime" runat="server" Text="截止日期："></asp:Label>
                        </th>
                        <td>
                            <%--<ShopNum1:Calendar ID="CalendarEndTime" runat="server" />--%>
                            <asp:TextBox ID="textEndTime" runat="server" CssClass="tinput"></asp:TextBox>
                            <img id="img1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative;
                                top: 4px; width: 16px;" />
                            <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="textEndTime"
                                PopupButtonID="img1" CssClass="ajax__calendar" Format="yyyy-MM-dd" />
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textEndTime"
                                Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
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
                    <tr class="radiobtn">
                        <th align="right">
                            <asp:Label ID="Label4" runat="server" Text="能否多选："></asp:Label>
                        </th>
                        <td>
                            <asp:RadioButtonList ID="radioButtonCheck" runat="server" ForeColor="Black" RepeatDirection="Horizontal"
                                Width="98px" Height="26px" RepeatLayout="Flow">
                                <asp:ListItem Value="0">能</asp:ListItem>
                                <asp:ListItem Value="1">不能</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" OnClick="btnConfirm_Click"
                    CssClass="fanh" />
                <asp:Button ID="Button1" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/SurveyTheme_Manage.aspx" Text="返回列表" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
