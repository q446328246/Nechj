<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1_SupplyDemandCheck_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1_SupplyDemandCheck_List" %>


<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>供求信息审核列表</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelTitle" runat="server" Text="供求信息审核列表" /></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div>
                    <table border="0" cellspacing="0" cellpadding="0">
                        <tr style="height: 35px; vertical-align: top;">
                            <td style="text-align: right;">
                                <asp:Localize ID="LocalizeFavourTickitName" runat="server" Text="所属分类："></asp:Localize>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="DropDownListCommon_Cf" runat="server" AutoPostBack="true" CssClass="tselect"
                                            Style="width: 100px;" OnSelectedIndexChanged="DropDownListCommon_Cf_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:DropDownList ID="DropDownListCommon_Cs" runat="server" AutoPostBack="true" CssClass="tselect"
                                            Style="width: 100px;" OnSelectedIndexChanged="DropDownListCommon_Cs_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        &nbsp;
                                        <asp:DropDownList ID="DropDownListCommon_Ct" runat="server" CssClass="tselect" Style="width: 100px;">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="lmf_padding" style="text-align: right; display:none;">
                                <asp:Localize ID="Localize1" runat="server" Text="审核状态："></asp:Localize>
                            </td>
                            <td style="display:none;">
                                <asp:DropDownList ID="DropDownListIsAudit" runat="server" CssClass="tselect" Style="width: 201px;">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;发布人：
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMemberID" runat="server" CssClass="tinput" Width="180" ></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;交易类型：
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListTradeType" runat="server" CssClass="tselect" >
                                <asp:ListItem Value="-1" Text="-请选择-"></asp:ListItem>
                                <asp:ListItem Value="0" Text="供"></asp:ListItem>
                                <asp:ListItem Value="1" Text="求"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="dele" OnClick="ButtonSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:Button ID="ButtonSerch" runat="server" Text="查看" CssClass="dele" 
                                    OnClientClick="return EditButton()" OnClick="ButtonSerch_Click" Visible="false" />
                             </td>
                             <td>
                                    <asp:LinkButton ID="ButtonAudit" runat="server" OnClick="ButtonAudit_Click" OnClientClick="return AuditButton()"
                                CssClass="shtg lmf_btn"  CausesValidation="False" ><span>审核通过</span></asp:LinkButton>
                             </td>
                             <td>&nbsp;</td>
                                <td>
                                <asp:LinkButton ID="ButtonCancelAudit" runat="server" OnClick="ButtonCancelAudit_Click"
                        OnClientClick="return AuditButton()" CssClass="shwtg lmf_btn"  CausesValidation="False" >
                        <span>审核未通过</span></asp:LinkButton>   
                                </td>
                                <td>&nbsp;</td>
                                 <td>
                                    <asp:LinkButton  ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick="return DeleteButton()"
                         CssClass="shanchu lmf_btn"  CausesValidation="False" >
                         <span>批量删除</span></asp:LinkButton>
                                 </td>
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
                GridLines="Vertical" Style="margin-top: 15px;">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle  CssClass="lmf_page"  BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick="javascript: SelectAllCheckboxes(this);" type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="信息标题">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.RetUrl("SupplyDemandDetail",Eval("ID").ToString()) %>'
                                target="_blank">
                                <%# Eval("Title").ToString().Length > 26 ? Eval("Title").ToString().Substring(0, 26) : Eval("Title").ToString()%></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MemberID" HeaderText="发布人" SortExpression="MemberID"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="所属分类" DataField="CategoryName" ItemStyle-HorizontalAlign="Center"
                        SortExpression="CategoryName" />
                    <asp:TemplateField HeaderText="交易类型">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# ShowTradeType(Eval("TradeType")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="信息有效期">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# GetValidateTime(Eval("ValidTime")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="审核状态">
                        <ItemTemplate>
                            <%#Audit(Eval("IsAudit").ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="序号" DataField="OrderID" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "SupplyDemandDetails.aspx?guid="+Eval("ID")+"&type=audit" %>" style="color: #4482b4;">
                                查看</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("ID") %>' OnClientClick="return window.confirm('您确定要删除吗?');">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_SupplyDemandCheck_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="HiddenFieldCode" Name="code" PropertyName="Value"
                Type="String" />
            <asp:Parameter Name="associatedMemberID" Type="String" DefaultValue="" />
            <asp:ControlParameter ControlID="TextBoxMemberID" Name="MemberID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="DropDownListTradeType" Name="TradeType" PropertyName="SelectedValue"
                    Type="Int32" />
             <asp:ControlParameter ControlID="CheckAudit" Name="Audit" PropertyName="Value"
                    Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckAudit" runat="server" Value=""/>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </form>
</body>
</html>
