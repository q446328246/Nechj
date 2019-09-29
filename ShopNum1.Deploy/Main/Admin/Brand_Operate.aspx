<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Brand_Operate.aspx.cs"
         Inherits="ShopNum1.Deploy.Main.Admin.Brand_Operate" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>����Ʒ��</title>
        <link rel="stylesheet" type="text/css" href="style/css.css" />
        <script type="text/javascript">

        //ѡ��ͼ
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
            //Ʒ�Ʒ���

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
                            <asp:Label ID="LabelPageTitle" runat="server" Text="����Ʒ��"></asp:Label></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="inner_page_list">
                        <table border="0" cellpadding="0" cellspacing="1">
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelName" runat="server" Text="Ʒ�����ƣ�"></asp:Label>
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoName" runat="server"
                                                                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="Ʒ���������50���ַ�"
                                                                    ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" width="150px">
                                    Ʒ�����
                                </th>
                                <td>
                                    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="tinput"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelWebSite" runat="server" Text="Ʒ����ַ��"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxWebSite" runat="server" CssClass="tinput"></asp:TextBox><span>
                                                                                                                        ����Ʒ����ַ</span>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoWebSite" runat="server"
                                                                    ControlToValidate="TextBoxWebSite" Display="Dynamic" ErrorMessage="Ʒ�Ƶ�ַ���100���ַ�"
                                                                    ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelKeywords" runat="server" Text="Ʒ�ƹؼ��֣�"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxKeywords" runat="server" CssClass="tinput" MaxLength="50"></asp:TextBox><span>
                                                                                                                                        �̳����õĹؼ��֣�����SEO�Ż���</span>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoKeywords" runat="server"
                                                                    ControlToValidate="TextBoxKeywords" Display="Dynamic" ErrorMessage="�ؼ������200���ַ�"
                                                                    ValidationExpression="^[\s\S]{0,200}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelOrderID" runat="server" Text="Ʒ������"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxOrderID" MaxLength="9" runat="server" CssClass="tinput"></asp:TextBox>
                                    <asp:Label ID="Label5" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorOrderID" runat="server" ControlToValidate="TextBoxOrderID"
                                                                Display="Dynamic" ErrorMessage="��ֵ����Ϊ��"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoOrderID" runat="server"
                                                                    ControlToValidate="TextBoxOrderID" Display="Dynamic" ErrorMessage="ֻ����������" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                                    <span>(�Զ�����)</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelIsShow" runat="server" Text="�Ƿ�ǰ̨��ʾ��"></asp:Label>
                                </th>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsShow" runat="server" CssClass="tselect">
                                        <asp:ListItem Value="0">����ʾ</asp:ListItem>
                                        <asp:ListItem Value="1">��ʾ</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:Label ID="Label4" runat="server" Text="*" ForeColor="red"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    �Ƿ��Ƽ���
                                </th>
                                <td>
                                    <asp:CheckBox ID="CheckBoxIsCommend" runat="server" /><span>�Ƿ��Ƽ���</span>
                                </td>
                            </tr>
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelLogo" runat="server" Text="Ʒ��Logo��"></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxLogo" runat="server" CssClass="tinput"></asp:TextBox>
                                    <input id="ButtonSelectSingleImage" class="selpic" type="button" value="ѡ��ͼƬ" onclick=" openSingleChild() " /><asp:RegularExpressionValidator
                                                                                                                                                      ID="RegularExpressionValidatorLogo" runat="server" ControlToValidate="TextBoxLogo"
                                                                                                                                                      Display="Dynamic" ErrorMessage="Ʒ��Logo���250���ַ�" ValidationExpression="^[\s\S]{0,250}$"></asp:RegularExpressionValidator>
                                    <img id="ImageOriginalImge" alt="" height="20" width="20" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                         runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="height: 115px;">
                                    <asp:Label ID="LabelRemark" runat="server" Text="Ʒ�Ƽ�飺"></asp:Label>
                                </th>
                                <td style="height: 115px;">
                                    <asp:TextBox ID="TextBoxRemark" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <th align="right" style="border-bottom: none; height: 115px;">
                                    <asp:Label ID="Label1Description" runat="server" Text="Ʒ��������"></asp:Label>
                                </th>
                                <td style="border-bottom: none; height: 115px;">
                                    <asp:TextBox ID="TextBoxDescription" runat="server" CssClass="tinput txtarea" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoDescription" runat="server"
                                                                    ControlToValidate="TextBoxDescription" Display="Dynamic" ErrorMessage="Ʒ���������150���ַ�"
                                                                    ValidationExpression="^[\s\S]{0,150}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <div class="tablebtn">
                        <asp:Button ID="ButtonConfirm" runat="server" Text="ȷ��" ToolTip="" OnClick="ButtonConfirm_Click"
                                    CssClass="fanh" />
                        <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                                    PostBackUrl="~/Main/Admin/Brand_List.aspx" Text="�����б�" />
                        <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenFieldBrandName" runat="server" />
        </form>
    </body>
</html>