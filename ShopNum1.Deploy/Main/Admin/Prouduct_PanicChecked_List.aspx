<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Prouduct_PanicChecked_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.Prouduct_PanicChecked_List" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>抢购商品审核</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="抢购商品审核" /></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Localize ID="LocalizeName" runat="server" Text="商品名称："></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizeShopName" runat="server" Text="店铺名称："></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="display: none;">
                            <asp:Localize ID="LocalizeRepertoryNumber" runat="server" Text="商品编号："></asp:Localize>
                        </td>
                        <td style="display: none;">
                            <asp:TextBox ID="TextBoxRepertoryNumber" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizeProductGuid" runat="server" Text="商品分类："></asp:Localize>
                        </td>
                        <td>
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListProductGuid1" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownListProductGuid1_SelectedIndexChanged" CssClass="tselect"
                                        Style="width: 100px;">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid2" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DropDownListProductGuid2_SelectedIndexChanged" CssClass="tselect"
                                        Style="width: 100px;">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid3" runat="server" CssClass="tselect"
                                        Style="width: 100px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="text-align: right;">
                            <asp:Localize ID="Localize1" runat="server" Text="会员ID："></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopID" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizeIsAudit" runat="server" Text="审核状态："></asp:Localize>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsAudit" runat="server" Width="207px" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizePrice" runat="server" Text="价格范围："></asp:Localize>
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxPrice1" runat="server" CssClass="tinput" Style="width: 58px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorCostPrice1" runat="server"
                                            ControlToValidate="TextBoxPrice1" Display="Dynamic" ErrorMessage="价格格式不正确" ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxPrice2" runat="server" CssClass="tinput" Style="width: 58px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPrice2"
                                            Display="Dynamic" ErrorMessage="价格格式不正确" ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                        <asp:Button ID="ButtonSearch" OnClick="ButtonSearch_Click" runat="server" Text="查询"
                                            CssClass="dele" />
                                        <asp:DropDownList ID="DropDownListIsSaled" Visible="false" CssClass="tinput" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr style="display: none; height: 35px; vertical-align: top;">
                        <td>
                            <asp:Localize ID="LocalizesSName" runat="server" Text="店主名称;"></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top" style="display: none;">
                                <asp:LinkButton ID="ButtonSearchDetail" runat="server" Visible="false" CssClass="dele"
                                    OnClick="ButtonSearchDetail_Click" OnClientClick=" return EditButton() "><span>查看</span></asp:LinkButton>
                            </td>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonAudit" runat="server" CssClass="shtg lmf_btn" OnClick="ButtonAudit_Click"
                                    OnClientClick=" return AuditButton() "><span>审核通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonCancelAudit" runat="server" CssClass="shwtg lmf_btn" OnClientClick=" return AuditButton() "
                                    OnClick="ButtonCancelAudit_Click"><span>审核未通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click"
                                    OnClientClick=" return DeleteButton() "><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <cc1:num1gridview id="Num1GridViewShow" runat="server" autogeneratecolumns="False"
                allowpaging="True" allowsorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" width="98%" addsequencecolumn="False"
                allowmulticolumnsorting="False" bordercolor="#CCDDEF" borderstyle="Solid" borderwidth="0"
                cellpadding="4" del="False" deleteprompttext="确实要删除指定的记录吗？" edit="False" fixheader="False"
                gridviewsortdirection="Ascending" pagingstyle="None" style="margin: 0 auto;"
                tablename="" datasourceid="ObjectDataSourceDate">
                        <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White">
                        </HeaderStyle>
                        <PagerStyle  HorizontalAlign="Left"  CssClass="lmf_page"   BackColor="#F7F7DE" ForeColor="Black"></PagerStyle>
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <HeaderStyle CssClass="select_width" />

                                <ItemTemplate>
                                    <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品名称" SortExpression="Name">
                                <ItemTemplate>
                                    <a href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString(), "ProductListIsPanic") %>'
                                       target="_blank"><%#Utils.GetUnicodeSubString(Eval("Name").ToString(), 35, "") %></a>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="店铺名" SortExpression="ShopName">
                                <ItemTemplate>
                                    <a href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString()) %>' target="_blank">
                                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ShopName") %>'></asp:Label></a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="店铺ID" SortExpression="ShopID">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# "shop" + Eval("ShopID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="MemLoginID" HeaderText=" 会员ID" SortExpression="MemLoginID" />
                            <asp:BoundField HeaderText="库存" DataField="RepertoryCount" SortExpression="RepertoryCount" />
                            <asp:BoundField HeaderText="价格" DataField="MarketPrice" SortExpression="MarketPrice" />
                            <asp:TemplateField HeaderText="商品图片" SortExpression="OriginalImage">
                                <ItemTemplate>
                                    <img src='<%# Page.ResolveUrl(Eval("OriginalImage").ToString()) %> ' onmouseover=" javascript:ddrivetip('<img width=200px height=200 src=<%# Page.ResolveUrl(Eval("OriginalImage").ToString()) %> >', '#ffffff'); "
                                         onmouseout=" hideddrivetip() " height="20" width="20" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="审核状态" SortExpression="IsAudit">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Is(Eval("IsAudit")) %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <a href="<%# "ProductSearchDetal.aspx?guid=" + Eval("Guid") + "&Type=Panic&Back=3" %>"   style="color: #4482b4;">查看</a>
                                    <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                                    OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>
                        </Columns>
                    </cc1:num1gridview>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="SearchNew"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_ProuductChecked_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxName" Name="productName" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxRepertoryNumber" Name="ProductNum" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="HiddenFieldCode" Name="productCategory" PropertyName="Value"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxPrice1" Name="price1" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxPrice2" Name="price2" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListIsSaled" Name="isSaled" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListIsAudit" Name="isAudit" PropertyName="SelectedValue"
                Type="String" />
            <asp:Parameter DefaultValue="1" Name="isPanicBuy" Type="String" />
            <asp:Parameter DefaultValue="0" Name="isSpellBuy" Type="String" />
            <asp:ControlParameter ControlID="TextBoxShopID" Name="MemLoginID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxShopName" Name="shopName" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxSName" Name="sName" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </form>
    <script type="text/javascript" src="js/showimg.js"> </script>
</body>
</html>
