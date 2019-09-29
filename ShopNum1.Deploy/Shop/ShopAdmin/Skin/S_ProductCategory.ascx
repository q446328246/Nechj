<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="System.Data" %>
<div id="content" class="ordmain1">
    <div class="biaogenr">
        <div class="btntable_tbg">
            <div class="shanc">
                <a class="shanchu lmf_btn" href="#">批量删除</a>
            </div>
            <div class="shanc" style="display: none;">
                <a class="baocpx lmf_btn" href="#">保存排序</a>
            </div>
        </div>
        <table cellpadding="0" cellspacing="0" border="0" width="100%" class="gridview_m blue_tbw1">
            <tr>
                <th width="430" class="th_le" style="text-align: left;">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;分类排序&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;分类名称
                </th>
                <th>
                    是否在前台显示
                </th>
                <th class="th_ri" style="text-align: center;">
                    操作
                </th>
            </tr>
            <% DataTable dataTable = S_ProductCategory.dt_ProdcutCategory;
               if (dataTable != null)
               {
                   foreach (DataRow dataRow in dataTable.Rows)
                   { %>
            <tr class="one lmf_huaguo" id='parent_<%= dataRow["ID"] %>'>
                <td align="left" valign="middle" class="th_le">
                    <div class="lmf_jia fl">
                        <% if (dataRow["v"].ToString() != "")
                           { %>
                        <img style="border-width: 0px;" src="images/lmf_jia.jpg" onclick=' funsub(<%= dataRow["ID"] %>) ' />
                        <% }
                           else
                           { %>
                        <span style="display: block; height: 20px; width: 13px;">&nbsp;</span>
                        <% } %>
                    </div>
                    <div class="lmf_xuanze fl">
                        <% if (dataRow["v"].ToString() == "")
                           { %>
                        <input type="checkbox" class="checkboxsn vcheck" onclick=" checksub(this, '<%= dataRow["ID"] %>') "
                            value='<%= dataRow["ID"] %>' /><% } %></div>
                    <div class="lmf_paixu fl">
                        <input type="text" name="orderby" lang='<%= dataRow["ID"] %>' value='<%= dataRow["orderid"] %>'
                            style="width: 65px;" /></div>
                    <div class="lmf_titlee fl">
                        <input type="text" value='<%= dataRow["Name"] %>' /></div>
                </td>
                <td align="center" valign="middle" width="100px">
                    <% if (dataRow["isshow"].ToString() == "1")
                       { %>
                    <img style="border-width: 0px;" src="images/dui.jpg" class="isshow" lang='<%= dataRow["ID"] + "-" %><%= dataRow["isshow"] %>' />
                    <% }
                       else
                       { %>
                    <img style="border-width: 0px;" src="images/cuo.jpg" class="isshow" lang='<%= dataRow["ID"] + "-" %><%= dataRow["isshow"] %>' />
                    <% } %>
                </td>
                <td class="th_ri" style="width: 300px;">
                    <a href="#" class="saveedit" style="color: #4482b4;" lang='<%= dataRow["ID"] %>'
                        onclick=" treelist_save(this) ">保存</a>&nbsp; <a href="S_ProductCategory_Operate.aspx?op=edit&id=<%= dataRow["ID"] %>&width=810&height=500"
                            style="color: #4482b4;">编辑</a>&nbsp;
                    <% if (dataRow["v"].ToString() == "")
                       { %>
                    <a href="javascript:void(0)" style="color: #4482b4;" lang='<%= dataRow["ID"] %>'
                        class="delv" onclick=" treelist_delete(this) ">删除</a>&nbsp;
                    <% } %>
                    <a href='S_ProductCategory_Operate.aspx?op=add&id=<%= dataRow["ID"] %>&parentid=<%= dataRow["ID"] %>&width=810&height=500'
                        style="color: #4482b4;">添加子分类</a>
                </td>
            </tr>
            <tr style="display: none;" class="two" id='sub_two_<%= dataRow["ID"] %>'></tr>
            <% }
               } %>
        </table>
    </div>
</div>
