<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BTCRecommend.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.BTCRecommend" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>商品品牌</title>
    <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script src="js/jquery.js" type="text/javascript"> </script>
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
</head>
<body class="widthah">
    <form id="form1" runat="server">
    <div style="left: -1000px; position: absolute; top: 377px; visibility: hidden;" id="dhtmltooltip">
        <img src="" height="200" width="200px">
    </div>
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    商品品牌</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr style="height: 35px; vertical-align: top;">
                       
                        <td align="right" class="lmf_padding">
                            <asp:Label ID="Label4" runat="server" Text="商品名：" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TxtProductName" runat="server" CssClass="tinput" Width="100"></asp:TextBox>
                        </td>
                          <td class="lmf_padding">
                            <asp:Label ID="LabelCreateTime" runat="server" Text="下单日期："></asp:Label>
                        </td>
                        <td>
                            <table cellpadding="0" cellspacing="0" border="0">
                                <tr>
                                    <td>
                                        <asp:TextBox ID="TextBoxCreateTime1" CssClass="tinput_data" runat="server"></asp:TextBox>
                                    </td>
                                    <td valign="top" style="padding-left: 4px;">
                                        <img id="imgCalendarCreateTime1" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                            height: 18px; position: relative; top: 4px;" />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                        <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                            EnableScriptLocalization="True">
                                        </ShopNum1:ToolkitScriptManager>
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxCreateTime1"
                                            PopupButtonID="imgCalendarCreateTime1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                        </ShopNum1:CalendarExtender>
                                    </td>
                                    <td class="lmf_px">
                                        -
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="tinput_data" ID="TextBoxCreateTime2" runat="server"></asp:TextBox>
                                    </td>
                                    <td valign="top" style="padding-left: 4px;">
                                        <img id="imgCalendarCreateTime2" alt="" src="/ImgUpload/Calendar.png" style="width: 16px;
                                            height: 18px; position: relative; top: 4px;" />
                                    </td>
                                    <td>
                                        <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidatorCreateTime2" runat="server"
                                            ControlToValidate="TextBoxCreateTime2" Display="Dynamic" ErrorMessage="时间格式不正确"
                                            ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>--%>
                                    </td>
                                    <td>
                                        <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxCreateTime2"
                                            PopupButtonID="imgCalendarCreateTime2" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                        </ShopNum1:CalendarExtender>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="lmf_padding">
                            <asp:Label ID="Label2" runat="server" Text="选择以推荐的类型：" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListTuiJian" runat="server" CssClass="tselect" Style="width: 100px;">
                                <asp:ListItem Value="-2" Selected="True">-全部-</asp:ListItem>
                                <asp:ListItem Value="1">销量推荐</asp:ListItem>
                                <asp:ListItem Value="2">最新推荐</asp:ListItem>
                                <asp:ListItem Value="3">特色推荐</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                        
                        
                    </tr>
                    <tr>
                        
                        <td class="lmf_padding">
                            <asp:Label ID="Label3" runat="server" Text="排序方式：" Font-Bold="False"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="DropDownListPaiXu" runat="server" CssClass="tselect"
                                Style="width: 100px;">
                                <asp:ListItem Value="-2" Selected="True">-全部-</asp:ListItem>
                                
                                <asp:ListItem Value="2">周销量排序</asp:ListItem>
                                <asp:ListItem Value="3">月销量排序</asp:ListItem>
                                <asp:ListItem Value="1">季销量排序</asp:ListItem>
                                <asp:ListItem Value="4">时间段销量排序</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                CssClass="dele" />
                        </td>
                    </tr>
                </table>
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                           
                             <%-- <td class="lmf_padding">
                            <asp:Label ID="Label1" runat="server" Text="需要设置的内容：" Font-Bold="False"></asp:Label>
                        </td>--%>
                            <td valign="top" class="lmf_app" style="display: true;">
                                <asp:DropDownList ID="DropDownListAddOrDelete" runat="server" CssClass="tselect"
                                Style="width: 100px;">
                                <asp:ListItem Value="-2" Selected="True">-全部-</asp:ListItem>
                                <asp:ListItem Value="1">设为销量推荐</asp:ListItem>
                                <asp:ListItem Value="2">设为最新推荐</asp:ListItem>
                                <asp:ListItem Value="3">设为特色推荐</asp:ListItem>
                                <asp:ListItem Value="4">取消销量推荐</asp:ListItem>
                                <asp:ListItem Value="5">取消最新推荐</asp:ListItem>
                                <asp:ListItem Value="6">取消特色推荐</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                            <td valign="top" class="lmf_app">
                                <asp:LinkButton ID="ButtonDelete" runat="server" OnClientClick=" return OperateButton() "
                                    OnClick="ButtonDelete_Click" CssClass="shanchu lmf_btn"><span>设置</span></asp:LinkButton>
                            </td>
                            <td valign="top" class="lmf_app">
                                <ShopNum1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <ShopNum1:Num1GridView ID="Num1GridviewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实操作吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" DataSourceID="ObjectDataSourceData" AllowMultiColumnSorting="False"
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
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                        </HeaderTemplate>
                        <HeaderStyle CssClass="select_width" />
                        <ItemTemplate>
                            <input id="checkboxItem" type="checkbox" value='<%# Eval("Guid") %>' align="middle" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" SortExpression="Guid" />
                  
                    <asp:BoundField DataField="Name" HeaderText="商品名" SortExpression="Name">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MemLoginID" HeaderText="卖家ID" SortExpression="MemLoginID">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="ShopName" HeaderText="店铺名" SortExpression="ShopName" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                   
                    <asp:BoundField DataField="WeekSales" HeaderText="周销量" SortExpression="WeekSales" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField DataField="MonthSales" HeaderText="月销量" SortExpression="MonthSales" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField DataField="Quarteri" HeaderText="季销量" SortExpression="Quarteri" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField DataField="AllSales" HeaderText="时间段内销量" SortExpression="AllSales" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                    <asp:BoundField DataField="CreateTime" HeaderText="上传时间" SortExpression="CreateTime" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>
                     <asp:BoundField DataField="RecommendNum" HeaderText="推荐次数" SortExpression="RecommendNum" ItemStyle-HorizontalAlign="Center">
                    </asp:BoundField>


                    <asp:TemplateField HeaderText="是否销售推荐" SortExpression="IsShow">
                        <ItemTemplate>
                            <asp:Image ID="Image1" runat="server" src='<%# PageOperator.GetListImageStatus22(Eval("IsSalesBTC").ToString() == "1" ? "1" : "0") %>' />
                          
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否最新推荐" SortExpression="IsCommend">
                        <ItemTemplate>
                            <asp:Image ID="Image2" runat="server" src='<%# PageOperator.GetListImageStatus22(Eval("IsNewBTC").ToString() == "1" ? "1" : "0") %>' />
                           
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="是否特色推荐" SortExpression="IsComm">
                        <ItemTemplate>
                            <asp:Image ID="Image3" runat="server" src='<%# PageOperator.GetListImageStatus22(Eval("IsTercelBTC").ToString() =="1" ? "1" : "0") %>'  />
                           
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                   <%-- <asp:TemplateField HeaderText="操作">
                        <ItemTemplate>
                            <a href="<%# "Brand_Operate.aspx?guid=" + "'" + Eval("Guid") + "'" %>" style="color: #4482b4;">
                                编辑</a>
                            <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("Guid") %>'
                                OnClientClick=" return window.confirm('您确定要删除吗?'); " OnClick="ButtonDeleteBylink_Click">删除</asp:LinkButton>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>--%>
                </Columns>
            </ShopNum1:Num1GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="SelectBTCRecommend"
        TypeName="ShopNum1.BusinessLogic.ShopNum1_Brand_Action">
        <SelectParameters>
            <asp:ControlParameter ControlID="TxtProductName" Name="name" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TextBoxCreateTime1" Name="DateStart" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="TextBoxCreateTime2" Name="DateOver" 
                PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="DropDownListTuiJian" Name="RecommendType" 
                PropertyName="SelectedValue" Type="String" />
            <asp:ControlParameter ControlID="DropDownListPaiXu" Name="Sort" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    <asp:HiddenField ID="HiddenFieldCode" runat="server" Value="-1" />
    </form>
    <script type="text/javascript" src="js/showimg.js"> </script>
</body>
</html>