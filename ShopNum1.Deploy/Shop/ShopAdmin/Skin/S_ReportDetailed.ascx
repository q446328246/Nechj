<div class="biaogenr">
    <asp:Repeater ID="RepeaterShow" runat="server">
        <ItemTemplate>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
                <tr>
                    <th colspan="2" scope="col">
                        举报详细
                    </th>
                </tr>
                <tr>
                    <td class="bordleft" width="130" style="padding-right: 5px; text-align: right;">
                        会员举报信息：
                    </td>
                    <td class="bordrig" style="border-right: none; padding: 0;">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="130" style="padding-right: 5px; text-align: right;">
                                    举报商家的ID号：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("ReportShop") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-right: 5px; text-align: right;">
                                    商品链接：
                                </td>
                                <td class="bordrig">
                                    <a href='<%#Eval("ProductUrl") %>'>
                                        <%#Eval("ProductUrl") %></a>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-right: 5px; text-align: right;">
                                    举报类型：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("ReportType") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-right: 5px; text-align: right;">
                                    证据：
                                </td>
                                <td style="padding-top: 8px;" class="bordrig">
                                    <%#Eval("Evidence") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-bottom: none; padding-right: 5px; text-align: right;">
                                    证据图片：
                                </td>
                                <td style="border-bottom: none;" class="bordrig">
                                    <asp:Image ID="ImageUrl" ImageUrl='<%#Eval("EvidenceImage") %>' runat="server" Width="100"
                                        Height="100" onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130" style="padding-right: 5px; text-align: right;">
                        店铺申诉信息：
                    </td>
                    <td style="border-right: none; padding: 0;">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="130" style="padding-right: 5px; text-align: right;">
                                    是否申诉：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("IsComplaint").ToString() == "1" ? "已申诉" : "未申诉" %>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-right: 5px; text-align: right;">
                                    申诉内容：
                                </td>
                                <td class="bordrig">
                                    <textarea id="txtContent" style="border: 0px; width: 460px;"><%#Eval("ComplaintContent") %></textarea>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-right: 5px; text-align: right;">
                                    申诉图片：
                                </td>
                                <td class="bordrig">
                                    <a href='<%#Eval("EvidenceImage").ToString().Replace("~/", "/") %>' target="_blank">
                                        <asp:Image ID="Image1" ImageUrl='<%#Eval("EvidenceImage") %>' runat="server" Width="100"
                                            Height="100" onerror="javascript:this.src='/ImgUpload/noImage.gif'" /></a>
                                </td>
                            </tr>
                            <tr>
                                <td style="border-bottom: none; padding-right: 5px; text-align: right;">
                                    申诉时间：
                                </td>
                                <td class="bordrig" style="border-bottom: none;">
                                    <%#Eval("ComplaintTime") %>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="bordleft" width="130" style="padding-right: 5px; text-align: right;">
                        平台处理信息：
                    </td>
                    <td class="bordrig" style="border-right: none; padding: 0;">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td width="130" style="padding-right: 5px; text-align: right;">
                                    处理状态：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("ProcessingStatus").ToString() == "0" ? "未处理" : "已处理" %>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-right: 5px; text-align: right;">
                                    处理结果：
                                </td>
                                <td class="bordrig">
                                    <%#Eval("ProcessingResults") %>
                                </td>
                            </tr>
                            <tr>
                                <td style="padding-right: 5px; text-align: right;">
                                    处理时间：
                                </td>
                                <td style="padding-top: 8px;" class="bordrig">
                                    <%#Eval("ProcessingTime") %>
                                </td>
                            </tr>
                            <tr style="display: none;">
                                <td style="border-bottom: none; padding-right: 5px; text-align: right;">
                                    处理人：
                                </td>
                                <td style="border-bottom: none;" class="bordrig">
                                    <%#Eval("OperateUser") %>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:Repeater>
    <div class="op_btn">
        <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" />
    </div>
</div>
<asp:HiddenField ID="HiddenFieldMember" runat="server" Value="no" />
