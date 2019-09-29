<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<% DataTable dt = S_Limit_ProductList.dt_LimitProduct; %>
<div class="dpsc_mian">
    <p class="ptitle">
        <span class="spanrig">
            <% if (lblState.Text != "已发布" && lblState.Text != "已结束" && lblState.Text != "已取消")
               { %>
            <a class="tianjiafl lmf_btn" href="S_Limit_AddProduct.aspx?act=add&lid=<%= ShopNum1.Common.Common.ReqStr("lid") %>">
                添加商品</a>
            <% } %>
        </span><a href="S_Welcome.aspx">我是卖家</a> <span class="breadcrume_icon">>></span>
        <a href="S_Limit_ActivityList.aspx">限时折扣</a> <span class="breadcrume_icon">>></span>
        <span class="breadcrume_text">商品管理</span>
        <div id="list_main">
            <ul id="sidebar">
                <li id="0" class='TabbedPanelsTab'><a href="S_Limit_ActivityList.aspx">限时折扣</a></li>
                <li id="1" class='TabbedPanelsTab' style="display: none;"><a href="S_Limit_Packages.aspx">
                    套餐列表</a></li>
                <li id="2" class='TabbedPanelsTab' style="display: none;"><a href="S_Limit_BuyPackage.aspx">
                    购买套餐</a></li>
                <li id="3" class='TabbedPanelsTab TabbedPanelsTabSelected'>商品管理</li>
            </ul>
            <div id="content">
                <div style="padding-left: 10px;">
                    <table width="100%" cellspacing="0" cellpadding="0" border="0" style="color: #666666;
                        line-height: 26px; margin-top: 11px; padding-left: 10px;">
                        <tr>
                            <td>
                                <strong>活动名称：</strong><asp:Label ID="lblName" runat="server"></asp:Label>
                            </td>
                            <td>
                                <strong>开始时间：</strong><asp:Label ID="lblStartName" runat="server"></asp:Label>
                            </td>
                            <td>
                                <strong>结束时间：</strong><asp:Label ID="lblEndTime" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <strong>默认折扣：</strong><asp:Label ID="lblDisCount" runat="server"></asp:Label>折
                            </td>
                            <td style="display: none;">
                                <strong>商品限制：</strong><asp:Label ID="lblLimitPcount" runat="server"></asp:Label>
                            </td>
                            <td>
                                <strong>已选商品：</strong><asp:Label ID="lblSelectProduct" runat="server"></asp:Label>
                            </td>
                            <td>
                                <strong>状态：</strong><asp:Label ID="lblState" runat="server"></asp:Label>
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
                </div>
                <div style="margin: 0 10px;">
                    <table width="100%" cellspacing="0" cellpadding="0" border="0" class="blue_tbw" id="publisactivity">
                        <tr>
                            <th width="300" scope="col" class="th_le" style="text-align: center;">
                                商品名称
                            </th>
                            <th width="60" scope="col">
                                商品价格
                            </th>
                            <th width="100" scope="col">
                                商品折扣
                            </th>
                            <th width="50" scope="col" style="display: none;">
                                商品状态
                            </th>
                            <th width="50" class="th_ri" scope="col">
                                操作
                            </th>
                        </tr>
                        <% if (dt != null)
                           {
                               if (dt.Rows.Count > 0)
                               {
                                   for (int i = 0; i < dt.Rows.Count; i++)
                                   {
                                       string strId = dt.Rows[i]["id"].ToString();
                                       string strName = dt.Rows[i]["name"].ToString();
                                       string strDiscount = dt.Rows[i]["discount"].ToString();
                                       string strPrice = dt.Rows[i]["shopprice"].ToString();
                                       string stroriginalImage = dt.Rows[i]["originalImage"].ToString();
                                       string strImg = dt.Rows[i]["smallimage"].ToString();
                                       string strState = dt.Rows[i]["state"].ToString();
                                       string strGuid = dt.Rows[i]["guid"].ToString();
                                       string strMemloginId = dt.Rows[i]["memloginid"].ToString();
                                       if (strState == "1")
                                           strState = "正常";
                                       else
                                           strState = "取消";
                        %>
                        <!--循环代码-->
                        <tr>
                            <td class="th_le1" style="text-align: left;">
                                <a rel="<%= stroriginalImage %>" target="_blank" href="<%= ShopUrlOperate.shopHref(strGuid, strMemloginId) %>"
                                    title="<%= strName %>">
                                    <img src="<%= strImg %>" style="height: 50px; width: 50px;" /><%= strName %></a>
                            </td>
                            <td>
                                <%= strPrice %>
                            </td>
                            <td style="padding: 0px; width: 80px;">
                                <div class="nosbe">
                                    <span class="edit_name" title="双击编辑">
                                        <%= strDiscount %></span> <span class="edit_v" style="display: none">
                                            <input type="text" value="<%= strDiscount %>" class="edit_txt" /><input type="button"
                                                class="btn_save" value="保存" lang="<%= strId %>" name="rep" /></span>
                                    <div class="ord_subs qiu_subos">
                                        <div class="ord_sub">
                                            双击修改折扣</div>
                                        <div class="ord_subs_tt ord_subs_te">
                                        </div>
                                    </div>
                                </div>
                            </td>
                            <td style="display: none;">
                                <% if (lblState.Text == "已取消")
                                   { %>
                                已取消<% }
                                   else
                                   { %>
                                <%= strState %><% } %>
                            </td>
                            <td class="th_ri1">
                                <% if (lblState.Text == "已发布" && strState == "正常")
                                   { %>
                                <span lang="<%= strId %>" class="cancellimit">取消</span>
                                <% }
                                   else if (lblState.Text != "已取消" && lblState.Text != "已结束")
                                   { %>
                                <span class="dellimit" lang="<%= strId %>">删除</span>
                                <% } %>
                            </td>
                        </tr>
                        <% }
                               }
                               else
                               { %>
                        <tr>
                            <td colspan="5" class="th_le th_ri">
                                <div class="no_datas">
                                    <div class="no_data">
                                        您还没有添加活动商品!</div>
                                </div>
                            </td>
                        </tr>
                        <% }
                           } %>
                        <!--循环代码-->
                    </table>
                    <% if (dt != null && dt.Rows.Count > 0)
                       { %>
                    <div class="btntable_tbg">
                        <div id="pageDiv" runat="server" class="fy">
                        </div>
                    </div>
                    <% } %>
                    <div style="margin-top: 20px; text-align: center;">
                        <% if (lblState.Text == "未发布")
                           { %>
                        <asp:Button ID="btnPublish" runat="server" Text="发布" OnClientClick=" return checkpublish(); "
                            CssClass="querbtn" /><% } %></div>
                </div>
            </div>
        </div>
</div>
<script type="text/javascript" language="javascript">
    function checkpublish() {
        if (confirm('确定发布该活动吗？')) {
            if ($("#publisactivity td").size() < 5) {
                alert("请添加限时折扣商品！");
                return false;
            }
            ;
            return true;
        } else {
            return false;
        }
    }
</script>
