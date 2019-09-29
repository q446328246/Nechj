<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<% DataTable dt = S_Limit_Packages.dt_LimitPackages; %>
<div class="dpsc_mian">
    <p class="ptitle">
        <a href="S_Welcome.aspx">卖家中心</a> <span class="breadcrume_icon">>></span> <a href="S_PackAgeList.aspx">
            限时折扣</a><span class="breadcrume_icon">>></span> <a class="breadcrume_text">限时折扣</a></p>
    <div id="list_main">
        <ul id="sidebar">
            <li id="0" class='TabbedPanelsTab'><a href="S_Limit_ActivityList.aspx">限时折扣</a></li>
            <li id="1" class='TabbedPanelsTab TabbedPanelsTabSelected'>套餐列表</li>
            <li id="2" class='TabbedPanelsTab'><a href="S_Limit_BuyPackage.aspx">购买套餐</a></li>
        </ul>
        <div id="content">
            <table width="100%" cellspacing="0" cellpadding="0" border="0" class="blue_tbdd">
                <tbody>
                    <tr>
                        <th width="120" scope="col">
                            开始时间
                        </th>
                        <th width="120" scope="col">
                            结束时间
                        </th>
                        <th width="80" scope="col">
                            活动次数限制
                        </th>
                        <th width="100" scope="col">
                            已发布活动次数
                        </th>
                        <th width="100" scope="col">
                            剩余活动次数
                        </th>
                        <th width="80" scope="col">
                            商品限制
                        </th>
                        <th width="50" scope="col">
                            状态
                        </th>
                    </tr>
                    <!--循环代码-->
                    <% if (dt != null)
                       {
                           for (int i = 0; i < dt.Rows.Count; i++)
                           {
                               string strStartTime = dt.Rows[i]["starttime"].ToString();
                               string strEndTime = dt.Rows[i]["EndTime"].ToString();
                               string strPublishedNum = dt.Rows[i]["PublishedNum"].ToString();
                               string strLeaveNum = dt.Rows[i]["LeaveNum"].ToString();
                               string strLimtActivityNum = dt.Rows[i]["LimtActivityNum"].ToString();
                               string strLimitProductNum = dt.Rows[i]["LimitProductNum"].ToString();
                               string strState = dt.Rows[i]["state"].ToString();
                               switch (strState)
                               {
                                   case "0":
                                       strState = "正常";
                                       break;
                                   case "1":
                                       strState = "取消";
                                       break;
                               }
                    %>
                    <tr>
                        <td scope="col">
                            <%= strStartTime %>
                        </td>
                        <td scope="col">
                            <%= strEndTime %>
                        </td>
                        <td scope="col">
                            <%= strLimtActivityNum %>
                        </td>
                        <td scope="col">
                            <%= strPublishedNum %>
                        </td>
                        <td scope="col">
                            <%= strLeaveNum %>
                        </td>
                        <td scope="col">
                            <%= strLimitProductNum %>
                        </td>
                        <td scope="col">
                            <%= strState %>
                        </td>
                    </tr>
                    <% }
                       } %>
                    <!--循环代码-->
                </tbody>
            </table>
            <table width="98%" border="0" cellspacing="0" cellpadding="0" class="btntable_t">
                <tr>
                    <td style="border-left: solid 1px #e3e3e3; border-right: none;">
                    </td>
                    <td style="border-right: none;">
                    </td>
                    <td style="border-left: none;">
                        <div id="pageDiv" runat="server" class="fy">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
