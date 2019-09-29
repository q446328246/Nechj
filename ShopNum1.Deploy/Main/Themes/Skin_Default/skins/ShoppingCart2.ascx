<%@ Control Language="C#" EnableViewState="true" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<script language="javascript" type="text/javascript">
    //<!--
    function reloadcode() {
        var verify = document.getElementById('safecode');
        verify.setAttribute('src', '/imagecode.aspx?' + Math.random());
    }
    //-->
</script>
<script language="javascript" type="text/javascript">
    function ChangeTextStyle(textobj, status) {
        if (status == "1") {
            textobj.style.color = "#808080";
            textobj.style.border = "#8ab6dd 1px solid";
            textobj.style.height = "20px";
            textobj.style.width = "400px";
            textobj.style.fontSize = "12px";
        }
        else {
            textobj.style.color = "#000";
            textobj.style.border = "#ffad33 1px solid";
            textobj.style.height = "45px";
            textobj.style.width = "400px";
            textobj.style.fontSize = "12px";
        }
    }

    function MessageboxChange(tobj) {
        tobj.parentNode.getElementsByTagName("input")[0].value = tobj.value;
    }

    function GetRadioInvoice(obj) {
        var radios = obj.getElementsByTagName("input");
        if (radios[0].checked) {
            obj.parentNode.getElementsByTagName("div")[0].style.display = "block";
        }
        else {
            obj.parentNode.getElementsByTagName("div")[0].style.display = "none";
            obj.parentNode.getElementsByTagName("div")[0].getElementsByTagName("textarea")[0].value = "";
            obj.parentNode.getElementsByTagName("div")[0].getElementsByTagName("textarea")[1].value = "";
        }
    }
</script>
<!-- 商品列表 -->
<!-- 隔开 -->
<div class="cle1">
</div>
<div class="dfcartcon">
    <div class="ProductCart" style="width: 990px;">
        <div class="Panel Pannel">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr class="bfshopingcar01">
                    <th style="width: 20%">
                        <div align="center">
                            商品图片</div>
                    </th>
                    <th style="width: 16%">
                        <div align="center">
                            商品名称</div>
                    </th>
                    <th style="width: 10%">
                        <div align="center">
                            市场价（元）</div>
                    </th>
                    <th style="width: 10%">
                        <div align="center">
                            本店价（元）</div>
                    </th>
                    <th style="width: 10%">
                        <div align="center">
                            购买价</div>
                    </th>
                    <th style="width: 10%">
                        <div align="center">
                            <div align="center">
                                数量</div>
                        </div>
                    </th>
                    <th style="width: 10%">
                        <div align="center">
                            小计（元）</div>
                    </th>
                    <th style="width: 14%">
                        <div align="center">
                            邮费<img src="Themes/Skin_Default/Images/ico001.gif" width="13" height="16" /></div>
                    </th>
                </tr>
                <asp:Repeater ID="RepeaterShopCart2" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td colspan="8">
                                卖家:<asp:Label ID="LabelShopName" runat="server" Text='<%#((DataRowView)Container.DataItem).Row["ShopID"] %>'></asp:Label>
                                店铺:<asp:Label ID="LabelSellName" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["SellName"] %>'></asp:Label>
                                
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7" bgcolor="#F1F8FF">
                            </td>
                            <td align="center" valign="middle" bgcolor="#F1F8FF" id="FreightTd" runat="server"
                                style="border-left: 1px solid #ccc">
                                <div style="margin-top: 40px; position: relative; top: 0; left: 0;">
                                    <asp:UpdatePanel ID="UpdatePanelDropDownListPost" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownListPost" runat="server" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:Label ID="LabelShopAllPrice" runat="server" Visible="false"></asp:Label>
                                </div>
                            </td>
                        </tr>
                        <asp:Repeater ID="RepeaterShopProduct" runat="server">
                            <ItemTemplate>
                                <tr class="bfshopingcar01">
                                    <td>
                                        <asp:HiddenField ID="HiddenFieldGuid" Value='<%# ((DataRowView)Container.DataItem).Row["Guid"]%>'
                                            runat="server" />
                                        <asp:HiddenField ID="HiddenFieldMinusFee" Value='<%# ((DataRowView)Container.DataItem).Row["MinusFee"]%>'
                                            runat="server" />
                                        <asp:HiddenField ID="HiddenFieldFeeType" Value='<%# ((DataRowView)Container.DataItem).Row["FeeType"]%>'
                                            runat="server" />
                                        <asp:HiddenField ID="HiddenFieldProductGuid" Value='<%# ((DataRowView)Container.DataItem).Row["ProductGuid"]%>'
                                            runat="server" />
                                        <!--规格键-->
                                        <asp:HiddenField ID="HiddenFieldSName" Value='<%# ((DataRowView)Container.DataItem).Row["SpecificationName"]%>'
                                            runat="server" />
                                        <!--规格值-->
                                        <asp:HiddenField ID="HiddenFieldSValue" Value='<%# ((DataRowView)Container.DataItem).Row["SpecificationValue"]%>'
                                            runat="server" />
                                        <div align="center">
                                            <a href="<%#ShopUrlOperate.shopDetailHref(((DataRowView)Container.DataItem).Row["Guid"].ToString(),((DataRowView)Container.DataItem).Row["MemLoginID"].ToString(),"ProductDetail")%>">
                                                <asp:Image ID="ImageProductPic" runat="server" onerror="javascript:this.src='../../ImgUpload/noImage.gif'"
                                                    Width="49" Height="49" ImageUrl='<%# ((DataRowView)Container.DataItem).Row["OriginalImge"] %>' />
                                            </a>
                                        </div>
                                    </td>
                                    <td>
                                        <%# ((DataRowView)Container.DataItem).Row["Name"]%><br />
                                        <%# ((DataRowView)Container.DataItem).Row["Attributes"]%><br />
                                        保障:<asp:Label ID="LabelProductService" runat="server"></asp:Label>
                                    </td>
                                    <td align="center" valign="middle">
                                        <%# Globals.MoneySymbol%>
                                        <asp:Label ID="labelProductMarketPrice" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["MarketPrice"]%>' />
                                    </td>
                                    <td align="center" valign="middle">
                                        <%# Globals.MoneySymbol%><%# ((DataRowView)Container.DataItem).Row["ShopPrice"]%>
                                    </td>
                                    <td align="center" valign="middle">
                                        <%# Globals.MoneySymbol%>
                                        <asp:Label ID="labelBuyPrice" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["BuyPrice"]%>' />
                                    </td>
                                    <td align="center" valign="middle">
                                        <asp:Label ID="labelBuyNumber" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["BuyNumber"]%>' />
                                    </td>
                                    <td align="center" valign="middle" class="yellow">
                                        <%# Globals.MoneySymbol%>
                                        <asp:Label ID="labelAll" runat="server" />
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                        <tr>
                            <td colspan="8" bgcolor="#F1F8FF" valign="top" style="height: auto; text-align: left;">
                                是否要发票：
                                <asp:RadioButtonList ID="RadioButtonListInvoice" runat="server" RepeatLayout="Flow"
                                    RepeatDirection="Horizontal" AutoPostBack="false" onclick="GetRadioInvoice(this)">
                                    <asp:ListItem Value="0">是</asp:ListItem>
                                    <asp:ListItem Value="1" Selected="True">否</asp:ListItem>
                                </asp:RadioButtonList>
                                <span style="color: #FF3B0A; font-size: 14px;">(如果选是可能要增加税票的费用，请先和掌柜协商)</span>
                                <asp:Panel ID="PanelInvoice" runat="server" Visible="true" Style="display: none;">
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td style="width: 80px; border: none;">
                                                <div align="left">
                                                    发票抬头：</div>
                                            </td>
                                            <td style="text-align: left; border: none;">
                                                <ShopNum1:TextBox ID="TextBoxInvoicespayable" TextMode="MultiLine" Height="25px"
                                                    Width="285px" runat="server" MaxLength="50" />
                                            </td>
                                        </tr>
                                        <tr style="">
                                            <td style="width: 80px; border: none; padding-bottom: 4px;">
                                                <div align="left">
                                                    发票内容：</div>
                                            </td>
                                            <td style="text-align: left; border: none; padding-bottom: 4px;">
                                                <ShopNum1:TextBox ID="TextBoxInvoice" TextMode="MultiLine" Height="30px" Width="340px"
                                                    runat="server" MaxLength="250" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
            <div class="sgest" style="height: auto; vertical-align: middle; padding: 6px; line-height: 20px;">
                <span>给卖家留言：</span>
                <textarea title="选填，可以告诉卖家您对商品的特殊要求，如：颜色、尺码等" onfocus="if(this.value=='选填，可以告诉卖家您对商品的特殊要求，如：颜色、尺码等'){ this.value=''; ChangeTextStyle(this,2);}"
                    onblur="if(this.value=='') {this.value='选填，可以告诉卖家您对商品的特殊要求，如：颜色、尺码等';ChangeTextStyle(this,1);}"
                    onmouseover="this.style.border='#ffad33 1px solid'" onchange="if(this.value!='选填，可以告诉卖家您对商品的特殊要求，如：颜色、尺码等'){MessageboxChange(this)}"
                    onmouseout="if(this.value!=''){this.style.border='#8ab6dd 1px solid'}" style="color: #808080;
                    border: #8ab6dd 1px solid; font-size: 12px; height: 20px; width: 400px;">选填，可以告诉卖家您对商品的特殊要求，如：颜色、尺码等</textarea>
                <asp:TextBox ID="TextBoxMessage" runat="server" Style="display: none;"></asp:TextBox>
            </div>
            <div class="sgest" style="border-top: 1px solid #ccc;">
                <span class="fr" style="height: 40px; padding: 0 16px">购物金额小计为：<font class="StorePrice"><%# Globals.MoneySymbol%><asp:Label
                    ID="labelAllPrice" runat="server" Visible="false" />
                    <asp:Label ID="LabelOnlyProductPrice" runat="server" Text=""></asp:Label>
                    <asp:Label ID="LabelBuyShopPrice" Visible="false" runat="server" /></font> </span>
                <span class="fr" style="height: 40px; padding: 0 16px">节省了：<font class="StorePrice"><%# Globals.MoneySymbol%><asp:Label
                    ID="labelLower" runat="server" /></font></span> <span class="fr" style="height: 40px;
                        padding: 0 16px">比市场价：<font class="Price"><%# Globals.MoneySymbol%><asp:Label ID="labelMaretPrice"
                            runat="server" /></font></span>
            </div>
        </div>
    </div>
</div>
<div class="dfcartcon">
    <div class="ProductCart PrtCart" style="width: 990px;">
        <div class="Panel Pannel">
            <div class="Paneltop" style="border-top: none;">
                <div class="orderinfo">
                    <div class="tile">
                        确认收货地址</div>
                    <div class="ordercont" style="height: auto;">
                        <asp:UpdatePanel ID="UpdatePanelRadioButtonAddress" runat="server">
                            <ContentTemplate>
                                <div class="taddress">
                                    <asp:RadioButtonList ID="RadioButtonListAddress" AutoPostBack="true" runat="server">
                                    </asp:RadioButtonList>
                                </div>
                                <!--会员选择手动输入地址-->
                                <asp:Panel ID="PanelAddress" runat="server" Visible="false">
                                    <div class="terest fl">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <div align="right">
                                                        收货人姓名：</div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxName" runat="server" CssClass="select1"></asp:TextBox>
                                                    <span style="color: Red">*</span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorName" runat="server" ControlToValidate="TextBoxName"
                                                        Display="Dynamic" ErrorMessage="收货人不能为空！"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <div align="right">
                                                        电子邮件（Email）：</div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxEmail" runat="server" CssClass="select1"></asp:TextBox>
                                                    <span style="color: Red">*</span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorEmail" runat="server" ControlToValidate="TextBoxEmail"
                                                        Display="Dynamic" ErrorMessage="电子邮件不能为空！"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEmail" runat="server"
                                                        ControlToValidate="TextBoxEmail" Display="Dynamic" ErrorMessage="电子邮件不正确！" ValidationExpression="^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <!-- 配送方式 -->
                                                    <asp:HiddenField ID="HiddenFieldSelectDispatch" Value="0" runat="server" />
                                                    <div align="right">
                                                        选择地区：</div>
                                                </td>
                                                <td colspan="3">
                                                    <asp:DropDownList ID="DropDownListDispatchRegionCode1" runat="server" AutoPostBack="true"
                                                        Style="width: 100px;">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="DropDownListDispatchRegionCode2" runat="server" AutoPostBack="true"
                                                        Style="margin-left: 25px; width: 100px;">
                                                    </asp:DropDownList>
                                                    <asp:DropDownList ID="DropDownListDispatchRegionCode3" runat="server" AutoPostBack="true"
                                                        Style="margin-left: 25px; width: 100px;">
                                                    </asp:DropDownList>
                                                    <span style="color: Red">*</span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div align="right">
                                                        详细收货地址：</div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxAddress" runat="server" CssClass="select1"></asp:TextBox>
                                                    <span style="color: Red">*</span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorAddress" runat="server" ControlToValidate="TextBoxAddress"
                                                        Display="Dynamic" ErrorMessage=" 详细收货地址不能为空！"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <div align="right">
                                                        邮政编码：</div>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxPostalcode" runat="server" CssClass="select1"></asp:TextBox>
                                                    <span style="color: Red">*</span>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorPostalcode" runat="server"
                                                        ControlToValidate="TextBoxPostalcode" Display="Dynamic" ErrorMessage=" 邮政编码不能为空！"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionTextBoxPostalcode" runat="server"
                                                        ControlToValidate="TextBoxPostalcode" Display="Dynamic" ErrorMessage="邮政编码格式不对！"
                                                        ValidationExpression="^[a-zA-Z0-9 ]{3,12}$"></asp:RegularExpressionValidator>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <div align="right">
                                                        电话号码：</div>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBoxTel1" Width="60px" runat="server" CssClass="select1"></asp:TextBox>-<asp:TextBox
                                                        ID="TextBoxTel2" Width="100px" runat="server" CssClass="select1"></asp:TextBox>-<asp:TextBox
                                                            ID="TextBoxTel3" Width="60px" runat="server" CssClass="select1"></asp:TextBox><span
                                                                style="color: #999999">区号-电话号码-分机</span>
                                                </td>
                                                <td>
                                                    <div align="right">
                                                        手机号码：</div>
                                                </td>
                                                <td align="left">
                                                    <asp:TextBox ID="TextBoxMobile" runat="server" CssClass="select1"></asp:TextBox>
                                                    <span style="color: Red">*</span>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxMobile"
                                                        Display="Dynamic" ErrorMessage="请填写正确的手机号" ValidationExpression="^(1[3|5|7|8][0-9])\d{8}$"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMobile" runat="server"
                                                        ControlToValidate="TextBoxMobile" Display="Dynamic" ErrorMessage=" 手机号码不能为空！"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:HiddenField ID="HiddenFieldAddressCode" Value="-1" runat="server" />
                                    </div>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
            <div class="Panel Pannel" style="border: none;">
                <div class="Paneltop">
                    <!-- 支付方式 -->
                    <div class="zffs orderinfo">
                        <div class="all_top">
                            <div class="latest_shop1 fl" style="border: none;">
                                选择支付方式</div>
                        </div>
                        <div class="zffs_table">
                            <asp:UpdatePanel ID="UpdatePanelPayment" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td>
                                            </td>
                                            <td style="width: 15%">
                                                名称
                                            </td>
                                            <td>
                                                描述
                                            </td>
                                            <td style="width: 50px">
                                                所需费用
                                            </td>
                                            <td style="display: none">
                                            </td>
                                        </tr>
                                        <asp:Repeater ID="RepeaterShoppingCartPayment" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <ShopNum1:groupradiobutton id="RadioButtonPayment" runat="server" groupname="RadioButtonPayment"
                                                            autopostback="true">
                                                        </ShopNum1:groupradiobutton>
                                                        <!--支付方式的Guid -->
                                                        <asp:HiddenField ID="HiddenFieldGuid" Value='<%# ((DataRowView)Container.DataItem).Row["Guid"]%>'
                                                            runat="server" />
                                                        <span runat="server" visible="false" id="guid">
                                                            <%# DataBinder.Eval(Container.DataItem, "Guid")%></span>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="LabelName" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Name"]%>' />
                                                    </td>
                                                    <td>
                                                        <%#  ((DataRowView)Container.DataItem).Row["Memo"]%>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="LabelCharge" runat="server" Text='<%# ((DataRowView)Container.DataItem).Row["Charge"]%>' />
                                                        <asp:Literal ID="LiteralIsPersent" Text="%" Visible="false" runat="server"></asp:Literal>
                                                    </td>
                                                    <td style="display: none">
                                                        <asp:HiddenField ID="HiddenFieldIsPersent" runat="server" Value='<%# ((DataRowView)Container.DataItem).Row["IsPercent"]%>' />
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                      
                    <!-- 隔开 -->
                    <div class="cle" style="width: 700px; overflow: hidden; font-size: 18px;">
                    </div>
                    <div class="direct_info_top">
                        确认订单价格</div>
                    <!-- 隔开 -->
                    <div class="cle" style="width: 700px; height: 18px; line-height: 18px; overflow: hidden;
                        font-size: 18px;">
                    </div>
                    <div class="dd_confire">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr id="Verifycode" runat="server">
                                <td>
                                    <div align="right" style="width: 60px;">
                                        验证码：</div>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCode" runat="server" Width="150px" CssClass="allinput1" Height="12px"
                                        class="input_text2" onBlur="this.className='input_text2'" onFocus="this.className='input_text'"></asp:TextBox>
                                    <span style="color: #999999;">请输入图中的验证码 </span><a style="cursor: pointer" onclick="reloadcode()">
                                        看不清楚?点一下 </a>
                                    <img src="/imagecode.aspx?javascript:Math.random()" id="safecode" border="0" onclick="reloadcode()"
                                        alt="看不清?点一下" style="cursor: hand;" />
                                </td>
                            </tr>
                            <tr>
                                <td valign="top">
                                    <div align="right" style="width: 80px;">
                                        需支付总价：</div>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="UpdatePanelAllPrice" UpdateMode="Always" runat="server">
                                        <ContentTemplate>
                                            <div class="fl">
                                                <span style="font-weight: bold; color: #FF5500; font-size: 14px;">
                                                    <asp:Label ID="LabelAllCartPrice" runat="server"></asp:Label></span> <span style="color: #999999;">
                                                        <asp:Label ID="LabelPriceMeto" runat="server"></asp:Label></span>
                                            </div>
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="cle" style="width: 700px; height: 5px; line-height: 5px; overflow: hidden;
                                        font-size: 5px;">
                                    </div>
                                    <asp:UpdatePanel ID="UpdatePanelImageButton" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="ImageButtonCreate" runat="server" ImageUrl="../Images/shoppingcart2_btn02.png" /><br />
                                            <span style="color: #999999;">如果运费或商品价格有变动，您可以在提交订单后要求卖家修改。<br />
                                                请提交订单后及时付款，以免被其它买家购买导致库存不足。</span>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
<asp:HiddenField ID="HiddenFieldPaymentPriceValue" runat="server" />
<asp:HiddenField ID="HiddenFieldMemLoginID" Value="0" runat="server" />
<!--存配送方式Guid -->
<asp:HiddenField ID="HiddenFieldDispatchModeGuid" Value="0" runat="server" />
<!--存配送方式名称 -->
<asp:HiddenField ID="HiddenFieldDispatchModeName" Value="" runat="server" />
<!--支付方式的Guid -->
<asp:HiddenField ID="HiddenFieldPaymentGuid" Value="0" runat="server" />
<!--支付方式的名称-->
<asp:HiddenField ID="HiddenFieldPaymentName" Value="" runat="server" />
<!--发票类型-->
<asp:HiddenField ID="HiddenFieldInvoiceType" Value="0" runat="server" />
