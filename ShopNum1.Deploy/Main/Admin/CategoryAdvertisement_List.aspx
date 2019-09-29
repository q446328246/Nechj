<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="CategoryAdvertisement_List.aspx.cs"
    Inherits="ShopNum1.Deploy.Main.Admin.CategoryAdvertisement_List" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>分类广告列表</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
    <script type="text/javascript">

        //选择单图
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
                    分类广告列表</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellspacing="0" cellpadding="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td align="right">
                            广告名称：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxPageName" runat="server" CssClass="tinput" Width="200"></asp:TextBox>
                        </td>
                        <td align="right" class="lmf_padding">
                            是否购买：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsBuy" Width="201px" runat="server" CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-全部-</asp:ListItem>
                                <asp:ListItem Value="1">已购买</asp:ListItem>
                                <asp:ListItem Value="0">未购买</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td class="lmf_padding">
                            是否显示：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListIsShow" Width="201px" runat="server" CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-全部-</asp:ListItem>
                                <asp:ListItem Value="1">显示</asp:ListItem>
                                <asp:ListItem Value="0">不显示</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            广告分类：
                        </td>
                        <td>
                            <asp:DropDownList CssClass="tselect" Style="width: 100px;" ID="DropDownListCategory1"
                                AutoPostBack="true" runat="server" OnSelectedIndexChanged="DropDownListCategory1_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListCategory2" AutoPostBack="true" runat="server" CssClass="tselect"
                                Style="width: 100px;" OnSelectedIndexChanged="DropDownListCategory2_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListCategory3" runat="server" CssClass="tselect" Style="width: 100px;">
                                <asp:ListItem Selected="True" Value="-1">-请选择-</asp:ListItem>
                            </asp:DropDownList>
                            <span style="color: Red">（请先选择广告位）</span>
                        </td>
                        <td align="right" class="lmf_padding">
                            广告位：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListAdPageName" AutoPostBack="true" runat="server"
                                CssClass="tselect" Width="152px" OnSelectedIndexChanged="DropDownListAdPageName_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="-1">-全部-</asp:ListItem>
                                <asp:ListItem Value="1">商品分类</asp:ListItem>
                                <asp:ListItem Value="2">分类信息分类</asp:ListItem>
                                <asp:ListItem Value="3">供求分类</asp:ListItem>
                                <asp:ListItem Value="4">店铺分类</asp:ListItem>
                                <asp:ListItem Value="5">资讯分类</asp:ListItem>
                                <asp:ListItem Value="6">品牌分类</asp:ListItem>
                            </asp:DropDownList>
                            <asp:DropDownList ID="DropDownListAdID" AutoPostBack="true" runat="server" Width="152px"
                                CssClass="tselect">
                                <asp:ListItem Selected="True" Value="-1">-全部-</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" Text="查询" CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top">
                                <asp:Button ID="ButtonSearchDetail" runat="server" CausesValidation="False" Text="查看详细"
                                    OnClientClick=" return EditButton() " CssClass="fanh" OnClick="ButtonSearchDetail_Click"
                                    Visible="false" />
                                <asp:LinkButton ID="ButtonAdd" runat="server" OnClick="ButtonAdd_Click" CausesValidation="False"
                                    class="tianjia2 lmf_btn"><span>添加</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" Text="编辑" OnClientClick=" return EditButton() "
                                    OnClick="ButtonEdit_Click" CssClass="fanh" Visible="false" />
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return DeleteButton() "
                                    CausesValidation="False" class="shanchu lmf_btn"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
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
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("ID") %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="ID" ItemStyle-HorizontalAlign="Center" HeaderText="广告ID" />
                    <asp:TemplateField HeaderText="页面名">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%# CategoryType(Eval("CategoryType")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="AdvertisementName" ItemStyle-HorizontalAlign="Center"
                        HeaderText="广告名称" />
                    <asp:BoundField DataField="CategoryName" ItemStyle-HorizontalAlign="Center" HeaderText="广告所属分类" />
                    <asp:TemplateField HeaderText="链接地址">
                        <ItemTemplate>
                            <a href='<%# Eval("AdDefaultLike") %>' target="_blank">
                                <%# Eval("AdDefaultLike") %></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否购买">
                        <ItemTemplate>
                            <asp:Label ID="Label2" runat="server" Text='<%#IsBuy(Eval("IsBuy")) %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否显示">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" src='<%# PageOperator.GetListImageStatus(Eval("IsShow").ToString()) %>' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "CategoryAdvertisement_Operate.aspx?ID=" + Eval("ID") %>" style="color: #4482b4;">
                                编辑</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                CommandArgument='<%# Eval("ID") %>' OnClientClick=" return window.confirm('您确定要删除吗?'); ">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_CategoryAdvertisement_Action" OldValuesParameterFormatString="original_{0}">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxPageName" DefaultValue="-1" Name="AdName"
                    PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="DropDownListAdPageName" Name="CategoryType" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListAdID" Name="CategoryID" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="HiddenFieldCategoryCode" Name="AdCode" PropertyName="Value"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListIsShow" Name="AdIShow" PropertyName="SelectedValue"
                    Type="String" />
                <asp:ControlParameter ControlID="DropDownListIsBuy" Name="AdIsBuy" PropertyName="SelectedValue"
                    Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        <asp:HiddenField ID="HiddenFieldCategoryCode" runat="server" Value="-1" />
    </div>
    </form>
</body>
</html>
