<%@ Control Language="C#" EnableViewState="false"%>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Import Namespace="System.Data" %>
<div class="bBox bBoxnt">
    <h2>
        资讯列表</h2>
    <div class="sp-message">
        <asp:Panel ID="PanelNoFind" runat="server" Visible="false">
            <p class="nofind">没有找到符合条件的资讯！</p>
        </asp:Panel>
        <ul>
        <asp:Repeater ID="RepeaterShow" runat="server">
            <ItemTemplate>
            <li>
                <div class="mes-lists">
                    <div class="mes-imgs">
                        <span><%# Eval("ClickCount")%></span></div>
                    <div class="mes_h3">
                        <h5><a href='<%# GetPageName.RetUrl("NewsDetail",Eval("guid"))%>' target="_blank">
                            
                                <%# Eval("Title")%>
                        </a></h5>
                        <div class="mes_content">
                            <a  href='<%# GetPageName.RetUrl("NewsDetail",Eval("guid"))%>'>[查看详细]</a></div>
                        <p>分类：<%# Eval("Name")%>&nbsp;&nbsp;&nbsp;来源：<%# Eval("MemLoginID")%>&nbsp;&nbsp;&nbsp;发布时间：<%# Eval("CreateTime")%></p>
                    </div>
                </div>
            </li>
             </ItemTemplate>
        </asp:Repeater>
        </ul>
    </div>
    <div class="content" style="display:none;">
        <table width="100%" border="0" cellpadding="0" cellspacing="1" style="text-align: center; display:none;" class="table1">
            <tr>
                <td width="50%" style="background: #D4D4D4; color: #D60000; font-size: 14px; font-weight: bold;">
                    资讯标题
                </td>
                <td width="50%" style="background: #D4D4D4; color: #D60000; font-size: 14px; font-weight: bold;">
                    添加日期
                </td>
            </tr>
        </table>    
        <asp:HiddenField ID="HiddenFieldGuid" runat="server" />
    </div>
</div>
<!-- 分页部分-->
<div class="pager" style="display: none;">
    <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
    &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
    <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
    &nbsp;<span class="fpager">转到
        <asp:Literal ID="lnkTo" runat="server" />
        页</span>
</div>
<!--分页-->
<div class="fenye">
    <div class="lambert">
        <table cellpadding="0" cellspacing="0" border="0">
            <tr>
                <td><span class="fenye1">共</span></td>
                <td><span><asp:Label ID="LabelPageCount" runat="server" Text=""></asp:Label></span></td>
                <td><span class="fenye2">页，到第</span></td>
                <td><asp:TextBox ID="TextBoxIndex" runat="server" CssClass="pro_input"></asp:TextBox></td>
                <td class="fenye_td1"><span class="fenye3">页</span></td>
                <td class="fenye_td2"><asp:Button ID="ButtonSure" runat="server" Text="Button" CssClass="pro_btn" /></td>
            </tr>
        </table>
    </div>
    <div id="pageDiv" runat="server" class="pro_page">
        <div class="black2 ">
            <span class="disabled">< </span><span class="current">1</span><a href="#?page=2">2</a><span
                class="diandian">...</span> <a href="#?page=200">200</a> <a href="#?page=2">></a>
        </div>
    </div>
</div>
