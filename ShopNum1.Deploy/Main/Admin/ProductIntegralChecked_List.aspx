<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ProductIntegralChecked_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ProductIntegralChecked_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>主平台-商品红包审核列表</title>
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
                    红包商品审核列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizeName" runat="server" Text=" 商品名称："></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="Localize1" runat="server" Text="会员ID："></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizePrice" runat="server" Text="红包范围："></asp:Localize>
                        </td>
                        <td>
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
                            </table>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonSee" runat="server" CssClass="chank2 lmf_btn" OnClick="ButtonSee_Click1"
                                    OnClientClick=" return EditButton() ">
                                            <span>查看</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonEdit" runat="server" OnClientClick=" return AuditButton() "
                                    CssClass="shtg lmf_btn" OnClick="ButtonOperate_Click"><span>审核通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonCancelAudit" runat="server" OnClick="ButtonCancelAudit_Click"
                                    OnClientClick=" return AuditButton() " CssClass="shwtg lmf_btn"><span>审核未通过</span></asp:LinkButton>
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
                            <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="商品名称" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%# Eval("Name").ToString().Length > 16 ? Eval("Name").ToString().Substring(0, 16) : Eval("Name").ToString() %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="红包" SortExpression="Score" ItemStyle-Width="50">
                        <ItemTemplate>
                            <%# Eval("Score") %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="会员ID" SortExpression="MemLoginID"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="库存" DataField="RepertoryCount" SortExpression="RepertoryCount"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField DataField="CreateTime" HeaderText="申请时间" SortExpression="SaleTime"
                        ItemStyle-Width="100" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="审核状态" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <%#Is(Eval("IsAudit").ToString()) %>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "ProductIntegralDetal.aspx?guid=" + Eval("Guid") + "&Type=0" %>" style="color: #4482b4;">
                                查看</a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="GetDataInfoInAdminNew"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Shop_ScoreProduct_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxName" Name="Name" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxRepertoryNumber" Name="RepertoryNumber" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxPrice1" Name="starJF" PropertyName="Text"
                    Type="Int32" DefaultValue="-1" />
                <asp:ControlParameter ControlID="TextBoxPrice2" Name="endJF" PropertyName="Text"
                    Type="Int32" DefaultValue="-1" />
                <asp:Parameter DefaultValue="0" Name="IsAudit" Type="Int32" />
                <asp:ControlParameter ControlID="HiddenFieldCode" Name="ProductCategoryCode" PropertyName="Value"
                    Type="String" />
                <asp:Parameter DefaultValue="0" Name="IsDeleted" Type="String" />
                <asp:Parameter DefaultValue="-1" Name="IsSaled" Type="Int32" />
                <asp:ControlParameter ControlID="TextBoxMemLoginID" Name="MemLoginID" PropertyName="Text"
                    Type="String" />
                <asp:Parameter DefaultValue="-1" Name="IsNew" Type="Int32" />
                <asp:Parameter DefaultValue="-1" Name="IsHot" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </div>
    <script type="text/javascript" src="js/showimg.js"> </script>
    <div style="display: none">
        <asp:TextBox ID="TextBoxRepertoryNumber" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
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
    </div>
    </form>
</body>
</html>
