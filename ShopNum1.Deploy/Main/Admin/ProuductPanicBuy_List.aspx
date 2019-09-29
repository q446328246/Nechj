<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ProuductPanicBuy_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ProuductPanicBuy_List" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>主平台-商品抢购列表</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="left: -1000px; position: absolute; top: 377px; visibility: hidden;" id="dhtmltooltip">
        <img src="" height="200" width="200px">
    </div>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    抢购商品列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Localize ID="LocalizeName" runat="server" Text=" 商品名称："></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="display: none;">
                            <asp:Localize ID="LocalizeRepertoryNumber" runat="server" Text="商品编号："></asp:Localize>
                        </td>
                        <td style="display: none;">
                            <asp:TextBox ID="TextBoxRepertoryNumber" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="display: none;">
                            <asp:Localize ID="LocalizeProductGuid" runat="server" Text="商品分类："></asp:Localize>
                        </td>
                        <td style="display: none;">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DropDownListProductGuid1" runat="server" AutoPostBack="True"
                                        CssClass="tselect" Style="margin-right: 0; width: 100px;" OnSelectedIndexChanged="DropDownListProductGuid1_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid2" runat="server" AutoPostBack="True"
                                        CssClass="tselect" Style="margin-right: 0; width: 100px;" OnSelectedIndexChanged="DropDownListProductGuid2_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListProductGuid3" runat="server" CssClass="tselect"
                                        Style="margin-right: 0; width: 100px;">
                                    </asp:DropDownList>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizeShopName" runat="server" Text="店铺名称："></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="display: none; text-align: right;">
                            <asp:Localize ID="Localize1" runat="server" Text="会员ID："></asp:Localize>
                        </td>
                        <td style="display: none;">
                            <asp:TextBox ID="TextBoxShopID" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding" style="display: none; text-align: right;">
                            <asp:Localize ID="LocalizeIsAudit" runat="server" Text="是否上架："></asp:Localize>
                        </td>
                        <td style="display: none;">
                            <asp:DropDownList ID="DropDownListIsSaled" Width="207px" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            <asp:Localize ID="LocalizePrice" runat="server" Text="价格范围："></asp:Localize>
                        </td>
                        <td colspan="5">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxPrice1" runat="server" CssClass="tinput" Width="66"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorCostPrice1" runat="server"
                                            ControlToValidate="TextBoxPrice1" Display="Dynamic" ErrorMessage="价格格式不正确" ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxPrice2" runat="server" CssClass="tinput" Width="66"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPrice2"
                                            Display="Dynamic" ErrorMessage="价格格式不正确" ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <%--  <td align="right">
                            <asp:Localize ID="LocalizesSName" runat="server" Text="店主名称：" Visible="false" ></asp:Localize>
                        </td>--%>
                                    <td>
                                        <asp:TextBox ID="TextBoxSName" runat="server" CssClass="tinput" Width="200" Visible="false"></asp:TextBox>
                                        <asp:Button ID="ButtonSearch" OnClick="ButtonSearch_Click" runat="server" Text="查询"
                                            CssClass="dele" />
                                        <asp:DropDownList ID="DropDownListIsAudit" Visible="false" runat="server" CssClass="tselect"
                                            Style="width: 100px;">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top" style="display: none;">
                                <asp:DropDownList ID="DropDownListOperate" runat="server" CssClass="tselect" Style="width: 150px;">
                                    <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                                    <asp:ListItem Value="IsSell,1">可售</asp:ListItem>
                                    <asp:ListItem Value="IsSell,0">禁售</asp:ListItem>
                                    <asp:ListItem Value="IsSaled,1">上架</asp:ListItem>
                                    <asp:ListItem Value="IsSaled,0">取消上架</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonSee" runat="server" CssClass="dele" OnClick="ButtonSee_Click"
                                    OnClientClick=" return EditButton() " Visible="false"><span>查看</span></asp:LinkButton>
                            </td>
                            <td valign="top" style="display: none;">
                                <asp:LinkButton ID="ButtonEdit" runat="server" OnClientClick=" return AuditButton() "
                                    CssClass="zxcz lmf_btn" OnClick="ButtonOperate_Click"><span>执行操作</span></asp:LinkButton>
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
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceDate" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="商品名称" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a href='<%# ShopUrlOperate.shopDetailHref(Eval("Guid").ToString(), Eval("MemLoginID").ToString(), "ProductIsPanic_Detail") %>'
                                target="_blank">
                                <%#Utils.GetUnicodeSubString(Eval("Name").ToString(), 35, "") %></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="商品图片" SortExpression="OriginalImage" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <img src='<%# Page.ResolveUrl(Eval("OriginalImage").ToString()) %> ' onmouseover=" javascript:ddrivetip('<img width=200px height=200 src=<%# Page.ResolveUrl(Eval("OriginalImage").ToString()) %> >', '#ffffff'); "
                                onmouseout=" hideddrivetip() " height="20" width="20" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="商品价格" SortExpression="MarketPrice" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Label ID="LabelPrice" runat="server" Text='<%#Eval("MarketPrice") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="店铺名" SortExpression="ShopName">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString()) %>' target="_blank">
                                <asp:Label ID="Label3" runat="server" Text='<%# Bind("ShopName") %>'></asp:Label></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <%--   <asp:BoundField DataField="MemLoginID" HeaderText="会员ID" SortExpression="MemLoginID"
                        ItemStyle-HorizontalAlign="Center" />--%>
                    <asp:BoundField DataField="StartTime" HeaderText="开始时间" SortExpression="StartTime"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="EndTime" HeaderText="结束时间" SortExpression="EndTime" ItemStyle-HorizontalAlign="Center" />
                    <%--  <asp:BoundField HeaderText="编号" DataField="ProductNum" SortExpression="ProductNum"
                        ItemStyle-HorizontalAlign="Center" />--%>
                    <asp:BoundField DataField="SaleNumber" HeaderText=" 已销售数量" SortExpression="SaleNumber"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="库存" DataField="RepertoryCount" SortExpression="RepertoryCount"
                        ItemStyle-HorizontalAlign="Center" />
                    <%-- <asp:BoundField DataField="ProductCategoryName" HeaderText="所属分类" SortExpression="ProductCategoryName"
                        ItemStyle-HorizontalAlign="Center" />--%>
                    <%-- <asp:TemplateField HeaderText="是否可售" SortExpression="IsSell" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image ID="ImageIsSell" runat="server" src='<%# PageOperator.GetListImageStatus(Eval("IsSell").ToString()=="0"?"1":"0") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否上架" SortExpression="IsSaled" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image ID="ImageIsSaled" runat="server" src='<%# PageOperator.GetListImageStatus(Eval("IsSaled").ToString()=="0"?"1":"0") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    <asp:TemplateField HeaderText="审核状态" SortExpression="IsAudit" Visible="false">
                        <ItemTemplate>
                            <asp:Image ID="ImageIsAudit" runat="server" src='<%# PageOperator.GetListImageStatus(Eval("IsAudit").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <%-- <asp:BoundField HeaderText="排序号" DataField="OrderID" SortExpression="OrderID" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>--%>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "ProductSearchDetal.aspx?guid=" + Eval("Guid") + "&Type=Panic&Back=3" %>"
                                style="color: #4482b4;">查看</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
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
    </div>
    </form>
    <script type="text/javascript" src="js/showimg.js"> </script>
</body>
</html>
