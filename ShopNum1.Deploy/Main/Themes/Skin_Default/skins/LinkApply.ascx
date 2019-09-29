<%@ Control Language="C#" %>
<%@ Import Namespace="ShopNum1.WebControl" %>
<div class="ApplyLink">
    <div class="all_top">
        <span class="latest_shop1 fl">申请友情链接</span>
    </div>
    <div class="ApplyLink_con">
        <div class="ApplyStep fl">
            <h1>
                申请步骤</h1>
            <p>
                1.请先在贵网站做好<%=LinkApply.Name %>的文字友情链接：链接文字：<%=LinkApply.Name %>
                链接地址：<%=LinkApply.NetName %></p>
            <p>
                2.做好链接后，请在右侧填写申请信息。<%=LinkApply.Name %>只接受申请文字友情链接</p>
            <p>
                3.已经开通我站友情链接且内容健康向上的网站，经<%=LinkApply.Name %>审核后，可以显示在此友情链接页面。</p>
            <p>
                4.PR值≥5的网站，有希望显示在<%=LinkApply.Name %>的首页。</p>
        </div>
        <div class="ApplyInfo fr">
            <h1>
                申请信息</h1>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td align="right">
                        网站名称：
                    </td>
                    <td>
                        <ShopNum1:TextBox ID="TextBoxName" runat="server" MaxLength="50" HintInfo="网站名称，正确的网站名称"
                            HintTitle="网站名称" CanBeNull="必填" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        网址：<td>
                            <ShopNum1:TextBox ID="TextBoxHref" CanBeNull="必填" runat="server" RequiredFieldType="网页地址"
                                HintInfo="网站地址,填写正确的网站首页的地址" HintTitle="网站地址" />
                        </td>
                </tr>
                <tr>
                    <td align="right">
                        网站介绍：
                    </td>
                    <td>
                        <ShopNum1:TextBox ID="TextBoxDescription" TextMode="MultiLine" runat="server" HintInfo="网站介绍"
                            HintTitle="网站介绍" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        网站备注：
                    </td>
                    <td>
                        <ShopNum1:TextBox ID="TextBoxMemo" TextMode="MultiLine" runat="server" HintInfo="网站备注"
                            HintTitle="网站备注" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <div align="left">
                            <asp:Button ID="ButtonApply" type="reset" name="button2" runat="server" Text="提交申请"
                                CssClass="linksbtn" />
                        </div>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</div>
