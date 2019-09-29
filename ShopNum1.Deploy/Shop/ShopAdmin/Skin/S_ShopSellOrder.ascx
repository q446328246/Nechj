<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script type="text/javascript" language="javascript">
    $(function () {
        //搜索
        $("#sk").click(function () {
            location.href = "S_ShopSellOrder.aspx?pn=" + escape($("#pname").val()) + "&sd=" + $("#txtstartdate").val() + "&ed=" + $("#txtenddate").val();
        });
    });
</script>
<div id="content" class="ordmain1">
    <div class="pad">
        <table cellspacing="0" cellpadding="0" border="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    商品名称：
                </td>
                <td>
                    <%--   <asp:TextBox ID="TextBoxProductName" runat="server" CssClass="ss_nr1"></asp:TextBox>--%>
                    <input name="pname" type="text" id="pname" class="ss_nr1" value='<%= ShopNum1.Common.Common.ReqStr("pn") %>' />
                </td>
                <td align="right" class="ss_nr_spac">
                    销售日期：
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <%--    <td>
                                <ShopNum1:TextBox ID="TextBoxTime1" RequiredFieldType="日期" runat="server" CssClass="ss_nrduan"
                                    Style="background: none;" />
                            </td>
                            <td class="line_spac">
                                -
                            </td>
                            <td>
                                <ShopNum1:TextBox ID="TextBoxTime2" RequiredFieldType="日期" runat="server" CssClass="ss_nrduan"
                                    Style="background: none;" />
                            </td>--%>
                            <td>
                                <input value='<%= ShopNum1.Common.Common.ReqStr("sd") %>' name="startdate" type="text" id="txtstartdate"
                                    class="ss_nrduan" onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd' }) " />
                            </td>
                            <td class="line_spac">
                                -
                            </td>
                            <td>
                                <input value='<%= ShopNum1.Common.Common.ReqStr("ed") %>' name="enddate" type="text" id="txtenddate"
                                    class="ss_nrduan" onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd' }) " />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
                    <%--   <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="chax btn_spc" />--%>
                    <input name="sk" id="sk" type="button" class="chax btn_spc" value="查询" />
                </td>
            </tr>
        </table>
    </div>
    <div class="btntable_tbg">
        <div style="padding-left: 14px;">
            <asp:Button ID="ButtonReport" runat="server" Text="导出到Excel" CausesValidation="False"
                CssClass="sqjdbzj1" />&nbsp;&nbsp;
            <asp:Button ID="ButtonHtml" runat="server" CausesValidation="False" CssClass="sqjdbzj1"
                OnClientClick=" javascript:document.getElementById('form1').target = '_blank';window.location.href = window.location.href; "
                Text="导出到Html" />
        </div>
    </div>
    <table cellpadding="0" cellspacing="0" width="100%" class="blue_tbw1">
        <tr>
            <th style="text-align: center" class="th_le">
                商品名称
            </th>
            <th style="text-align: center">
                货号
            </th>
            <th style="text-align: center">
                销售数量
            </th>
            <th style="text-align: center">
                销售额
            </th>
            <th style="text-align: center" class="th_ri">
                均价
            </th>
        </tr>
        <asp:Repeater EnableViewState="False" ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td style="text-align: center" class="th_le">
                        <%# ((DataRowView) Container.DataItem).Row["ProductName"] %>
                    </td>
                    <td style="text-align: center">
                        <%# ((DataRowView) Container.DataItem).Row["RepertoryNumber"] %>
                    </td>
                    <td style="text-align: center">
                        <%# ((DataRowView) Container.DataItem).Row["BuyNumber"] %>
                    </td>
                    <td style="text-align: center">
                        <%# ((DataRowView) Container.DataItem).Row["BuyPrice"] %>
                    </td>
                    <td style="text-align: center" class="th_ri">
                        <%# ((DataRowView) Container.DataItem).Row["AveragePrice"] %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <% if (RepeaterShow.Items.Count == 0)
       { %>
    <div class="no_datas">
        <div class="no_data">
            暂无数据</div>
    </div>
    <% } %>
    <div class="btntable_tbg">
        <!-- 分页部分-->
        <div class="pager" style="text-align: center;">
            <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
            &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
            &nbsp;<span class="fpager">转到
                <asp:Literal ID="lnkTo" runat="server" />
                页</span>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#selectPage").change(function () {
            var sreport = $(this).attr("lang");
            location.href = sreport + "?page=" + $(this).find("option:selected").val();
        });
    });
</script>
