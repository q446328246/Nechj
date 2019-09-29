<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
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
                window.location.href = "S_ComplaintReport.aspx?id=" + id;
            }
        });
    })
</script>
<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    举报类型：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                        <asp:ListItem Value="炒作信用度">炒作信用度</asp:ListItem>
                        <asp:ListItem Value="哄抬物价">哄抬物价</asp:ListItem>
                        <asp:ListItem Value="图片发布侵权">图片发布侵权</asp:ListItem>
                        <asp:ListItem Value="发布广告信息">发布广告信息</asp:ListItem>
                        <asp:ListItem Value="支付方式不符合商品">支付方式不符合商品</asp:ListItem>
                        <asp:ListItem Value="出售禁售货">出售禁售货</asp:ListItem>
                        <asp:ListItem Value="放错类目属性">放错类目属性</asp:ListItem>
                        <asp:ListItem Value="重复铺货">重复铺货</asp:ListItem>
                        <asp:ListItem Value="滥用关键字">滥用关键字</asp:ListItem>
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
                <th width="14%">
                    举报编号
                </th>
                <th width="20%">
                    举报类型
                </th>
                <th width="10%">
                    举报人
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
                <th class="th_ri" width="10%">
                    操作
                </th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="RepeaterShow" runat="server">
                <ItemTemplate>
                    <tr>
                        <td class="th_le1">
                            <input name="checkbox" type="checkbox" class="vcheck" value='<%#Eval("ID") %>' />
                        </td>
                        <td>
                            <%#Eval("ID") %>
                        </td>
                        <td>
                            <%#Eval("ReportType") %>
                        </td>
                        <td>
                            <%#Eval("MemLoginID") %>
                        </td>
                        <td>
                            <%#Eval("IsComplaint").ToString() == "1" ? "已申诉" : "<span style='color:red'>未申诉</span>" %>
                        </td>
                        <td>
                            <%#Eval("ProcessingStatus").ToString() == "2" ? "已处理" : "<span style='color:red'>未处理</span>" %>
                        </td>
                        <td>
                            <%#Eval("ReportTime") %>
                        </td>
                        <td class="th_ri1">
                            <a href="S_ReportDetailed.aspx?ID=<%#Eval("ID") %>">查看</a>
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
    <!--分页-->
    <div class="btntable_tbg">
        <div id="pageDiv" runat="server" class="fy">
        </div>
    </div>
    <!--分页-->
</div>
