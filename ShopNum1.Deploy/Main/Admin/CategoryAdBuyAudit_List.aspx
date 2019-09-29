<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdBuyAudit_List.aspx.cs"
         Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdBuyAudit_List" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>����������б�</title>
        <link rel='stylesheet' type='text/css' href='style/css.css' />
        <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
        <script type='text/javascript' src='js/resolution-test.js'> </script>
        <script type="text/javascript">

        //ѡ��ͼ
            function openSingleChild1() {
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    var strLen = k.length;
                    var lastIndex = k.lastIndexOf('/');
                    document.getElementById("TextBoxAdNowPic").value = k.substring(lastIndex + 1, strLen);
                    document.getElementById("ImageOriginalImge1").src = imgvalue[1];
                }
            }


            function openSingleChild2() {
                var k = window.showModalDialog("Image_List_Select.aspx", window, "dialogWidth:820px;status:no;dialogHeight:650px");
                if (k != null) {
                    var imgvalue = new Array();
                    imgvalue = k.split(",");
                    var strLen = k.length;
                    var lastIndex = k.lastIndexOf('/');
                    document.getElementById("TextBoxDefaultPic").value = k.substring(lastIndex + 1, strLen);
                    document.getElementById("ImageOriginalImge2").src = imgvalue[1];
                }
            }
        </script>
    </head>
    <body class="widthah">
        <form id="form1" runat="server">
            <div id="right">
                <div class="rhigth">
                    <div class="rl">
                    </div>
                    <div class="rcon">
                        <h3>
                            <asp:Label ID="LabelTitle" runat="server" Text="����������б�"></asp:Label></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="order_edit">
                        <table cellpadding="0" cellspacing="0" border="0">
                            <tr style="height: 35px; vertical-align: top;">
                                <td>
                                    ������ƣ�
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxPageName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                                </td>
                                <td class="lmf_padding" style="text-align: right;">
                                    �����ԱID��
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxMemLoginID" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                                </td>
                                <td class="lmf_padding" style="text-align: right;">
                                    �����ࣺ
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListCategory1" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListCategory1_SelectedIndexChanged"
                                                      CssClass="tselect" Style="width: 100px;">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListCategory2" AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListCategory2_SelectedIndexChanged"
                                                      CssClass="tselect" Style="width: 100px;">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:DropDownList ID="DropDownListCategory3" runat="server" CssClass="tselect" Style="width: 100px;">
                                        <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 35px; vertical-align: top;">
                                <td style="text-align: right;">
                                    ���״̬��
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsAudit" Width="207" runat="server" CssClass="tselect">
                                        <asp:ListItem Selected="True" Value="-2">-ȫ��-</asp:ListItem>
                                        <asp:ListItem Value="0">δ���</asp:ListItem>
                                        <asp:ListItem Value="2">���δͨ��</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="lmf_padding" style="text-align: right;">
                                    �Ƿ񸶿
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsPayMent" Width="207" runat="server" CssClass="tselect">
                                        <asp:ListItem Selected="True" Value="-1">-ȫ��-</asp:ListItem>
                                        <asp:ListItem Value="1">�Ѹ���</asp:ListItem>
                                        <asp:ListItem Value="0">δ����</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                <td class="lmf_padding" style="text-align: right;">
                                    ���λ��
                                </td>
                                <td>
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="DropDownListAdPageName" AutoPostBack="true" runat="server"
                                                                  Width="100" OnSelectedIndexChanged="DropDownListAdPageName_SelectedIndexChanged"
                                                                  CssClass="tselect">
                                                    <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                                    <asp:ListItem Value="1">��Ʒ����</asp:ListItem>
                                                    <asp:ListItem Value="2">������Ϣ����</asp:ListItem>
                                                    <asp:ListItem Value="3">�������</asp:ListItem>
                                                    <asp:ListItem Value="4">���̷���</asp:ListItem>
                                                    <asp:ListItem Value="5">��Ѷ����</asp:ListItem>
                                                    <asp:ListItem Value="6">Ʒ�Ʒ���</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:DropDownList ID="DropDownListAdID" AutoPostBack="true" runat="server" Width="100"
                                                                  CssClass="tselect">
                                                    <asp:ListItem Selected="True" Value="-1">-��ѡ��-</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:Button ID="ButtonSearch" runat="server" Text="��ѯ" CssClass="dele" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div class="sbtn">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td valign="top">
                                        <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClientClick=" return DeleteButton() "
                                                        OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn"><span>����ɾ��</span></asp:LinkButton>
                                    </td>
                                    <td valign="top" class="lmf_app">
                                        <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                                    </td>
                                </tr>
                            </table>
                            <%-- <asp:Button ID="ButtonSearchDetail" runat="server" CausesValidation="False" Text="�鿴|���"
                        OnClientClick="return EditButton()" CssClass="liuyan com" OnClick="ButtonSearchDetail_Click" />--%>
                        </div>
                    </div>
                    <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AllowPaging="True" AddSequenceColumn="False"
                                           AllowMultiColumnSorting="False" AutoGenerateColumns="False" BorderColor="#DEDFDE"
                                           BorderStyle="Solid" BorderWidth="0" CellPadding="4" DataSourceID="ObjectDataSourceData"
                                           Del="False" DeletePromptText="ȷʵҪɾ��ָ���ļ�¼��" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                                           PagingStyle="None" TableName="" Width="98%" AllowSorting="True">
                        <FooterStyle BackColor="#CCCC99" />
                        <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                        <%--��ҳ--%>
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
                                    <input id="checkboxItem" type="checkbox" value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
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
                            <asp:TemplateField HeaderText="�Ƿ񸶿�">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(Eval("IsPayMent").ToString()) %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="���״̬">
                                <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(Eval("IsAudit").ToString()) %>' />
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
                                    <a href="<%# "CategoryAdBuy_SearchDetail.aspx?guid='" + Eval("ID") + "'&type=Audit" %>"
                                       style="color: #4482b4;">�鿴</a>
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
                        <asp:ControlParameter ControlID="DropDownListIsAudit" Name="isAudit" PropertyName="SelectedValue"
                                              Type="String" />
                        <asp:ControlParameter ControlID="DropDownListAdID" Name="CategoryID" PropertyName="SelectedValue"
                                              Type="String" />
                        <asp:ControlParameter ControlID="HiddenFieldCategoryCode" Name="categorycode" PropertyName="Value"
                                              Type="String" />
                        <asp:ControlParameter ControlID="DropDownListAdPageName" Name="CategoryType" PropertyName="SelectedValue"
                                              Type="String" />
                        <asp:ControlParameter ControlID="TextBoxMemLoginID" DefaultValue="-1" Name="memloginid"
                                              PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="DropDownListIsPayMent" Name="isPayMent" PropertyName="SelectedValue"
                                              Type="String" />
                        <asp:ControlParameter ControlID="TextBoxPageName" DefaultValue="-1" Name="advertisementname"
                                              PropertyName="Text" Type="String" />
                        <asp:Parameter DefaultValue="-1" Name="IsEffective" Type="String" />
                    </SelectParameters>
                </asp:ObjectDataSource>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
                <asp:HiddenField ID="HiddenFieldCategoryCode" runat="server" Value="-1" />
            </div>
        </form>
        <script type="text/javascript" src="js/showimg.js"> </script>
    </body>
</html>