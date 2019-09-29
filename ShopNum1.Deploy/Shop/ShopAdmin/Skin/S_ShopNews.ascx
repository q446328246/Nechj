<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
<script type="text/javascript" language="javascript">
    $(function () {
        //批量删除操作
        $(".shanchu").click(function () {
            var ArrayGuid = new Array();
            var flat = false;
            $("input[name='checksub']").each(function () {
                if ($(this).is(":checked")) {
                    flat = true;
                    ArrayGuid.push("'" + $(this).val() + "'");
                }
            });
            if (flat) {
                IsDelete(ArrayGuid.join(","));
            } else {
                alert("请选择一项！");
            }
        });
    });

    function IsDelete(val) {
        if (confirm("是否删除勾选项？")) {
            $.get("/Api/ShopAdmin/S_DeleteOp.ashx?type=ShopNews&delid=" + val, null, function (data) {
                if (data == "ok") {
                    alert("删除成功！");
                    location.reload();
                    window.location.href = "S_ShopNews.aspx";
                    return false;
                } else {
                    Alert("删除失败！");
                    return false;
                }
            });
        }
    }

    $(function () {
        $("#checktop").click(function () {
            $("input[name='checksub']").attr("checked", $(this).is(":checked"));
        });
    });
</script>
<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    标题：
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="ss_nr1"></asp:TextBox>
                </td>
                <td align="right" class="ss_nr_spac">
                    是否审核：
                </td>
                <td width="190">
                    <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect">
                        <asp:ListItem Value="-1">-全部-</asp:ListItem>
                        <asp:ListItem Value="0">未审核</asp:ListItem>
                        <asp:ListItem Value="1">审核通过</asp:ListItem>
                        <asp:ListItem Value="2">审核未通过</asp:ListItem>
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
            <a href="javascript:void(0)" class="shanchu lmf_btn">批量删除</a>
        </div>
        <div class="shanc">
            <a href="S_ShopNewsEdit.aspx" class="tianjiafl lmf_btn">添加资讯</a>
        </div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
        <tr>
            <th class="th_le" width="6%">
                <input name="checktop" type="checkbox" title="全选" id="checktop" />
            </th>
            <th width="24%">
                资讯标题
            </th>
            <th width="10%">
                是否展示
            </th>
            <th width="10%">
                资讯分类
            </th>
            <th width="10%">
                点击次数
            </th>
            <th width="10%">
                是否审核
            </th>
            <th width="20%">
                生成时间
            </th>
            <th width="10%" class="th_ri">
                操作
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="th_le">
                        <input name="checksub" type="checkbox" class="vcheck" value='<%#Eval("Guid") %>' />
                    </td>
                    <td>
                        <a href='<%# ShopUrlOperate.shopDetailHref(Eval("Guid").ToString(), Eval("MemLoginID").ToString(), "NewsDetail") %>'
                            target="_blank">
                            <%#Utils.GetUnicodeSubString(Eval("Title").ToString(), 29, "") %>
                        </a>
                    </td>
                    <td>
                        <%#Eval("IsShow").ToString() == "1" ? "显示" : "未显示" %>
                    </td>
                    <td>
                        <%#Utils.GetUnicodeSubString(ShopNum1.ShopAdminWebControl.S_ShopNews.GetNewsCategoryName(Eval("NewsCategoryGuid").ToString()), 20, "") %>
                    </td>
                    <td>
                        <%#Eval("ClickCount") %>
                    </td>
                    <td>
                        <%#ShopNum1.ShopAdminWebControl.S_ShopNews.IsAudit(Eval("IsAudit").ToString()) %>
                    </td>
                    <td>
                        <%#Eval("CreateTime") %>
                    </td>
                    <td class="boright">
                        <a href="S_ShopNewsEdit.aspx?guid=<%#Eval("Guid") %>">编辑</a>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <% if (RepeaterShow.Items.Count == 0)
           { %>
        <tr>
            <td colspan="8" class="th_le th_ri">
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
