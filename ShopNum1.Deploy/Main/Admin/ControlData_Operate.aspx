<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ControlData_Operate.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ControlData_Operate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新增模块数据</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type="text/javascript" language="javascript">
        //选择单图
        function openSingleChild() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var strLen = k.length;
                var lastIndex = k.lastIndexOf('/');
                document.getElementById("TextBoxControlImg").value = k.substring(lastIndex + 1, strLen);
                document.getElementById("ImgControlImg").src = k;
            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        //选择单图
        function openLogoSingleChild2() {
            var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
            if (k != null) {
                var strLen = k.length;
                var lastIndex = k.lastIndexOf('/');

                document.getElementById("TextBoxProductImg").value = k.substring(lastIndex + 1, strLen);
                document.getElementById("ImgProductImg").src = k;
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
                    <asp:Label ID="LabelPageTitle" runat="server" Text="新增模块数据"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelTitle" runat="server" Text="数据类型："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListDataType" CssClass="tselect" Width="184px" runat="server"
                                OnSelectedIndexChanged="DropDownListDataType_SelectedIndexChanged" AutoPostBack="true">
                                <asp:ListItem Text="文字" Value="1"></asp:ListItem>
                                <asp:ListItem Text="图片" Value="2"></asp:ListItem>
                                <asp:ListItem Text="商品" Value="3"></asp:ListItem>
                                <asp:ListItem Text="flash" Value="4"></asp:ListItem>
                                <asp:ListItem Text="多链接" Value="5"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label17" runat="server" Text="标题："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxTitle" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:Label ID="Label18" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxTitle"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label22" runat="server" Text="链接："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxHref" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:Label ID="Label24" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxHref"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                ControlToValidate="TextBoxHref" Display="Dynamic" ErrorMessage="最多250个字符" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            <asp:Label ID="LabelHref" runat="server" Text="需要 http:// 前缀"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label2" runat="server" Text="排序号："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderID" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorContent" runat="server" ControlToValidate="TextBoxOrderID"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryOrderID" runat="server"
                                ControlToValidate="TextBoxOrderID" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label19" runat="server" Text="所属组："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxGroupID" CssClass="tinput" runat="server"></asp:TextBox>
                            <asp:Label ID="Label20" runat="server" Text="*" ForeColor="red"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxGroupID"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBoxGroupID"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <asp:Panel ID="PanelImg" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label11" runat="server" Text="图片："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxControlImg" runat="server"></asp:TextBox>
                                <asp:Label ID="Label15" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxControlImg"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <input id="Button1" type="button" value="选择图片" onclick=" openSingleChild() " />
                                <img id="ImgControlImg" alt="" src="images/noImage.gif" runat="server" />
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelProduct" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label9" runat="server" Text="图片："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxProductImg" runat="server"></asp:TextBox>
                                <asp:Label ID="Label10" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxControlImg"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <input id="Button2" type="button" value="选择图片" onclick=" openLogoSingleChild2() " />
                                <img id="ImgProductImg" alt="" src="" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label12" runat="server" Text="价格："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxPrice" runat="server"></asp:TextBox>
                                <asp:Label ID="Label13" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxPrice"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorCostPrice1" runat="server"
                                    ControlToValidate="TextBoxPrice" Display="Dynamic" ErrorMessage="价格格式不正确" ValidationExpression="^[0-9]{1,7}(\.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelFlash" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label14" runat="server" Text="内容："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxFlashImage" runat="server" TextMode="MultiLine"></asp:TextBox>
                                <asp:Label ID="Label16" runat="server" Text="*" ForeColor="red"></asp:Label>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxFlashImage"
                                    Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxFlashImage"
                                    Display="Dynamic" ErrorMessage="最多250个字符" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                    <tr>
                        <th align="right">
                            补充
                        </th>
                        <td>
                            <asp:CheckBox ID="CheckBoxMore" runat="server" OnCheckedChanged="CheckBoxMore_CheckedChanged"
                                AutoPostBack="True" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="是否显示："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsShow" runat="server" CssClass="tselect" Style="width: 80px;">
                                <asp:ListItem Text="否" Value="0"></asp:ListItem>
                                <asp:ListItem Text="是" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <asp:Panel ID="PanelMore" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label23" runat="server" Text="标题2："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxTitle1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label21" runat="server" Text="链接2："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxHref1" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBoxHref1"
                                    Display="Dynamic" ErrorMessage="最多250个字符" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label25" runat="server" Text="标题3："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxTitle2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label27" runat="server" Text="链接3："></asp:Label>
                            </th>
                            <td>
                                <asp:TextBox ID="TextBoxHref2" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBoxHref2"
                                    Display="Dynamic" ErrorMessage="最多250个字符" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="BottonConfirm" runat="server" OnClick="ButtonConfirm_Click" Text="确定"
                    ToolTip="Submit" CssClass="fanh" />
                <%--<input id="inputReset" runat="server" type="reset" value="重置" class="bt2" />--%>
                <asp:Button ID="BottonBack" runat="server" Text="返回列表" CssClass="fanh" CausesValidation="False"
                    OnClick="BottonBack_Click" />
                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldControlGuid" runat="server" Value="0" />
    </form>
</body>
</html>
