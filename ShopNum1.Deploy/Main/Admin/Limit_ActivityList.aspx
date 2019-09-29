<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Limit_ActivityList.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Limit_ActivityList" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ʱ�ۿۻ�б�</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="mhead">
            <div class="ml">
                <div class="mr">
                    <ul class="mul">
                        <li id="current1"><a href="Limit_ActivityList.aspx" class="cur">��б�</a> </li>
                        <li id="current2" style="display: none;"><a href="Limit_Setting.aspx">����</a> </li>
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
                            <input type="checkbox" onclick=" javascript:SelectAllCheckboxesNew(this); " id="checkboxAll">
                        </th>
                        <th scope="col">
                            �����
                        </th>
                        <th scope="col">
                            ��������
                        </th>
                        <th scope="col">
                            ��ʼʱ��
                        </th>
                        <th scope="col">
                            ����ʱ��
                        </th>
                        <th scope="col">
                            �ۿ�
                        </th>
                        <th scope="col">
                            ����
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <% if (dt != null)
                       {
                           for (int i = 0; i < dt.Rows.Count; i++)
                           {
                               string strId = dt.Rows[i]["id"].ToString();
                               string strName = dt.Rows[i]["name"].ToString();
                               string strAname = dt.Rows[i]["ShopName"].ToString();
                               string strStartTime = dt.Rows[i]["starttime"].ToString();
                               string strEndTime = dt.Rows[i]["endtime"].ToString();
                               string strState = dt.Rows[i]["state"].ToString();
                               switch (strState)
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
                                   case "5":
                                       strState = "δ���";
                                       break;
                               }
                    %>
                    <!--ѭ������-->
                    <tr style="cursor: default;" onmouseout=" Num1GridViewShow_mout(this) " onmouseover=" Num1GridViewShow_mover(this) ">
                        <td align="center" style="">
                            <input type="checkbox" value="<%= strId %>" name="subcheck" />
                        </td>
                        <td align="center">
                            <span id="Span1">
                                <%= strName %></span>
                        </td>
                        <td align="center">
                            <span id="Span2">
                                <%= strAname %></span>
                        </td>
                        <td align="center">
                            <span id="Span3">
                                <%= strStartTime %></span>
                        </td>
                        <td align="center">
                            <span id="Span4">
                                <%= strEndTime %></span>
                        </td>
                        <td align="center">
                            <span id="Span5">
                                <%= strState %></span>
                        </td>
                        <td align="center">
                            <span class="opspan"><a href="Limit_Product.aspx?lid=<%= strId %>">�鿴</a></span>|
                            <% if (strState == "δ���")
                               { %>
                            <span class="opspan oppass"><a style="color: #4482b4;" href="?agree=<%= strId %>&jk"
                                onclick=" return window.confirm('��ȷ��Ҫ���ͨ����?'); ">���ͨ��</a></span>| <span class="opspan opupass">
                                    <a style="color: #4482b4;" href="?disagree=<%= strId %>&jk" onclick=" return window.confirm('��ȷ��Ҫ����ͨ����?'); ">
                                        ����ͨ��</a></span>|
                            <% }
                               else if (strState == "���ͨ��")
                               { %>
                            <span class="opspan opupass"><a style="color: #4482b4;" href="?end=<%= strId %>&jk"
                                onclick=" return window.confirm('��ȷ��Ҫ������?'); ">����</a></span>|
                            <% } %>
                            <span class="opspan opdel"><a style="color: #4482b4;" href="?delete=<%= strId %>&jk"
                                onclick=" return window.confirm('��ȷ��Ҫɾ����?'); ">ɾ��</a></span>
                        </td>
                    </tr>
                    <!--ѭ������-->
                    <% }
                               }
                       else
                       { %>
                    <tr>
                        <td colspan="9">
                            <center>
                                û���ҵ���������ۿۻ��</center>
                        </td>
                    </tr>
                    <% } %>
                    <tr class="lmf_page" align="right" style="background-color: #F7F7DE; color: Black;">
                        <td style="height: 30px;" colspan="10">
                            <div class="btnlist" style="overflow: auto;">
                                <div class="fnum">
                                    ÿҳ��ʾ������ <a href="?pagesize=10">10</a><a href="?pagesize=20">20</a><a href="?pagesize=50">50</a>
                                </div>
                                <div class="fpage" id="pageDiv" runat="server">
                                </div>
                                <script type="text/javascript" language="javascript">
                                    $(function () {
                                        $(".fpage").find("input").click(function () {
                                            alert("t");
                                            location.href = "?pageid=" + $("input[name='vjpage']").val();
                                        });
                                    });
                                </script>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
    <input type="hidden" id="CheckGuid" runat="server" />
    </form>
</body>
</html>
