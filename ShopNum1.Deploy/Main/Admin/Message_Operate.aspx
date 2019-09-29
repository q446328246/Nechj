<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Message_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Message_Operate" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<%@ Register Src="UserControl/MemberSelect.ascx" TagName="MemberSelect" TagPrefix="uc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>操作信息</title>
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
            border-left: solid 1px #4B66A5;
            border-top: solid 0px #4B66A5;
            border-right: solid 1px #4B66A5;
            border-bottom: solid 1px #4B66A5;
        }
    </style>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script src="js/CommonJS.js" type="text/javascript"></script>
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
            var svalue = document.getElementById("MemberSelect2_ListBoxRightMember").value;
            if (svalue == "") {
                alert("请选择会员");
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
                        <li><a class="cur" id="current1" style="cursor: pointer;" onclick="change_option(2,1);">
                            <asp:Label runat="server" ID="tab01" Text="消息内容" /></a> </li>
                        <li><a id="current2" style="cursor: pointer;" onclick="change_option(2,2);">
                            <asp:Label runat="server" ID="tab02" Text="发送对象" /></a> </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="welcon clearfix">
            <div id="content1" runat="server" style="display: block;">
                <div class="inner_page_list">
                    <table border="0" cellpadding="0" cellspacing="0" class="shoptable">
                        <tr>
                            <th align="right" width="150px">
                                <asp:Label ID="LabelTitle" runat="server" Text="消息标题："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput"></asp:TextBox>
                                <font color="red">
                                    <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                </font>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitle" runat="server" ControlToValidate="TextBoxTitle"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorTitle" runat="server"
                                    ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right" width="150px">
                                <asp:Label ID="LabelContent" runat="server" Text="消息内容："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxContent" runat="server" CssClass="tinput" TextMode="MultiLine"
                                    Width="440" Height="62"></asp:TextBox>
                                <font color="red">
                                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                                </font>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxContent"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <!-- **************************发送对象************************** -->
            <%--<div id="content2" runat="server" align="left">--%>
            <div id="content2" runat="server" style="display: none;">
                <uc1:MemberSelect ID="MemberSelect2" runat="server" />
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonConfirm" runat="server" Text="确定" OnClick="ButtonConfirm_Click"
                    OnClientClick="if(Page_ClientValidate()){return checkNull();} return false;"
                    ToolTip="Submit" CssClass="fanh" />
                <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                    PostBackUrl="SendMessage_List.aspx" Text="返回列表" />
                <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
