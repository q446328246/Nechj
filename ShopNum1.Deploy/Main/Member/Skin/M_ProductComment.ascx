<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_ProductComment.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_ProductComment" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Deploy.Main.Member.Skin" %>
<% DataTable dt = M_ProductComment.dt_order; %>
<style type="text/css">
    input, img, label
    {
        cursor: pointer;
    }
</style>
<!--内容部分Content-->
<div id="content_bg">
    <div class="con_order">
        <div class="zjh1_1">
            <%--<h1><a href="#" >评价须知</a></h1>--%>
            <div class="zjbk">
                <%if (dt != null)
                  {%>
                <%for (int i = 0; i < dt.Rows.Count; i++)
                  {
                      string strUrl = ShopUrlOperate.shopHrefcenter(dt.Rows[i]["productguid"].ToString(), dt.Rows[i]["shopid"].ToString(), dt.Rows[i]["shop_category_id"].ToString());
                %>
                <!--循环代码-->
                <dl class="zjpro">
                    <dt><a href="<%=strUrl %>" target="_blank">
                        <img src="<%=dt.Rows[i]["productimg"] %>" width="100" height="100" onerror="javascript:this,src='/ImgUpload/noImg.jpg_100x100.jpg'" /></a></dt>
                    <dd>
                        <a href="<%=strUrl %>" target="_blank" class="blue">
                            <%=dt.Rows[i]["productname"] %></a>
                        <input type="hidden" name="hidProductGuId" value='<%=dt.Rows[i]["productguid"] %>' />
                        <input type="hidden" name="hidProductName" value='<%=dt.Rows[i]["productname"] %>' />
                        <input name="hidShopId" type="hidden" value='<%=dt.Rows[i]["shopid"] %>' />
                        <input name="hidProductPrice" type="hidden" value='<%=dt.Rows[i]["ShopPrice"] %>' />
                        <input name="hidSpec" type="hidden" value='<%=dt.Rows[i]["specificationname"] %>' />
                        <input name="hidCategory" type="hidden" value='<%=dt.Rows[i]["shop_category_id"].ToString() %>' />
                    </dd>
                    <dd style="color: #bbb;">
                        <%=dt.Rows[i]["specificationname"].ToString().Replace("0","")%></dd>
                    <dd style="color: #bbb;">
                        价格：<%=dt.Rows[i]["ShopPrice"]%></dd>
                </dl>
                <div class="fabiaok1">
                    <h2 style="cursor: pointer;">
                        &nbsp;
                        <input id="ListCommentType_0" type="radio" name="ListCommentType_<%=i %>" value="5"
                            checked="checked" /><label for="ListCommentType_0">
                                <img src="images/pingjhua.jpg" width="16" height="16" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                        <input id="ListCommentType_1" type="radio" name="ListCommentType_<%=i %>" value="3" /><label
                            for="ListCommentType_1">
                            <img src="images/pingjhua02.jpg" width="16" height="16" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
                        <input id="ListCommentType_2" type="radio" name="ListCommentType_<%=i %>" value="1" /><label
                            for="ListCommentType_2">
                            <img src="images/pingjhua03.jpg" width="17" height="17" /></label>
                    </h2>
                    <div class="fbtext">
                        <textarea name="TextBoxComment" rows="2" cols="20" class="text_fb"></textarea>
                        <div style="padding-top: 2px; text-align: right; padding-right: 5px; display: none;">
                            <input name="NicName_<%=i %>" t_name="isNicName" type="radio" value="0" checked="checked" />公开评论&nbsp;
                            <span style="display: none;">
                                <input name="NicName_<%=i %>" t_name="isNicName" type="radio" value="1" />匿名评论</span>
                        </div>
                    </div>
                </div>
                <div style="clear: both;">
                </div>
                <!--循环代码-->
                <%}
                  } %>
                <div class="dianppf">
                    <div class="pingf">
                        <span href="#" class="pin_span">店铺动态评分</span></div>
                    <div class="pingtab">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    宝贝与描述相符
                                </td>
                                <td>
                                    <input type="radio" id="ListCharacter_5" name="ListCharacter" value="5" checked="checked" />
                                    <label for="ListCharacter_5">
                                        很相符</label>
                                </td>
                                <td>
                                    <input type="radio" id="ListCharacter_4" name="ListCharacter" value="4" />
                                    <label for="ListCharacter_4">
                                        比较相符</label>
                                </td>
                                <td>
                                    <input id="ListCharacter_3" type="radio" name="ListCharacter" value="3" />
                                    <label for="ListCharacter_3">
                                        相符</label>
                                </td>
                                <td>
                                    <input id="ListCharacter_2" type="radio" name="ListCharacter" value="2" />
                                    <label for="ListCharacter_2">
                                        不相符</label>
                                </td>
                                <td>
                                    <input id="ListCharacter_1" type="radio" name="ListCharacter" value="1" />
                                    <label for="ListCharacter_1">
                                        很不相符</label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    卖家的服务态度
                                </td>
                                <td>
                                    <input id="ListAttitude_5" type="radio" name="ListAttitude" value="5" checked="checked" />
                                    <label for="ListAttitude_5">
                                        很好</label>
                                </td>
                                <td>
                                    <input id="ListAttitude_4" type="radio" name="ListAttitude" value="4" />
                                    <label for="ListAttitude_4">
                                        比较好</label>
                                </td>
                                <td>
                                    <input id="ListAttitude_3" type="radio" name="ListAttitude" value="3" />
                                    <label for="ListAttitude_3">
                                        一般</label>
                                </td>
                                <td>
                                    <input id="ListAttitude_2" type="radio" name="ListAttitude" value="2" />
                                    <label for="ListAttitude_2">
                                        差</label>
                                </td>
                                <td>
                                    <input id="ListAttitude_1" type="radio" name="ListAttitude" value="1" />
                                    <label for="ListAttitude_1">
                                        很差</label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    卖家发货的速度
                                </td>
                                <td>
                                    <input id="ListSpeed_5" type="radio" name="ListSpeed" value="5" checked="checked" />
                                    <label for="ListSpeed_5">
                                        很快</label>
                                </td>
                                <td>
                                    <input id="ListSpeed_4" type="radio" name="ListSpeed" value="4" />
                                    <label for="ListSpeed_4">
                                        比较快</label>
                                </td>
                                <td>
                                    <input id="ListSpeed_3" type="radio" name="ListSpeed" value="3" />
                                    <label for="ListSpeed_3">
                                        一般</label>
                                </td>
                                <td>
                                    <input id="ListSpeed_2" type="radio" name="ListSpeed" value="2" />
                                    <label for="ListSpeed_2">
                                        慢</label>
                                </td>
                                <td>
                                    <input id="ListSpeed_1" type="radio" name="ListSpeed" value="1" />
                                    <label for="ListSpeed_1">
                                        很慢</label>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
            <div style="text-align: center;">
                <asp:Button ID="btnSave" CssClass="zhuijbtn1" OnClientClick="return subcheck()" runat="server"
                    OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</div>
<input type="hidden" id="hidCtype" runat="server" />
<input type="hidden" id="hidPGuId" runat="server" />
<input type="hidden" id="hidCommentC" runat="server" />
<input type="hidden" id="hidListCharacter" runat="server" />
<input type="hidden" id="hidListSpeed" runat="server" />
<input type="hidden" id="hidListAttitude" runat="server" />
<input type="hidden" id="hidProductName" runat="server" />
<input type="hidden" id="hidShopId" runat="server" />
<input type="hidden" id="hidProductPrice" runat="server" />
<input type="hidden" id="hidNick" runat="server" />
<input type="hidden" id="hidSpecValue" runat="server" />
<input type="hidden" id="hidCategory" runat="server" />
<script type="text/javascript" language="javascript">
    $(function () {
        $("textarea[name='TextBoxComment']").focus(function () {
            if ($(this).val() == "宝贝用的好吗?来分享一下您的使用感受吧！") {
                $(this).val("");
            }
        });
    });
    function subcheck() {
        var specV = new Array();
        var xcheck = new Array();
        $("input[name='hidSpec']").each(function (m, n) {
            specV.push($(this).val());
            $("input[name='ListCommentType_" + m + "']").each(function () {
                if ($(this).is(":checked")) {
                    xcheck.push($(this).val());
                }
            });
        });
        $("#<%=hidCtype.ClientID%>").val(xcheck.join(","));
        $("#<%=hidSpecValue.ClientID%>").val(specV.join(","));
        var nickarry = new Array();
        $("input[t_name='isNicName']").each(function () {
            if ($(this).is(":checked")) {
                nickarry.push($(this).val());
            }
        });
        $("#<%=hidNick.ClientID%>").val(nickarry.join(","));
        var xshopid = new Array();
        $("input[name='hidShopId']").each(function () { xshopid.push($(this).val()); });
        $("#<%=hidShopId.ClientID%>").val(xshopid.join(","));



        var xcategory = new Array();
        $("input[name='hidCategory']").each(function () { xcategory.push($(this).val()); });
        $("#<%=hidCategory.ClientID%>").val(xcategory.join(","));
        var xprice = new Array();
        $("input[name='hidProductPrice']").each(function () { xprice.push($(this).val()); });
        $("#<%=hidProductPrice.ClientID%>").val(xprice.join(","));
        var xpname = new Array();
        $("input[name='hidProductName']").each(function () { xpname.push($(this).val()); });
        $("#<%=hidProductName.ClientID%>").val(xpname.join(","));

        var pcontent = new Array(); var bflag = 0;
        $("textarea[name='TextBoxComment']").each(function () {
            if ($(this).val().length == 0) {
                $(this).focus(); alert("评论内容不能为空！"); bflag = 1;
            }
            if ($(this).val().length > 500) {
                $(this).focus(); alert("评论内容不能超过500字！"); bflag = 2;
            }
            pcontent.push($(this).val().replace(",", ""));
        });
        $("#<%=hidCommentC.ClientID%>").val(pcontent.join(","));
        var pguid = new Array();
        $("input[name='hidProductGuId']").each(function () {
            pguid.push($(this).val());
        });
        $("#<%=hidPGuId.ClientID%>").val(pguid.join(","));
        $("input[name='ListCharacter']").each(function () {
            if ($(this).is(":checked")) {
                $("#<%=hidListCharacter.ClientID%>").val($(this).val());
            }
        });
        $("input[name='ListSpeed']").each(function () {
            if ($(this).is(":checked")) {
                $("#<%=hidListSpeed.ClientID%>").val($(this).val());
            }
        });
        $("input[name='ListAttitude']").each(function () {
            if ($(this).is(":checked")) {
                $("#<%=hidListAttitude.ClientID%>").val($(this).val());
            }
        });
        if (bflag == "0") { return true; }
        else { return false; }
    }
</script>
