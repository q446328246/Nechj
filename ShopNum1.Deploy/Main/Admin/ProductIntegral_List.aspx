<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ProductIntegral_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.ProductIntegral_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>��ƽ̨-��Ʒ����б�</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"></script>
    <script type='text/javascript' src='js/resolution-test.js'></script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="left: -1000px; top: 377px; visibility: hidden; position: absolute;" id="dhtmltooltip">
        <img src="" height="200" width="200px">
    </div>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    �����Ʒ�б�</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="text-align: right;">
                            <asp:Localize ID="LocalizeName" runat="server" Text=" ��Ʒ���ƣ�"></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="Localize1" runat="server" Text="��ԱID��"></asp:Localize>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMemLoginID" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizeIsAudit" runat="server" Text="�Ƿ��ϼܣ�"></asp:Localize>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsSaled" Width="207px" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="text-align: right;">
                            <asp:Localize ID="LocalizePrice" runat="server" Text="�����Χ��"></asp:Localize>
                        </td>
                        <td colspan="3">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxPrice1" runat="server" CssClass="tinput" Style="width: 58px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidatorCostPrice1" runat="server"
                                            ControlToValidate="TextBoxPrice1" Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ" ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxPrice2" runat="server" CssClass="tinput" Style="width: 58px;"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBoxPrice2"
                                            Display="Dynamic" ErrorMessage="�۸��ʽ����ȷ" ValidationExpression="^[0-9]+(.[0-9]{1,3})?$"></asp:RegularExpressionValidator>
                                    </td>
                                    <%--  <td align="right">
                            <asp:Localize ID="LocalizesSName" runat="server" Text="�������ƣ�" Visible="false" ></asp:Localize>
                        </td>--%>
                                    <td>
                                        <asp:TextBox ID="TextBoxSName" runat="server" CssClass="tinput" Width="200" Visible="false"></asp:TextBox>
                                        <asp:Button ID="ButtonSearch" OnClick="ButtonSearch_Click" runat="server" Text="��ѯ"
                                            CssClass="dele" />
                                        <asp:DropDownList ID="DropDownListIsAudit" Visible="false" runat="server" CssClass="tselect"
                                            Style="width: 100px;">
                                        </asp:DropDownList>
                                    </td>
                            </table>
                        </td>
                        <td class="lmf_padding" style="text-align: right;">
                        </td>
                        <td>
                        </td>
                        <td class="lmf_padding">
                        </td>
                    </tr>
                    <tr style="height: 35px; vertical-align: top; display: none;">
                        <td class="lmf_padding" style="text-align: right;">
                            <asp:Localize ID="Localize2" runat="server" Text="�Ƿ�������"></asp:Localize>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsHot" Width="207px" runat="server" CssClass="tselect">
                                <asp:ListItem Text="-ȫ��-" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="��" Value="1"></asp:ListItem>
                                <asp:ListItem Text="��" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
                            <asp:Localize ID="LocalizeIsNew" runat="server" Text="�Ƿ����£�"></asp:Localize>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsNew" Width="207px" runat="server" CssClass="tselect">
                                <asp:ListItem Text="-ȫ��-" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="��" Value="1"></asp:ListItem>
                                <asp:ListItem Text="��" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:DropDownList ID="DropDownListOperate" runat="server" CssClass="tselect" Style="width: 150px;">
                                    <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    <asp:ListItem Value="1">�ϼ�</asp:ListItem>
                                    <%--<asp:ListItem Value="2">��Ϊ��Ʒ</asp:ListItem>
                        <asp:ListItem Value="3">��Ϊ����</asp:ListItem>--%>
                                    <asp:ListItem Value="0">--------</asp:ListItem>
                                    <asp:ListItem Value="4">�¼�</asp:ListItem>
                                    <%--<asp:ListItem Value="5">ȡ����Ʒ</asp:ListItem>
                        <asp:ListItem Value="6">ȡ������</asp:ListItem>--%>
                                </asp:DropDownList>
                            </td>
                            <td valign="top" class="lmf_app" style="display: none;">
                                <asp:LinkButton ID="ButtonSee" runat="server" CssClass="dele" OnClick="ButtonSee_Click"
                                    OnClientClick="return EditButton()" Visible="false"><span>�鿴</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonEdit" runat="server" OnClientClick="return OperateButton()"
                                    CssClass="zxcz lmf_btn" OnClick="ButtonOperate_Click"><span>ִ�в���</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click"
                                    OnClientClick="return DeleteButton()"><span>����ɾ��</span></asp:LinkButton>
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
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--��ҳ--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="��Ʒ����" SortExpression="Name" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <a target="_blank" href='<%#ShopUrlOperate.shopDetailHref(Eval("Guid").ToString(),Eval("MemLoginID").ToString(),"ProductIntegral")%>'
                                class="sroceimg">
                                <%# Eval("Name").ToString().Length > 16 ? Eval("Name").ToString().Substring(0, 16) : Eval("Name").ToString()%>
                            </a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ͼƬ" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <img src='<%# Page.ResolveUrl(Eval("OriginalImge").ToString())%> ' onmouseover="javascript:ddrivetip('<img width=200px height=200 src=<%# Page.ResolveUrl(Eval("OriginalImge").ToString())%> >','#ffffff')"
                                onmouseout="hideddrivetip()" height="20" width="20" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="���" SortExpression="Score">
                        <ItemTemplate>
                            <%# Eval("Score")%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="��ԱID" SortExpression="MemLoginID"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField HeaderText="���" DataField="RepertoryCount" SortExpression="RepertoryCount"
                        ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="�ϼ�" SortExpression="IsSaled" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <asp:Image ID="ImageIsSaled" runat="server" src='<%# PageOperator.GetListImageStatus(Eval("IsSaled").ToString()=="0"?"1":"0") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "ProductIntegralDetal.aspx?guid="+Eval("Guid")+"&type=1" %>" style="color: #4482b4;">
                                �鿴</a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="GetDataInfoInAdmin"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Shop_ScoreProduct_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxName" Name="Name" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="TextBoxRepertoryNumber" Name="RepertoryNumber" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextBoxPrice1" Name="starJF" PropertyName="Text"
                    Type="Int32" DefaultValue="-1" />
                <asp:ControlParameter ControlID="TextBoxPrice2" Name="endJF" PropertyName="Text"
                    Type="Int32" DefaultValue="-1" />
                <asp:Parameter DefaultValue="1" Name="IsAudit" Type="Int32" />
                <asp:ControlParameter ControlID="HiddenFieldCode" Name="ProductCategoryCode" PropertyName="Value"
                    Type="String" />
                <asp:Parameter DefaultValue="0" Name="IsDeleted" Type="String" />
                <asp:ControlParameter ControlID="DropDownListIsSaled" Name="IsSaled" PropertyName="SelectedValue"
                    Type="Int32" />
                <asp:ControlParameter ControlID="TextBoxMemLoginID" Name="MemLoginID" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListIsNew" Name="IsNew" PropertyName="Text"
                    Type="Int32" />
                <asp:ControlParameter ControlID="DropDownListIsHot" Name="IsHot" PropertyName="Text"
                    Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </div>
    <script type="text/javascript" src="js/showimg.js"></script>
    <div style="display: none">
        <asp:DropDownList ID="DropDownListProductGuid1" runat="server" AutoPostBack="True"
            CssClass="tselect" Style="width: 100px; margin-right: 0;" OnSelectedIndexChanged="DropDownListProductGuid1_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListProductGuid2" runat="server" AutoPostBack="True"
            CssClass="tselect" Style="width: 100px; margin-right: 0;" OnSelectedIndexChanged="DropDownListProductGuid2_SelectedIndexChanged">
        </asp:DropDownList>
        <asp:DropDownList ID="DropDownListProductGuid3" runat="server" CssClass="tselect"
            Style="width: 100px; margin-right: 0;">
        </asp:DropDownList>
        <asp:TextBox ID="TextBoxRepertoryNumber" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
    </div>
    </form>
</body>
</html>
