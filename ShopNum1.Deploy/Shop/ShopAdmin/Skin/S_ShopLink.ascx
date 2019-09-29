<%@ Control Language="C#"%>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script src="/JS/jquery-1.6.2.min.js" type="text/javascript"> </script>
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
        if (confirm("是否删除勾选项？")) {
            $.get("/Api/ShopAdmin/S_DeleteOp.ashx?type=ShopLink&delid=" + val, null, function (data) {
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
</script>
<div id="content" class="ordmain1">
    <div class="pad">
        <table border="0" cellspacing="0" cellpadding="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    掌柜名：
                </td>
                <td>
                    <asp:TextBox ID="TextBoxShopMemLoginID" runat="server" CssClass="ss_nr1"></asp:TextBox>
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
            <a href="S_ShopLinkEdit.aspx" class="tianjiafl lmf_btn">添加链接</a>
        </div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tbw1">
        <tr>
            <th class="th_le" width="6%">
                <input name="checktop" type="checkbox" title="全选" id="checktop" />
            </th>
            <th width="20%">
                店铺名
            </th>
            <th width="24%">
                店铺地址
            </th>
            <th width="10%">
                掌柜名
            </th>
            <th width="10%">
                是否显示
            </th>
            <th width="20%">
                添加时间
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
                        <a href='<%#Eval("ShopUrl") %>' target="_blank">
                            <%#Utils.GetUnicodeSubString(Eval("ShopName").ToString(), 26, "") %>
                        </a>
                    </td>
                    <td>
                        <a href='<%#ShopUrlOperate.GetShopDomainByUrl(Eval("vshopurl").ToString()) %>' target="_blank">
                            <%#ShopUrlOperate.GetShopDomainByUrl(Eval("vshopurl").ToString()) %>
                        </a>
                    </td>
                    <td>
                        <%#Eval("ShopMemLoginID") %>
                    </td>
                    <td>
                        <%#Eval("IsShow").ToString() == "1" ? "显示" : "<span style=\"color:red\">不显示</span>" %>
                    </td>
                    <td>
                        <%#Eval("CreateTime") %>
                    </td>
                    <td class="th_ri">
                        <a href="S_ShopLinkEdit.aspx?guid=<%#Eval("Guid") %>">编辑</a>
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
    <div class="btntable_tbg">
        <!--分页-->
        <div id="pageDiv" runat="server" class="fy">
        </div>
        <!--分页-->
    </div>
</div>
