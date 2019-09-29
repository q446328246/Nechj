<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="M_ComplaintsDetailed.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Member.Skin.M_ComplaintsDetailed" %>
<div id="content" class="ordmain1">
    <asp:Repeater ID="RepeaterShow" runat="server">
        <ItemTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
                <tr>
                    <th colspan="2">
                        投诉详细
                    </th>
                </tr>
                <tr>
                    <td class="bordleft2" style="text-align: right;">
                        会员投诉信息：
                    </td>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td class="bordleft1" style="text-align: right;" width="130">
                                    投诉商家的ID号：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("ComplaintShop") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="bordleft1" style="text-align: right;">
                                    订单编号：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("OrderID") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="bordleft1" style="text-align: right;">
                                    举报类型：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("ComplaintType") %>
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
                                    <%#Eval("IsAppeal").ToString()=="1"?"<font>已申诉</font>":"<font color:red>未申诉</font>" %>
                                </td>
                            </tr>
                            <tr>
                                <td class="bordleft1" style="text-align: right;">
                                    申诉内容：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("AppealContent") %>
                                </td>
                            </tr>
                            <tr>
                                <td class="bordleft1" style="text-align: right;">
                                    申诉图片：
                                </td>
                                <td class="bordrig">
                                    <asp:Image ID="ImageProductImage" runat="server" ImageUrl='<%#Eval("AppealImage") %>'
                                        Width="100" Height="100" onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
                                </td>
                            </tr>
                            <tr>
                                <td class="bordleft1" style="text-align: right;">
                                    申诉时间：
                                </td>
                                <td class="bordrig" style="padding-top: 8px;">
                                    <%#Eval("AppealTime") %>
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
                                    <%#Eval("ProcessingStatus").ToString()=="0"?"未处理":"已处理" %>
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
        <asp:Button ID="ButtonBackList" runat="server" Text="返回"  CssClass="baocbtn" 
            onclick="ButtonBackList_Click" />
    </div>
    <asp:HiddenField ID="HiddenFieldMember" runat="server" Value="no" />
</div>
