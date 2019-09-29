<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="M_CreditDetails.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_CreditDetails" %>
<%@ Register Src="M_RankScoreModifyLog.ascx" TagName="M_RankScoreModifyLog" TagPrefix="uc1" %>
<%@ Register Src="M_ScoreModifyLog.ascx" TagName="M_ScoreModifyLog" TagPrefix="uc2" %>
<div id="list_main" class="list_main">
    <ul id="sidebar">
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="0"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=0&pageid=1">当前个人红包</a></li>
        <li class='<%=ShopNum1.Common.Common.ReqStr("type")=="1"?"TabbedPanelsTab TabbedPanelsTabSelected":"TabbedPanelsTab" %>'>
            <a href="?type=1&pageid=1">当前等级红包</a></li>
    </ul>
    <div id="content" class="ordmain1">
        <asp:Panel ID="PanelRankScoreModifyLog" runat="server">
            <%--            <ShopNum1:M_RankScoreModifyLog ID="M_RankScoreModifyLog" runat="server" SkinFilename="Skin/M_RankScoreModifyLog.ascx"
                PageSize="10" />--%>
            <uc1:M_RankScoreModifyLog ID="M_RankScoreModifyLog1" runat="server" PageSize="10" />
        </asp:Panel>
        <asp:Panel ID="PanelScoreModifyLog" runat="server">
            <%--            <ShopNum1:M_ScoreModifyLog ID="M_ScoreModifyLog" runat="server" SkinFilename="Skin/M_ScoreModifyLog.ascx"
                PageSize="10" />--%>
            <uc2:M_ScoreModifyLog ID="M_ScoreModifyLog1" runat="server" PageSize="10" />
        </asp:Panel>
        <script type="text/javascript" language="javascript">
            // 判断是否是数字
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
                    var pageEnd = parseInt($(".page_2 b:eq(0)").text());
                    if (pageEnd <= pageindex)
                        pageindex = pageEnd;
                    location.href = 'M_CreditDetails.aspx?type=<%=ShopNum1.Common.Common.ReqStr("type")%>&pageid=' + pageindex;
                }
            }
        </script>
    </div>
</div>
