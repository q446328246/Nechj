<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Theme_ActivityList.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Theme_ActivityList" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>主题活动管理</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script language="Javascript" type="text/javascript">        var oldcolor;

        function Num1GridViewShow_mout(rowEl) {
            for (var i = 0; i < rowEl.cells.length; i++) {
                rowEl.cells[i].style.backgroundColor = oldcolor;
            }
        }

        function Num1GridViewShow_mover(rowEl) {
            for (var i = 0; i < rowEl.cells.length; i++) {
                oldcolor = rowEl.cells[i].style.backgroundColor;
                rowEl.cells[i].style.backgroundColor = "#ebeef5";
            }
        }

        function opDelete() {
            location.href = "?subdel=" + $("#CheckGuid").val();
        } </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    主题活动管理</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                    </tbody>
                </table>
                <div class="sbtn">
                    <table cellspacing="0" cellpadding="0" border="0">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <a href="Theme_ActivityOperate.aspx" class="tianjia2 lmf_btn" id="ButtonAdd"><span>添加</span></a>
                                </td>
                                <td valign="top" style="display: none;" class="lmf_app">
                                </td>
                                <td valign="top" class="lmf_app">
                                    <asp:LinkButton ID="ButtonDelete" runat="server" CssClass="shanchu lmf_btn" OnClientClick=" return DeleteButton(); "
                                        OnClick="ButtonDelete_Click"><span>批量删除</span></asp:LinkButton>
                                </td>
                                <td valign="top" class="lmf_app">
                                    <t:MessageShow ID="MessageShow" Visible="false" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <div>
                <table cellspacing="0" cellpadding="4" border="0" id="Num1GridViewShow" rules="cols"
                    class="gridview_m">
                    <thead>
                        <tr align="center" style="color: White;" class="list_header">
                            <th scope="col" class="select_width">
                                <input type="checkbox" onclick=" javascript:SelectAllCheckboxesNew(this); " id="checkboxAll">
                            </th>
                            <th scope="col">
                                活动名称
                            </th>
                            <th scope="col">
                                开始时间
                            </th>
                            <th scope="col">
                                结束时间
                            </th>
                            <th scope="col">
                                活动说明
                            </th>
                            <th scope="col">
                                状态
                            </th>
                            <th scope="col">
                                操作
                            </th>
                        </tr>
                    </thead>
                    <tbody>
                        <% if (dt != null)
                           {
                               for (int i = 0; i < dt.Rows.Count; i++)
                               {
                                   string strId = dt.Rows[i]["Guid"].ToString();
                                   string strName = dt.Rows[i]["ThemeTitle"].ToString();
                                   string strStartTime = dt.Rows[i]["StartDate"].ToString();
                                   string strEndTime = dt.Rows[i]["EndDate"].ToString();
                                   string strState = dt.Rows[i]["ThemeStatus"].ToString();
                                   string strTXT = dt.Rows[i]["ThemeStatus"].ToString();
                                   string strThemeDescription = dt.Rows[i]["ThemeDescription"].ToString();
                                   if (Convert.ToDateTime(strStartTime) <= DateTime.Now)
                                       strState = "1";
                                   string strUrlEnd = "";
                                   switch (strState)
                                   {
                                       case "0":
                                           strTXT = "未开始";
                                           break;
                                       case "1":
                                           strTXT = "进行中";
                                           if (Convert.ToDateTime(strEndTime) <= DateTime.Now)
                                           {
                                               strTXT = "已结束";
                                               strUrlEnd = "&close=true";
                                           }
                                           break;
                                       case "2":
                                           strTXT = "已关闭";
                                           break;
                                   }
                        %>
                        <tr style="cursor: default;" onmouseout=" Num1GridViewShow_mout(this) " onmouseover=" Num1GridViewShow_mover(this) ">
                            <td align="center" style="">
                                <input type="checkbox" value="<%= strId %>" id="checkbox1">
                            </td>
                            <td align="center" style="">
                                <span id="Span1"><a href="/themesproduct.html?themeguid=<%= strId %>" target="_blank">
                                    <%= strName %></a></span>
                            </td>
                            <td align="center" style="">
                                <span id="Span2">
                                    <%= strStartTime %></span>
                            </td>
                            <td align="center" style="">
                                <span id="Span3">
                                    <%= strEndTime %></span>
                            </td>
                            <td align="center" style="">
                                <span id="Span6">
                                    <p mode="wrap" style="text-align: left; white-space: normal; width: 600px;">
                                        <%= strThemeDescription.Length > 100 ? strThemeDescription.Substring(1, 100) : strThemeDescription %></p>
                                </span>
                            </td>
                            <td align="center" style="">
                                <span id="Span5">
                                    <%= strTXT %></span>
                            </td>
                            <td align="center" style="">
                                <a style="color: #4482b4;" href="Theme_ActivityOperate.aspx?update=<%= strId %>&jk">
                                    编辑</a> <a style="color: #4482b4;" href="Theme_ProductList.aspx?Aid=<%= strId %><%= strUrlEnd %>&vj">
                                        管理</a> <a style="color: #4482b4;" href="?delete=<%= strId %>&jk" onclick=" return window.confirm('您确定要删除吗?'); ">
                                            删除</a>
                                <%-- <% if (strState == "0")
                            { %>
                             
                         <%}else if (strState != "2")
                            { %>
                            <a style="color: #4482b4;" href="?close=<%=strId %>&jk"  onclick="return window.confirm('您确定要关闭吗?');">关闭</a>
                         <%}%>--%>
                            </td>
                        </tr>
                        <% }
                           } %>
                        <tr class="lmf_page" align="right" style="background-color: #F7F7DE; color: Black;">
                            <td style="height: 30px;" colspan="7">
                                <div class="btnlist" style="overflow: auto;" id="showPage" runat="server" visible="false">
                                    <div class="fnum">
                                        每页显示数量： <a href="?pagesize=10">10</a><a href="?pagesize=20">20</a><a href="?pagesize=50">50</a>
                                    </div>
                                    <div class="fpage" id="pageDiv" runat="server">
                                    </div>
                                </div>
                                <script type="text/javascript" language="javascript">
                                    function NumTxt_Int(o) {
                                        o.value = o.value.replace(/\D/g, '');
                                    }

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

                                    $(function () {
                                        $(".fpage").find(".quedbtn").click(function () {
                                            var pageindex = $("input[name='vjpage']").val();
                                            if (checknum(pageindex)) {
                                                var pageEnd = parseInt($(".fpage font.pagecount").text());
                                                if (pageEnd <= pageindex)
                                                    pageindex = pageEnd;
                                                location.href = '?pageid=' + pageindex;
                                            }
                                        });
                                    });
                                </script>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <input type="hidden" id="CheckGuid" runat="server" value="0" />
    </form>
</body>
</html>
