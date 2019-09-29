<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_SysMsg.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_SysMsg" %>
<div id="list_main">
    <ul id="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("isread")=="0"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?isread=0&pageid=1">未读信息</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("isread")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?isread=1&pageid=1">已读信息</a></li>
    </ul>
    <div id="content" class="ordmain1">
        <div class="biaogenr" style="margin-left: 0; margin-right: 0;">
            <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
                <tr>
                    <th width="60%" class="th_le">
                        标题
                    </th>
                    <th width="30%">
                        时间
                    </th>
                    <th width="10%" class="th_ri">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="RepMsg" runat="server" OnItemDataBound="RepMsg_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <td class="th_le" style="text-align: left;">
                                <asp:Label ID="LabelMessageInfoGuid" runat="server" Text='<%#Eval("MessageInfoGuid")%>'></asp:Label>
                            </td>
                            <td>
                                <%#Eval("SendTime")%>
                            </td>
                            <td class="th_ri">
                                <a href='M_SysMsgDetail.aspx?guid=<%#Eval("Guid")%>&isread=<%=ShopNum1.Common.Common.ReqStr("isread") %>&pageid=<%=ShopNum1.Common.Common.ReqStr("pageid")%>'>
                                    查看</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <%if (RepMsg.Items.Count == 0)
                  { %>
                <tr>
                    <td colspan="3" style="height: 16px; border-left: solid 1px #e3e3e3; border-right: solid 1px #e3e3e3;">
                        <div class="no_data">
                            暂无数据</div>
                    </td>
                </tr>
                <% }%>
            </table>
            <!--分页-->
            <div class="btntable_tbg">
                <div id="pageDiv" runat="server" class="fy">
                </div>
            </div>
            <!--分页-->
        </div>
        <script type="text/javascript" language="javascript">
            //跳转到制定的页码
            function ontoPage(txtId) {
                location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("isread") %>&pageid=' + $("#txtIndex").val();
            }
            $(function () {
                //批量删除操作
                $(".shanchu").click(function () {
                    var ArrayGuid = new Array();
                    var bflag = true;
                    $("input[name='checksub']").each(function () {
                        if ($(this).is(":checked")) {
                            bflag = false;
                            ArrayGuid.push("'" + $(this).val() + "'");
                        }
                    });
                    if (bflag) {
                        alert("请勾选一条数据！"); return false;
                    }
                    $.get(ajax_delurl + "?type=sysmsg&delid=" + val, null, function (data) {
                        if (data == "ok") { alert("删除成功"); return false; }
                        else { alert("删除失败！"); return false; }
                    });
                });
            });
        </script>
    </div>
</div>
