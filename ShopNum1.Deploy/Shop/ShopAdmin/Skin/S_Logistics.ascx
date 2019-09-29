<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div id="content" class="ordmain1">
    <div class="biaogenr">
        <asp:Repeater ID="RepeaterFeeTemplate" runat="server">
            <ItemTemplate>
                <table cellpadding="0" class="blue_tbw1" cellspacing="0" width="100%">
                    <tr>
                        <th class="th_le" colspan="2">
                            <span class="fl" style="padding-left: 10px;">
                                <input type="hidden" runat="server" id="hiddenTemplateid" value='<%# ((DataRowView) Container.DataItem).Row["templateid"] %>' /><%# ((DataRowView) Container.DataItem).Row["templatename"] %></span>
                        </th>
                        <th class="th_ri" colspan="4">
                            <span class="fr" style="padding-right: 10px;">最后编辑时间：<%# ((DataRowView) Container.DataItem).Row["altertime"] %>
                                <a href="S_LogisticsTemplateOperate.aspx?templateid=<%#((DataRowView) Container.DataItem).Row["templateid"] %>">
                                    修改</a> |<a href="javascript:void(0)" onclick=" if (confirm('是否删除？')) {window.location.href = '?delid=<%#Eval("templateid") %>&sing=delok';} ">删除</a></span>
                        </th>
                    </tr>
                    <tr style="background: #f6faff;">
                        <td class="th_le1" style="height: 18px; line-height: 18px;">
                            运送方式
                        </td>
                        <td style="height: 18px; line-height: 18px;">
                            运送到
                        </td>
                        <td style="height: 18px; line-height: 18px;">
                            首件(个)
                        </td>
                        <td style="height: 18px; line-height: 18px;">
                            首费(元)
                        </td>
                        <td style="height: 18px; line-height: 18px;">
                            续件(个)
                        </td>
                        <td class="th_ri1" style="height: 18px; line-height: 18px; white-space: nowrap;">
                            续费(元)
                        </td>
                    </tr>
                    <asp:Repeater ID="RepeaterChildFeeTemplate" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td class="th_le1" style="text-align: center; width: 86px;">
                                    <input type="hidden" runat="server" id="hiddenGroupid" value='<%# ((DataRowView) Container.DataItem).Row["groupid"] %>' />
                                    <%# ((DataRowView) Container.DataItem).Row["feename"] %>
                                </td>
                                <td style="text-align: left; width: 280px;">
                                    <%# ((DataRowView) Container.DataItem).Row["groupregionnames"] %>
                                </td>
                                <td style="text-align: center; width: 86px;">
                                    1
                                </td>
                                <td style="text-align: center; width: 86px;">
                                    <%# ((DataRowView) Container.DataItem).Row["fee"] %>
                                </td>
                                <td style="text-align: center; width: 86px;">
                                    1
                                </td>
                                <td class="th_ri1" style="text-align: center;">
                                    <%# ((DataRowView) Container.DataItem).Row["oneadd"] %>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <div class="btntable_tbg" style="text-align: center;">
            <!-- 分页部分-->
            <div class="pager" style="width: 100%">
                <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
                &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
                <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
                <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
                <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
                &nbsp;<span class="fpager" style="display: none;">转到
                    <asp:Literal ID="lnkTo" runat="server" />
                    页</span>
                <input type="hidden" id="HiddenShowCount" name="HiddenShowCount" value="2" runat="server" />
            </div>
        </div>
    </div>
</div>
