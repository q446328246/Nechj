<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="MMSMemberGroup_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.MMSMemberGroup_Operate" %>

<%@ Register Src="UserControl/MemberSelect.ascx" TagName="MemberSelect" TagPrefix="uc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员组管理操作</title>
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

        function change_option(number, index) {
            for (var i = 1; i <= number; i++) {
                document.getElementById('current' + i).className = '';
                document.getElementById('content' + i).style.display = 'none';
            }
            document.getElementById('current' + index).className = 'cur';
            document.getElementById('content' + index).style.display = 'block';
        }

        function checkNull() {
            var svalue = document.getElementById("MemberSelect1_ListBoxRightMember").options.length;
            if (parseInt(svalue) == 0) {
                alert("已选会员不能为空！");
                return false;
            }
            return true;
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
                        <li><a class="cur" id="current1" style="cursor: pointer;" onclick=" change_option(2, 1) ">
                            <asp:Label runat="server" ID="Label6" Text="会员组添加" /></a>
                            <%-- <a class="cur"  id="current1" style="cursor: pointer;" onclick="changeTab(2,1);">
                        <asp:Label runat="server" ID="tab01" Text="资讯详细"  /></a>--%>
                        </li>
                        <li><a id="current2" style="cursor: pointer;" onclick=" change_option(2, 2); ">
                            <asp:Label runat="server" ID="Label7" Text="会员选择" /></a>
                            <%--    <a  id="current2" style="cursor: pointer;" onclick="changeTab(2,2);">
                                <asp:Label runat="server" ID="tab02" Text="关联资讯" /></a>--%>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="welcon clearfix">
            <div id="content1" runat="server" style="display: block;">
                <div class="inner_page_list">
                    <table border="0" cellpadding="0" cellspacing="1">
                        <tr>
                            <th align="right" width="150px">
                                <asp:Label ID="LabelName" runat="server" Text="会员组名称："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="会员组名称最多50个字符"
                                    ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="LabelDescription" runat="server" Text="会员组描述："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput" Height="60px"
                                    TextMode="MultiLine" Width="440"></asp:TextBox>
                                <asp:Label ID="Label2" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDescription" runat="server"
                                    ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorName0" runat="server"
                                    ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="会员组描述最多500个字符"
                                    ValidationExpression="^[\s\S]{0,500}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <!-- *******************发送对象******************* -->
            <%--<div id="content2" runat="server" align="left">--%>
            <div id="content2" runat="server" style="display: none; font-size: 14px;">
                <uc1:MemberSelect ID="MemberSelect1" runat="server" />
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" OnClientClick=" if (Page_ClientValidate()) { return checkNull();}return false; "
                    OnClick="ButtonConfirm_Click" ToolTip="Submit" CssClass="fanh" />
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="~/Main/Admin/MMSMemberGroup_List.aspx" Text="返回列表" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
