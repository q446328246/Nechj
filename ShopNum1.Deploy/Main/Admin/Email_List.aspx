<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Email_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Email_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="t" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>�ʼ�ģ�����</title>
    <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    �ʼ�ģ�����
                </h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit" style="display: none;">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td style="display: none">
                            <asp:Localize ID="LocalizeTitle" runat="server" Text="�ʼ����⣺"></asp:Localize>
                        </td>
                        <td style="display: none">
                            <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput" Width="220"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorTextBoxTitle" runat="server"
                                ControlToValidate="TextBoxTitle" Display="Dynamic" ErrorMessage="���50���ַ�" ValidationExpression="^[\s\S]{0,50}$"></asp:RegularExpressionValidator>
                        </td>
                        <td class="lmf_padding" style="display: none">
                            <asp:Localize ID="LocalizeTypeName" runat="server" Text="�ʼ����"></asp:Localize>
                        </td>
                        <td style="display: none">
                            <asp:DropDownList ID="DropDownListTypeName" runat="server" CssClass="tselect">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <%--                <tr><asp:Button ID="butSearch" runat="server" OnClick="" Text="��ѯ"/></tr>--%>
                </table>
                <div class="sbtn">
                    <asp:Button ID="ButtonAdd" runat="server" Text="���" OnClientClick=" return GetCheckedBoxValues() "
                        CssClass="tianjia2 picbtn" OnClick="ButtonAdd_Click" />
                    <asp:Button ID="ButtonReply" runat="server" Text="�༭" Visible="false" OnClientClick=" return EditButton() "
                        CssClass="fanh" OnClick="ButtonEdit_Click" />
                    <asp:Button ID="ButtonDelete" runat="server" Text="����ɾ��" OnClientClick=" return DeleteButton() "
                        CssClass="shanchu com" OnClick="ButtonDelete_Click" Visible="false" />
                    <t:MessageShow ID="MessageShow" Visible="false" runat="server" />
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridView" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceDate" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="0" CellPadding="4"
                GridLines="Vertical">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--��ҳ--%>
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <%--<asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                    <asp:BoundField DataField="Title" HeaderText="�ʼ�����" ItemStyle-HorizontalAlign="Center" />
                    <%--  <asp:BoundField HeaderText="��������" DataField="TypeName" ItemStyle-HorizontalAlign="Center" />--%>
                    <asp:BoundField DataField="Description" HeaderText="�ʼ�����" ItemStyle-HorizontalAlign="Center" />
                    <asp:TemplateField HeaderText="����">
                        <ItemTemplate>
                            <a href="<%# "Email_Operate.aspx?guid='" + Eval("Guid") + "'" %>" style="color: #4482b4;">
                                �༭</a>
                            <%--  <asp:LinkButton ID="LinkDelte" runat="server"   Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                            CommandArgument='<%# Eval("Guid") %>' OnClientClick="return window.confirm('��ȷ��Ҫɾ����?');">ɾ��</asp:LinkButton>
                            --%></ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_Email_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxTitle" Name="title" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DropDownListTypeName" DefaultValue="UserName" Name="typename"
                    PropertyName="SelectedValue" Type="String" />
                <asp:Parameter DefaultValue="0" Name="isDeleted" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
