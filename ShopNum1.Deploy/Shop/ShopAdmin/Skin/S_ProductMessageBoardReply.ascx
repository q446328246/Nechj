<div class="biaogenr">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod" style="margin-top: 15px;">
        <tr>
            <th colspan="2" scope="col">
                商品留言详细
            </th>
        </tr>
        <tr>
            <td class="bordleft">
                商品：
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelProductGuid" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                留言人：
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelMemLoginID" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                留言IP：
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelIPAddress" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                留言时间：
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelSendTime" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                留言内容：
            </td>
            <td class="bordrig" style="border-bottom: 1px solid #C6DFFF;">
                <textarea id="txtContent" runat="server" cssclass="op_area" textmode="MultiLine"
                    style="border: 1px solid #CCCCCC; width: 400px;" maxlength="200"></textarea>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                留言回复时间：
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelReplyTime" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft">
                是否回复：
            </td>
            <td class="bordrig">
                <asp:Label ID="LabelIsReply" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="bordleft" style="border-bottom: 1px solid #C6DFFF;">
                回复内容：
            </td>
            <td class="bordrig" style="border-bottom: 1px solid #C6DFFF;">
                <asp:TextBox ID="TextBoxReplyContent" runat="server" CssClass="op_area" TextMode="MultiLine"
                    MaxLength="200"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div class="op_btn">
        <asp:Button ID="btn_OK" runat="server" Text="确定" CssClass="querbtn" />
        <asp:Button ID="btn_Back" runat="server" Text="返回列表" CssClass="querbtn" />
    </div>
</div>
