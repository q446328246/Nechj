<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ClearData.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ClearData" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <title>清除体验数据</title>
    <style type="text/css">
        <!
        -- body, td, th
        {
            font-size: 12px;
        }
        .welcome
        {
            margin:0;
        }
        .welcome .title
        {
            line-height: 30px;
            height: 30px;
            margin-left: 23px;
            background-color: #eeeeee;
            width: 80px;
            text-align: center;
            font-weight: bold;
            border: 1px solid #6699cc;
            border-bottom: none;
        }
        .welcome .describe
        {
            line-height: 30px;
            height: 30px;
        }
    
        .welcome .content .product
        {
            margin-bottom: 10px; 
        
        } 
        .welcome .content .product .product_title
        {
            background-color: #f2f9fd;
            font-weight: bold;
            padding-left: 6px;
        }
        -- >
        .orinput{border: 1px solid #DCDCDC;
    height: 22px;
    line-height: 22px;
    margin-right: 10px;
    width: 80px;}
        </style>
    <link type="text/css" rel="Stylesheet" href="css/index.css" />
    <script src="js/CommonJS.js" type="text/javascript"></script>
    <script src="../js/jquery-1.6.2.min.js" type="text/javascript"></script>
    <script>

        $(document).ready(function () {
            //var tables= $("#<%=hiddenFieldCheckedClearData.ClientID%>").val("");
            //$(":checkbox[name='ClearData']").change(function(){

            //WritehiddenFieldCheckedClearData();
            //})

            //$("#CheckboxCheckAll").change(function(){
            //var CheckboxCheckAll=$("#CheckboxCheckAll").get(0).checked; 
            //$(":checkbox[name='ClearData']").attr("checked",CheckboxCheckAll);


            $("#<%=CheckboxCheckAll.ClientID %>").change(function () {
                var checkbox = $("span[name='ClearData']").find(":checkbox");
                for (i = 0; i < checkbox.length; i++) {
                    checkbox[i].checked = true
                }

                //writehiddenfieldcheckedcleardata();

            })


            //给hiddenFieldCheckedClearData 赋值
            function WritehiddenFieldCheckedClearData() {
                var Checkedvalues = "";
                var checkbox = $(":checkbox[name='ClearData']");
                for (i = 0; i < checkbox.length; i++) {
                    if (checkbox[i].checked == true) {
                        Checkedvalues += checkbox[i].value + ";";
                    }
                }
                if (Checkedvalues.length > 0) {
                    Checkedvalues = Checkedvalues.substr(0, Checkedvalues.length - 1);

                }
                $("#<%=hiddenFieldCheckedClearData.ClientID%>").val(Checkedvalues);
            }
        })
        //判断是否已选要清除的数据
        function CheckClearData() {
            var tables = $("#<%=hiddenFieldCheckedClearData.ClientID%>").val();
            if (tables.length > 0) {
                return true;
            }
            alert("请选择要清除的数据");
            return false;
        }
    </script>
</head>
<body style="padding: 0; background-image: url(images/Bg_right.gif); background-repeat: repeat;
    font-size: 12px">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    清除体验数据</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix" style="padding-left: 20px; padding-right: 20px;">
            <p style="color: #333333; margin-top: 0px; border-bottom: 1px dashed #cccccc; width: 100%;
                padding-bottom: 10px; font-size: 13px;">
                您可以通过此功能将安装系统时所安装的体验数据全部删除,删除的数据包括商品分类,商品类型,商品数据,资讯数据等。<br />
                注意：<span style="color: #666666; font-size: 12px;">您最新添加的数据也会一起删除,请慎重使用此功能,建议先做好数据备份。</span>
            </p>
            <div class="welcome">
                <div class="content">
                    <div class="product ">
                        <div class="product_content">
                            <table width="100%" border="0" cellspacing="1" cellpadding="0" bgcolor="ffffff">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac; padding-top: 10px;">
                                                全选/取消：<asp:CheckBox ID="CheckboxCheckAll" name="CheckAll" runat="server" Visible="false" />
                                                <input id="checkboxAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox"
                                                    runat="server" />
                                                <%--   <input id="CheckboxCheckAll"   name="CheckAll" type="checkbox"  />--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                <!--;ShopNum1_SpecificationManagement;ShopNum1_SpecificationDetails-->
                                                商品数据：<asp:CheckBox ID="CheckboxProduct" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>商品数据,包括商品分类,图片,评论,订单数据,商品属性,直通车数据,规格管理,商品类型</span>
                                                <%--  <input id="CheckboxProduct"  name="ClearData" type="checkbox" value="ShopNum1_Shop_Product;ShopNum1_ProductCategory;ShopNum1_Shop_ProductCategory;ShopNum1_ProductCategoryAndProductBranDrelation;ShopNum1_ShopProductProp;ShopNum1_ShopProductRelationProp;ShopNum1_ShopProductPropValue;ShopNum1_SpecificationProudct;ShopNum1_SpecificationProductImage;ShopNum1_TbItem;ShopNum1_TbSystem;ShopNum1_OrderInfo;ShopNum1_OrderProduct;ShopNum1_OrderOperateLog" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>商品数据,包括商品分类,图片,评论,订单数据</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                品牌数据：<asp:CheckBox ID="CheckboxCategoryAndBrand" name="ClearData" runat="server" /><span
                                                    style="color: #666666;"> <span style="color: #ff0000;">* </span>商品品牌</span>
                                                <%--  <input id="CheckboxCategoryAndBrand"   name="ClearData"type="checkbox" value="ShopNum1_Brand;ShopNum1_ProductCategoryAndProductBranDrelation" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>商品品牌</span>--%>
                                            </td>
                                        </tr>
                                        <%-- <tr>
                        <td colspan="2"  style="padding-left:136px;color:#2f7ecc;">
                           订单数据：<input id="CheckboxOrder"  name="ClearData" type="checkbox" value="ShopNum1_OrderInfo;ShopNum1_OrderProduct;ShopNum1_OrderOperateLog" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>包括订单操作记录等数据</span>
                        </td>
                        </tr>--%>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                会员数据：<asp:CheckBox ID="CheckboxMem" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>会员信息,会员预览历史,签到数据信息,等级红包变更表,消费红包变更表,供求类别,供求信息,供求评论,系统后台操作日志,订单操作日志,用户浏览器记录,商品评价,但不包括会员等级</span>
                                                <%--<input id="CheckboxMem"  name="ClearData" type="checkbox" value="ShopNum1_Member;ShopNum1_MessageBoard;ShopNum1_Address;ShopNum1_AdvancePaymentFreezeLog;ShopNum1_AdvancePaymentApplyLog;ShopNum1_MemberGroup;ShopNum1_MemberAssignGroup;ShopNum1_AdvancePaymentModifyLog;ShopNum1_RankScoreModifyLog" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>会员信息,但不包括会员等级</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                店铺数据：<asp:CheckBox ID="CheckboxShop" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>店铺信息,店铺信誉,店铺保证,店铺申请担保列表,但不包括店铺等级</span>
                                                <%--<input id="CheckboxShop"  name="ClearData" type="checkbox" value="ShopNum1_ShopInfo;ShopNum1_ShopRank;ShopNum1_ShopReputation;ShopNum1_ShopCategory;ShopNum1_ShopEnsure" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>店铺信息,店铺等级,店铺分类,店铺信誉,店铺保证</span>--%>
                                            </td>
                                        </tr>
                                        <%-- <tr>
                        <td colspan="2"  style="padding-left:124px;color:#2f7ecc;">
                        清空供应商：<input id="CheckboxSupplier"  name="ClearData" type="checkbox" value="ShopNum1_SupplierFinancialManagement;ShopNum1_SupplierRepertoryRecord;ShopNum1_SupplierImagePath;ShopNum1_SupplierImage;ShopNum1_SupplierImage_Type;ShopNum1_Product;ShopNum1_SupplierProductCategory;ShopNum1_SupplierCategoryRelated;ShopNum1_SupplierImageCategory;ShopNum1_Supplier;ShopNum1_SupplierOrderProduct" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>供应商数据,包括供应商商品、商品分类、商品图片</span>
                         </td>
                        </tr>--%>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                图片数据：<asp:CheckBox ID="CheckboxImage" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>图片,图片类型,图片路径</span>
                                                <%--<input id="CheckboxImage"  name="ClearData" type="checkbox" value="ShopNum1_Image;ShopNum1_Image_Type;ShopNum1_ImageCategory" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>图片,图片类型,图片路径</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                资讯数据：<asp:CheckBox ID="CheckboxArticle" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>资讯,资讯评论,资讯相关,公告</span>
                                                <%--<input id="CheckboxArticle"  name="ClearData" type="checkbox" value="ShopNum1_Article;ShopNum1_ArticleComment;ShopNum1_RelatedArticle" /><span style=" color:#666666;"> <span style="color:#ff0000;">* </span>资讯,资讯评论,资讯相关</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                视频数据：<asp:CheckBox ID="CheckboxVideo" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>视频,视频分类,视频评论</span>
                                                <%--<input id="CheckboxVideo"  name="ClearData" type="checkbox" value="ShopNum1_Shop_Video;ShopNum1_Shop_VideoCategory;ShopNum1_Shop_VideoComment" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>视频,视频分类,视频评论</span>--%>
                                            </td>
                                        </tr>
                                        <%-- <tr>
                        <td colspan="2"  style="padding-left:136px;color:#2f7ecc;">
                            红包商城：<asp:CheckBox ID="CheckboxScore" runat="server" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>红包订单,红包商品,红包购物车,红包订单商品,红包商品分类</span>
                            <%--<input id="CheckboxScore"  name="ClearData" type="checkbox" value="ShopNum1_Shop_ScoreProduct;ShopNum1_Shop_ScoreProductCategory" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>红包订单,红包商品,红包购物车,红包订单商品,红包商品分类</span>
                         </td>
                        </tr>--%>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                站内消息：<asp:CheckBox ID="CheckboxAgentMessage" name="ClearData" runat="server" /><span
                                                    style="color: #666666;"> <span style="color: #ff0000;">* </span>后台站内消息,会员站内消息,系统发送消息</span>
                                                <%-- <input id="CheckboxAgentMessage"  name="ClearData" type="checkbox" value="ShopNum1_MessageInfo" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>后台站内消息,会员站内消息</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                附件数据：<asp:CheckBox ID="CheckboxAttachMent" name="ClearData" runat="server" /><span
                                                    style="color: #666666;"> <span style="color: #ff0000;">* </span>附件,附件分类</span>
                                                <%-- <input id="CheckboxAttachMent"  name="ClearData" type="checkbox" value="ShopNum1_AttachMent;ShopNum1_AttachMentCategory" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>附件,附件分类</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                在线调查：<asp:CheckBox ID="CheckboxSurveyOption" name="ClearData" runat="server" /><span
                                                    style="color: #666666;"> <span style="color: #ff0000;">* </span>在线调查,在线调查选项表</span>
                                                <%--  <input id="CheckboxSurveyOption"  name="ClearData" type="checkbox" value="ShopNum1_SurveyTheme;ShopNum1_SurveyOption" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>在线调查,在线调查选项表</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2f7ecc;">
                                                友情链接：<asp:CheckBox ID="CheckboxLink" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>友情链接</span>
                                                <%-- <input id="CheckboxLink"  name="ClearData" type="checkbox" value="ShopNum1_Link" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>友情链接</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                在线客服：<asp:CheckBox ID="CheckboxService" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>在线客服</span>
                                                <%-- <input id="CheckboxService"  name="ClearData" type="checkbox" value="ShopNum1_OnlineService" /><span style="color:#666666;"> <span style="color:#ff0000;">* </span>在线客服</span>--%>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                红包商品：<asp:CheckBox ID="CheckboxScore" name="ClearData" runat="server" /><span style="color: #666666;">
                                                    <span style="color: #ff0000;">* </span>红包商品,红包商品分类,红包订单,红包订单商品</span>
                                            </td>
                                        </tr>
                                        <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                            金币（BV）信息：<asp:CheckBox ID="CheckboxAdvancePayment" name="ClearData" runat="server" /><span
                                                style="color: #666666;"> <span style="color: #ff0000;">* </span>金币（BV）充值,金币（BV）冻结,金币（BV）变更,转账历史</span>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" style="padding-left: 52px; color: #2672ac;">
                                                促销活动：<asp:CheckBox ID="CheckboxLimtPackage" name="ClearData" runat="server" /><span
                                                    style="color: #666666;"> <span style="color: #ff0000;">* </span>折扣活动,限时商品,团购活动</span>
                                            </td>
                                        </tr>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </table>
                            <div style="border-top: 1px dashed #cccccc; margin-top: 21px; padding-top: 15px;
                                padding-bottom: 25px; width: 100%; background: #f1f5f8;">
                                <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="f1f5f8">
                                    <tr>
                                        <td align="right" style="color: #222222; width: 19%;">
                                            请输入管理员用户名：
                                        </td>
                                        <td align="left">
                                            <asp:TextBox ID="TextBoxLoginID" runat="server" CssClass="orinput" Style="border: 1px solid #DCDCDC;
                                                height: 22px; line-height: 22px; margin-right: 10px; width: 240px;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxLoginID"
                                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                            <font color="red">*</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="color: #222222; padding-top: 10px;">
                                            请输入管理员密码：
                                        </td>
                                        <td style="padding-top: 10px;">
                                            <asp:TextBox ID="TextBoxPwd" runat="server" TextMode="Password" CssClass="orinput"
                                                Style="border: 1px solid #DCDCDC; height: 22px; line-height: 22px; margin-right: 10px;
                                                width: 240px;"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPwd"
                                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                                            <font color="red">*</font>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td align="left">
                                            <div style="height: 22px; margin-top: 12px;">
                                                <asp:Button ID="ButtonClearExperienceData" runat="server" Text="清除体验数据" CssClass="bt3_clear"
                                                    OnClick="ButtonClearExperienceData_Click" />
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
    <asp:HiddenField ID="hiddenFieldCheckedClearData" runat="server" Value="" />
    </form>
</body>
</html>
