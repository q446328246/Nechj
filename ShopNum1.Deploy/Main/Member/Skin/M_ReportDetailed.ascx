<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_ReportDetailed.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_ReportDetailed" %>
<asp:Repeater ID="RepeaterShow" runat="server">
    <ItemTemplate>
        <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
            <tr>
                <th colspan="2">
                    举报详细
                </th>
            </tr>
            <tr>
                <td class="bordleft" style="text-align: right;">
                    会员举报信息：
                </td>
                <td>
                    <table width="100%" cellpadding="1" cellspacing="0" class="xj_table">
                        <tr>
                            <td class="bordleft1" style="text-align: right;" width="130">
                                举报商家的ID号：
                            </td>
                            <td class="bordrig">
                                <%#Eval("ReportShop") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                商品链接：
                            </td>
                            <td class="bordrig">
                                <a target="_blank" href='<%#Eval("ProductUrl") %>'>
                                    <%#Eval("ProductUrl") %></a>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                举报类型：
                            </td>
                            <td class="bordrig">
                                <%#Eval("ReportType") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                证据：
                            </td>
                            <td class="bordrig" style="padding-top: 8px;">
                                <%#Eval("Evidence") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                证据图片：
                            </td>
                            <td class="bordrig">
                                <asp:Image ID="ImageUrl" ImageUrl='<%#Eval("EvidenceImage") %>' runat="server" Width="100"
                                    Height="100" onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="bordleft2" style="text-align: right;" width="130">
                    店铺申诉信息：
                </td>
                <td>
                    <table width="100%" cellpadding="1" cellspacing="0" class="xj_table">
                        <tr>
                            <td class="bordleft1" style="text-align: right;" width="130">
                                是否申诉：
                            </td>
                            <td class="bordrig">
                                <%#Eval("IsComplaint").ToString()=="1"?"已申诉":"未申诉" %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                申诉内容：
                            </td>
                            <td class="bordrig">
                                <%#Eval("ComplaintContent") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                申诉图片：
                            </td>
                            <td class="bordrig">
                                <asp:Image ID="ImageProductImage" runat="server" ImageUrl='<%#Eval("ComplaintImage") %>'
                                    Width="100" Height="100" onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                申诉时间：
                            </td>
                            <td class="bordrig" style="padding-top: 8px;">
                                <%#Eval("ComplaintTime") %>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td class="bordleft2" style="text-align: right; border-bottom: 1px solid #C6DFFF;"
                    width="130">
                    平台处理信息：
                </td>
                <td>
                    <table width="100%" cellpadding="1" cellspacing="0" class="xj_table">
                        <tr>
                            <td class="bordleft1" style="text-align: right;" width="130">
                                处理状态：
                            </td>
                            <td class="bordrig">
                                <%#ShopNum1.MemberWebControl.M_MyReport.ProcessingStatus( Eval("ProcessingStatus").ToString())%>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right;">
                                处理结果：
                            </td>
                            <td class="bordrig">
                                <%#Eval("ProcessingResults") %>
                            </td>
                        </tr>
                        <tr>
                            <td class="bordleft1" style="text-align: right; border-bottom: 1px solid #C6DFFF;">
                                处理时间：
                            </td>
                            <td class="bordrig" style="border-bottom: 1px solid #C6DFFF;">
                                <%#Eval("ProcessingTime") %>
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
