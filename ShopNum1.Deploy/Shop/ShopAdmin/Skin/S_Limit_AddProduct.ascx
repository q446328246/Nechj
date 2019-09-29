<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<% DataTable dt = S_Limit_AddProduct.dt_LimitProduct; %>

<script type="text/javascript" language="javascript">
    var lid = <%= Request.QueryString["lid"] %>;
</script>
<div class="dpsc_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">我是卖家</a> <span class="breadcrume_icon">>></span> <a href="S_Limit_ActivityList.aspx">
            限时折扣</a> <span class="breadcrume_icon">>></span> <a href="S_Limit_ProductList.aspx?act=productlist&lid=<%= Request.QueryString["lid"] %>">
                商品管理</a><span class="breadcrume_icon">>></span><a class="breadcrume_text">添加商品</a></p>
    <div id="list_main">
        <ul id="sidebar">
            <li id="0" class='TabbedPanelsTab'><a href="S_Limit_ActivityList.aspx">限时折扣</a></li>
            <li id="1" class='TabbedPanelsTab' style="display: none;"><a href="S_Limit_Packages.aspx">
                套餐列表</a></li>
            <li id="2" class='TabbedPanelsTab' style="display: none;"><a href="S_Limit_BuyPackage.aspx">
                购买套餐</a></li>
            <li id="3" class='TabbedPanelsTab'><a href="S_Limit_ProductList.aspx?act=productlist&lid=<%= Request.QueryString["lid"] %>">
                商品管理</a></li>
            <li id="4" class='TabbedPanelsTab TabbedPanelsTabSelected'>添加商品</li>
        </ul>
        <div id="content" class="ordmain1">
            <table width="100%" cellspacing="0" cellpadding="0" border="0" style="color: #666666;
                line-height: 26px; margin-top: 11px; padding-left: 10px;">
                <tr>
                    <td>
                        活动名称：<asp:Label ID="lblName" runat="server"></asp:Label>
                    </td>
                    <td>
                        开始时间：<asp:Label ID="lblStartName" runat="server"></asp:Label>
                    </td>
                    <td>
                        结束时间：<asp:Label ID="lblEndTime" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        默认折扣：<asp:Label ID="lblDisCount" runat="server"></asp:Label>折
                    </td>
                    <td style="display: none;">
                        商品限制：<asp:Label ID="lblLimitPcount" runat="server"></asp:Label>
                    </td>
                    <td>
                        已选商品：<asp:Label ID="lblSelectProduct" runat="server"></asp:Label>
                    </td>
                    <td>
                        状态：
                        <asp:Label ID="lblState" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <div class="limit_notes" style="background: #ffffcc; border: 1px solid #ffd3a8; margin-right: 10px;
                margin-top: 10px; padding: 10px 20px;">
                <h3 style="color: #ff6600;">
                    说明：</h3>
                <ul>
                    <li>每件商品在每期限时折扣套餐中只能参加一个活动，已参加其它活动的商品在选择列表将被标志为已参加</li>
                    <li>手工取消的商品可以再参加其它活动</li>
                </ul>
            </div>
            <table width="100%" cellspacing="0" cellpadding="0" border="0" class="blue_tbw" id="publisactivity">
                <tr>
                    <th width="300" scope="col" class="th_le" style="text-align: center;">
                        商品名称
                    </th>
                    <th width="60" scope="col">
                        商品价格
                    </th>
                    <th width="50" class="th_ri" scope="col">
                        操作
                    </th>
                </tr>
                <!--循环代码-->
                <% if (dt != null)
                   {
                       for (int i = 0; i < dt.Rows.Count; i++)
                       {
                           string strGuid = dt.Rows[i]["guid"].ToString();
                           string strName = dt.Rows[i]["name"].ToString();
                           string strPrice = dt.Rows[i]["shopprice"].ToString();
                           string strImg = dt.Rows[i]["smallimage"].ToString();
                           string strIsget = dt.Rows[i]["isget"].ToString();
                           string strMemloginId = dt.Rows[i]["memloginId"].ToString();
                %>
                <tr>
                    <td class="th_le">
                        <a href="<%= ShopUrlOperate.shopHref(strGuid, strMemloginId) %>" class="or_img">
                            <img src="<%= strImg %>" style="height: 50px; width: 50px;" /></a><%= strName %>
                    </td>
                    <td>
                        <%= strPrice %>
                    </td>
                    <td class="th_ri">
                        <% if (strIsget != "")
                           { %>已参加<% }
                           else
                           { %>
                        <input type="button" class="butAdd" value="添加" lang="<%= strGuid %>" />
                        <% } %>
                    </td>
                </tr>
                <% }
                   } %>
                <!--循环代码-->
            </table>
            <div class="btntable_tbg">
                <div id="pageDiv" runat="server" class="fy">
                </div>
            </div>
        </div>
    </div>
</div>
