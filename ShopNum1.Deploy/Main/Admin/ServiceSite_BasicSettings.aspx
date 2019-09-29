<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ServiceSite_BasicSettings.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ServiceSite_BasicSettings" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>基本设置</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script src="js/CommonJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var lock = 0;
        //选择单图
        function openSingleChild() {
            if (lock == 0) {
                lock = 1
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) { k = window.returnValue; }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("TextBoxOriginalImge").value = imgvalue[0];
                    document.getElementById("ImageOriginalImge").src = imgvalue[1];
                }
                lock = 0;
            }
        }

        function openSingleChild1() {
            if (lock == 0) {
                lock = 1
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) { k = window.returnValue; }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("TextBoxShopOriginalImge").value = imgvalue[0];
                    document.getElementById("ImageShopOriginalImge").src = imgvalue[1];
                }
                lock = 0;
            }
        }

        function openSingleChild2() {
            if (lock == 0) {
                lock = 1
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k == undefined) { k = window.returnValue; }
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    document.getElementById("TextBoxMemberOriginalImge").value = imgvalue[0];
                    document.getElementById("ImageMemberOriginalImge").src = imgvalue[1];
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
                    基本设置</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table border="0" cellpadding="0" cellspacing="1">
                    <tr>
                        <th align="right" width="180px">
                            <asp:Label ID="LabelAddCouponIsAudit" runat="server" Text="添加优惠券是否默认审核："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListAddCouponIsAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAddProductIsAudit" runat="server" Text="添加普通商品是否默认审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAddProductIsAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAddPanicBuyProductIsAudit" runat="server" Text="添加抢购商品是否默认审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAddPanicBuyProductIsAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelAddSpellBuyProductIsAudit" runat="server" Text="添加团购商品是否默认审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAddSpellBuyProductIsAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelProductCommentISAudit" runat="server" Text="商品评论是否需要审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListProductCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelCategoryInfoCommentISAudit" runat="server" Text="分类信息评论是否需要审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryInfoCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSupplyDemandCommentISAudit" runat="server" Text="供求信息评论是否需要审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSupplyDemandCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelArticleCommentISAudit" runat="server" Text="平台资讯评论是否需要审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListArticleCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShopArticleCommentISAudit" runat="server" Text="店铺资讯评论是否需要审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopArticleCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMessageCommentISAudit" runat="server" Text="平台留言是否需要审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListMessageCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShopMessageCommentISAudit" runat="server" Text="店铺留言是否需要审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopMessageCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelVideoCommentISAudit" runat="server" Text="店铺视频评论是否需要审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListVideoCommentISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelCategoryInfoISAudit" runat="server" Text="会员发布分类是否需要审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryInfoISAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSupplyDemandIsAudit" runat="server" Text="会员发布供求是否需要审核："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSupplyDemandIsAudit" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要审核</asp:ListItem>
                                <asp:ListItem Value="1">需要审核</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="180px">
                            <asp:Label ID="Label7" runat="server" Text="金币（BV）支付是否需要短信确认码："></asp:Label>
                        </th>
                        <td valign="middle">
                            <asp:DropDownList ID="DropDownListMobileCheck" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要验证</asp:ListItem>
                                <asp:ListItem Value="1">需要验证</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelProductCommentVerifyCode" runat="server" Text="商品评论是否需要验证码："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListProductCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--   <asp:ListItem Value="0">不需要验证码</asp:ListItem>--%>
                                <asp:ListItem Value="1">需要验证码</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <%-- <tr>
                        <th align="right">
                            <asp:Label ID="LabelCategoryInfoCommentVerifyCode" runat="server" Text="分类信息评论是否需要验证码："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryInfoCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不需要验证码</asp:ListItem>
                                <asp:ListItem Value="1">需要验证码</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label8" runat="server" Text="是否开启关键词过滤："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListKewWordCheck" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不开启</asp:ListItem>
                                <asp:ListItem Value="1">开启</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelSupplyDemandCommentVerifyCode" runat="server" Text="供求信息评论是否需要验证码："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSupplyDemandCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--  <asp:ListItem Value="0">不需要验证码</asp:ListItem>--%>
                                <asp:ListItem Value="1">需要验证码</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelProductBuyVerifyCode" runat="server" Text="购买商品是否需要验证码："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListProductBuyVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--<asp:ListItem Value="0">不需要验证码</asp:ListItem>--%>
                                <asp:ListItem Value="1">需要验证码</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelAriticleCommentVerifyCode" runat="server" Text="平台资讯评论是否需要验证码："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAriticleCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%-- <asp:ListItem Value="0">不需要验证码</asp:ListItem>--%>
                                <asp:ListItem Value="1">需要验证码</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelShopAriticleCommentVerifyCode" runat="server" Text="店铺资讯评论是否需要验证码："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopAriticleCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--<asp:ListItem Value="0">不需要验证码</asp:ListItem>--%>
                                <asp:ListItem Value="1">需要验证码</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelVideoCommentVerifyCode" runat="server" Text="店铺视频评论是否需要验证码："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListVideoCommentVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--<asp:ListItem Value="0">不需要验证码</asp:ListItem>--%>
                                <asp:ListItem Value="1">需要验证码</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMessageVerifyCode" runat="server" Text="平台留言是否需要验证码："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListMessageVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--  <asp:ListItem Value="0">不需要验证码</asp:ListItem>--%>
                                <asp:ListItem Value="1">需要验证码</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelShopMessageVerifyCode" runat="server" Text="店铺留言是否需要验证码："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopMessageVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%-- <asp:ListItem Value="0">不需要验证码</asp:ListItem>--%>
                                <asp:ListItem Value="1">需要验证码</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelRegVerifyCode" runat="server" Text="会员注册是否需要验证码："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListRegVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%-- <asp:ListItem Value="0">不需要验证码</asp:ListItem>--%>
                                <asp:ListItem Value="1">需要验证码</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMemLoginVerifyCode" runat="server" Text="会员登录是否需要验证码："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListMemLoginVerifyCode" runat="server" CssClass="tselect"
                                Width="301px">
                                <%--   <asp:ListItem Value="0">不需要验证码</asp:ListItem>--%>
                                <asp:ListItem Value="1">需要验证码</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelArticleCommentCondition" runat="server" Text="平台资讯评论的条件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListArticleCommentCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">所有用户</asp:ListItem>
                                <asp:ListItem Value="1">仅登录用户</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShopArticleCommentCondition" runat="server" Text="店铺资讯评论的条件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopArticleCommentCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">所有用户</asp:ListItem>
                                <asp:ListItem Value="1">仅登录用户</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMessageCondition" runat="server" Text="平台发表留言的条件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListMessageCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">所有用户</asp:ListItem>
                                <asp:ListItem Value="1">仅登录用户</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelShopMessageCondition" runat="server" Text="店铺发表留言的条件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShopMessageCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">所有用户</asp:ListItem>
                                <asp:ListItem Value="1">仅登录用户</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelSupplyDemandCommentCondition" runat="server" Text="供求评论的条件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSupplyDemandCommentCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">所有用户</asp:ListItem>
                                <asp:ListItem Value="1">仅登录用户</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right">
                            <asp:Label ID="LabelCategoryInfoCommentCondition" runat="server" Text="分类信息评论的条件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCategoryInfoCommentCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">所有用户</asp:ListItem>
                                <asp:ListItem Value="1">仅登录用户</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label1" runat="server" Text="视频评论的条件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListVideoCommentCondition" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">所有用户</asp:ListItem>
                                <asp:ListItem Value="1">仅登录用户</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label2" runat="server" Text="签到是否送红包："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSignOrSendScore" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不送红包</asp:ListItem>
                                <asp:ListItem Value="1">赠送红包</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label5" runat="server" Text="签到赠送消费红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSignScore" runat="server" CssClass="tinput" Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label6" runat="server" Text="签到赠送等级红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSignRankScore" runat="server" CssClass="tinput" Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none;">
                        <th align="right">
                            <asp:Label ID="LabelDecreaseRepertory" runat="server" Text="减库存的时机："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListDecreaseRepertory" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">下订单时</asp:ListItem>
                                <asp:ListItem Value="1">发货时</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelPayIsEmail" runat="server" Text="付款时："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListPayIsEmail" runat="server" CssClass="tselect" Width="301px">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelShipmentIsEmail" runat="server" Text="发货时："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShipmentIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelShipmentOKIsEmail" runat="server" Text="确认收货时："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListShipmentOKIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelCancelOrderIsEmail" runat="server" Text="取消订单时："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListCancelOrderIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelOrderIsEmail" runat="server" Text="下订单时是否给客户发邮件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListOrderIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMemberRegister" runat="server" Text="注册成功后是否给客户发邮件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListMemberRegister" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="Label28" runat="server" Text="注册时是否需要给客户发送激活邮件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListRegIsActivationEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelApplyOpenShopIsEmail" runat="server" Text="申请开店后是否给客户发邮件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListApplyOpenShopIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelAuditOpenShopIsEmail" runat="server" Text="开店审核后是否给客户发邮件："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAuditOpenShopIsEmail" runat="server" CssClass="tselect"
                                Width="301px">
                                <asp:ListItem Value="0">不发送邮件</asp:ListItem>
                                <asp:ListItem Value="1">发送邮件</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRegPresentScore" runat="server" Text="会员注册赠送消费红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRegPresentScore" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px">0</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRegPresentScore" runat="server"
                                Display="Dynamic" ControlToValidate="TextBoxRegPresentScore" ErrorMessage="只能输入

数字" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxRegPresentScore" runat="server"
                                ControlToValidate="TextBoxRegPresentScore" Display="Dynamic" ErrorMessage="该值不能

为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelRegPresentRankScore" runat="server" Text="会员注册赠送等级红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRegPresentRankScore" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px">0</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRegPresentRankScore"
                                runat="server" ControlToValidate="TextBoxRegPresentRankScore" ErrorMessage="只能输入数字"
                                Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxRegPresentRankScore"
                                runat="server" ControlToValidate="TextBoxRegPresentRankScore" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyMessageRankSorce" runat="server" Text="发布平台留言赠送的等级红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyMessageRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyMessageRankSorce"
                                runat="server" ControlToValidate="TextBoxMyMessageRankSorce" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxMyMessageRankSorce"
                                runat="server" ControlToValidate="TextBoxMyMessageRankSorce" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyMessageSorce" runat="server" Text="发布平台留言赠送的消费红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyMessageSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyMessageSorce" runat="server"
                                ControlToValidate="TextBoxMyMessageSorce" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxMyMessageSorce"
                                runat="server" ControlToValidate="TextBoxMyMessageSorce" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyShopMessageRankSorce" runat="server" Text="发布店铺留言赠送的等级红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyShopMessageRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyShopMessageRankSorce"
                                runat="server" ControlToValidate="TextBoxMyShopMessageRankSorce" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxMyShopMessageRankSorce"
                                runat="server" ControlToValidate="TextBoxMyShopMessageRankSorce" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyShopMessageSorce" runat="server" Text="发布店铺留言赠送的消费红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyShopMessageSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyShopMessageSorce"
                                runat="server" ControlToValidate="TextBoxMyShopMessageSorce" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxMyShopMessageSorce"
                                runat="server" ControlToValidate="TextBoxMyShopMessageSorce" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelBuyProductRankScore" runat="server" Text="消费额和赠送等级红包比例："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBuyProductRankScore" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            % <span style="color: Red">*</span><span>(10%,表示 100元赠送10红包)</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBuyProductRankScore" runat="server"
                                ControlToValidate="TextBoxBuyProductRankScore" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorBuyProductRankScore"
                                runat="server" ControlToValidate="TextBoxBuyProductRankScore" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelBuyProductScore" runat="server" Text="消费额和赠送消费红包比例："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBuyProductScore" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            % <span style="color: Red">*</span><span>(10%,表示 100元赠送10红包)</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxBuyProductScore" runat="server"
                                ControlToValidate="TextBoxBuyProductScore" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxBuyProductScore"
                                runat="server" ControlToValidate="TextBoxBuyProductScore" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMyCommentRankSorce" runat="server" Text="商品评论赠送的等级红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyCommentRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxMyCommentRankSorce" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxMyCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxMyCommentRankSorce" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelMyCommentSorce" runat="server" Text="商品评论赠送的消费红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyCommentSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxMyCommentSorce" runat="server"
                                ControlToValidate="TextBoxMyCommentSorce" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxMyCommentSorce"
                                runat="server" ControlToValidate="TextBoxMyCommentSorce" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelSellerCommentRankSorce" runat="server" Text="卖家回评赠送会员的等级红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSellerCommentRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxSellerCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxSellerCommentRankSorce" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxSellerCommentRankSorce"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelSellerCommentSorce" runat="server" Text="卖家回评赠送会员的消费红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxSellerCommentSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxSellerCommentSorce"
                                runat="server" ControlToValidate="TextBoxSellerCommentSorce" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBoxSellerCommentSorce"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelArticleCommentRankSorce" runat="server" Text="平台资讯评论赠送的等级红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxArticleCommentRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxArticleCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxArticleCommentRankSorce" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxArticleCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxArticleCommentRankSorce" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelArticleCommentSorce" runat="server" Text="平台资讯评论赠送的消费红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxArticleCommentSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxArticleCommentSorce"
                                runat="server" ControlToValidate="TextBoxArticleCommentSorce" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxArticleCommentSorce"
                                runat="server" ControlToValidate="TextBoxArticleCommentSorce" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelShopArticleCommentRankSorce" runat="server" Text="店铺资讯评论赠送的等级红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopArticleCommentRankSorce" MaxLength="9" runat="server"
                                CssClass="tinput" Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxShopArticleCommentRankSorce"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBoxShopArticleCommentRankSorce"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelShopArticleCommentSorce" runat="server" Text="店铺资讯评论赠送的消费红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopArticleCommentSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxShopArticleCommentSorce"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBoxShopArticleCommentSorce"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMySupplyDemandCommentRankSorce" runat="server" Text="供求评论赠送的等级红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMySupplyDemandCommentRankSorce" MaxLength="9" runat="server"
                                CssClass="tinput" Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxMySupplyDemandCommentRankSorce"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBoxMySupplyDemandCommentRankSorce"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMySupplyDemandCommentSorce" runat="server" Text="供求评论赠送的消费红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMySupplyDemandCommentSorce" MaxLength="9" runat="server"
                                Width="299px" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="TextBoxMySupplyDemandCommentSorce"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBoxMySupplyDemandCommentSorce"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyCategoryInfoCommentRankSorce" runat="server" Text="分类评论赠送的等级红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyCategoryInfoCommentRankSorce" MaxLength="9" runat="server"
                                Width="299px" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="TextBoxMyCategoryInfoCommentRankSorce"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBoxMyCategoryInfoCommentRankSorce"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelMyCategoryInfoCommentSorce" runat="server" Text="分类评论赠送的消费红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMyCategoryInfoCommentSorce" MaxLength="9" runat="server"
                                Width="299px" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="TextBoxMyCategoryInfoCommentSorce"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBoxMyCategoryInfoCommentSorce"
                                ErrorMessage="只能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelVideoCommentRankSorce" runat="server" Text="视频评论赠送的等级红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxVideoCommentRankSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxVideoCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxVideoCommentRankSorce" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxVideoCommentRankSorce"
                                runat="server" ControlToValidate="TextBoxVideoCommentRankSorce" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="LabelVideoCommentSorce" runat="server" Text="视频评论赠送的消费红包："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxVideoCommentSorce" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxVideoCommentSorce" runat="server"
                                ControlToValidate="TextBoxVideoCommentSorce" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertoryTextBoxVideoCommentSorce"
                                runat="server" ControlToValidate="TextBoxVideoCommentSorce" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelGoodAppraiseReputation" runat="server" Text="会员好评店铺增加的信用："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxGoodAppraiseReputation" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorGoodAppraiseReputation" runat="server"
                                ControlToValidate="TextBoxGoodAppraiseReputation" Display="Dynamic" ErrorMessage="

该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorGoodAppraiseReputation"
                                runat="server" ControlToValidate="TextBoxGoodAppraiseReputation" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelStandardAppraiseReputation" runat="server" Text="会员中评店铺增加的信用："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxStandardAppraiseReputation" MaxLength="9" runat="server"
                                Width="299px" CssClass="tinput"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorStandardAppraiseReputation"
                                runat="server" ControlToValidate="TextBoxStandardAppraiseReputation" Display="Dynamic"
                                ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStandardAppraiseReputation"
                                runat="server" ControlToValidate="TextBoxStandardAppraiseReputation" ErrorMessage="只

能输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="LabelBadAppraiseReputation" runat="server" Text="会员差评店铺扣除的信用："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxBadAppraiseReputation" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px"></asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorBadAppraiseReputation" runat="server"
                                ControlToValidate="TextBoxBadAppraiseReputation" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorBadAppraiseReputation"
                                runat="server" ControlToValidate="TextBoxBadAppraiseReputation" ErrorMessage="只能输入数字"
                                ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>店铺商品平台提成比例开关：</span>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListAdminProductFcRate" runat="server" Width="301px"
                                CssClass="tselect">
                                <asp:ListItem Value="false">不开启</asp:ListItem>
                                <asp:ListItem Value="true">开启</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span><span>分类提成开启受本开关限制，若分类提成没有开启，默认按照店铺商品平台提成比例计算</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>店铺商品平台提成比例：</span>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdminProductFcRate" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px" Text="30">
                            </asp:TextBox>
                            % <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorAdminProductFcRate" runat="server"
                                ControlToValidate="TextBoxAdminProductFcRate" Display="Dynamic" ErrorMessage="该值不能为空">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorAdminProductFcRate"
                                runat="server" ControlToValidate="TextBoxAdminProductFcRate" Display="Dynamic"
                                ErrorMessage="格式不正确" ValidationExpression="^[0-9]{1,2}$">
                            </asp:RegularExpressionValidator>
                            <span>(百分比 比如输入20就是20%)</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <span>店铺商品共赢金平台提成比例开关：</span>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsAdminProductFcCount" runat="server" Width="301px"
                                CssClass="tselect">
                                <asp:ListItem Value="false">不开启</asp:ListItem>
                                <asp:ListItem Value="true">开启</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <span>店铺商品共赢金平台提成比例：</span>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxAdminProductFcCount" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px" Text="30">
                            </asp:TextBox>
                            % <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="TextBoxOrderCommission"
                                Display="Dynamic" ErrorMessage="该值不能为空">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server"
                                ControlToValidate="TextBoxOrderCommission" Display="Dynamic" ErrorMessage="格式不正确"
                                ValidationExpression="^[0-9]{1,2}$">
                            </asp:RegularExpressionValidator>
                            <span>(百分比 比如输入20就是20%)</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>店铺订单提成开关：</span>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsOrderCommission" runat="server" Width="301px"
                                CssClass="tselect">
                                <asp:ListItem Value="false">不开启</asp:ListItem>
                                <asp:ListItem Value="true">开启</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>店铺订单提成比例：</span>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxOrderCommission" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px" Text="30">
                            </asp:TextBox>
                            % <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="TextBoxOrderCommission"
                                Display="Dynamic" ErrorMessage="该值不能为空">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server"
                                ControlToValidate="TextBoxOrderCommission" Display="Dynamic" ErrorMessage="格式不正确"
                                ValidationExpression="^[0-9]{1,2}$">
                            </asp:RegularExpressionValidator>
                            <span>(百分比 比如输入20就是20%)</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>推荐会员提成是否开启：</span>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListIsRecommendCommision" runat="server" Width="301px"
                                CssClass="tselect">
                                <asp:ListItem Value="false">不开启</asp:ListItem>
                                <asp:ListItem Value="true">开启</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">*</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <span>推荐会员提成比例：</span>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRecommendCommision" MaxLength="9" runat="server" CssClass="tinput"
                                Width="299px" Text="30">
                            </asp:TextBox>
                            % <span style="color: Red">*</span>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="TextBoxOrderCommission"
                                Display="Dynamic" ErrorMessage="该值不能为空">
                            </asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server"
                                ControlToValidate="TextBoxRecommendCommision" Display="Dynamic" ErrorMessage="格式不正确"
                                ValidationExpression="^[0-9]{1,2}$">
                            </asp:RegularExpressionValidator>
                            <span>(百分比 比如输入20就是20%)</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="Label1SiteHtml" runat="server" Text="网站开启伪静态："></asp:Label>
                        </th>
                        <td>
                            <asp:DropDownList ID="DropDownListSiteHtml" runat="server" Width="301px" CssClass="tselect">
                                <asp:ListItem Value="false">不开启</asp:ListItem>
                                <asp:ListItem Value="true">开启</asp:ListItem>
                            </asp:DropDownList>
                            <span>请选择</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label10" runat="server" Text="店铺ID初始值："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxShopID" CssClass="tinput" runat="server" Width="299px">10000</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxShopID" runat="server"
                                ControlToValidate="TextBoxShopID" ErrorMessage="只能输入数字" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorTextBoxShopID" runat="server"
                                ControlToValidate="TextBoxShopID" Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <span>请输入店铺ID初始值(比如如果这里是10000,开店后填写域名那里默认域名就是shop10000.****.com)</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label26" runat="server" Text="默认收货天数："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDefaultReceivedDays" CssClass="tinput" runat="server" Width="299px">7</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server"
                                ControlToValidate="TextBoxDefaultReceivedDays" ErrorMessage="只能输入数字" Display="Dynamic"
                                ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxDefaultReceivedDays"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <span>请输入默认收货天数(如果买家在默认收货天数内还未收货，卖家可以在订单详细页执行确认收货操作)</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label27" runat="server" Text="默认取消订单天数："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxDefaultCancelOrderDays" CssClass="tinput" runat="server"
                                Width="299px">7</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server"
                                ControlToValidate="TextBoxDefaultCancelOrderDays" ErrorMessage="只能输入数字" Display="Dynamic"
                                ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxDefaultCancelOrderDays"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <span>请输入默认取消订单天数(付款前超过了默认天数,系统将自动取消订单。)</span>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right">
                            <asp:Label ID="Label24" runat="server" Text="退款间隔多少天后由平台介入："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxRefundIsAdmin" CssClass="tinput" runat="server" Width="299px">7</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server"
                                ControlToValidate="TextBoxRefundIsAdmin" ErrorMessage="只能输入数字" Display="Dynamic"
                                ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="TextBoxRefundIsAdmin"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <span>请输入</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label3" runat="server" Text="每次红包兑换最大商品量："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxMaxScroeProductCount" CssClass="tinput" runat="server" Width="299px">1</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxMaxScroeProductCount"
                                ErrorMessage="只能输入数字" Display="Dynamic" ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxMaxScroeProductCount"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <span>请输入红包兑换最大商品量</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Label ID="Label4" runat="server" Text="直通车每日扣除金币（BV）金额："></asp:Label>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxZtcGoodsMoney" CssClass="tinput" runat="server" Width="299px"
                                MaxLength="8">1</asp:TextBox>
                            <span style="color: Red">*</span>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server"
                                ControlToValidate="TextBoxMaxScroeProductCount" ErrorMessage="只能输入数字" Display="Dynamic"
                                ValidationExpression="^[0-9]*$"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxZtcGoodsMoney"
                                Display="Dynamic" ErrorMessage="该值不能为空"></asp:RequiredFieldValidator>
                            <span>请输入金币（BV）金额(系统每天会自动扣除直通车用户金币（BV）)</span>
                        </td>
                    </tr>
                    <tr>
                        <script type="text/javascript" language="javascript">
                            function checknum(str) {
                                var re = /^[0-9]+$/;
                                if (!re.test(str)) {
                                    alert("请输入正确的数字！");
                                    return false;
                                } else { return true; }
                            }

                            function baseCheck() {
                                var checkV = document.getElementById("txtWxPay").value;
                                if (checknum(checkV)) {
                                    return true;
                                }
                                else {
                                    return false;
                                }
                            }
                        </script>
                        <th align="right">
                            <asp:Label ID="Label9" runat="server" Text="微信默认费用："></asp:Label>
                        </th>
                        <td>
                            <input type="text" id="txtWxPay" runat="server" class="tinput" style="width: 299px"
                                maxlength="8" value="500" />
                            <span style="color: Red">*</span> <span>请输入微信费用金额(微信费用金额为整型)</span>
                        </td>
                    </tr>
                    <tr class="radiobtn">
                        <th align="right">
                            <asp:Label ID="Label12" runat="server" Text="默认支付类型："></asp:Label>
                        </th>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonListPayType" RepeatDirection="Horizontal" runat="server"
                                RepeatLayout="Flow">
                                <asp:ListItem Selected="True" Value="0">支付给平台</asp:ListItem>
                                <asp:ListItem Value="1">支付给店铺</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize2" runat="server" Text="ICP备案号："></asp:Localize>
                        </th>
                        <td>
                            <asp:TextBox ID="TextBoxICPNum" CssClass="tinput" Width="299px" runat="server"></asp:TextBox>
                            <span>请输入ICP备案号(工业和信息化部关于网站备案管理系统颁发的网络信息许可证号码)</span>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            <asp:Localize ID="Localize3" runat="server" Text="ICP备案文件："></asp:Localize>
                        </th>
                        <td>
                            <asp:FileUpload ID="FileUploadICP" runat="server" CssClass="tinput" Width="299px" />
                            <span>请输入ICP备案文件(备案后的资质认证文件)</span>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="tablebtn">
                <asp:Button ID="ButtonEdit" runat="server" Text="确定" CssClass="qued" OnClick="ButtonEdit_Click"
                    OnClientClick="return baseCheck()" />
                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                <asp:HiddenField ID="HiddenFieldXmlPath" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
