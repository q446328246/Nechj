<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<% DataTable dt = S_Limit_ActivityList.dt_LimitActivity; %>
<div id="list_main">
    <ul id="sidebar">
        <li id="0" class='TabbedPanelsTab TabbedPanelsTabSelected'>限时折扣</li>
        <li id="1" class='TabbedPanelsTab' style="display: none;"><a href="S_Limit_Packages.aspx">
            套餐列表</a></li>
        <li id="2" class='TabbedPanelsTab' style="display: none;"><a href="S_Limit_BuyPackage.aspx">
            购买套餐</a></li>
    </ul>
    <div id="content" class="ordmain1">
        <div class="biaogenr">
            <table width="100%" cellspacing="0" cellpadding="0" border="0" class="blue_tb2">
                <tbody>
                    <tr>
                        <th width="30%" class="th_le">
                            活动名称
                        </th>
                        <th width="20%">
                            开始时间
                        </th>
                        <th width="20%">
                            结束时间
                        </th>
                        <th width="10%">
                            折扣
                        </th>
                        <th width="10%">
                            状态
                        </th>
                        <th width="10%" class="th_ri">
                            操作
                        </th>
                    </tr>
                    <!--循环代码-->
                    <% if (dt != null)
                       {
                           for (int i = 0; i < dt.Rows.Count; i++)
                           {
                               string strId = dt.Rows[i]["id"].ToString();
                               string strName = dt.Rows[i]["name"].ToString();
                               string strStartTime = dt.Rows[i]["StartTime"].ToString();
                               string strEndTime = dt.Rows[i]["EndTime"].ToString();
                               string strDisCount = dt.Rows[i]["Discount"].ToString();
                               string strState = dt.Rows[i]["state"].ToString();
                               string strTxt = "";
                               switch (strState)
                               {
                                   case "0":
                                       strTxt = "未发布";
                                       break;
                                   case "1":
                                       strTxt = "审核通过";
                                       break;
                                   case "2":
                                       strTxt = "审核未通过";
                                       break;
                                   case "3":
                                       strTxt = "已结束";
                                       break;
                                   case "5":
                                       strTxt = "已发布待审核";
                                       break;
                               }
                               if (Convert.ToDateTime(strEndTime) < DateTime.Now)
                                   strTxt = "已结束";
                    %>
                    <tr>
                        <td>
                            <%= strName %>
                        </td>
                        <td>
                            <%= strStartTime %>
                        </td>
                        <td>
                            <%= strEndTime %>
                        </td>
                        <td>
                            <%= strDisCount %>
                        </td>
                        <td>
                            <%= strTxt %>
                        </td>
                        <td>
                            <%--      <%if (strState == "1")
                 { %>
			            
			            <%}
                 else
                 { %>
			              <a href="S_Limit_ProductList.aspx?act=plist&lid=<%=strId %>">管理</a>
			           <%} %>--%>
                            <a href="S_Limit_ProductList.aspx?act=plist&lid=<%= strId %>">管理</a> <span class="cancelActivity"
                                style="display: none;" lang="<%= strId %>">取消</span> <a href="javascript:void(0)"
                                    onclick=" if (confirm('是否删除该限时折扣活动？')) {window.location.href = 'S_Limit_ActivityList.aspx?lid=<%= strId %>&sign=del';} else {return false;} ">
                            删除</span>
                        </td>
                    </tr>
                    <% }
                       }
                       else
                       { %>
                    <tr>
                        <td colspan="6">
                            <div class="no_datas">
                                <div class="no_data">
                                    暂无限时折扣活动</div>
                            </div>
                        </td>
                    </tr>
                    <% } %>
                    <!--循环代码-->
                </tbody>
            </table>
            <% if (dt != null)
               { %>
            <div class="btntable_tbg">
                <div id="pageDiv" runat="server" class="fy">
                </div>
            </div>
            <% } %>
        </div>
    </div>
</div>
