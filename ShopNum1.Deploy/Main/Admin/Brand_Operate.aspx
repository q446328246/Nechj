<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Brand_Operate.aspx.cs"
         Inherits="ShopNum1.Deploy.Main.Admin.Brand_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>新增品牌</title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
        <script type="text/javascript">

        //选择单图
            function openSingleChild() {
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) {
                    k = window.returnValue;
                }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    var strLen = k.length;
                    var lastIndex = k.lastIndexOf('/');
                    document.getElementById("TextBoxLogo").value = imgvalue[0];
                    document.getElementById("ImageOriginalImge").src = imgvalue[1];
                }
            }

            var lock = 0;
            //品牌分类

            function ProductBrandCategory() {
                if (lock == 0) {
                    lock = 1;
                    var BrandGuid = document.getElementById("hiddenFieldGuid").value;
                    var memlogid = document.getElementById("LabelProductBrandCategory").innerHTML;
                    var k = window.showModalDialog("ProductCategoryList_Seleted.aspx?BrandGuid=" + BrandGuid + "&date=" + new Date(), window, "dialogWidth:820px;status:no;dialogHeight:550px");
                    if (k == undefined) {
                        k = window.returnValue;
                    }
                    if (k != null) {
                        document.getElementById("spanProductCategoryName").value = k.split(";")[0];
                        document.getElementById("hiddenProductCategoryCode").value = k.split(";")[1];
                    }

                    lock = 0;
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
                            <asp:Label ID="LabelPageTitle" runat="server" Text="新增品牌"></asp:Label></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="inner_page_list">
                        <table border="0" cellpadding="0" cellspacing="1">
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelName" runat="server" Text="品牌名称："></asp:Label>
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoName" runat="server"
                                                                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="品牌名称最多50个字符"
                                                                    ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" width="150px">
                                    品牌类别：
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="tinput"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelWebSite" runat="server" Text="品牌网址："></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxWebSite" runat="server" CssClass="tinput"></asp:TextBox><span>
                                                                                                                        输入品牌网址</span>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoWebSite" runat="server"
                                                                    ControlToValidate="TextBoxWebSite" Display="Dynamic" ErrorMessage="品牌地址最多100个字符"
                                                                    ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelKeywords" runat="server" Text="品牌关键字："></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxKeywords" runat="server" CssClass="tinput" MaxLength="50"></asp:TextBox><span>
                                                                                                                                        商城设置的关键字，利于SEO优化。</span>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoKeywords" runat="server"
                                                                    ControlToValidate="TextBoxKeywords" Display="Dynamic" ErrorMessage="关键字最多200个字符"
                                                                    ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelOrderID" runat="server" Text="品牌排序："></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox>
                                    <asp:Label ID="Label5" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="TextBoxOrderID"
                                                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoOrderID" runat="server"
                                                                    ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                    <span>(自动计算)</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelIsShow" runat="server" Text="是否前台显示："></asp:Label>
                                </th>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsShow" runat="server" CssClass="tselect">
                                        <asp:ListItem Value="0">不显示</asp:ListItem>
                                        <asp:ListItem Value="1">显示</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="Label4" runat="server" Text="*" ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    是否推荐：
                                </th>
                                <td>
                                    <asp:CheckBox ID="CheckBoxIsCommend" runat="server" /><span>是否推荐。</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelLogo" runat="server" Text="品牌Logo："></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxLogo" runat="server" CssClass="tinput"></asp:TextBox>
                                    <input id="ButtonSelectSingleImage" class="selpic" type="button" value="选择图片" onclick=" openSingleChild() " /><asp:RegularExpressionValidator
                                                                                                                                                      ID="RegularExpressionValidatorLogo" runat="server" ControlToValidate="TextBoxLogo"
                                                                                                                                                      Display="Dynamic" ErrorMessage="品牌Logo最多250个字符" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                                    <img id="ImageOriginalImge" alt="" height="20" width="20" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                         runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="height: 115px;">
                                    <asp:Label ID="LabelRemark" runat="server" Text="品牌简介："></asp:Label>
                                </th>
                                <td style="height: 115px;">
                                    <asp:TextBox ID="TextBoxRemark" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="border-bottom: none; height: 115px;">
                                    <asp:Label ID="Label1Description" runat="server" Text="品牌描述："></asp:Label>
                                </th>
                                <td style="border-bottom: none; height: 115px;">
                                    <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoDescription" runat="server"
                                                                    ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="品牌描述最多150个字符"
                                                                    ValidationExpression="^[\s\S]{0,150}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tablebtn">
                        <asp:Button ID="ButtonConfirm" runat="server" Text="确定" ToolTip="" OnClick="ButtonConfirm_Click"
                                    CssClass="fanh" />
                        <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                                    PostBackUrl="~/Main/Admin/Brand_List.aspx" Text="返回列表" />
                        <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenFieldBrandName" runat="server" />
        </form>
    </body>
</html>