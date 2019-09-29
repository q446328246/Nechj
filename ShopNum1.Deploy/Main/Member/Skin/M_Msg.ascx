<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_Msg.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_Msg" %>

<div id="list_main" class="list_main">
    <ul id="sidebar">
        <li class='<%=Request.QueryString["isread"].ToString()=="0"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?isread=0&pageid=1">未读信息</a></li>
        <li class='<%=Request.QueryString["isread"].ToString()=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?isread=1&pageid=1">已读信息</a></li>
        <li class='<%=Request.QueryString["isread"].ToString()=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?isread=2&pageid=1">已发送消息</a></li>
    </ul>
    <div id="content" class="ordmain1">
        <div class="biaogenr" style="margin-left: 0; margin-right: 0;">
            <div class="btntable_tbg">
                <table border="0" cellspacing="0" cellpadding="0" class="btntable_t">
                    <tr>
                        <td>
                            <div class="shanc">
                                <a href="#" class="shanchu lmf_btn">批量删除</a>
                            </div>
                        </td>
                        <td>
                            <%--<%if (ShopNum1.Common.Common.ReqStr("isread") == "2")
                              { %>--%>
                            <a href="M_SendMsg.aspx" class="tianjiafl2 lmf_btn">发送</a>
                            <%--<%} %>--%>
                        </td>
                    </tr>
                </table>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
                <tr>
                    <th class="th_le" width="4%">
                        <input name="checktop" type="checkbox" value="" />
                    </th>
                    <th width="56%">
                        标题
                    </th>
                    <th width="30%">
                        时间
                    </th>
                    <th width="10%" class="th_ri">
                        操作
                    </th>
                </tr>
                <asp:Repeater ID="RepMsg" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td class="th_le">
                                <input name="checksub" type="checkbox" value='<%#Eval("Guid") %>' />
                            </td>
                            <td style="text-align: left;">
                                <%#Eval("title") %>
                            </td>
                            <td>
                                <%#Eval("sendtime") %>
                            </td>
                            <td class="th_ri">
                                <a href='M_MsgDetail.aspx?guid=<%#Eval("Guid")%>&isread=<%=ShopNum1.Common.Common.ReqStr("isread")%>&pageid=<%=ShopNum1.Common.Common.ReqStr("pageid") %>'>
                                    查看</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <%if (RepMsg.Items.Count == 0)
                  { %>
                <tr>
                    <td colspan="4" style="height: 16px; border-left: solid 1px #e3e3e3; border-right: solid 1px #e3e3e3;">
                        <div class="no_data">
                            暂无数据</div>
                    </td>
                </tr>
                <% }%>
            </table>
            <script type="text/javascript" language="javascript">
                function checknum(str) {
                    var re = /^[0-9]+.?[0-9]*$/;
                    if (!re.test(str)) {
                        alert("请输入正确的数字！");
                        return false;
                    } else { return true; }
                }
                //页面跳转
                function ontoPage(o) {
                    var pageindex = $(o).parent().parent().prev().prev().find("input").val();
                    if (checknum(pageindex)) {
                        location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("isread") %>&pageid=' + pageindex;
                    }
                }
            </script>
            <!--分页-->
            <div class="btntable_tbg">
                <div id="pageDiv" runat="server" class="fy">
                </div>
            </div>
            <!--分页-->
        </div>
        <script type="text/javascript" language="javascript">
            $(function () {
                $("input[name='checktop']").click(function () {
                    $("input[name='checksub']").attr("checked", $(this).is(":checked"));
                });
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
                    IsDelete(ArrayGuid.join(","));
                });
            });

            function IsDelete(val) {
                if (confirm("是否删除勾选项？")) {
                    $.get("/Api/Main/Member/DeleteOp.ashx?type=msg&delid=" + val, null, function (data) {
                        if (data == "ok") { alert("删除成功！"); window.location.reload(); return false; }
                        else { alert("删除失败！"); return false; }
                    });
                }
            }
        </script>
    </div>
</div>
