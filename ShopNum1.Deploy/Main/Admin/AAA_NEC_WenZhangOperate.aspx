<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="AAA_NEC_WenZhangOperate.aspx.cs"
         Inherits="ShopNum1.Deploy.Main.Admin.AAA_NEC_WenZhangOperate" %>

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
                            <asp:Label ID="LabelPageTitle" runat="server" Text="新增文章"></asp:Label></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="inner_page_list">
                        <table border="0" cellpadding="0" cellspacing="1">
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelName" runat="server" Text="标题："></asp:Label>
                                </th>
                                <td valign="middle">
                                    <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput"></asp:TextBox>
                                    <asp:Label ID="Label3" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoName" runat="server"
                                                                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="标题名称最多50个字符"
                                                                    ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelWebSite" runat="server" Text="文章网址："></asp:Label>
                                </th>
                                <td>
                                    <asp:TextBox ID="TextBoxWebSite" runat="server" CssClass="tinput"></asp:TextBox><span>
                                                                                                                        输入文章网址</span>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorLogoWebSite" runat="server"
                                                                    ControlToValidate="TextBoxWebSite" Display="Dynamic" ErrorMessage="文章地址最多100个字符"
                                                                    ValidationExpression="^[\s\S]{0,100}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            
                          
                            <tr>
                                <th align="right">
                                    <asp:Label ID="LabelLogo" runat="server" Text="品牌图片："></asp:Label>
                                </th>
                                <td>
                                     <asp:FileUpload ID="FileUploadOrganizationImage" CssClass="tinput" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="Span7" style="color: red">&nbsp;</span>
                                   
                                    
                                    <img id="ImageOriginalImge" alt="" height="20" width="20" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                         runat="server" />
                                </td>
                            </tr>
                         
                           
                        </table>
                    </div>
                    <div class="tablebtn">
                        <asp:Button ID="ButtonConfirm" runat="server" Text="确定" ToolTip="" OnClick="ButtonConfirm_Click"
                                    CssClass="fanh" />
                        <asp:Button ID="Button3" runat="server" CssClass="fanh" CausesValidation="false"
                                    PostBackUrl="~/Main/Admin/AAA_NEC_WenZhang.aspx" Text="返回列表" />
                        <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
            <asp:HiddenField ID="hiddenFieldBrandName" runat="server" />
        </form>
    </body>
</html>