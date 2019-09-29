<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.Common" %>
<script type="text/javascript" language="javascript">
    var obj;
    function list(cs1) {
        obj = document.getElementById(cs1);
        if (obj) {
            if (obj.style.display == 'none') {
                obj.style.display = '';
            }
            else {
                obj.style.display = 'none';
            }
        }
    }

</script>
<table align="left" border="0" cellpadding="3">
    <tbody>
        <tr id="TRqqTitle" runat="server">
            <td colspan="2">
                <div align="left">
                    <a href="javascript:list('OnLineService_ctl00_TRqqContent');">
                        <div style="background: url(/Main/Themes/Skin_Default/Images/070529qq.jpg); width: 166px;
                            height: 25px;">
                        </div>
                    </a>
                </div>
            </td>
        </tr>
        <tr id="TRqqContent" style="display: none;" runat="server">
            <td>
                <table align="center" border="0" cellpadding="2" cellspacing="0">
                    <tbody>
                        <asp:Repeater EnableViewState="False" ID="RepeaterQQ" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <a href="http://wpa.qq.com/msgrd?V=1&Uin=<%# Eval("ServiceAccount") %>&Menu=yes"
                                            target="_blank">
                                            <img src="http://wpa.qq.com/pa?p=1:<%# Eval("ServiceAccount") %>:4" alt="点击这里给我发送消息"
                                                border="0" width="21" height="15"></a>
                                        <asp:Label ID="Label1" ForeColor="Red" Font-Size="12px" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr id="TRwwTitle" runat="server">
            <td colspan="2">
                <div align="left">
                    <a href="javascript:list('OnLineService_ctl00_TRwwContent');">
                        <div style="background: url(/Main/Themes/Skin_Default/Images/wangwang.jpg); width: 166px;
                            height: 25px;">
                        </div>
                    </a>
                </div>
            </td>
        </tr>
        <tr id="TRwwContent" style="display: none;" runat="server">
            <td>
                <table align="center" border="0" cellpadding="0" cellspacing="0">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <div align="center">
                                    <asp:Repeater EnableViewState="False" ID="RepeaterWW" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <a target="_blank" href='http://amos1.taobao.com/msg.ww?v=2&uid=<%# Eval("ServiceAccount") %>&s=1'
                                                        style="text-decoration: none">
                                                        <img border="0" src='<%# Globals.SkinPath+"/Images/wangwang.gif" %>' width="21" height="21" />
                                                        <asp:Label ID="Label1" ForeColor="Red" Font-Size="12px" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                    </a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr id="TRmsnTitle" runat="server">
            <td colspan="2">
                <div align="left">
                    <a href="javascript:list('OnLineService_ctl00_TRmsnContent');">
                        <div style="background: url(/Main/Themes/Skin_Default/Images/MSN.jpg); width: 166px;
                            height: 25px;">
                        </div>
                    </a>
                </div>
            </td>
        </tr>
        <tr id="TRmsnContent" style="display: none;" runat="server">
            <td>
                <table align="center" border="0" cellpadding="2" cellspacing="0">
                    <tbody>
                        <div align="right">
                            <asp:Repeater EnableViewState="False" ID="RepeaterMSN" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td>
                                            <a href="msnim:chat?contact=<%# Eval("ServiceAccount") %> " target="_blank" style="text-decoration: none">
                                                <img border="0" src='<%# Globals.SkinPath+"/Images/msn.gif" %>' width="21" height="21" />
                                                <asp:Label ID="Label1" ForeColor="Red" Font-Size="12px" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                            </a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr id="TRbaiduTitle" runat="server">
            <td colspan="2">
                <div align="left">
                    <a href="javascript:list('OnLineService_ctl00_TRbaiduContent');">
                        <div style="background: url(/Main/Themes/Skin_Default/Images/baiduhai.jpg); width: 166px;
                            height: 25px;">
                        </div>
                    </a>
                </div>
            </td>
        </tr>
        <tr id="TRbaiduContent" style="display: none;" runat="server">
            <td>
                <table align="center" border="0" cellpadding="0" cellspacing="0">
                    <tbody>
                        <tr>
                            <td colspan="2">
                                <div align="center">
                                    <asp:Repeater EnableViewState="False" ID="RepeaterHi" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td>
                                                    <a href="http://web.im.baidu.com/?detail&amp;aid=6&default_tab= 1&&un=<%# Eval("ServiceAccount") %>"
                                                        target="_blank" style="text-decoration: none">
                                                        <img border="0" src='<%# Globals.SkinPath+"/Images/hi.gif" %>' width="21" height="21" />
                                                        <asp:Label ID="Label1" ForeColor="Red" Font-Size="12px" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                                                    </a>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
    </tbody>
</table>
