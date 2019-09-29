<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopInfoList_Audit.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ShopInfoList_Audit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>

<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<%@ Import Namespace="ShopNum1.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type='text/javascript' src='js/resolution-test.js'></script>
    <script src="js/tanchuDIV2.js" type="text/javascript"></script>
    <script src="js/dragbox/Shopnum1.Dialog.min.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="js/dragbox/Shopnum1.DragBox.min.css" />
    <script src="js/CommonJS.js" type="text/javascript"></script>
    <script type="text/javascript" language="javascript">
        function funCheck() {
            OperateButton();
            var leg = $("#CheckGuid").val().indexOf(",");
            if ($("#CheckGuid").val() != "0" && leg == -1) {
                ECF.dialog.open('ShopAuditFailedReason.aspx?width=700&height=400&guid=' + $("#CheckGuid").val(), { width: 700, height: 400, title: "店铺审核失败" });
                return false;
            }
            else {
                alert("每次只能选中一项！");
            }
            return false;
        }
    </script>
</head>
<body >
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" EnableScriptLocalization="true"
        runat="server">
    </asp:ScriptManager>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    <asp:Label ID="LabelPageTitle1" runat="server" Text="待审核店铺列表"></asp:Label></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td>
                            店铺名称：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxShopName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                         <td class="lmf_padding" align="left">
                            会员ID：
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMemberName" CssClass="tinput" runat="server" Width="200"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            店铺类型：
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListShopType" runat="server" CssClass="tinput" Width="200">
                            <asp:ListItem Text="-请选择-" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="个人" Value="0"></asp:ListItem>
                            <asp:ListItem Text="企业" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                           &nbsp;&nbsp;
                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td valign="top" style="display: none;">
                                <asp:LinkButton ID="ButtonSearchShop" runat="server" CausesValidation="False" OnClientClick=" return EditButton() "
                                    CssClass="dele" OnClick="ButtonSearchShop_Click" Visible="false"><span>查看</span></asp:LinkButton>
                            </td>
                            <td valign="top">
                                <asp:LinkButton ID="ButtonOperate" runat="server" OnClick="ButtonOperate_Click" OnClientClick="return OperateButtonNew()"
                                    CssClass="shtg lmf_btn"><span>审核通过</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonOperate1" runat="server" OnClientClick="return funCheck()"
                                    CssClass="shwtg lmf_btn"><span>审核未通过</span></asp:LinkButton>
                                    <%--<a href="javascript:void(0)" onclick="" class="shwtg lmf_btn dialog">&nbsp;&nbsp;&nbsp;审核未通过</a>--%>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" CausesValidation="False" OnClientClick="return DeleteOneButton()"
                                    CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click"><span>批量删除</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <shopnum1:messageshow id="MessageShow" runat="server" visible="False" />
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" datasourceid="ObjectDataSource" AllowMultiColumnSorting="False"
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
                                        <input id="checkboxAll" onclick="javascript:SelectAllCheckboxes(this);" type="checkbox" />
                                    </HeaderTemplate>
                                    <HeaderStyle CssClass="select_width" />

                                    <ItemTemplate>
                                        <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="店铺名称" SortExpression="ShopName">
                                    <ItemTemplate>
                                        <a id="A1" href='<%#ShopUrlOperate.GetShopUrl(Eval("ShopID").ToString()) %>' target="_blank"
                                            runat="server">
                                            <asp:Label ID="Label6" runat="server" Text='<%# Bind("ShopName") %>'></asp:Label></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="230px"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="店铺类型" SortExpression="ShopType">
                                    <ItemTemplate>
                                        <%#Eval("ShopType").ToString()=="0"?"个人":"企业" %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="会员ID" SortExpression="MemLoginID">
                                    <ItemTemplate>
                                         <%# Eval("MemLoginID")%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" Width="90px" />
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="申请时间" DataField="ApplyTime" SortExpression="ApplyTime" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="90px"/>
                                    <asp:BoundField HeaderText="排序号" DataField="OrderID" SortExpression="OrderID" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="60px"></asp:BoundField>
                 <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                        <ItemTemplate>
 		                <a href="<%# "ShopInfo_AuditOperate.aspx?guid="+Eval("Guid")%>" style="color: #4482b4;">
                                查看</a>
				<asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid")%>'
                                OnClientClick="return window.confirm('您确定要删除吗?');" OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="60px"/>
                    </asp:TemplateField>

                            </Columns>
                            <HeaderStyle HorizontalAlign="Center" BackColor="#6699CC" Font-Bold="True" ForeColor="#FFFFFF">
                            </HeaderStyle>
                            <PagerStyle  CssClass="lmf_page"  HorizontalAlign="Left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
                            
                        </shopnum1:num1gridview>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSource" runat="server" SelectMethod="Search"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_ShopInfoList_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxShopName" Name="ShopName" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter ControlID="TextBoxMemberName" Name="memberLoginID" PropertyName="Text"
                Type="String" />
            <asp:ControlParameter Name="IsAudit" Type="String" DefaultValue="0" ControlID="HiddenFieldIsAudit"
                PropertyName="Value" />
            <asp:ControlParameter ControlID="DropDownListShopType"  Name="ShopType"
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    <asp:HiddenField ID="HiddenFieldRegionCode" runat="server" Value="-1" />
    <asp:HiddenField ID="HiddenFieldIsAudit" runat="server" Value="0" />
    </form>
</body>
</html>
