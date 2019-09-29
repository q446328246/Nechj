<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ShopZtcApplyAudit_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.ShopZtcApplyAudit_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="t" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>直通车审核</title>

        <link rel='stylesheet' type='text/css' href='style/css.css' />
        <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
        <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
        <script type='text/javascript' src='js/resolution-test.js'> </script>

    </head>
    <body  class="widthah">
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
                            <asp:Label ID="LabelTitle" runat="server" Text="直通车审核" /></h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="order_edit">
                        <div style="margin-bottom: 10px;">


                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr style="height: 35px; vertical-align: top;">
                                    <td>
                                        <asp:Localize ID="LocalizeTitle" runat="server" Text="商品标题："></asp:Localize>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxTitle" runat="server" CssClass="tinput" Width="180"></asp:TextBox>
                                    </td>
                                    <td class="lmf_padding">
                                        <asp:Localize ID="LocalizeShopID" runat="server" Text="店铺会员ID："></asp:Localize>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="TextBoxShopID" runat="server" CssClass="tinput" Width="180"></asp:TextBox>
                                    </td>
                                    <td class="lmf_padding">
                                        <asp:Localize ID="Localize2" runat="server" Text="店铺名称："></asp:Localize>
                                    </td>
                                    <td>
                         
                                        <asp:TextBox ID="TextBoxShopName" runat="server" CssClass="tinput" Width="180"></asp:TextBox>

                                    </td>
                       
                                </tr>
                                <tr style="height: 35px; vertical-align: top;">
                                    <td align="right">
                                        <asp:Localize ID="Localize3" runat="server" Text="类型："></asp:Localize>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListType" runat="server" CssClass="tselect" Width="187">
                                            <asp:ListItem Value="-1">-请选择-</asp:ListItem>
                                            <asp:ListItem Value="0">申请</asp:ListItem>
                                            <asp:ListItem Value="1">充值</asp:ListItem>
                                        </asp:DropDownList>

                                    </td>
                                    <td class="lmf_padding" align="right">
                                        <asp:Localize ID="Localize1" runat="server" Text="审核状态："></asp:Localize>

                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DropDownListIsAudit" Width="187" runat="server" CssClass="tselect">
                                        </asp:DropDownList>

                                    </td>

                                    <td class="lmf_padding">
                                        <asp:Localize ID="LocalizeCreateTime" runat="server" Text="开始时间："></asp:Localize>

                                    </td>
                                    <td>
                                        <table cellpadding="0" cellspacing="0" border="0">
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="TextBoxTime1" CssClass="tinput" Style="width: 58px;" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                                                                    ControlToValidate="TextBoxTime1" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                                </td>
                                                <td valign="top" style="padding-left: 4px;">
                                                    <img id="imgCalendarSReplyTime2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative; top: 4px; width: 16px;" />
                                                </td>
                                                <td>
                                                    <t:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="TextBoxTime1"
                                                                               PopupButtonID="imgCalendarSReplyTime2" CssClass="ajax__calendar" />
                                                </td>
                                                <td class="lmf_px">
                                                    -
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="TextBoxTime2" CssClass="tinput" Style="width: 58px;" runat="server"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorEndDate" runat="server"
                                                                                    ControlToValidate="TextBoxTime2" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^\d{4}-(\d{2}|\d{1})-(\d{2}|\d{1})( (\d{2}|\d{1}):(\d{2}|\d{1}):(\d{2}|\d{1}))*"></asp:RegularExpressionValidator>
                                                </td>
                                                <td valign="top" style="padding-left: 4px;">
                                                    <img id="imgCalendarSReplyTime3" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative; top: 4px; width: 16px;" />
                                                </td>
                                                <td>
                                                    <t:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxTime2"
                                                                               PopupButtonID="imgCalendarSReplyTime3" CssClass="ajax__calendar" />
                                                </td>
                                                <td>
                                                    <asp:Button ID="Button1" runat="server" Text="查询" CssClass="dele" OnClick="ButtonSearch_Click" />
                                                </td>
                                            </tr>
                                        </table>

                                    </td>

                                </tr>
                            </table>
                        </div>
                        <div class="sbtn">
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td valign="top">
                                        <asp:LinkButton ID="ButtonAudit" runat="server" CssClass="shtg lmf_btn" OnClick="ButtonAudit_Click"
                                                        OnClientClick=" return AuditButton() "><span>审核通过</span></asp:LinkButton>
                                    </td>
                                    <td valign="top" class="lmf_app">
                                        <asp:LinkButton ID="ButtonCancelAudit" runat="server" CssClass="shwtg lmf_btn" OnClientClick=" return AuditButton() "
                                                        OnClick="ButtonCancelAudit_Click" Visible="true"><span>审核未通过</span></asp:LinkButton>
                                    </td>
                                    <td valign="top" class="lmf_app">
                                        <asp:LinkButton ID="ButtonDelete" runat="server" CssClass="shanchu lmf_btn" OnClick="ButtonDelete_Click"
                                                        OnClientClick=" return DeleteButton() " Visible="true"><span>批量删除</span></asp:LinkButton>
                                    </td>
                                    <td valign="top" class="lmf_app">
                                        <ShopNum1:MessageShow ID="MessageShow" Visible="false" runat="server" />
                                    </td>
                                </tr>
                            </table>
                            <%-- <asp:Button ID="ButtonSearchDetail" runat="server" Text="查看"   CssClass="dele"   OnClientClick="return EditButton()"
            OnClick="ButtonSearchDetail_Click" />--%>
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
                                    <input id="checkboxItem" value='<%# Eval("ID") %>' type="checkbox" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="商品名称">
                                <ItemTemplate>
                                    <a href='<%#ShopUrlOperate.shopDetailHrefByShopID(Eval("ProductGuid").ToString(), Eval("ShopID").ToString(), "ProductDetail") %>'
                                       target="_blank">
                                        <%#Eval("ProductName").ToString().Length > 20 ? Eval("ProductName").ToString().Substring(0, 20) : Eval("ProductName").ToString() %>
                                    </a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="会员ID" DataField="MemberID" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="店铺名称" DataField="ShopName" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="支付金额" DataField="Ztc_Money" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="开始时间" DataField="StartTime" ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField HeaderText="申请时间" DataField="ApplyTime" ItemStyle-HorizontalAlign="Center" />
                            <asp:TemplateField HeaderText="类型">
                                <ItemTemplate>
                                    <%# Eval("Type").ToString().Trim() == "0" ? "<font>申请</font>" : "<font>充值</font>" %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="支付状态">
                                <ItemTemplate>
                                    <%# Eval("PayState").ToString().Trim() == "0" ? "<font color=red>未支付</font>" : "<font color=green>已支付</font>" %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="审核状态">
                                <ItemTemplate>
                                    <%#Is(Eval("AuditState").ToString()) %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作" SortExpression="IsShow">
                                <ItemTemplate>
                                    <a href="<%# "ShopZtcApplyDetal.aspx?ID=" + "'" + Eval("ID") + "'" %>"
                                       style="color: #4482b4;">查看</a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="15%" />
                            </asp:TemplateField>
                        </Columns>
                    </ShopNum1:Num1GridView>
                </div>
            </div>
            <asp:ObjectDataSource ID="ObjectDataSourceDate" runat="server" SelectMethod="GetInfo"
                                  TypeName="ShopNum1.BusinessLogic.ShopNum1_ZtcApply_Action">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TextBoxTitle" Name="ProductName" PropertyName="Text"
                                          Type="String" />
                    <asp:ControlParameter ControlID="TextBoxShopID" Name="MemberID" PropertyName="Text"
                                          Type="String" />
                    <asp:ControlParameter ControlID="TextBoxShopName" Name="ShopName" PropertyName="Text"
                                          Type="String" />
                    <asp:ControlParameter ControlID="DropDownListType" Name="Type" PropertyName="SelectedValue"
                                          Type="String" />
                    <asp:ControlParameter ControlID="DropDownListIsAudit" Name="AuditState" PropertyName="SelectedValue"
                                          Type="String" />
                    <asp:ControlParameter ControlID="TextBoxTime1" Name="Time1" PropertyName="Text"
                                          Type="String" />
                    <asp:ControlParameter ControlID="TextBoxTime2" Name="Time2" PropertyName="Text"
                                          Type="String" />
                </SelectParameters>
            </asp:ObjectDataSource>
            <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
        </form>
    </body>
</html>