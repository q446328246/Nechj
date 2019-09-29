<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_Comment.ascx.cs" Inherits="ShopNum1.Deploy.Main.Member.Skin.M_Comment" %>
<%@ Register Src="M_SupplyDemandComment.ascx" TagName="M_SupplyDemandComment" TagPrefix="uc1" %>
<%@ Register Src="M_ShopVideoComment.ascx" TagName="M_ShopVideoComment" TagPrefix="uc2" %>
<%@ Register Src="M_VideoComment.ascx" TagName="M_VideoComment" TagPrefix="uc3" %>
<%@ Register Src="M_ArticleComment.ascx" TagName="M_ArticleComment" TagPrefix="uc4" %>
<%@ Register Src="M_ShopNewsComment.ascx" TagName="M_ShopNewsComment" TagPrefix="uc5" %>
<div id="list_main">
    <ul class="sidebar">
        <li id="0" class='<%=ShopNum1.Common.Common.ReqStr("type")=="0"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=0&pageid=1">供求评论</a></li>
        <li id="1" class='<%=ShopNum1.Common.Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=1&pageid=1">店铺视频评论</a></li>
        <li id="2" class='<%=ShopNum1.Common.Common.ReqStr("type")=="2"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=2&pageid=1">平台视频评论</a></li>
        <li id="3" class='<%=ShopNum1.Common.Common.ReqStr("type")=="3"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=3&pageid=1">平台资讯评论</a></li>
        <li id="4" class='<%=ShopNum1.Common.Common.ReqStr("type")=="4"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=4&pageid=1">店铺资讯评论</a></li>
    </ul>
    <div id="content" class="ordmain">
        <%--供求评论--%>
        <asp:Panel ID="PanelComment1" runat="server" Visible="false">
            <%--            <ShopNum1:M_SupplyDemandComment ID="M_SupplyDemandComment" runat="server" SkinFilename="Skin/M_SupplyDemandComment.ascx"
                PageSize="10" />--%>
            <uc1:M_SupplyDemandComment ID="M_SupplyDemandComment1" runat="server" PageSize="10" />
        </asp:Panel>
        <%--店铺视频评论--%>
        <asp:Panel ID="PanelComment2" runat="server" Visible="false">
            <%--            <ShopNum1:M_ShopVideoComment ID="M_ShopVideoComment" runat="server" PageSize="10"  SkinFilename="Skin/M_ShopVideoComment.ascx" />--%>
            <uc2:M_ShopVideoComment ID="M_ShopVideoComment1" runat="server" PageSize="10" />
        </asp:Panel>
        <%--平台视频评论--%>
        <asp:Panel ID="PanelComment3" runat="server" Visible="false">
            <%--            <ShopNum1:M_VideoComment ID="M_VideoComment" runat="server" SkinFilename="Skin/M_VideoComment.ascx"
                PageSize="10" />--%>
            <uc3:M_VideoComment ID="M_VideoComment1" runat="server" PageSize="10" />
        </asp:Panel>
        <%--平台资讯评论--%>
        <asp:Panel ID="PanelComment4" runat="server" Visible="false">
            <%--            <ShopNum1:M_ArticleComment ID="M_ArticleComment" runat="server" SkinFilename="Skin/M_ArticleComment.ascx"
                PageSize="10" />--%>
            <uc4:M_ArticleComment ID="M_ArticleComment1" runat="server" PageSize="10" />
        </asp:Panel>
        <%--店铺资讯评论--%>
        <asp:Panel ID="PanelComment5" runat="server" Visible="false">
            <%--           <ShopNum1:M_ShopNewsComment ID="M_ShopNewsComment" runat="server" SkinFilename="Skin/M_ShopNewsComment.ascx"
                PageSize="10" />--%>
            <uc5:M_ShopNewsComment ID="M_ShopNewsComment1" runat="server" PageSize="10" />
        </asp:Panel>
        <script type="text/javascript" language="javascript">
            //跳转到制定的页码
            function ontoPage(txtId) {
                location.href = '?isread=<%= ShopNum1.Common.Common.ReqStr("type") %>&pageid=' + $("#txtIndex").val();
            }

            $(function () {
                $("input[name='checktop']").click(function () {
                    $("input[name='checksub']").attr("checked", $(this).is(":checked"));
                });
            });

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
                    }
                    else {
                        alert("请选择一项数据！");
                    }

                });
            });
        </script>
    </div>
</div>
