<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" language="javascript">
    function NumTxt_Int(o) {
        if (o.toString() == "")
            o.value = "0";
        o.value = o.value.replace(/\D/g, '');
    }
</script>
<div class="dpsc_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">卖家中心</a> <span class="breadcrume_icon">>></span> <a href="S_PackAgeList.aspx">
            促销管理</a> <span class="breadcrume_icon">>></span><a href="#">购买套餐</a></p>
    <div id="list_main">
        <ul id="sidebar">
            <li id="0" class='TabbedPanelsTab'><a href="S_Limit_ActivityList.aspx">限时折扣</a></li>
            <li id="1" class='TabbedPanelsTab'><a href="S_Limit_Packages.aspx">套餐列表</a></li>
            <li id="2" class='TabbedPanelsTab TabbedPanelsTabSelected'>购买套餐</li>
        </ul>
        <div id="content">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
                <tr>
                    <td class="bordleft" width="130">
                        套餐购买数量：
                    </td>
                    <td class="bordrig">
                        <input type="text" id="txtNum" runat="server" onkeydown="NumTxt_Int(this)" onkeyup="NumTxt_Int(this)" />
                        <span check="errormsg" class="red">&nbsp;</span>
                        <br />
                        <span class="red">*</span>购买单位为月(30天)，一次最多购买12个月，您可以在所购买周期内以月为单位发布限时折扣活动 每月您需要支付1金币
                        每月最多发布活动10000次 每次活动最多发布10000件商品 套餐时间从审批后开始计算
                    </td>
                </tr>
            </table>
            <div style="margin: 20px 0px 50px 0px; text-align: center;">
                <asp:Button ID="btnSub" runat="server" Text="提交" />
            </div>
        </div>
    </div>
</div>
