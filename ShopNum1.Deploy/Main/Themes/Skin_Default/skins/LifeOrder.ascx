<%@ Control Language="C#" %>
<div id="content" runat="server" style="padding-top: 20px;">
    <center>
        <div class="mallFpCon">
            <dl style="background: #ffffff; border: 1px solid #bfbfbf; line-height: 20px; width: 800px;">
                <dt>
                    <h1 style="background: bfbfbf;">
                        <center>
                            自提货订单验证</center>
                    </h1>
                </dt>
                <dd>
                    尊敬的商户:<span id="memloginID"><%=hidShopMemloginId.Value %></span> ,您好!<br />
                    您已经成功验证个<span id="successlifeorder"><%=hidSuccesslifeorder.Value %></span>自提货订单。
                    您目前尚有<span id="waitlifeorder"><%=hidWaitlifeorder.Value %></span>个自提货订单未验证。<a href="/shop/ShopAdmin/S_index.aspx?tosurl=S_LifeOrder_List.aspx"
                        target="_blank">查看详情</a></dd>
                <dd style="text-align: center">
                    <input type="text" id="txtLifeCode" class="txt_gray" runat="server" onkeyup="NumTxt_Int(this)"
                        maxlength="6" /><asp:Button ID="btnViewDetail" OnClientClick="return CheckLifeOrder()"
                            runat="server" Text="查看详细" CssClass="btn_graylong" /><asp:Button ID="btnSure" OnClientClick="return CheckLifeOrder()"
                                runat="server" CssClass="btn_graylong" Text="一键验证" /></dd>
            </dl>
        </div>
        <asp:Repeater ID="repOrderInfo" runat="server">
            <ItemTemplate>
                <table width="800" cellspacing="0" cellpadding="0" border="0" class="btntable_top">
                    <tbody>
                        <tr>
                            <th colspan="5" style="border-left: solid 1px #e3e3e3; text-align: left;">
                                &nbsp;订单编号：<%#Eval("ordernumber")%>&nbsp;&nbsp;&nbsp; 买家：<%#Eval("memloginId") %>&nbsp;&nbsp;&nbsp;下单时间：<%#Eval("confirmtime")%>&nbsp;&nbsp;&nbsp;确定消费时间：<%=System.DateTime.Now.ToString()%>
                            </th>
                        </tr>
                    </tbody>
                </table>
                <table width="800" cellspacing="0" cellpadding="0" id="biaodhd1" class="blue_tb1">
                    <thead style="background: #bcbcbc;">
                        <tr>
                            <th width="82" style="text-align: center;">
                                商品图片
                            </th>
                            <th width="200" style="text-align: center;">
                                商品名称
                            </th>
                            <th width="100" style="text-align: center;">
                                商品规格
                            </th>
                            <th style="width: 60px; text-align: center;">
                                商品价格
                            </th>
                            <th style="width: 60px; text-align: center;">
                                购买数量
                            </th>
                            <th style="width: 80px; text-align: center;" rowspan="1">
                                应付金额
                            </th>
                            <th rowspan="1">
                                买家留言
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td width="82" style="text-align: center;">
                                <a title="<%#Eval("Name")%>" target="_blank" class="alink_blue" href="<%#ShopUrlOperate.shopDetailHref(Eval("Guid").ToString(),Eval("MemloginId").ToString(),"ProductDetail")%>">
                                    <img width="60" height="60" onerror="javascript:this,src='/ImgUpload/noImg.jpg_60x60.jpg'"
                                        src="<%#Eval("ProductImg")%>"></a>
                            </td>
                            <td width="200" style="text-align: center;">
                                <a title="<%#Eval("ProductName")%>" target="_blank" class="alink_blue" href="<%#ShopUrlOperate.shopDetailHref(Eval("Guid").ToString(),Eval("MemloginId").ToString(),"ProductDetail")%>">
                                    <%#Eval("ProductName")%></a><br>
                            </td>
                            <td style="width: 100px; text-align: center;">
                                <span class="redbold">
                                    <%#Eval("specificationName")%></span>
                            </td>
                            <td style="width: 70px; text-align: center;">
                                <span class="redbold">
                                    <%#Eval("ShopPrice")%></span>
                            </td>
                            <td width="30" style="text-align: center;">
                                <%#Eval("BuyNumber")%>
                            </td>
                            <td style="width: 110px; text-align: center;" rowspan="1">
                                <span id="t_price_0" class="redbold">
                                    <%#Eval("ShouldPayPrice")%></span>
                            </td>
                            <td rowspan="1" style="text-align: left;">
                                <%#Eval("clienttosellermsg")%>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </ItemTemplate>
        </asp:Repeater>
    </center>
</div>
<div>
</div>
<%if (!content.Visible)
  { %><br />
<center>
    您没有权限查看相关信息!</center>
<%} %>
<input type="hidden" id="hidShopMemloginId" runat="server" />
<input type="hidden" id="hidSuccesslifeorder" runat="server" />
<input type="hidden" id="hidWaitlifeorder" runat="server" />
<style type="text/css">
    .btntable_top
    {
        margin: 10px auto 8px;
    }
    .btntable_top tr td
    {
        background: none repeat scroll 0 0 #F3F3F3;
        border-bottom: 1px solid #E0E0E0;
        border-right: 1px solid #E0E0E0;
        border-top: 1px solid #E0E0E0;
        height: 30px;
        line-height: 30px;
        text-align: center;
    }
    
    .biaodhd1
    {
        background: none repeat scroll 0 0 #E3E3E3;
        margin: 10px auto 0;
        width: 100%;
    }
    .biaodhd1 tr th
    {
        background: url("/Main/Themes/Skin_Default/images/czthbg.jpg") repeat-x scroll 0 0 rgba(0, 0, 0, 0);
        color: #666666;
        font-weight: normal;
        height: 30px;
        line-height: 30px;
        text-align: center;
    }
    
    .th_le1
    {
        border-left: solid 1px #e3e3e3;
    }
    .th_ri1
    {
        border-right: solid 1px #e3e3e3;
    }
    
    .blue_tb1
    {
        margin: 0 auto;
        margin-top: 8px;
        margin-bottom: 8px;
        background: #e3e3e3;
    }
    .blue_tb1 tr th
    {
        height: 30px;
        line-height: 30px;
        background: url(/Main/Themes/Skin_Default/images/czthbg.jpg) repeat-x;
    }
    .blue_tb1 tr td
    {
        text-align: center;
        line-height: 18px;
        padding: 10px;
        background: none repeat scroll 0 0 #FFFFFF;
    }
    
    .dind_l
    {
        border-left: solid 1px #e0e0e0;
    }
    .dind_r
    {
        border-right: solid 1px #e0e0e0;
    }
    
    .txt_gray
    {
        border: 1px solid #bcbcbc;
        color: #8524CC;
        width: 114px;
        height: 24px;
        line-height: 24px;
        font-size: 15px;
    }
    .btn_graylong
    {
        border: none;
        color: #404040;
        cursor: pointer;
        display: inline-block;
        font-size: 12px;
        font-weight: normal;
        height: 26px;
        line-height: 26px;
        overflow: hidden;
        margin-left: 10px;
        text-align: center;
        width: 116px;
    }
    .mallFpCon dl
    {
        text-align: left;
        font-size: 14px;
    }
    .mallFpCon dl dt
    {
        background-color: #e7e7e7;
        font-size: 15px;
        height: 30px;
        line-height: 30px;
        margin-bottom: 22px;
    }
    .mallFpCon dl dd
    {
        padding: 0px 58px 28px 58px;
    }
    .mallFpCon dl dd a
    {
        color: #891221;
        text-decoration: underline;
    }
</style>
<script type="text/javascript" language="javascript">
    function NumTxt_Int(o) {
        o.value = o.value.replace(/\D/g, '');
    }
    function CheckLifeOrder() {
        var code = document.getElementById("LifeOrder_ctl00_txtLifeCode").value;
        if (code.length != 6) {
            alert("自提货验证码必须是6位数！"); return false;
        }
        return true;
    }
</script>
