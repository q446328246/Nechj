<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_MyMessageBoardDetailed.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_MyMessageBoardDetailed" %>
<asp:Repeater ID="RepeaterShow" runat="server">
    <ItemTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
            <tr>
                <th colspan="2">
                    我的店铺留言详细
                </th>
            </tr>
            <tr>
                <td class="bordleft" style="text-align: right;">
                    我的店铺留言信息：
                </td>
                <td>
                    <table width="100%" cellpadding="1" cellspacing="0" class="xj_table">
                        <tr>
                            <td class="bordleft1" style="text-align: right;" width="130">
                                留言类型：
                            </td>
                            <td class="bordrig">
                                <%#ShopNum1.MemberWebControl.M_MyMessageBoard.GetMessageTypeName(Eval("MessageType").ToString())%>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                留言标题：
                            </td>
                            <td class="bordrig">
                                <%#Eval("Title") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                留言内容：
                            </td>
                            <td class="bordrig">
                                <%#Eval("Content") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                留言时间：
                            </td>
                            <td class="bordrig" style="padding-top: 8px;">
                                <%#Eval("SendTime") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                是否前台展示：
                            </td>
                            <td class="bordrig" style="padding-top: 8px;">
                                <%#Eval("IsShow").ToString()=="1"?"显示":"不显示" %>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="bordleft2" style="text-align: right; border-bottom: 1px solid #C6DFFF;">
                    店铺回复信息：
                </td>
                <td>
                    <table width="100%" cellpadding="1" cellspacing="0" class="xj_table">
                        <tr>
                            <td class="bordleft1" style="text-align: right;" width="130">
                                是否回复：
                            </td>
                            <td class="bordrig">
                                <%#Eval("IsReply").ToString()=="1"?"已回复":"未回复" %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                回复店铺：
                            </td>
                            <td class="bordrig">
                                <a target="_blank" href='<%#ShopUrlOperate.shopHref(Eval("ReplyUser").ToString())%>'>
                                    <%#ShopNum1.MemberWebControl.M_MyMessageBoard.GetShopName(Eval("ReplyUser").ToString())%>
                                </a>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                回复内容：
                            </td>
                            <td class="bordrig">
                                <%#Eval("ReplyContent") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right; border-bottom: 1px solid #C6DFFF;">
                                回复时间：
                            </td>
                            <td class="bordrig" style="padding-top: 8px; border-bottom: 1px solid #C6DFFF;">
                                <%#Eval("ReplyTime") %>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ItemTemplate>
</asp:Repeater>
<div style="text-align: center; margin: 20px 0px 50px 0px;">
    <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" OnClick="ButtonBackList_Click" />
</div>
<asp:HiddenField ID="HiddenFieldMember" runat="server" Value="no" />
