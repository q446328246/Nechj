<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MemberGroup_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MemberGroup_Operate" %>

<%@ Register Src="UserControl/MemberSelect.ascx" TagName="MemberSelect" TagPrefix="uc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员群组</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <style type="text/css">
        .content
        {
        }
        
        .content .contentHeader
        {
            background-color: #BCC7E0;
            border: solid 1px #4B66A5;
            font-weight: bold;
        }
        
        .content .contentMain
        {
            border-bottom: solid 1px #4B66A5;
            border-left: solid 1px #4B66A5;
            border-right: solid 1px #4B66A5;
            border-top: solid 0px #4B66A5;
        }
    </style>
    <script type="text/javascript">
        var number = 2;

        function changeTab(number, index) {
            for (var i = 1; i <= number; i++) {
                document.getElementById('current' + i).className = '';
                document.getElementById('content' + i).style.display = 'none';
            }
            document.getElementById('current' + index).className = 'cur';
            document.getElementById('content' + index).style.display = 'block';
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="mhead">
            <div class="ml">
                <div class="mr" id="header">
                    <ul class="mul">
                        <li><a class="cur" id="current1" style="cursor: pointer;" onclick=" changeTab(2, 1); ">
                            <asp:Label runat="server" ID="tab01" Text="会员组添加" /></a> </li>
                        <li><a id="current2" style="cursor: pointer;" onclick=" changeTab(2, 2); ">
                            <asp:Label runat="server" ID="tab02" Text="会员选择" /></a> </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="welcon clearfix">
            <div id="content1" runat="server" style="display: block;">
                <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                    <tr>
                        <th align="right">
                            <div class="shopth">
                                <asp:Label ID="LabelName" runat="server" Text="会员组名称："></asp:Label>
                            </div>
                        </th>
                        <td>
                            <div class="shoptd">
                                <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="名称最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <div class="shopth" style="height: 70px;">
                                <asp:Label ID="LabelDescription" runat="server" Text="会员组描述："></asp:Label>
                            </div>
                        </th>
                        <td>
                            <div class="shoptd" style="height: 70px;">
                                <asp:TextBox ID="TextBoxDescription" CssClass="tinput" runat="server" Height="60px"
                                    TextMode="MultiLine" Width="440"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" runat="server"
                                    ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorName0" runat="server"
                                    ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="描述最多500个字符"
                                    ValidationExpression="^[\s\S]

{0,500}$"></asp:RegularExpressionValidator>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <!-- *******************发送对象******************* -->
            <%--<div id="content2" runat="server" align="left">--%>
            <div id="content2" runat="server" style="display: none;">
                <uc1:MemberSelect ID="MemberSelect1" runat="server" />
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" OnClick="ButtonConfirm_Click"
                    ToolTip="Submit" CssClass="fanh" />
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/MemberGroup_List.aspx" Text="返回列表" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
