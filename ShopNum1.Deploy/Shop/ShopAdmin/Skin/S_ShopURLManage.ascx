<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div id="content" class="ordmain1">
    <div class="biaogenr">
        <table width="100%" cellspacing="0" cellpadding="0" border="0" class="btntable_top"
            id="showTable" runat="server">
            <tr>
                <td>
                    <div class="btntable_tbg">
                        <div class="shanc">
                            <a class="tianjiafl lmf_btn" id="wyss" href="/Shop/ShopAdmin/S_ShopURLManageEdit.aspx"
                                runat="server">申请域名</a>
                        </div>
                    </div>
                </td>
            </tr>
        </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
            <tr>
                <th class="th_le">
                    域名
                </th>
                <th>
                    申请时间
                </th>
                <th>
                    审核状态
                </th>
                <th class="th_ri">
                    操作
                </th>
            </tr>
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <tr height="45">
                        <td class="th_le1">
                            <a target="_blank" href='http://<%#ShopNum1.ShopAdminWebControl.S_ShopURLManage.GetLongUrl(Eval("DoMain").ToString()) %>'>
                                http://<%#ShopNum1.ShopAdminWebControl.S_ShopURLManage.GetLongUrl(Eval("DoMain").ToString()) %>
                            </a>
                        </td>
                        <td>
                            <%#Eval("AddTime") %>
                        </td>
                        <td>
                            <%#ShopNum1.ShopAdminWebControl.S_ShopURLManage.GetState(Eval("IsAudit").ToString()) %>
                        </td>
                        <td class="th_ri1">
                            <a href="S_ShopURLManageEdit.aspx?ID=<%#Eval("ID") %>">编辑</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
            <% if (RepeaterShow.Items.Count == 0)
               { %>
            <tr>
                <td colspan="7" class="th_le th_ri">
                    <div class="no_datas">
                        <div class="no_data">
                            暂无数据</div>
                    </div>
                </td>
            </tr>
            <% } %>
        </table>
        <!--分页-->
        <div class="btntable_tbg">
            <div id="pageDiv" runat="server" class="fy">
            </div>
        </div>
        <!--分页-->
    </div>
</div>
