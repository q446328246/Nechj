<%@ Control Language="C#" EnableViewState="false" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<%@ Import Namespace="System.Data" %>
<% DataTable dt = S_Limit_ActivityList.dt_LimitActivity; %>
<div id="list_main">
    <ul id="sidebar">
        <li id="0" class='TabbedPanelsTab TabbedPanelsTabSelected'>活动列表</li>
    </ul>
    <div id="content" class="ordmain1">
        <div class="biaogenr">
            <table width="100%" cellspacing="0" cellpadding="0" border="0" class="blue_tb2">
                <tr>
                    <th width="40%" class="th_le">
                        活动名称
                    </th>
                    <th width="10%">
                        组合销售价格
                    </th>
                    <th width="15%">
                        商品数量
                    </th>
                    <th width="15%">
                        状态
                    </th>
                    <th width="10%" class="th_ri">
                        操作
                    </th>
                </tr>
                <!--循环代码-->
                <asp:Repeater ID="repPackAge" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td align="left">
                                <div style="display: block; float: left;">
                                    <img src='<%#Eval("pic") %>_60x60.jpg' onerror=" javascript:this.src = '/ImgUpload/noImg.jpg_60x60.jpg'; " />
                                </div>
                                <div style="display: block; float: left; padding-left: 10px; text-align: left; width: 210px;">
                                    <%#Eval("name") %></div>
                            </td>
                            <td>
                                <%#Eval("SalePrice") %>
                            </td>
                            <td>
                                <%#Eval("pcount") %>
                            </td>
                            <td>
                                <%#Eval("statetxt") %>
                            </td>
                            <td>
                                <a class="alink_blue" onclick=" if (confirm('是否删除?')) {window.location.href = '?del=<%#Eval("id") %>&sign=del';} else {return false;} ">
                                    删除</a> <a class="alink_blue" href='S_PackAgeOpreate.aspx?memloginId=<%#Eval("memloginid") %>&packid=<%#Eval("id") %>'>
                                        编辑</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
                <!--循环代码-->
            </table>
            <div class="btntable_tbg">
                <div id="pageDiv" runat="server" class="fy">
                </div>
            </div>
        </div>
    </div>
</div>
