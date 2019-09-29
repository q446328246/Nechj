<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="OpenShop.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.OpenShop" %>

<%--<%@ Register src="UserControl/ArticleRelateProductSelect.ascx" tagname="ArticleRelateProductSelect" tagprefix="uc1" %>
--%><!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>管理员给会员开店</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script src="../js/jquery-1.6.2.min.js" type="text/javascript"> </script>
    <script type="text/javascript">
        function ReceiveServerData1(shopName) {

            //接收表单的URL地址
            var url = "/Main/Api/userCheck.aspx"; //需要POST的值，把每个变量都通过&来联接
            var postStr = "otype=checkshopname" + "&shopname=" + shopName;
            var hid = document.getElementById("HiddenExistShopName");
            var context = document.getElementById("spanName"); //实例化Ajax
            var ajax = null;
            try {
                ajax = new XMLHttpRequest();
            } catch (trymicrosoft) {
                try {
                    ajax = new ActiveXObject("Msxml2.XMLHTTP");
                } catch (othermicrosoft) {
                    try {
                        ajax = new ActiveXObject("Microsoft.XMLHTTP");
                    } catch (failed) {
                        ajax = false;
                    }
                }
            }
            if (!ajax)
                alert("Error initializing XMLHttpRequest!");

            //通过Get方式打开连接
            ajax.open("POST", url, true);
            //定义传输的文件HTTP头信息
            ajax.setRequestHeader("Content-Type", "application/x-www-form-urlencoded");
            //发送POST数据
            ajax.send(postStr);

            //返回数据的处理函数
            ajax.onreadystatechange = function () {
                if (ajax.readyState == 4 && ajax.status == 200) {
                    if (ajax.responseText == "success") {
                        hid.value = "false";
                        document.getElementById("OpenShop_ctl00_ButtonSubmit").disabled = true;
                        context.innerHTML = "店铺名已经被使用了";
                    } else {
                        document.getElementById("OpenShop_ctl00_ButtonSubmit").disabled = false;
                        hid.value = "true";
                        context.innerHTML = "店铺名可以使用";
                    }
                }
            };
        }

        //<![CDATA[

        function CheckShopName(inputcontrol) {
            var context = document.getElementById("spanName");
            var reg = /^[\u4e00-\u9fa5\da-zA-Z\-\_]{3,12}$/;
            if (inputcontrol.value != "") {
                if (reg.test(inputcontrol.value)) {
                    context.innerHTML = "数据查询中..";
                    ReceiveServerData1(inputcontrol.value);

                } else {
                    context.innerHTML = "店铺名格式不正确";
                }
            } else {
                context.innerHTML = "店铺名不能为空";
            }
        }
        //]]>
    
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
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="添加店铺"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="150px">
                            会员名 ：
                        </th>
                        <td>
                            <asp:Label ID="LabelMemLoginID" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="150px">
                            店铺等级 ：
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListLv" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" InitialValue="-1" runat="server"
                                ControlToValidate="DropDownListLv" ErrorMessage="店铺等级必选！"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label10" runat="server" Text="店铺类别 ："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:RadioButton ID="RadioButtonGr" runat="server" Text="个人" GroupName="lx" AutoPostBack="true"
                                OnCheckedChanged="RadioButtonGr_CheckedChanged" Checked="true" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RadioButton ID="RadioButtonQy" runat="server" Text="企业" GroupName="lx" AutoPostBack="true"
                                OnCheckedChanged="RadioButtonQy_CheckedChanged" />
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelKeywords" runat="server" Text="店铺名称 ："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopName" MaxLength="20" runat="server" onchange="CheckShopName(this)"
                                CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span> <span style="display: inline;" id="spanName"></span>
                            <span style="color: #bbb; display: inline">店名最短为3个中英文字符</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxShopName" runat="server"
                                ControlToValidate="TextBoxShopName" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelOrderID" runat="server" Text="店铺分类 ："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopCategoryCode1" runat="server" AutoPostBack="true"
                                CssClass="tselect" OnSelectedIndexChanged="DropDownListShopCategoryCode1_SelectedIndexChanged"
                                Style="width: 100px;">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListShopCategoryCode2" runat="server" AutoPostBack="true"
                                CssClass="tselect" OnSelectedIndexChanged="DropDownListShopCategoryCode2_SelectedIndexChanged"
                                Style="width: 100px;">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListShopCategoryCode3" runat="server" Style="width: 100px;"
                                CssClass="tselect">
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" InitialValue="-1" runat="server"
                                ControlToValidate="DropDownListShopCategoryCode1" ErrorMessage="店铺分类必选！"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label11" runat="server" Text="主营商品 ："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMainGoods" MaxLength="200" TextMode="MultiLine" Width="200"
                                Height="90" runat="server" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span> <span style="display: inline;" id="spanName"></span>
                            <span style="color: #bbb; display: inline">介绍店铺主要销售的商品</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxMainGoods"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelIsShow" runat="server" Text="所在地区："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListRegionCode1" runat="server" AutoPostBack="true"
                                CssClass="tselect" Style="width: 80px;" OnSelectedIndexChanged="DropDownListRegionCode1_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListRegionCode2" runat="server" AutoPostBack="true"
                                CssClass="tselect" Style="width: 80px;" OnSelectedIndexChanged="DropDownListRegionCode2_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListRegionCode3" runat="server" CssClass="tselect"
                                Style="width: 80px;">
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                            <asp:CompareValidator ID="CompareValidatorDropDownListRegionCode1" runat="server"
                                ControlToValidate="DropDownListRegionCode3" Display="Dynamic" ErrorMessage="该值必需选择"
                                Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelLogo" runat="server" Text="详细地址："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxdetailAddress" MaxLength="100" CssClass="tinput" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label12" runat="server" Text="邮编号码 ："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxPostalCode" MaxLength="20" runat="server" CssClass="tinput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label13" runat="server" Text="联系电话 ："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxTel" MaxLength="20" runat="server" CssClass="tinput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label14" runat="server" Text="手机号码 ："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:TextBox ID="TextBoxPhone" MaxLength="20" runat="server" CssClass="tinput"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelWebSite" runat="server" Text="身份证号 ："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxIdentityCard" runat="server" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span> <span style="color: #bbb">请填写真实准确的身份证号</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" InitialValue="" runat="server"
                                ControlToValidate="TextBoxIdentityCard" ErrorMessage="身份证号必填！"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxIdentityCard"
                                runat="server" ControlToValidate="TextBoxIdentityCard" Display="Dynamic" ErrorMessage="身份证格式不正确！"
                                ValidationExpression="^\d{14}(\d{1}|\d{4}|(\d{3}[xX]))$"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <asp:Panel ID="PanelBusinessLicense" runat="server" Visible="false">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label7" runat="server" Text="上传营业执照："></asp:Label>
                            </th>
                            <td>
                                <asp:FileUpload ID="FileUploadBusinessLicense" runat="server" /><span style="color: Red">*</span>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelCardImage" runat="server">
                        <tr>
                            <th align="right">
                                <asp:Label ID="Label8" runat="server" Text="上传身份证："></asp:Label>
                            </th>
                            <td>
                                <asp:FileUpload ID="FileUploadCardImage" runat="server" />
                                <span style="color: #bbb">正反面图像</span><span style="color: Red">*</span>
                            </td>
                        </tr>
                    </asp:Panel>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonSubmit" runat="server" Text="提交" OnClick="ButtonSubmit_Click"
                    CssClass="fanh" />
                <input id="inputBack" type="button" onclick=" javascript: window, location.href = 'Member_List.aspx'; "
                    value="返回列表" class="fanh" />
            </div>
        </div>
    </div>
    <input id="hideCategory1" name="hideCategory1" type="hidden" />
    <input id="hideCategory2" name="hideCategory2" type="hidden" />
    <input id="hideCategory3" name="hideCategory3" type="hidden" />
    <input id="HiddenRegion1" name="HiddenRegion1" type="hidden" />
    <input id="HiddenRegion2" name="HiddenRegion2" type="hidden" />
    <input id="HiddenRegion3" name="HiddenRegion3" type="hidden" />
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
    <asp:HiddenField ID="HiddenFieldRegion" runat="server" Value="-1" />
    <asp:HiddenField ID="HiddenFieldGuid" runat="server" />
    <input id="HiddenExistShopName" value="false" type="hidden" />
    </form>
</body>
</html>
