<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script>
    $(function () {
        $(".woyaots").click(function () {
            var i = 0;
            var id;
            $("input[name='checkbox']").each(function () {
                if ($(this).is(":checked")) {
                    i++;
                    id = $(this).val();
                }
            });
            if (i == 0) {
                alert("请勾选一条数据！");
            } else if (i > 1) {
                alert("只能勾选一条数据！");
            } else {
                window.location.href = "S_ComplaintOrderComplaint.aspx?id=" + id;
            }
        });
    })
</script>
<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    投诉类型：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                        <asp:ListItem Value="恶意骚扰">恶意骚扰</asp:ListItem>
                        <asp:ListItem Value="售后保障服务">售后保障服务</asp:ListItem>
                        <asp:ListItem Value="未收到货">未收到货</asp:ListItem>
                        <asp:ListItem Value="违背承诺">违背承诺</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="chax btn_spc" name="12" />
                </td>
            </tr>
        </table>
    </div>
    <div class="btntable_tbg">
        <div class="shanc">
            <a class="woyaots lmf_btn" id="wyss" href="javascript:void(0)">我要申诉</a>
        </div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
        <thead>
            <tr>
                <th class="th_le" width="6%">
                    &nbsp;
                </th>
                <th width="20%">
                    投诉编号
                </th>
                <th width="14%">
                    投诉类型
                </th>
                <th width="10%">
                    投诉人
                </th>
                <th width="10%">
                    是否申诉
                </th>
                <th width="10%">
                    平台是否处理
                </th>
                <th width="20%">
                    发起时间
                </th>
                <th width="10%" class="th_ri">
                    操作
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="th_le">
                            <input name="checkbox" type="checkbox" class="vcheck" value='<%#Eval("ID") %>' />
                        </td>
                        <td>
                            <%#Eval("ID") %>
                        </td>
                        <td>
                            <%#Eval("ComplaintType") %>
                        </td>
                        <td>
                            <%#Eval("MemLoginID") %>
                        </td>
                        <td>
                            <%#Eval("IsAppeal").ToString() == "1" ? "已申诉" : "<span style='color:red'>未申诉</span>" %>
                        </td>
                        <td>
                            <%#Eval("ProcessingStatus").ToString() == "2" ? "已处理" : "<span style='color:red'>未处理</span>" %>
                        </td>
                        <td>
                            <%#Eval("ComplaintTime") %>
                        </td>
                        <td class="th_ri">
                            <a href="S_OrderComplaintDetailed.aspx?ID=<%#Eval("ID") %>">查看</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    <% if (RepeaterShow.Items.Count == 0)
       { %>
    <div class="no_datas">
        <div class="no_data">
            暂无数据</div>
    </div>
    <% } %>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="btntable_t">
    </table>
    <!--分页-->
    <div class="btntable_tbg">
        <div id="pageDiv" runat="server" class="fy">
        </div>
    </div>
    <!--分页-->
</div>
