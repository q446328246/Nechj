<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopNum1_SupplyDemandCheck_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ShopNum1_SupplyDemandCheck_List" %>


<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>������Ϣ����б�</title>
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
                    <asp:Label ID="LabelTitle" runat="server" Text="������Ϣ����б�" /></h3>
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
                                <asp:Localize ID="LocalizeFavourTickitName" runat="server" Text="�������ࣺ"></asp:Localize>
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
                                <asp:Localize ID="Localize1" runat="server" Text="���״̬��"></asp:Localize>
                            </td>
                            <td style="display:none;">
                                <asp:DropDownList ID="DropDownListIsAudit" runat="server" CssClass="tselect" Style="width: 201px;">
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;�����ˣ�
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxMemberID" runat="server" CssClass="tinput" Width="180" ></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;&nbsp;&nbsp;�������ͣ�
                            </td>
                            <td>
                                <asp:DropDownList ID="DropDownListTradeType" runat="server" CssClass="tselect" >
                                <asp:ListItem Value="-1" Text="-��ѡ��-"></asp:ListItem>
                                <asp:ListItem Value="0" Text="��"></asp:ListItem>
                                <asp:ListItem Value="1" Text="��"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                &nbsp;&nbsp;
                            </td>
                            <td>
                                <asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" CssClass="dele" OnClick="ButtonSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:Button ID="ButtonSerch" runat="server" Text="�鿴" CssClass="dele" 
                                    OnClientClick="return EditButton()" OnClick="ButtonSerch_Click" Visible="false" />
                             </td>
                             <td>
                                    <asp:LinkButton ID="ButtonAudit" runat="server" OnClick="ButtonAudit_Click" OnClientClick="return AuditButton()"
                                CssClass="shtg lmf_btn"  CausesValidation="False" ><span>���ͨ��</span></asp:LinkButton>
                             </td>
                             <td>&nbsp;</td>
                                <td>
                                <asp:LinkButton ID="ButtonCancelAudit" runat="server" OnClick="ButtonCancelAudit_Click"
                        OnClientClick="return AuditButton()" CssClass="shwtg lmf_btn"  CausesValidation="False" >
                        <span>���δͨ��</span></asp:LinkButton>   
                                </td>
                                <td>&nbsp;</td>
                                 <td>
                                    <asp:LinkButton  ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick="return DeleteButton()"
                         CssClass="shanchu lmf_btn"  CausesValidation="False" >
                         <span>����ɾ��</span></asp:LinkButton>
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
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceDate" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical" Style="margin-top: 15px;">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--��ҳ--%>
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
                    <asp:TemplateField HeaderText="��Ϣ����">
                        <ItemTemplate>
                            <a href='<%#ShopUrlOperate.RetUrl("SupplyDemandDetail",Eval("ID").ToString()) %>'
                                target="_blank">
                                <%# Eval("Title").ToString().Length > 26 ? Eval("Title").ToString().Substring(0, 26) : Eval("Title").ToString()%></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MemberID" HeaderText="������" SortExpression="MemberID"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="��������" DataField="CategoryName" ItemStyle-HorizontalAlign="Center"
                        SortExpression="CategoryName" />
                    <asp:TemplateField HeaderText="��������">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%# ShowTradeType(Eval("TradeType")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��Ϣ��Ч��">
                        <ItemTemplate>
                            <asp:Label ID="Label3" runat="server" Text='<%# GetValidateTime(Eval("ValidTime")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="���״̬">
                        <ItemTemplate>
                            <%#Audit(Eval("IsAudit").ToString())%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="���" DataField="OrderID" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "SupplyDemandDetails.aspx?guid="+Eval("ID")+"&type=audit" %>" style="color: #4482b4;">
                                �鿴</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("ID") %>' OnClientClick="return window.confirm('��ȷ��Ҫɾ����?');">ɾ��</asp:LinkButton>
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
