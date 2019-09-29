<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_MyCollect.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MyCollect" %>
<%@ Register Src="M_ShopCollect.ascx" TagName="M_ShopCollect" TagPrefix="uc1" %>
<%@ Register Src="M_MemberProductCollect.ascx" TagName="M_MemberProductCollect" TagPrefix="uc2" %>
<script type="text/javascript" language="javascript">
    //跳转到制定的页码
    function ontoPage(txtId) {
        location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("type") %>&pageid=' + $("input[name='searchpage']").val();
    }
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
            if (flat == false) {
                alert("请选择一项！");
            }
            else {
                IsDelete(ArrayGuid.join(","));
            }
        });
    });

    $(function () {
        $("input[name='checktop']").click(function () {
            $("input[name='checksub']").attr("checked", $(this).is(":checked"));
        });
    });
</script>
<div id="list_main" class="ordmain1">
    <ul id="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="0"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=0&pageid=1">商品收藏</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=1&pageid=1">店铺收藏</a></li>
    </ul>
    <div id="content">
        <asp:Panel ID="PanelMemberProductCollect" runat="server">
            <%--            <ShopNum1:M_MemberProductCollect ID="M_MemberProductCollect" runat="server" SkinFilename="Skin/M_MemberProductCollect.ascx"
                PageSize="10" />--%>
            <uc2:M_MemberProductCollect ID="M_MemberProductCollect1" runat="server" PageSize="10" />
        </asp:Panel>
        <asp:Panel ID="PanelShopCollect" runat="server">
            <%--            <ShopNum1:M_ShopCollect ID="M_ShopCollect" runat="server" SkinFilename="Skin/M_ShopCollect.ascx"
                PageSize="10" />--%>
            <uc1:M_ShopCollect ID="M_ShopCollect1" runat="server" PageSize="10" />
        </asp:Panel>
    </div>
</div>
