<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_MemberProductCollect.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MemberProductCollect" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<script src="js/jquery-1.6.2.min.js" type="text/javascript"></script>
<script type="text/javascript" language="javascript">
    function IsDelete(val) {
        if (confirm("是否删除勾选项？")) {
            $.get("/Api/Main/Member/DeleteOp.ashx?type=MemberProductCollect&delid=" + val, null, function(data) {
                if (data == "ok") {
                    alert("删除成功！");
                    var type = '<%=ShopNum1.Common.Common.ReqStr("type")%>';
                    window.location.href = "?type=" + type + "&pageid=1";
                    return false;
                } else {
                    alert("删除失败！");
                    return false;
                }
            });
        }
    }
</script>
<div class="biaogenr">
    <div class="btntable_tbg">
        <div class="shanc">
            <a href="javascript://void(0)" class="shanchu lmf_btn">批量删除</a>
        </div>
    </div>
    <table width="100%" border="0" cellspacing="0" cellpadding="5" class="blue_tb2">
        <tr>
            <th width="4%" class="th_le">
                <input name="checktop" type="checkbox" title="全选" />
            </th>
            <th width="30%">
                商品名称
            </th>
            <th width="10%">
                商品价格
            </th>
            <th width="16%">
                店铺名称
            </th>
            <th width="10%">
                卖家ID
            </th>
            <th width="18%" class="th_ri">
                收藏时间
            </th>
            <th width="29%" class="th_ri">
                商品专区
            </th>
        </tr>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td>
                        <input name="checksub" type="checkbox" value='<%#Eval("Guid")%>' />
                    </td>
                    <td>
                        <a target="_blank" href='<%#ShopUrlOperate.shopHref(Eval("ProductGuid").ToString(),Eval("SellLoginID").ToString() )%>?category=<%#Eval("shop_category_id") %>'>
                            <%#Eval("ProductName")%></a>
                    </td>
                    <td>
                        ￥<%#Eval("ShopPrice")%>
                    </td>
                    <td>
                        <%#Eval("ShopID")%>
                    </td>
                    <td>
                        <%#Eval("SellLoginID")%>
                    </td>
                    <td>
                        <%#Eval("CollectTime")%>
                    </td>
                    <td>
                    <%# Enum.GetName(typeof(ShopNum1.Common.ShopNum1.Common.CustomerCategory), Eval("shop_category_id"))%>
                        
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <%if (RepeaterShow.Items.Count == 0)
          { %>
        <tr>
            <td colspan="6" style="height: 16px;">
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
