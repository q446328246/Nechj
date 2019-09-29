<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamList.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.TeamList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>团队领导人</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    团队领导人</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 35px; vertical-align: top;">
                        <td class="lmf_padding">
                            <asp:Label ID="LabelSMemLoginNO" runat="server" Text="用户编号："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxMemLoginNO" runat="server" CssClass="tinput" Width="150px"></asp:TextBox>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="Label1" runat="server" Text="手机号："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextMobile" runat="server" CssClass="tinput" Width="150px"></asp:TextBox>
                        </td>
                       
                        
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" Text="查询" OnClick="ButtonSearch_Click"
                                CssClass="dele" />
                        </td>
                    </tr>
                   
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                          
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonReportAll" OnClick="ButtonReportAll_Click" runat="server"
                                    CausesValidation="False" CssClass="daochubtn lmf_btn"><span>导出全部</span></asp:LinkButton>
                                    
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                          
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False"  Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="Default" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False" 
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" 
                BorderWidth="0px" CellPadding="4"
                GridLines="Vertical" EnableModelValidation="True">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    
                  
                    <asp:BoundField DataField="MemLoginID" HeaderText="用户编号" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Mobile" HeaderText="手机号" SortExpression="Mobile">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="name" HeaderText="昵称" SortExpression="name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="RecoMemberTime" HeaderText="记录时间" SortExpression="RecoMemberTime">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    

                   
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
        <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SelectTeamList"
            TypeName="ShopNum1.BusinessLogic.ShopNum1_AdvancePaymentApplyLog_Action">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBoxMemLoginNO" Name="MemLoginID" PropertyName="Text"
                    Type="String" />
                <asp:ControlParameter ControlID="TextMobile" Name="mobile" PropertyName="Text"
                    Type="String" />

                <asp:ControlParameter ControlID="TextIsadmin" DefaultValue="0" Name="isadmin"  Type="String" />

            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:HiddenField ID="TextIsadmin" runat="server" Value="0" />
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
