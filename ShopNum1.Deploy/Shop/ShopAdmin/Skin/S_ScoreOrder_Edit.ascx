<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <th colspan="2" scope="col">
                红包订单详细
            </th>
            <tr>
                <td class="bordleft" style="width: 100px">
                    订单号 ：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:Label ID="LabelOrderNumber" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    订单状态 ：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:Label ID="LabelOderStatus" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    买家 ：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:Label ID="LabelMemLoginID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="bordleft">
                    下单时间 ：
                </td>
                <td class="bordrig" style="padding-top: 8px;">
                    <asp:Label ID="LabelCreateTime" runat="server"></asp:Label>
                </td>
            </tr>
        </tr>
        <tr>
            <td class="bordleft">
                订单总红包：
            </td>
            <td class="bordrig" style="padding-top: 8px;">
                <asp:Label ID="LabelTotalScore" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <th colspan="5" scope="col">
                红包商品信息
            </th>
        </tr>
        <tr>
            <td class="bordleft" style="text-align: center; width: 100px;">
                商品图片
            </td>
            <td class="bordleft" style="text-align: center; width: 100px;">
                商品名称
            </td>
            <td class="bordleft" style="text-align: center; width: 100px;">
                商品红包
            </td>
            <td class="bordleft" style="text-align: center; width: 100px;">
                购买数量
            </td>
            <td class="bordleft" style="text-align: center; width: 100px;">
                小计(红包)
            </td>
        </tr>
        <asp:Repeater ID="RepeaterShopCart2" runat="server">
            <ItemTemplate>
                <tr>
                    <td style="text-align: center" width="100" class="bordleft">
                        <a target="_blank" href='<%#ShopUrlOperate.shopDetailHref(Eval("ProductGuid").ToString(), Eval("IsShopMemLoginID").ToString(), "ProductIntegral") %>'>
                            <asp:Image ID="ImageProduct" Width="100" Height="100" runat="server" ImageUrl='<%# Eval("OriginalImge") %>'
                                onerror="javascript:this.src='/ImgUpload/noImage.gif'" />
                        </a>
                    </td>
                    <td style="text-align: center" class="bordleft">
                        <a target="_blank" href='<%#ShopUrlOperate.shopDetailHref(Eval("ProductGuid").ToString(), Eval("IsShopMemLoginID").ToString(), "ProductIntegral") %>'>
                            <%# Eval("Name") %>
                        </a>
                    </td>
                    <td style="text-align: center" width="90" class="bordleft">
                        <%# Eval("ProductScore") %>
                    </td>
                    <td style="text-align: center" width="90" class="bordleft">
                        <%# Eval("BuyNumber") %>
                    </td>
                    <td style="text-align: center" width="100" class="bordleft">
                        <%#Eval("Score") %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <table width="100%" border="0" cellpadding="0" cellspacing="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <th colspan="4" scope="col">
                收货信息
            </th>
        </tr>
        <tr>
            <tr>
                <td style="text-align: right; width: 120px;" class="bordleft">
                    收货人姓名：
                </td>
                <td width="30%" class="bordrig">
                    <asp:Label ID="LabelName" runat="server" Text="&nbsp;"></asp:Label>
                </td>
                <td style="text-align: right" class="bordleft">
                    电子邮件（EMAIL）：
                </td>
                <td width="35%" class="bordrig">
                    <asp:Label ID="LabelEmail" runat="server" Text="&nbsp;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right" class="bordleft">
                    详细收货地址：
                </td>
                <td class="bordrig">
                    <asp:Label ID="LabelAddress" runat="server" Text="&nbsp;"></asp:Label>
                </td>
                <td style="text-align: right" class="bordleft">
                    邮政编码：
                </td>
                <td class="bordrig">
                    <asp:Label ID="LabelPostalcode" runat="server" Text="&nbsp;"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="text-align: right" class="bordleft">
                    手机号码：
                </td>
                <td class="bordrig">
                    <asp:Label ID="LabelMobile" runat="server" Text="&nbsp;"></asp:Label>
                </td>
                <td style="text-align: right">
                </td>
                <td>
                </td>
            </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="ButtonOderStatus" runat="server" Text="确定" CssClass="baocbtn" OnClientClick=" return funCheckButton() " />
        <asp:Button ID="ButtonBackList" runat="server" Text="返回" CssClass="baocbtn" />
    </div>
</div>
<asp:HiddenField ID="HiddenFieldID" runat="server" />
