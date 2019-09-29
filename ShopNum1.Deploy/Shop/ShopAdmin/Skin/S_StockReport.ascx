<%@ Control Language="C#" %>
<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="ShopNum1.ShopAdminWebControl" %>
<div id="content" class="ordmain1">
    <div class="pad">
        <table cellspacing="0" cellpadding="0" border="0" class="lineh">
            <tr class="up_spac">
                <td align="right">
                    <asp:Label ID="LabelProductCategoryID" runat="server" Text="商品分类："></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DropDownListProductCategoryID" runat="server" CssClass="tselect">
                    </asp:DropDownList>
                </td>
                <td align="right" class="ss_nr_spac">
                    <asp:Label ID="LabelShopPrice" runat="server" Text="销售数量："></asp:Label>
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBoxSaleNumber1" runat="server" CssClass="ss_nrduan" Style="background: none;"
                                    MaxLength="5"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidatorRepertory" runat="server"
                                    ControlToValidate="TextBoxSaleNumber1" ErrorMessage="输入数字" ValidationExpression="^[0-9]*$"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                            <td class="line_spac">
                                -
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxSaleNumber2" runat="server" CssClass="ss_nrduan" Style="background: none;"
                                    MaxLength="5"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxSaleNumber2"
                                    ErrorMessage="输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr class="up_spac">
                <td align="right">
                    <asp:Label ID="Label1" runat="server" Text="商品名称："></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TextBoxProductName" runat="server" CssClass="ss_nr1" MaxLength="30"></asp:TextBox>
                </td>
                <td align="right" class="ss_nr_spac">
                    <asp:Label ID="LabelMarketPrice" runat="server" Text="库存量："></asp:Label>
                </td>
                <td>
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <asp:TextBox ID="TextBoxRepertoryCount1" runat="server" CssClass="ss_nrduan" Style="background: none;"
                                    MaxLength="5"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionTextBoxRepertoryCount1" runat="server"
                                    ControlToValidate="TextBoxRepertoryCount1" ErrorMessage="输入数字" ValidationExpression="^[0-9]*$"
                                    Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                            <td class="line_spac">
                                -
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxRepertoryCount2" runat="server" CssClass="ss_nrduan" Style="background: none;"
                                    MaxLength="5"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxRepertoryCount2"
                                    ErrorMessage="输入数字" ValidationExpression="^[0-9]*$" Display="Dynamic"></asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="chax btn_spc" />
                                <asp:CompareValidator ID="CompareValidatorTextBoxShopPrice2" runat="server" ErrorMessage="开始应低于末尾"
                                    Type="Double" Display="Dynamic" ControlToValidate="TextBoxSaleNumber2" ControlToCompare="TextBoxSaleNumber1"
                                    Operator="GreaterThan"></asp:CompareValidator>
                                <asp:CompareValidator ID="CompareValidatorTextBoxMarketPrice2" runat="server" ErrorMessage="开始应低于末尾"
                                    Type="Double" Display="Dynamic" ControlToValidate="TextBoxRepertoryCount2" ControlToCompare="TextBoxRepertoryCount1"
                                    Operator="GreaterThan"></asp:CompareValidator>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    <div class="btntable_tbg">
        <div style="padding-left: 14px;">
            <asp:Button ID="ButtonReport" runat="server" Text="导出到Excel" CausesValidation="False"
                CssClass="sqjdbzj1" />&nbsp;&nbsp;
            <asp:Button ID="ButtonHtml" runat="server" CausesValidation="False" CssClass="sqjdbzj1"
                OnClientClick=" javascript:document.getElementById('form1').target = '_blank';window.location.href = window.location.href; "
                Text="导出到Html" />
        </div>
    </div>
    <table cellspacing="0" cellpadding="0" border="0" class="blue_tbw1" width="100%">
        <tr>
            <th class="th_le" width="50%">
                商品名称
            </th>
            <th width="20%">
                所属分类
            </th>
            <th width="10%">
                货号
            </th>
            <th width="10%">
                已销售量
            </th>
            <th class="th_ri" width="10%">
                库存量
            </th>
        </tr>
        <asp:Repeater EnableViewState="False" ID="RepeaterShow" runat="server">
            <ItemTemplate>
                <tr>
                    <td class="th_le" style="text-align: left">
                        <%# ((DataRowView) Container.DataItem).Row["Name"] %>
                    </td>
                    <td style="text-align: center">
                        <%# ((DataRowView) Container.DataItem).Row["ProductSeriesName"] %>
                    </td>
                    <td style="text-align: center">
                        <%# ((DataRowView) Container.DataItem).Row["ProductNum"] %>
                    </td>
                    <td style="text-align: center">
                        <%# ((DataRowView) Container.DataItem).Row["SaleNumber"] %>
                    </td>
                    <td class="th_ri" style="text-align: center">
                        <%# ((DataRowView) Container.DataItem).Row["RepertoryCount"] %>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </table>
    <% if (RepeaterShow.Items.Count == 0)
       { %>
    <div class="no_datas">
        <div class="no_data">
            暂无数据</div>
    </div>
    <% } %>
    <div class="btntable_tbg">
        <!-- 分页部分-->
        <div class="pager" style="text-align: center;">
            <asp:Label ID="LabelPageMessage" runat="server"></asp:Label>
            &nbsp;<asp:HyperLink ID="lnkFirst" runat="server"><span class="fpager">[ 首页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkPrev" runat="server"><span class="fpager">| 上一页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkNext" runat="server"><span class="fpager">| 下一页</span></asp:HyperLink>
            <asp:HyperLink ID="lnkLast" runat="server"><span class="fpager">| 末页 ]</span></asp:HyperLink>
            &nbsp;<span class="fpager">转到
                <asp:Literal ID="lnkTo" runat="server" />
                页</span>
        </div>
    </div>
</div>
<script type="text/javascript" language="javascript">
    $(function () {
        $("#selectPage").change(function () {
            var sreport = $(this).attr("lang");
            location.href = sreport + "?page=" + $(this).find("option:selected").val();
        });
    });
</script>
