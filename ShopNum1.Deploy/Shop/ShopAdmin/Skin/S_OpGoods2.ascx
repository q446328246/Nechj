<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<input type="hidden" id="hidsubStock" runat="server" value="0" />
<input type="hidden" id="hidIsReal" runat="server" value="1" />
<input type="hidden" id="hidCategoryName" runat="server" />
<input type="hidden" id="hidName" runat="server" />
<input type="hidden" id="hidProductNum" runat="server" value="" />
<input type="hidden" id="hidRepertoryCount" runat="server" value="0" />
<input type="hidden" id="hidRepertoryAlertCount" runat="server" value="0" /><%--add by Victor 库存警告数量--%>
<input type="hidden" id="hidShopPrice" runat="server" value="" />
<input type="hidden" id="hidMarketPrice" runat="server" value="" />
<input type="hidden" id="hidUnitName" runat="server" />
<input type="hidden" id="hidBrand" runat="server" />
<input type="hidden" id="hidPType" runat="server" value="" />
<input type="hidden" id="hidSpec_Check" runat="server" />
<input type="hidden" id="hidBaseStock" runat="server" />
<input type="hidden" id="hidBaseProp" runat="server" />
<input type="hidden" id="hidpro_img" runat="server" />
<input type="hidden" id="hidproImage" runat="server" />
<input type="hidden" id="hidarea" runat="server" />
<input type="hidden" id="hidfee" runat="server" value="1" />
<input type="hidden" id="hidsubfee" runat="server" value="0" />
<input type="hidden" id="hidpublishGoods" runat="server" value="0" />
<input type="hidden" id="hidState" runat="server" value="0" />
<input type="hidden" id="hidProductSeries" runat="server" />
<input type="hidden" id="hidVd" runat="server" />
<input type="hidden" id="hidNewSpecs" runat="server" />
<input type="hidden" id="hidTipMsg" runat="server" />

<input type="hidden" id="hidScore_Pv_a" runat="server" />
<input type="hidden" id="hidScore_Pv_b" runat="server" />
<input type="hidden" id="hidScore_dv" runat="server" />
<input type="hidden" id="hidScore_hv" runat="server" />
<input type="hidden" id="hidScore_sv" runat="server" />

<input type="hidden" id="hidScore_max_hv" runat="server" />
<!--VIP专区可得积分--->
<input type="hidden" id="hidScore_pv_a_two" runat="server" />
<input type="hidden" id="hidShopPrice_two" runat="server" />
<input type="hidden" id="hidMarketPrice_two" runat="server" />
<!--积分专区可用积分-->
<input type="hidden" id="hidScore_cv" runat="server" />
<input type="hidden" id="hidShopPrice_free" runat="server" />
<input type="hidden" id="hidMarketPrice_free" runat="server" />

<!--区代专区首次-->

<input type="hidden" id="hidShopPrice_five" runat="server" />
<input type="hidden" id="hidMarketPrice_five" runat="server" />

<!--区代专区2次-->
<input type="hidden" id="hidShopPrice_six" runat="server" />
<input type="hidden" id="hidMarketPrice_six" runat="server" />
<!--社区店专首次-->

<input type="hidden" id="hidShopPrice_seven" runat="server" />
<input type="hidden" id="hidMarketPrice_seven" runat="server" />
<!--社区店专2次-->
<input type="hidden" id="hidShopPrice_eight" runat="server" />
<input type="hidden" id="hidMarketPrice_eight" runat="server" />

<!--CTC-->
<input type="hidden" id="hidScore_Pv_a_CTC" runat="server" />
<input type="hidden" id="hidScore_hv_CTC" runat="server" />
<input type="hidden" id="hidShopPrice_one_CTC" runat="server" />
<input type="hidden" id="hidMarketPrice_one_CTC" runat="server" />

<!--我的货物的颜色-->
<input type="hidden" id="hidColor" runat="server" />
<!--我的货物的尺寸-->
<input type="hidden" id="hidSize" runat="server" />


<!--新店铺CV交易专区-->
<input type="hidden" id="hidScore_pv_cv_DT" runat="server" />
<input type="hidden" id="hidShopPrice_DT" runat="server" />
<input type="hidden" id="hidMarketPrice_DT" runat="server" />
<!--数量限制-->
<input type="hidden" id="hiddenMaxNumber_one" runat="server" />
<!--发货数量-->
<input type="hidden" id="hiddentxtUnitNumber" runat="server" />
<input type="hidden" id="hiddenMyPrice" runat="server" />
<dl class="tibxxbg" id="v5-foot">
    <dt>商品详情：</dt>
    <dd>
        <div class="gray1" style="height: 30px;">
            详细描述产品功能属性、产品细节图片、支付物流、售后服务、公司实力等信息。</div>
        <div>
            <ul id="tabdetailhead">
                <li style="display: block; float: left; text-align: center; width: 100px;" class="tabDetatilSelect">
                    电脑端</li>
                <li style="display: block; float: left; text-align: center; width: 100px; height: 16px;">手机端</li>
            </ul>
            <div style="clear: both;">
            </div>
            <ul id="tabdetailbody">
                <li id="detail0">
                    <textarea name="textarea" id="txtDetail" runat="server" class="textwebedit" style="height: 240px;
                        width: 700px;"></textarea></li>
                <li id="detail1" style="display: none;">
                    <textarea name="textarea" onpaste="return false;" id="txtWapDetail" runat="server"
                        class="textwebeditv" style="height: 340px; width: 330px;"></textarea>
                    <a href="#v5-foot" id="showpicv" class="gofoot golist">插入图片</a>&nbsp;&nbsp;<font
                        id="wapdetailfont">字数请控制在5000个字符之内</font> </li>
            </ul>
        </div>
    </dd>
    <style type="text/css">
        .tabDetatilSelect
        {
            background: #6E8CDE;
            color: White;
        }
        
        .sp_dialog_detail
        {
            bottom: 800px;
            display: block;
            margin-left: 120px;
            overflow: hidden;
            position: absolute;
            z-index: 10002;
            z-index: 999999;
            zoom: 1;
        }
    </style>
    <div class="showPanic" style="display: none;">
        <dt>抢购须知：</dt>
        <dd>
            <div class="gray1" style="height: 20px;">
                关于抢购商品需要注意的。</div>
            <div>
                <div style="clear: both;">
                </div>
                <textarea name="textarea" id="txtPanicDetail" runat="server" class="textwebeditvp"
                    style="height: 240px; width: 700px;"></textarea>
            </div>
        </dd>
    </div>
    <script type="text/javascript" language="javascript">
        $(function () {
            $("#tabdetailhead li").click(function () {
                $(this).addClass("tabDetatilSelect").siblings().removeClass("tabDetatilSelect");
                $("#detail" + $(this).index()).show().siblings().hide();
            });
            $("#showpicv").click(function () {
                window.scrollTo(0, 2000);
                $("#sp_dialog_outDiv").removeClass("sp_dialog_out").addClass("sp_dialog_detail");
                $("#sp_dialog_outDiv").show();
                funOpen();
                $("#showiframe").attr("src", "/Shop/ShopAdmin/S_ShowShopPhoto.aspx");
            });

        });
        var wapeditor;

        function openSingleChild(Imgurl) {
            wapeditor.insertHtml("<a href=\"" + Imgurl + "\"><img src='" + Imgurl + "_160x160.jpg'></a>");
        }
    </script>
    <!--弹出层-->
    <div class="sp_dialog sp_dialog_out" style="display: none;" id="sp_dialog_outDiv">
        <div class="sp_dialog_cont" style="display: none;" id="sp_dialog_contDiv">
            <div class="sp_tan">
                <h4>
                    选择图片</h4>
                <div class="sp_close">
                    <a href="javascript:void(0)" onclick=" funClose() "></a>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="sp_tan_content">
                <iframe src="" id="showiframe" width="100%" height="470" frameborder="0" scrolling="no">
                </iframe>
            </div>
        </div>
    </div>
    <!--弹出层-->
</dl>
<p>
    物流信息</p>
<dl class="tibxxbg">
    <dt>商品所在地：</dt>
    <dd>
        <div id="p_local" style="float: left;">
        </div>
        <span check="errorMsg" style="color: Red; display: none">省份必须选择！</span><span style="color: Red;">*</span>
    </dd>
</dl>
<dl class="tibxxbg" style=" display:none">
    <dt>运费：</dt>
    <dd>
        <input name="fee_check" type="radio" value="1" checked="checked" />
        卖家承担运费
        <input name="fee_check" type="radio" value="0" />
        买家承担运费<span style="color: Red;">*</span></dd>
</dl>
<dl class="tibxxbg" >
    <dt>商品重量：</dt>
    <dd>
       <input name="input" type="text" id="textWeight" runat="server" value="0.00"
                        class="yuan" />克
      <span style="color: Red;">*（为0就是免邮费）</span>
                         </dd>

</dl>
<dl class="tibxxbg">
    <dt>&nbsp;</dt>
    <dd style="display: none" id="selectfee">
        <table width="85%" border="0" cellspacing="2" cellpadding="0" class="bgtable" style="display: none">
            <tr>
                <!--<td colspan="3" style="padding: 10px;">
                    <input name="sub_fee_check" type="radio" value="0" checked="checked" />使用运费模板
                    <div id="subfee">
                        <span>
                            <asp:Label ID="lblFeeName" runat="server"></asp:Label></span>
                        <input name="input" type="button" class="selpic" onclick=" SelectShopPostage(this) "
                            value="选择模板" />
                        <input type="hidden" id="hidfee_template" runat="server" /><span check="errorMsg"
                            id="fee_check" style="color: Red; display: none">请选择一个邮费模板!</span>
                    </div>
                </td>-->
            </tr>
            <tr style="display: none">
                <td width="25%" style="padding: 10px;">
                    <input name="sub_fee_check" type="radio" value="1" checked="checked"  />平邮<input name="input" type="text"
                        id="txtPost_fee" runat="server" value="0.00" class="yuan" />元
                </td>
                <td width="25%">
                    快递<input name="input" type="text" id="txtExpress_fee" runat="server" value="0.00"
                        class="yuan" />元
                </td>
                <td style="padding: 10px;">
                    EMS<input name="input" type="text" id="txtEms_fee" runat="server" class="yuan" value="0.00" />元
                </td>
            </tr>
        </table>
    </dd>
</dl>
<p>
    其他信息</p>
<dl class="tibxxbg">
    <dt>店铺商品分类：</dt>
    <dd>
        <table width="90%" border="0" cellspacing="0" cellpadding="0" class="xiangxsp_nr">
            <tr>
                <td width="28%">
                    <ul id="J_form">
                        <li id="nav_shop_cat">
                            <!-- shop-cat-list -->
                            <div class="shop-cat-list">
                                <ul class="J_ShopCatList">
                                    <asp:Repeater ID="repShopType" runat="server">
                                        <ItemTemplate>
                                            <li>
                                                <input type="hidden" id="hidShopFatherId" runat="server" value='<%#Eval("id") %>' />
                                                <span>
                                                    <input type="checkbox" value='<%#Eval("code") %>' name="shopCat" id='shopCatId<%#Eval("code") %>'
                                                        class="checkbox">
                                                    <label for='shopCatId<%#Eval("code") %>'>
                                                        <%#Eval("name") %></label></span> <span check="checksubType">
                                                            <%#Eval("name") %></span>
                                                <ul>
                                                    <asp:Repeater ID="repSubShopType" runat="server">
                                                        <ItemTemplate>
                                                            <li>
                                                                <input type="checkbox" value='<%#Eval("Code") %>' name="shopCat" id='shopCatId<%#Eval("Code") %>'
                                                                    class="checkbox">
                                                                <label for='shopCatId<%#Eval("Code") %>'>
                                                                    <%#Eval("name") %></label></li>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </ul>
                                            </li>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                            </div>
                            <span style="color: Red;">*</span>
                            <!-- shop-cat-list -->
                        </li>
                    </ul>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span check="errorMsg" style="color: Red; display: none">必须设置一个店铺分类！点击<a href="s_index.aspx?tosurl=S_ProductCategory.aspx"
                        target="_blank">设置分类</a>,进入到店铺。</span>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span class="gray1">商品可以从属于店铺的多个分类之下</span>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <span class="gray1">店铺分类可以由 "用户中心 -> 我是卖家 -> 商品管理 -> 店铺分类管理" 中自定义</span>
                </td>
            </tr>
        </table>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>商品发布：</dt>
    <dd>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="xiangxsp_nr">
            <tr>
                <td colspan="2">
                    <input name="publishGoods" type="radio" value="0" checked="checked" />
                    立即发布
                </td>
            </tr>
            <tr style="display: none;">
                <td width="120">
                    <input name="publishGoods" type="radio" value="1" />
                    发布时间
                </td>
                <td>
                    <div class="fudong">
                        <input type="text" class="Wdate" id="txtSendTime" disabled="disabled" runat="server"
                            onclick="WdatePicker()" /></div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <input name="publishGoods" type="radio" value="2" />
                    放入仓库
                </td>
            </tr>
        </table>
    </dd>
</dl>
<dl class="tibxxbg" style="display: none;">
    <dt>是否抢购：</dt>
    <dd>
        <input name="isPanic" type="radio" value="0" checked="checked" />
        否
        <input name="isPanic" type="radio" value="1" />是 <span id="spanendtime" style="display: none">
            抢购开始时间：<input type="text" id="Panic_starttime" runat="server" class="Wdate" onclick="WdatePicker({minDate:'%y-%M-#{%d}'})" />-抢购结束时间：<input
                type="text" id="Panic_endtime" runat="server" class="Wdate" onclick="WdatePicker({minDate:'%y-%M-#{%d+1}'})" /><font
                    color="red" id="ftime" style="display: none;">开始时间不能大于结束时间</font></span>
    </dd>
</dl>
<dl class="tibxxbg" style="display: none;">
    <dt>库存计数：</dt>
    <dd>
        <input name="setStock" type="radio" value="0" checked="checked" />拍下减库存<font color="green">(买家拍下商品即减少库存，存在风险。秒杀、超低价等热销商品。)</font><br />
        <span style="display: none;">
            <input name="setStock" type="radio" value="1" />确认收货减库存<font color="green">(买家拍下并确认收货减少库存，存在风险。如需减少恶拍、提高回款效率，可选此方式)</font></span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>关键字(keywords)：</dt>
    <dd>
        <input name="input" id="txtKeyword" runat="server" type="text" class="textwb" maxlength="50" />
        <span class="gray1">&nbsp;</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>描述(description)：</dt>
    <dd>
        <textarea name="textarea" id="txtDesc" maxlength="250" runat="server" class="textwb"
            style="height: 120px; width: 450px;"></textarea>
    </dd>
</dl>
<dl class="tibxxbg" style="margin: 10px 0px 30px 0px; text-align: center;">
    <dt></dt>
    <dd>
        <%-- <asp:Button ID="butSub" runat="server" CssClass="baocbtn" Text="提交" OnClientClick="return funsub();" />--%>
        <input type="button" id="btnOk" class="baocbtn" onclick=" if (!funsub()) {return false;}document.form1.target = '_self';this.disabled = 'disabled';__doPostBack('btnOk', ''); "
            value="提交" />
        <span id="erroradd" style="color: Red; display: none;">添加的商品超过店铺等级商品数量限制！</span>
    </dd>
</dl>
<style type="text/css">
    .errortxt
    {
        border: 1px solid #BB005E;
    }
</style>
