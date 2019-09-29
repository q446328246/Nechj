<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbProduct_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbProduct_Operate" %>
<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <meta http-equiv="X-UA-Compatible" content="IE=7" />
        <link rel="stylesheet" type="text/css" href="style/tbindex.css" />
        <link rel="stylesheet" type="text/css" href="style/index.css" />
        <link href="../css/htweb01.css" rel="stylesheet" type="text/css" />
        <%--  <link type="text/css" rel="Stylesheet" href="../css/htweb01.css" />--%>
        <style type="text/css">
            .content { }

            .content .contentHeader {
                background-color: #BCC7E0;
                border: solid 1px #4B66A5;
                font-weight: bold;
            }

            .content .contentMain {
                border-bottom: solid 1px #4B66A5;
                border-left: solid 1px #4B66A5;
                border-right: solid 1px #4B66A5;
                border-top: solid 0px #4B66A5;
            }
        </style>
        <script type="text/javascript">
        //单图
            function openSingleChild() {
                if (lock == 0) {
                    lock = 1;
                    //var obj = new Object();
                    //obj.myTestWindowA = window;//将这个window存入对象参数中
                    var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;dialogHeight:650px");
                    if (k != null) {
                        var imgvalue = new Array();
                        imgvalue = k.split(",");
                        document.getElementById('<%= TextBoxOrganizImg.ClientID %>').value = imgvalue[0];
                        document.getElementById('<%= ImgOrganizImg.ClientID %>').src = imgvalue[1];
                    }
                }
                lock = 0;
            }

            //多图

            function openChild() {
                if (lock == 0) {
                    lock = 1;
                    var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                    if (k != null) {
                        var imgvalue = new Array();
                        imgvalue = k.split(",");
                        document.getElementById('<%= TextBoxMultiImage.ClientID %>').value = imgvalue[0];
                    }
                }
                lock = 0;
            }

            //给FCK插图

            function openFCKChild(fckName) {
                if (lock == 0) {
                    lock = 1;
                    var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                    if (k != null) {
                        var oEditor = FCKeditorAPI.GetInstance(fckName);
                        var content = oEditor.GetXHTML(true);
                        var imgvalue = new Array();
                        imgvalue = k.split(",");
                        if (oEditor.EditMode == FCK_EDITMODE_WYSIWYG) {
                            oEditor.InsertHtml("<img src='" + imgvalue[1] + "' />");
                        }
                    }
                }
                lock = 0;
            }

            //品牌

            function brandEnabled() {
                var sDropDownListProductCategoryCode1 = document.getElementById("DropDownListProductCategoryCode1").value;
                if (sDropDownListProductCategoryCode1.value != "-1") {
                    document.getElementById("DropDownListProductBrand").Enabled = "true";
                }
            }

            function checkIsVisible() {
                var RadioList = document.getElementById('<%= RadioButtonListFeeType.ClientID %>');
                var radioArray = RadioList.getElementsByTagName('input');
                for (var i = 0; i < radioArray.length; i++) {
                    if (radioArray[i].type == 'radio' && radioArray[i].checked) {
                        if (radioArray[i].value == "1") {
                            document.getElementById('<%= isvisible.ClientID %>').style.display = "none";
                            document.getElementById('<%= TRMinusFee.ClientID %>').style.display = "";
                            return;
                        } else {
                            document.getElementById('<%= isvisible.ClientID %>').style.display = "";
                            document.getElementById('<%= TRMinusFee.ClientID %>').style.display = "none";
                            return;
                        }
                    }
                }
            }

            function FeeRadioClick() {
                if ($("#Product_Operate_ctl00_RadioButtonFeeYou").attr("checked") == "checked") {

                    $("#btnShopPostage").attr("disabled", "disabled");
                    $("#Product_Operate_ctl00_TextBoxPost_fee").removeAttr("disabled");
                    $("#Product_Operate_ctl00_TextBoxExpress_fee").removeAttr("disabled");
                    $("#Product_Operate_ctl00_TextBoxEms_fee").removeAttr("disabled");
                } else {
                    $("#btnShopPostage").removeAttr("disabled");
                    $("#Product_Operate_ctl00_TextBoxPost_fee").attr("disabled", "disabled");
                    $("#Product_Operate_ctl00_TextBoxExpress_fee").attr("disabled", "disabled");
                    $("#Product_Operate_ctl00_TextBoxEms_fee").attr("disabled", "disabled");
                }
            }

            ///提交的时候检查

            function checkAllSubmit() {
                if (Page_ClientValidate()) {
                    var RadioList = document.getElementById('<%= RadioButtonListFeeType.ClientID %>');
                    var radioArray = RadioList.getElementsByTagName('input');
                    var feeone = document.getElementById("Product_Operate_ctl00_RadioButtonFeeYou");
                    var feetemplate = document.getElementById("Product_Operate_ctl00_RadioButtonFeeTemplate");

                    if (radioArray[1].type == 'radio' && radioArray[1].checked && feeone.checked) {
                        if (document.getElementById("Product_Operate_ctl00_TextBoxPost_fee").value == 0 && document.getElementById("Product_Operate_ctl00_TextBoxExpress_fee").value == 0 && document.getElementById("Product_Operate_ctl00_TextBoxEms_fee").value == 0) {
                            alert("至少要填写一个邮费!");
                            return false;

                        }
                    }

                    if (radioArray[1].type == 'radio' && radioArray[1].checked && feetemplate.checked) {
                        if (document.getElementById("posttemplateHidden").value == "") {
                            alert("邮费不能为空!");
                            return false;
                        }
                    }

                    return true;
                }
                return false;

            }

            var lock = 0;
            //规格上传图片

            function SelectImage(linkobject) {
                if (lock == 0) {
                    lock = 1;
                    var imgNames = window.showModalDialog("ImageSpeci_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                    if (imgNames != null) {

                        var imgArray = new Array();
                        imgArray = imgNames.split(',');

                        $(linkobject).parent().find("img").remove(); //清空img
                        $(linkobject).children(":first").attr('value', imgNames);
                        for (var i = 0; i < imgArray.length; i++) {
                            if (imgArray[i] != "") {
                                $("<img />").attr("src", imgArray[i]).attr("style", "margin-left:10px;").height(20).width(20).appendTo($(linkobject).parent());
                            }
                        }
                    }
                    lock = 0;
                }

            }

            ///店铺模板处理

            function SelectShopPostage() {
                if (lock == 0) {
                    lock = 1;
                    var template = window.showModalDialog("ShopFeeTemplate_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                    if (template != null) {

                        var tArray = new Array();
                        tArray = template.split(',');
                        $("#shopfeetemplateUl li:first :hidden:first").val(tArray[0]);
                        $("#shopfeetemplateUl li:first div span").html(tArray[1]);
                        $("#shopfeetemplateUl li:first :hidden:eq(1)").val(tArray[1]);


                    }
                    lock = 0;
                }

            }
        </script>
        <script type="text/javascript">
            function ShowProdProp(sp) {
                if (sp.id == "main") {
                    sp.style.color = "#D40000";
                    $("#saleprop").css("color", "");
                    $("#ProductProp").css("color", "");
                    $("#prodContentDiv").show();
                    $("#prodSaleProDiv").hide();
                    $("#ProdProcuctProcDiv").hide();
                } else if (sp.id == "saleprop") {
                    sp.style.color = "#D40000";
                    $("#main").css("color", "");
                    $("#ProductProp").css("color", "");
                    $("#prodContentDiv").hide();
                    $("#ProdProcuctProcDiv").hide();
                    $("#prodSaleProDiv").show();
                } else if (sp.id == "ProductProp") {
                    sp.style.color = "#D40000";
                    $("#main").css("color", "");
                    $("#saleprop").css("color", "");
                    $("#prodContentDiv").hide();
                    $("#prodSaleProDiv").hide();
                    $("#ProdProcuctProcDiv").show();
                }
            }
        </script>
    </head>
    <body style="background-image: url(../images/Bg_right.gif); background-repeat: repeat; padding: 0;">
        <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" />
            <div class="main">
                <div class="table1">
                    <div class="title">
                        <span id="main" style="color: #D40000;" onclick=" ShowProdProp(this) " style="display: inline;">
                            基本信息</span> <span style="color: #20599c;">┆</span> <span id="saleprop" onclick=" ShowProdProp(this) ">
                                                                                   商品规格</span><span style="color: #20599c;">┆</span> <span id="ProductProp" onclick=" ShowProdProp(this) ">
                                                                                                                                         商品属性</span>
                    </div>
                    <div class="content" id="prodContentDiv">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td style="text-align: right; width: 120px;">
                                    主站商品分类：
                                </td>
                                <td align="left">
                                    <asp:UpdatePanel ID="UpdatePanelProdcutCate" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownListProductCategoryCode1" runat="server" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="DropDownListProductCategoryCode2" runat="server" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="DropDownListProductCategoryCode3" runat="server" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right; width: 120px;">
                                    主站商品品牌：
                                </td>
                                <td align="left">
                                    <asp:UpdatePanel ID="UpdatePanelBrand" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownListProductBrand" runat="server" AutoPostBack="true">
                                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="Label27" runat="server" Text="*" ForeColor="red"></asp:Label>
                                            <asp:CompareValidator ID="CompareValidatorDropDownListProductBrand" runat="server"
                                                                  ControlToValidate="DropDownListProductBrand" Display="Dynamic" ErrorMessage="该值必需选择"
                                                                  Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr style="display: table-row">
                                <td style="text-align: right; width: 120px;">
                                    店铺商品分类：
                                </td>
                                <td align="left">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownListProductSeriesCode1" runat="server" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="DropDownListProductSeriesCode2" runat="server" AutoPostBack="true">
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="DropDownListProductSeriesCode3" runat="server">
                                            </asp:DropDownList>
                                            <asp:Label ID="Label20" runat="server" Text="*" ForeColor="red"></asp:Label>
                                            <asp:CompareValidator ID="CompareFatherCateGory" runat="server" ControlToValidate="DropDownListProductSeriesCode1"
                                                                  Display="Dynamic" ErrorMessage="该值必需选择" Operator="NotEqual" ValueToCompare="-1"></asp:CompareValidator>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    商品名称：
                                </td>
                                <td>
                                    <ShopNum1:TextBox ID="TextBoxName" runat="server" CssClass="allinput1" CanBeNull="必填"
                                                      HintInfo="请填写该商品的名称,该项必填" HintTitle="请填写该商品的名称,该项必填">
                                    </ShopNum1:TextBox>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorName" runat="server"
                                                                    ControlToValidate="TextBoxName" Display="Dynamic" ErrorMessage="最多50个字符" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    物品类型：
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonListIsReal" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True" Value="1">实际物品</asp:ListItem>
                                        <asp:ListItem Value="0">虚拟物品</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <asp:Panel ID="PanelType" runat="server">
                                <tr>
                                    <td style="text-align: right">
                                        商品类别：
                                    </td>
                                    <td>
                                        <asp:RadioButtonList ID="RadioButtonListType" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Value="IsNew" Selected="True">新品</asp:ListItem>
                                            <asp:ListItem Value="IsHot">热卖</asp:ListItem>
                                            <asp:ListItem Value="IsPromotion">促销</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td style="text-align: right">
                                    商品型号：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBoxProductNum" runat="server" MaxLength="50" CssClass="allinput1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    商品单位：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBoxUnitName" runat="server" CssClass="allinput1" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <asp:Panel ID="PanelRepertoryCount" runat="server">
                                <tr>
                                    <td style="text-align: right">
                                        库存量：
                                    </td>
                                    <td align="left">
                                        <ShopNum1:TextBox ID="TextBoxRepertoryCount" runat="server" CssClass="allinput1"
                                                          CanBeNull="必填" HintInfo="请填写该商品的库存量,该项必填" HintTitle="请填写该商品的库存量,该项必填" RequiredFieldType="整数验证"
                                                          MaxLength="9">
                                        </ShopNum1:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td style="text-align: right">
                                    市场价：
                                </td>
                                <td align="left">
                                    <ShopNum1:TextBox ID="TextBoxMarketPrice" runat="server" CssClass="allinput1" CanBeNull="必填"
                                                      HintInfo="请填写该商品的市场价,该项必填" RequiredFieldType="金额" HintTitle="请填写该商品的市场价,该项必填"
                                                      MaxLength="6">
                                    </ShopNum1:TextBox>￥
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="LabelPriceType" runat="server" Text="本店价："></asp:Label>
                                </td>
                                <td align="left">
                                    <ShopNum1:TextBox ID="TextBoxShopPrice" runat="server" MaxLength="6" CssClass="allinput1"
                                                      CanBeNull="必填" HintInfo="请填写该商品的本店价,该项必填" RequiredFieldType="金额" HintTitle="请填写该商品的本店价,该项必填">
                                    </ShopNum1:TextBox>￥
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    <asp:Label ID="Label1" runat="server" Text="利润分成："></asp:Label>
                                </td>
                                <td align="left">
                                    <ShopNum1:TextBox ID="TextBoxGroupPrice" runat="server" MaxLength="6" CssClass="allinput1"
                                                      CanBeNull="必填" HintInfo="请填写该商品的利润分成,该项必填" RequiredFieldType="金额" HintTitle="请填写该商品的利润分成,该项必填">
                                    </ShopNum1:TextBox>
                                    <asp:Literal ID="LiteralPrdouctFcRate" runat="server">Y</asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    运费：
                                </td>
                                <td align="left">
                                    <div style="float: left; width: 214px;">
                                        <ShopNum1:RadioButtonList ID="RadioButtonListFeeType" onclick="checkIsVisible()"
                                                                  runat="server" RepeatDirection="Horizontal" HintInfo="如果是买家承担运费,则运费不能为0">
                                            <asp:ListItem Value="1">卖家承担运费</asp:ListItem>
                                            <asp:ListItem Selected="True" Value="0">买家承担运费</asp:ListItem>
                                            <%--  <asp:ListItem Selected="True" Value="0">买家承担运费</asp:ListItem>
                                <asp:ListItem  Value="1">卖家承担运费</asp:ListItem>--%>
                                        </ShopNum1:RadioButtonList>
                                    </div>
                                    <div style="color: Red; float: left; width: 5px;">
                                        *</div>
                                </td>
                            </tr>
                            <tr id="isvisible" runat="server">
                                <td style="text-align: right; width: 120px;">
                                </td>
                                <td>
                                    <ul id="shopfeetemplateUl">
                                        <li>
                                            <asp:RadioButton ID="RadioButtonFeeYou" Checked="true" runat="server" GroupName="RadioButtonFee"
                                                             onclick="FeeRadioClick()" />
                                            平邮:
                                            <ShopNum1:TextBox ID="TextBoxPost_fee" MaxLength="9" Width="70px" runat="server"
                                                              CanBeNull="必填" RequiredFieldType="金额" MinimumValue="0.00">
                                            </ShopNum1:TextBox>元 快递:
                                            <ShopNum1:TextBox ID="TextBoxExpress_fee" MaxLength="9" Width="70px" runat="server"
                                                              CanBeNull="必填" RequiredFieldType="金额" MinimumValue="0.00">
                                            </ShopNum1:TextBox>元 EMS:
                                            <ShopNum1:TextBox ID="TextBoxEms_fee" MaxLength="9" Width="70px" runat="server" CanBeNull="必填"
                                                              RequiredFieldType="金额" MinimumValue="0.00">
                                            </ShopNum1:TextBox>元 </li>
                                        <li>
                                            <asp:RadioButton ID="RadioButtonFeeTemplate" runat="server" GroupName="RadioButtonFee"
                                                             onclick="FeeRadioClick()" />
                                            使用运费模板
                                            <div>
                                                <input type="hidden" id="posttemplateHidden" value="" runat="server" />
                                                <asp:Label ID="LabelPostTemplateName" runat="server" Text=""></asp:Label><input type="button"
                                                                                                                                value="使用店铺模板" onclick=" SelectShopPostage() " id="btnShopPostage" class="bt2"
                                                                                                                                disabled="disabled" />
                                                <input type="hidden" name="posttemplateNameHidden" />
                                            </div>
                                        </li>
                                    </ul>
                                </td>
                            </tr>
                            <tr id="TRMinusFee" style="display: none" runat="server">
                                <td style="text-align: right; width: 120px;">
                                    买家自提货减去运费：
                                </td>
                                <td>
                                    <ShopNum1:TextBox ID="TextBoxMinusFee" MaxLength="9" CssClass="allinput1" runat="server"
                                                      CanBeNull="必填" RequiredFieldType="金额" MinimumValue="0.00">0.00</ShopNum1:TextBox>元
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    商品详细：
                                </td>
                                <td align="left">
                                    <input id="Button1" onclick=" openFCKChild('<%= FCKeditorDetail.ClientID %>') " class="bt2 bt3"
                                           type="button" value="插入商品详细图片" />
                                    <fckeditorv2:fckeditor id="FCKeditorDetail" runat="server" height="300">
                                    </fckeditorv2:fckeditor>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    商品图片：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="TextBoxOrganizImg" runat="server" CssClass="allinput1"></asp:TextBox>
                                    <asp:Label ID="Label15" runat="server" Text="*" ForeColor="red"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxOrganizImg"
                                                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                    <input id="bt2" class="bt2" style="bottom: -5px; position: relative;" type="button"
                                           value="选择图片" onclick=" openSingleChild() " />
                                    <img id="ImgOrganizImg" alt="" src="../images/noImage.gif" onerror="javascript:this.src='Themes/Skin_Default/images/noImage.gif'"
                                         runat="server" width="110" height="110" />
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    商品多图：
                                </td>
                                <td align="left" style="padding-top: 6px;">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:DataList ID="DataListPorductImage" runat="server" RepeatDirection="Horizontal">
                                                <ItemTemplate>
                                                    <table cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td style="padding: 6px;">
                                                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("OriginalImge", "{0}") %>'
                                                                           onerror="javascript:this.src='Themes/Skin_Default/images/noImage.gif'" Height="70px"
                                                                           Width="90px" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center">
                                                                <input id="checkboxItem" runat="server" value='<%# Eval("Guid") %>' type="checkbox"
                                                                       cssclass="allinput1" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                            <asp:TextBox ID="TextBoxMultiImage" runat="server"></asp:TextBox>
                                            <input id="ButtonSelectImage" class="bt2" type="button" value="选择图片" onclick=" openChild() "
                                                   cssclass="bt2" />
                                            <asp:Button ID="ButtonPicAdd" runat="server" Text="添加" CausesValidation="false" CssClass="bt2" />
                                            <asp:Button ID="ButtonPicDel" runat="server" Text="删除" CausesValidation="false" CssClass="bt2" />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    购买须知：
                                </td>
                                <td align="left">
                                    <input id="ButtonSelectSingleImage" onclick=" openFCKChild('<%= FCKeditorInstruction.ClientID %>') "
                                           class="bt2 bt3" type="button" value="插入购买须知图片" />
                                    <fckeditorv2:fckeditor id="FCKeditorInstruction" runat="server" height="300">
                                    </fckeditorv2:fckeditor>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    标题：
                                </td>
                                <td align="left">
                                    <ShopNum1:TextBox ID="TextBoxTitle" runat="server" CssClass="allinput1" MaxLength="50"
                                                      HintInfo="商品标题,此功能是为了方便百度等搜索引擎,搜索到您的商品" HintTitle="商品标题,此功能,是为了方便百度等搜索引擎,搜索到您的商品">
                                    </ShopNum1:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    关键字：
                                </td>
                                <td style="left">
                                    <ShopNum1:TextBox ID="TextBoxDescription" runat="server" CssClass="allinput1" HintInfo="可以添加多个关键字,请用空格隔开"
                                                      HintTitle="可以添加多个关键字,请用空格隔开" MaxLength="50">
                                    </ShopNum1:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    描述：
                                </td>
                                <td align="left">
                                    <ShopNum1:TextBox ID="TextBoxKeywords" runat="server" Height="120px" Width="304px"
                                                      CssClass="allinput1" HintInfo="商品描述,此功能是为了方便百度等搜索引擎,搜索到您的商品" MaxLength="200"
                                                      HintTitle="商品描述,此功能是为了方便百度等搜索引擎,搜索到您的商品">
                                    </ShopNum1:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="text-align: right">
                                    是否同步淘宝：
                                </td>
                                <td style="left">
                                    <asp:CheckBox ID="CheckBoxTb" runat="server" Checked="false" Text="是否同步淘宝" AutoPostBack="true" />
                                    <span id="spanTb" runat="server" style="color: Red;">(未同步)</span>
                                    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
                                </td>
                            </tr>
                            <asp:Panel ID="PanelIsPanicBuy" runat="server" Visible="false">
                                <tr>
                                    <td style="text-align: right">
                                        抢购价：
                                    </td>
                                    <td align="left">
                                        <ShopNum1:TextBox ID="TextBoxPanicPrice" runat="server" CssClass="allinput1" CanBeNull="必填"
                                                          HintInfo="请填写该商品的抢购价,该项必填" HintTitle="请填写该商品的抢购价,该项必填" RequiredFieldType="金额">
                                        </ShopNum1:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        抢购开始时间：
                                    </td>
                                    <td align="left">
                                        <ShopNum1:TextBox ID="TextBoxPanicBuyStartTime" CanBeNull="必填" RequiredFieldType="日期"
                                                          runat="server" CssClass="allinput1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        抢购结束时间：
                                    </td>
                                    <td align="left">
                                        <ShopNum1:TextBox ID="TextBoxPanicBuyEndTime" CanBeNull="必填" RequiredFieldType="日期"
                                                          runat="server" CssClass="allinput1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        抢购商品数量：
                                    </td>
                                    <td align="left">
                                        <ShopNum1:TextBox ID="TextBoxPanicBuyCount" runat="server" CssClass="allinput1" CanBeNull="必填"
                                                          HintInfo="请填写该商品的抢购数量,该项必填" HintTitle="请填写该商品的抢购数量,该项必填" RequiredFieldType="整数验证"
                                                          MaxLength="9">
                                        </ShopNum1:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <asp:Panel ID="PanelIsSpellBuy" runat="server" Visible="false">
                                <tr>
                                    <td style="text-align: right">
                                        团购价：
                                    </td>
                                    <td align="left">
                                        <ShopNum1:TextBox ID="TextBoxSpellPrice" runat="server" CssClass="allinput1" CanBeNull="必填"
                                                          HintInfo="请填写该商品的团购价格,该项必填" HintTitle="请填写该商品的团购价格,该项必填" RequiredFieldType="金额"
                                                          MaxLength="9">
                                        </ShopNum1:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        团购开始时间：
                                    </td>
                                    <td align="left">
                                        <ShopNum1:TextBox ID="TextBoxSpellBuyStartTime" CanBeNull="必填" RequiredFieldType="日期"
                                                          runat="server" CssClass="allinput1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        团购结束时间：
                                    </td>
                                    <td align="left">
                                        <ShopNum1:TextBox ID="TextBoxSpellBuyEndTime" CanBeNull="必填" RequiredFieldType="日期"
                                                          runat="server" CssClass="allinput1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        团购商品数量：
                                    </td>
                                    <td align="left">
                                        <ShopNum1:TextBox ID="TextBoxSpellBuyCount" runat="server" CssClass="allinput1" CanBeNull="必填"
                                                          HintInfo="请填写该商品的团购数量,该项必填" HintTitle="请填写该商品的团购数量,该项必填" RequiredFieldType="整数验证"
                                                          MaxLength="9">
                                        </ShopNum1:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        最少参加人数：
                                    </td>
                                    <td align="left">
                                        <ShopNum1:TextBox ID="TextBoxSpellMemberCount" runat="server" CssClass="allinput1"
                                                          CanBeNull="必填" HintInfo="请填写该商品的团购人数不能少于多少,该项必填" RequiredFieldType="整数验证" HintTitle="请填写该商品的团购人数数不能少于多少,该项必填"
                                                          MaxLength="9">
                                        </ShopNum1:TextBox>
                                    </td>
                                </tr>
                            </asp:Panel>
                            <tr>
                                <td align="right">
                                </td>
                                <td align="left">
                                    <asp:Button ID="ButtonAdd" runat="server" Text="上架商品" CssClass="bt2 bt3" OnClientClick=" return checkAllSubmit() " />
                                    <asp:Button ID="ButtonCollect" runat="server" Text="放入仓库" CssClass="bt2" OnClientClick=" return checkAllSubmit() " />
                                    <input id="ResetGoBack" runat="server" type="button" onclick="javascript:window,location.href='Product_List.aspx'"
                                           value="返回列表" class="bt2" />
                                </td>
                            </tr>
                        </table>
                        <asp:HiddenField ID="hiddenGuid" runat="server" />
                    </div>
                    <div class="content" id="prodSaleProDiv" style="display: none;">
                        <asp:UpdatePanel ID="UpdatePanelSpecification" runat="server" UpdateMode="Conditional"
                                         ChildrenAsTriggers="false">
                            <ContentTemplate>
                                <asp:Repeater ID="RepeaterSpecification" runat="server" EnableViewState="true">
                                    <HeaderTemplate>
                                        <table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="LabelName" runat="server" Text=' <%# ((DataRowView) Container.DataItem).Row["SpecificationName"] %>'></asp:Label>：
                                            </td>
                                            <td>
                                                <asp:CheckBoxList ID="CheckBoxListValue" runat="server" AutoPostBack="true">
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: right">
                                            </td>
                                            <td>
                                                <asp:PlaceHolder ID="PlaceHolderSkuImg" runat="server" EnableViewState="true">
                                                    <asp:Table ID="TableSkuImg" runat="server" Width="100%" border="0" CellSpacing="0"
                                                               CellPadding="0">
                                                    </asp:Table>
                                                </asp:PlaceHolder>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                                <asp:PlaceHolder ID="PlaceHolderSpecification" runat="server" EnableViewState="true">
                                    <div class="spweb_line">
                                        <asp:Table ID="tableSku" runat="server" EnableViewState="true" border="0" CellSpacing="0"
                                                   CellPadding="0">
                                        </asp:Table>
                                    </div>
                                </asp:PlaceHolder>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="RepeaterSpecification" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div class="content" id="ProdProcuctProcDiv" style="display: none;">
                        <asp:UpdatePanel ID="UpdatePanelProcuctProc" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Repeater ID="RepeaterPropData" runat="server" EnableViewState="true">
                                    <HeaderTemplate>
                                        <table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr>
                                            <td style="text-align: right">
                                                <asp:Label ID="LabelName" runat="server" Text='<%# ((DataRowView) Container.DataItem).Row["PropName"] %>'></asp:Label>：
                                            </td>
                                            <td>
                                                <asp:HiddenField ID="HiddenFieldID" Value='<%# ((DataRowView) Container.DataItem).Row["ID"] %>'
                                                                 runat="server" />
                                                <asp:HiddenField ID="HiddenFieldShowType" Value='<%# ((DataRowView) Container.DataItem).Row["ShowType"] %>'
                                                                 runat="server" />
                                                <asp:RadioButtonList ID="RadioButtonListPropValue" RepeatDirection="Horizontal" Visible="false"
                                                                     runat="server">
                                                </asp:RadioButtonList>
                                                <asp:DropDownList ID="DropDownListPropValue" Visible="false" runat="server">
                                                </asp:DropDownList>
                                                <asp:CheckBoxList ID="CheckBoxListPropValue" RepeatDirection="Horizontal" Visible="false"
                                                                  runat="server">
                                                </asp:CheckBoxList>
                                                <asp:TextBox ID="TextBoxPropValue" Height="80px" Width="250px" Visible="false" TextMode="MultiLine"
                                                             runat="server"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                    </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </form>
    </body>
</html>