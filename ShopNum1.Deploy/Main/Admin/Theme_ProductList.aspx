<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Theme_ProductList.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Theme_ProductList" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������Ʒ�б�</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <%--<div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    ������˹���</h3>
            </div>
        </div>--%>
        <div class="mhead">
            <div class="ml">
                <div class="mr">
                    <ul class="mul">
                        <li id="current1"><a href="?state=0&Aid=<%= Common.ReqStr("aid") %>" class="<%= Common.ReqStr("state") == "" || Common.ReqStr("state") == "0" ? "cur" : "" %>"
                            id="LinkButtonAll">�����</a> </li>
                        <li id="current2"><a href="?state=1&Aid=<%= Common.ReqStr("aid") %>" class="<%= Common.ReqStr("state") == "1" ? "cur" : "" %>"
                            id="LinkButtonNopayment">���ͨ��</a> </li>
                        <li id="current3"><a href="?state=2&Aid=<%= Common.ReqStr("aid") %>" class="<%= Common.ReqStr("state") == "2" ? "cur" : "" %>"
                            id="A1">���δͨ��</a> </li>
                        <li id="current4"><a href="?state=3&Aid=<%= Common.ReqStr("aid") %>" class="<%= Common.ReqStr("state") == "3" ? "cur" : "" %>"
                            id="LinkButtonPayment">�ѽ���</a> </li>
                        <li id="current5"><a href="Theme_ActivityList.aspx">�����б�</a> </li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div class="sbtn">
                    <table cellspacing="0" cellpadding="0" border="0">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <asp:LinkButton ID="LinkButton1" runat="server" CssClass="shanchu lmf_btn" OnClientClick=" return DeleteButton(); "
                                        OnClick="ButtonDelete_Click"><span>����ɾ��</span></asp:LinkButton>
                                </td>
                                <td valign="top" class="lmf_app">
                                    <t:MessageShow ID="MessageShow" Visible="false" runat="server" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
            <table cellspacing="0" cellpadding="4" border="0" id="Num1GridViewShow" rules="cols"
                class="gridview_m">
                <thead>
                    <tr align="center" style="color: White;" class="list_header">
                        <th scope="col" class="select_width">
                            <input type="checkbox" onclick=" javascript:SelectAllCheckboxesNew(this); " id="checkboxAll" />
                        </th>
                        <th scope="col">
                            ��Ʒ����
                        </th>
                        <th scope="col">
                            �������
                        </th>
                        <%--<th scope="col">
                            ����ʱ��
                        </th>--%>
                        <th scope="col">
                            ���״̬
                        </th>
                        <th scope="col">
                            ����
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% if (dt.Rows.Count > 0)
                       {
                           for (int i = 0; i < dt.Rows.Count; i++)
                           {
                               string strId = dt.Rows[i]["Guid"].ToString();
                               string strName = dt.Rows[i]["ProductName"].ToString();
                               string strShopName = dt.Rows[i]["ShopName"].ToString();
                               //string strEndTime = dt.Rows[i]["endtime"].ToString();
                               string strThemeGuid = dt.Rows[i]["ThemeGuid"].ToString();
                               string strState = dt.Rows[i]["IsAudit"].ToString();
                               string strProGuId = dt.Rows[i]["productguid"].ToString();
                               string strMemloginId = dt.Rows[i]["memloginid"].ToString();
                               switch (strState.Trim())
                               {
                                   case "0":
                                       strState = "δ���";
                                       break;
                                   case "1":
                                       strState = "���ͨ��";
                                       break;
                                   case "2":
                                       strState = "����ͨ��";
                                       break;
                                   case "3":
                                       strState = "�ѽ���";
                                       break;
                               }
                               string strProductUrl = ShopUrlOperate.RedirectProductDetailByMemloginID(dt.Rows[i]["Guid"].ToString(), dt.Rows[i]["MemloginId"].ToString(), "0", "0");
                    %>
                    <!--ѭ������-->
                    <tr style="cursor: default;" onmouseout=" Num1GridViewShow_mout(this) " onmouseover=" Num1GridViewShow_mover(this) ">
                        <td align="center" style="">
                            <input type="checkbox" value="<%= strId %>" name="subcheck">
                        </td>
                        <td align="center">
                            <span id="Span1"><a href="<%= strProductUrl %>" target="_blank">
                                <%= strName %></a></span>
                        </td>
                        <td align="center">
                            <span id="Span3">
                                <%= strShopName %></span>
                        </td>
                        <%--<td align="center">
                            <span id="Span4">
                                <%=strEndTime%></span>
                        </td>--%>
                        <td align="center">
                            <span id="Span5">
                                <%= strState %></span>
                        </td>
                        <td align="center">
                            <span class="opspan"><a href="<%= ShopUrlOperate.RedirectProductDetailByMemloginID(strProGuId, strMemloginId, "0", "0") %>"
                                target="_blank" style="color: #4482b4;">�鿴</a></span>|
                            <% if (strState == "δ���")
                               { %>
                            <span class="opspan oppass"><a style="color: #4482b4;" href="?agree=<%= strId %>&Aid=<%= strThemeGuid %>&jk"
                                onclick=" return window.confirm('��ȷ��Ҫ���ͨ����?'); ">���ͨ��</a></span>| <span class="opspan opupass">
                                    <a style="color: #4482b4;" href="?disagree=<%= strId %>&Aid=<%= strThemeGuid %>&jk"
                                        onclick=" return window.confirm('��ȷ��Ҫ����ͨ����?'); ">����ͨ��</a></span>|
                            <% }
                               else if (strState == "���ͨ��")
                               { %>
                            <span class="opspan opupass"><a style="color: #4482b4;" href="?end=<%= strId %>&Aid=<%= strThemeGuid %>&jk"
                                onclick=" return window.confirm('��ȷ��Ҫ������?'); ">����</a></span>|
                            <% } %>
                            <span class="opspan opdel"><a style="color: #4482b4;" href="?delete=<%= strId %>&Aid=<%= strThemeGuid %>&jk"
                                onclick=" return window.confirm('��ȷ��Ҫɾ����?'); ">ɾ��</a></span>
                        </td>
                    </tr>
                    <!--ѭ������-->
                    <% }
                       }
                       else
                       { %>
                    <tr>
                        <td colspan="7">
                            <center>
                                û���ҵ����������Ʒ��</center>
                        </td>
                    </tr>
                    <% } %>
                    <tr class="lmf_page" align="right" style="background-color: #F7F7DE; color: Black;">
                        <td style="height: 30px;" colspan="10">
                            <div class="btnlist" style="display: none; overflow: auto;">
                                <div class="fnum">
                                    ÿҳ��ʾ������ <a href="?pagesize=10">10</a><a href="?pagesize=20">20</a><a href="?pagesize=50">50</a>
                                </div>
                                <div class="page" id="pageDiv" runat="server">
                                </div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <input type="hidden" id="CheckGuid" runat="server" value="0" />
    </form>
</body>
</html>
