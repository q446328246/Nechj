<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<% DataTable dt = S_GroupProduct.dt_GroupProduct; %>
<div class="ordmain1" id="content">
    <div class="biaogenr">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="blue_tb2">
            <tr>
                <th width="40%" class="th_le">
                    团购名称
                </th>
                <th width="30%">
                    团购活动
                </th>
                <th width="10%">
                    已团购
                </th>
                <th width="10%">
                    活动状态
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
                       string strAName = dt.Rows[i]["Aname"].ToString();
                       string strGroupSmallImg = dt.Rows[i]["GroupSmallImg"].ToString();
                       string strGroupCount = dt.Rows[i]["GroupCount"].ToString();
                       string strState = dt.Rows[i]["State"].ToString();
                       switch (strState)
                       {
                           case "0":
                               strState = "未审核";
                               break;
                           case "1":
                               strState = "已通过";
                               break;
                           case "2":
                               strState = "未通过";
                               break;
                           case "3":
                               strState = "已结束";
                               break;
                       }
                       string strProductUrl = ShopUrlOperate.RedirectProductDetailByMemloginID(dt.Rows[i]["id"].ToString(), dt.Rows[i]["MemloginId"].ToString(), "1", "1");
            %>
            <tr>
                <td style="text-align: left;">
                    <a href="<%= strProductUrl %>" target="_blank" style="display: block; float: left;">
                        <img src="<%= strGroupSmallImg %>" width="60" height="60" onerror=" javascript:this, src = '/ImgUpload/noImg.jpg_60x60.jpg'; " /></a>
                    <a href="<%= strProductUrl %>" target="_blank" style="display: block; float: left;
                        padding-left: 10px; width: 210px;">
                        <%= strName %></a>
                </td>
                <td>
                    <%= strAName %>
                </td>
                <td>
                    <%= strGroupCount %>
                </td>
                <td>
                    <%= strState %>
                </td>
                <td>
                    <% if (strState == "未审核" || strState == "未通过")
                       { %>
                    <a href="S_GroupProductOperate.aspx?id=<%= strId %>&vj">编辑</a>
                    <% } %>
                    <a class="delgroup" lang="<%= strId %>" onclick=" if (confirm('是否删除该数据?')) {window.location.href = 'S_GroupProduct.aspx?del=<%= strId %>&sign=del';} ">
                        删除</a>
                </td>
            </tr>
            <% }
               } %>
            <!--循环代码-->
        </table>
        <% if (dt == null)
           { %>
        <div class="no_datas">
            <div class="no_data">
                暂无商品团购数据</div>
        </div>
        <% } %>
        <div class="btntable_tbg">
            <div id="pageDiv" runat="server" class="fy">
            </div>
        </div>
    </div>
</div>
