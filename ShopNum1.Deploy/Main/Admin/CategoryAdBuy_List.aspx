<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdBuy_List.aspx.cs"
         Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdBuy_List" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>��Ա������λ�б�</title>
        <link rel='stylesheet' type='text/css' href='style/css.css' />
        <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
        <script type='text/javascript' src='js/resolution-test.js'> </script>
    </head>
    <body class="widthah1">
        <form id="form1" runat="server">
            <div id="right">
                <div class="rhigth">
                    <div class="rl">
                    </div>
                    <div class="rcon">
                        <h3>
                            ��Ա������λ�б�</h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="order_edit">
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr style="height: 35px; vertical-align: top;">
                                <td>
                                    ������ƣ�
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxPageName" runat="server" CssClass="tinput" Width="200px"></asp:TextBox>
                                </td>
                                <td class="lmf_padding">
                                    �����ԱID��
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxMemLoginID" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                                </td>
                                <td class="lmf_padding">
                                    �Ƿ���ڣ�
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsEffective" Width="201px" runat="server" CssClass="tselect">
                                        <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                        <asp:ListItem Value="1">δ����</asp:ListItem>
                                        <asp:ListItem Value="0">�ѹ���</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr style="height: 35px; vertical-align: top;">
                                <td align="right">
                                    �����ࣺ
                                </td>
                                <td>
                                    <asp:DropDownList CssClass="tselect" Style="width: 100px;" ID="DropDownListCategory1"
                                                      AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListCategory1_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList CssClass="tselect" Style="width: 100px;" ID="DropDownListCategory2"
                                                      AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListCategory2_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListCategory3" runat="server" CssClass="tselect" Style="width: 100px;">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                    <span style="color: Red">������ѡ����λ��</span>
                                </td>
                                <td class="lmf_padding">
                                    ���λ��
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListAdPageName" AutoPostBack="true" runat="server"
                                                      CssClass="tselect" Width="152px" OnSelectedIndexChanged="DropDownListAdPageName_SelectedIndexChanged">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                        <asp:ListItem Value="1">��Ʒ����</asp:ListItem>
                                        <asp:ListItem Value="2">������Ϣ����</asp:ListItem>
                                        <asp:ListItem Value="3">�������</asp:ListItem>
                                        <asp:ListItem Value="4">���̷���</asp:ListItem>
                                        <asp:ListItem Value="5">��Ѷ����</asp:ListItem>
                                        <asp:ListItem Value="6">Ʒ�Ʒ���</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListAdID" AutoPostBack="true" runat="server" Width="152px"
                                                      CssClass="tselect">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" CssClass="dele" />
                                </td>
                            </tr>
                        </table>
                        <div class="sbtn">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td valign="top">
                                        <asp:Button ID="ButtonSearchDetail" runat="server" CausesValidation="False" Text="�鿴|���"
                                                    OnClientClick=" return EditButton() " CssClass="fanh" OnClick="ButtonSearchDetail_Click"
                                                    Visible="false" />
                                        <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                                        CausesValidation="False" class="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                            <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                        </div>
                    </div>
                    <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                                           AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                                           descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                                           Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                                           PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
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
                                    <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <HeaderStyle CssClass="select_width" />
                                <ItemTemplate>
                                    <input id="checkboxItem" type="checkbox" value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="ID" ItemStyle-HorizontalAlign="Center" HeaderText="���ID">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="ҳ����">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# CategoryType(Eval("CategoryType")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="AdvertisementName" ItemStyle-HorizontalAlign="Center"
                                            HeaderText="�������">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="MemLoginID" ItemStyle-HorizontalAlign="Center" HeaderText="�����Ա">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="CategoryName" ItemStyle-HorizontalAlign="Center" HeaderText="�����������">
                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="���ӵ�ַ">
                                <ItemTemplate>
                                    <a href='<%# Eval("AdvertisementLike") %>' target="_blank">
                                        <%# Eval("AdvertisementLike") %></a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="��ʼʱ��">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#(Eval("StartTime")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="����ʱ��">
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%#(Eval("EndTime")) %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="�Ƿ����">
                                <ItemTemplate>
                                    <%--   <asp:Label ID="Label3" runat="server" Text='<%# Convert.ToDateTime(Eval("EndTime"))
                    <=System.DateTime.Now?"�ѹ���":"δ����" %>'></asp:Label>--%>
                                    <asp:Image ID="Image1" runat="server" src='<%# GetImageStatus(Eval("EndTime").ToString()) %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���ͼƬ">
                                <ItemTemplate>
                                    <img src='<%# Page.ResolveUrl("~/ImgUpload/MemberImg/CategoryAdImg/" + Eval("AdvertisementPic")) %> '
                                         onmouseover=" javascript:ddrivetip('<img width=200px height=200 src=<%# Page.ResolveUrl("~/ImgUpload/MemberImg/CategoryAdImg/" + Eval("AdvertisementPic")) %> >', '#ffffff'); "
                                         onmouseout=" hideddrivetip() " height="20" width="20" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="����">
                                <ItemTemplate>
                                    <a href="<%# "CategoryAdBuy_SearchDetail.aspx?guid=" + Eval("ID") %>" style="color: #4482b4;">
                                        �鿴</a>
                                    <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                                    CommandArgument='<%# Eval("ID") %>' OnClientClick=" return window.confirm('��ȷ��Ҫɾ����?'); ">ɾ��</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </ShopNum1:Num1GridView>
                </div>
                <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SearchBuyAdInfo"
                                      TypeName="ShopNum1.BusinessLogic.ShopNum1_CategoryAdPayMent_Action" OldValuesParameterFormatString="original_{0}">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="1" Name="isAudit" Type="String" />
                        <asp:Parameter DefaultValue="1" Name="isPayMent" Type="String" />
                        <asp:ControlParameter ControlID="DropDownListAdID" Name="CategoryID" PropertyName="SelectedValue"
                                              Type="String" />
                        <asp:ControlParameter ControlID="HiddenFieldCategoryCode" Name="categorycode" PropertyName="Value"
                                              Type="String" />
                        <asp:ControlParameter ControlID="DropDownListAdPageName" Name="CategoryType" PropertyName="SelectedValue"
                                              Type="String" />
                        <asp:ControlParameter ControlID="TextBoxMemLoginID" DefaultValue="-1" Name="memloginid"
                                              PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="TextBoxPageName" DefaultValue="-1" Name="advertisementname"
                                              PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="DropDownListIsEffective" Name="IsEffective" PropertyName="SelectedValue"
                                              Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
                <asp:HiddenField ID="HiddenFieldCategoryCode" runat="server" Value="-1" />
            </div>
        </form>
        <script type="text/javascript" src="js/showimg.js"> </script>
    </body>
</html>