<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Link_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Link_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增友情链接</title>
    <link href="style/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">

        //选择单图
        function openSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                //          var strLen=k.length;
                //          var lastIndex=k.lastIndexOf('/');
                var strArray = k.split(",");
                // alert(strArray[0]);
                document.getElementById("textBoxImgAddress").value = strArray[0];
                //           k.substring(lastIndex+1,strLen); 
                document.getElementById("ImageOriginalImge").src = strArray[1];
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="新增友情链接"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            <asp:Label ID="lblLinkType" runat="server" Text="链接类型："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropListLinkType" CssClass="tselect" runat="server" AutoPostBack="True"
                                OnSelectedIndexChanged="DropListLinkType_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:Label ID="Label1" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblTitle" runat="server">链接名称：</asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="textBoxTitle" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label2" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" runat="server"
                                ControlToValidate="textBoxTitle" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorT" runat="server" ControlToValidate="textBoxTitle"
                                Display="Dynamic" ErrorMessage="标题最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblLinkAddress" runat="server" Text="链接地址："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="textBoxLinkAddress" runat="server" CssClass="tinput">http://</asp:TextBox>
                            <asp:Label ID="Label3" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:Label ID="Label11" runat="server" Text="（格式：http://...）"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Display="Dynamic"
                                ControlToValidate="textBoxLinkAddress" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="textBoxLinkAddress"
                                ErrorMessage="地址格式错误" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblOrderID" runat="server" Text="排序号："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="textBoxOrderID" runat="server" CssClass="tinput"></asp:TextBox>
                            <asp:Label ID="Label6" runat="server" ForeColor="#FF0066" Text="*"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="textBoxOrderID"
                                ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="textBoxOrderID"
                                ErrorMessage="只能为数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <asp:Panel ID="PanelPic" runat="server">
                        <tr>
                            <th align="right">
                                <asp:Label ID="lblIMGTYPE" runat="server" Text="图片类型："></asp:Label>
                            </th>
                            <td>
                                <asp:RadioButtonList ID="radioButtonImgType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="radioButtonIMGTYPE_SelectedIndexChanged"
                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                    <asp:ListItem Selected="True" Value="0">本地图片</asp:ListItem>
                                    <asp:ListItem Value="1">远程图片</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="lblImgAddress" runat="server" Text="本地上传："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="textBoxImgAddress" runat="server" CssClass="tinput"></asp:TextBox><asp:Label
                                    ID="Label10" runat="server" Text="*" ForeColor="red"></asp:Label><asp:RequiredFieldValidator
                                        ID="RequiredFieldValidatorImgAddress" runat="server" ControlToValidate="textBoxImgAddress"
                                        ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:Panel ID="Panelimage" runat="server">
                                    <input id="ButtonSelectSingleImage" class="selpic" type="button" value="选择图片" onclick=" openSingleChild() " /><img
                                        id="ImageOriginalImge" runat="server" alt="" src="" width="60" height="60" /></asp:Panel>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorPackImagePath" runat="server"
                                    ControlToValidate="textBoxImgAddress" Display="Dynamic" ErrorMessage="路径最多250个字符"
                                    ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblDescription" runat="server" Text="站点介绍："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="textBoxDescription" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblIsShow" runat="server" Text="是否前台显示："></asp:Label>
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxIsShow" runat="server" Checked="True" Text="是" /><span>是否在前台显示。</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="lblRemark" runat="server" Text="备注："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="textBoxMemo" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="BottonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                    CssClass="fanh" />
                <asp:Button ID="ButtonBack" runat="server" CssClass="fanh" PostBackUrl="~/Main/Admin/Link_Manage.aspx"
                    Text="返回列表" CausesValidation="False" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    </form>
</body>
</html>
