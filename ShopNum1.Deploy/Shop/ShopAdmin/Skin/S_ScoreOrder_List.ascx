<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.Common" %>
<% DataTable dt = S_GroupOrder_List.dt_GroupOrderList;
   DataTable dt_sub = null; %>
<script type="text/javascript" language="javascript">
    $(function () {
        //批量删除操作
        $(".shanchu").click(function () {
            var ArrayGuid = new Array();
            var falt = false;
            $("input[name='checksub']").each(function () {
                if ($(this).is(":checked")) {
                    falt = true;
                    ArrayGuid.push("'" + $(this).val() + "'");
                }
            });
            if (falt) {
                IsDelete(ArrayGuid.join(","));
            } else {
                alert("请选择一项数据！");
            }
        });
    });

    function IsDelete(val) {
        if (confirm("确认是否删除数据？")) {
            $.get("/Api/ShopAdmin/S_DeleteOp.ashx?type=ScoreOrderInfo&delid=" + val, null, function (data) {
                if (data == "ok") {
                    alert("删除成功！");
                    location.reload();
                    return false;
                } else {
                    alert("删除失败！");
                    return false;
                }
            });
        }
    }

    $(function () {
        $("input[name='checktop']").click(function () {
            $("input[name='checksub']").attr("checked", $(this).is(":checked"));
        });
    });
    // 判断是否是数字

    function checknum(str) {
        var re = /^[0-9]+.?[0-9]*$/;
        if (!re.test(str)) {
            alert("请输入正确的数字！");
            return false;
        } else {
            return true;
        }
    }

    //页面跳转

    function ontoPage(o) {
        var pageindex = $(o).parent().parent().prev().prev().find("input").val();
        if (checknum(pageindex)) {
            var pageEnd = parseInt($(".page_2 b:eq(0)").text());
            if (pageEnd <= pageindex)
                pageindex = pageEnd;
            location.href = "S_ScoreOrder_List.aspx?pageid=" + pageindex;
        }
    }
</script>
<div id="list_main">
    <ul class="sidebar">
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "0" || ShopNum1.Common.Common.ReqStr("stype") == "" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_ScoreOrder_List.aspx?stype=0">所有订单</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "1" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_ScoreOrder_List.aspx?stype=1&OderStatus=0">未处理</a></li>
        <li class='<%= ShopNum1.Common.Common.ReqStr("stype") == "2" ? "TabbedPanelsTab TabbedPanelsTabSelected" : "TabbedPanelsTab" %>'>
            <a href="S_ScoreOrder_List.aspx?stype=2&OderStatus=1">已处理</a></li>
    </ul>
    <div id="content" class="ordmain">
        <div class="pad">
            <table border="0" cellspacing="0" cellpadding="0" class="lineh">
                <tr class="up_spac">
                    <td align="right">
                        红包订单号：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxOrderNumber" runat="server" CssClass="ss_nr1"></asp:TextBox>&nbsp;&nbsp;
                    </td>
                    <td align="right" class="ss_nr_spac">
                        买家ID：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="ss_nr1"></asp:TextBox>&nbsp;&nbsp;
                    </td>
                    <td>
                        <asp:Button ID="ButtonGetDate" runat="server" Text="查询" CssClass="chax btn_spc" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="btntable_tbg">
            <div class="shanc">
                <a href="javascript:void(0)" class="shanchu lmf_btn">批量删除</a>
            </div>
        </div>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="blue_tbw1">
            <tr>
                <th class="th_le" width="6%">
                    <input name="checktop" type="checkbox" title="全选" id="checktop" />
                </th>
                <th width="24%">
                    红包订单号
                </th>
                <th width="10%">
                    买家
                </th>
                <th width="10%">
                    收货人
                </th>
                <th width="20%">
                    联系电话
                </th>
                <th width="10%">
                    总红包
                </th>
                <th width="10%">
                    处理
                </th>
                <th class="th_ri" width="10%">
                    <span id="OrderPanic6">操作</span>
                </th>
            </tr>
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="th_le">
                            <input name="checksub" type="checkbox" class="vcheck" value='<%#Eval("Guid") %>' />
                        </td>
                        <td>
                            <%#Eval("OrderNumber") %>
                        </td>
                        <td>
                            <%#Eval("MemLoginID") %>
                        </td>
                        <td>
                            <%#Eval("Name") %>
                        </td>
                        <td>
                            <%#Eval("Mobile") %>
                        </td>
                        <td>
                            <%#Eval("TotalScore") %>
                        </td>
                        <td>
                            <%#Eval("OderStatus").ToString() == "0" ? "<span color:red>未处理</span>" : "<span>已处理</span>" %>
                        </td>
                        <td class="th_ri">
                            <span id="OrderPanic6"><a href="S_ScoreOrder_Edit.aspx?guid=<%#Eval("Guid") %>">查看</a></span>
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
        <!--分页-->
        <div class="btntable_tbg">
            <div id="pageDiv" runat="server" class="fy">
            </div>
        </div>
        <!--分页-->
    </div>
</div>
