<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewSelect_Money_All.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.NewSelect_Money_All" %>

<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>每日资金统计</title>
  <link rel='stylesheet' type='text/css' href='style/css.css' />
    <link id="sizestylesheet" rel='stylesheet' type='text/css' href='style/css1.css' />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
    <script type='text/javascript' src='js/resolution-test.js'> </script>
 
</head>
<body>
    <form id="form1" runat="server">
  
    <div id="right">
        <div class="rhigth"> 
            <div class="rl">
            </div>
            <div class="rcon">
                <h3>
                    每日资金统计</h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <table cellpadding="0" cellspacing="0" border="0">
               <td class="lmf_padding">
                            <asp:Label ID="LabelSDate" runat="server" Text="操作日期："></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSDate1" runat="server" CssClass="tinput_data"></asp:TextBox>
                        </td>
                        <td style="padding-left: 4px; vertical-align: top;">
                            <img id="imgCalendarSDate1" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 3px; width: 16px;" />
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorStartDate" runat="server"
                                ControlToValidate="TextBoxSDate1" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                EnableScriptLocalization="True">
                            </ShopNum1:ToolkitScriptManager>
                        </td>
                        <td>
                            <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TextBoxSDate1"
                                PopupButtonID="imgCalendarSDate1" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                            </ShopNum1:CalendarExtender>
                        </td>
                        <td class="lmf_px">
                            -
                        </td>
                        <td>
                            <asp:TextBox ID="TextBoxSDate2" runat="server" CssClass="tinput_data"></asp:TextBox>
                        </td>
                        <td style="padding-left: 4px; vertical-align: top;">
                            <img id="imgCalendarSDate2" alt="" src="/ImgUpload/Calendar.png" style="height: 18px;
                                position: relative; top: 3px; width: 16px;" />
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidatorEndDate" runat="server"
                                ControlToValidate="TextBoxSDate2" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                        </td>
                        <td>
                            <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="TextBoxSDate2"
                                PopupButtonID="imgCalendarSDate2" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                            </ShopNum1:CalendarExtender>
                        </td>
                        <td>
                            <asp:Button ID="ButtonSearch" runat="server" Text="查询" OnClick="ButtonSearch_Click"
                                CssClass="dele" />
                        </td>
                </table>
            </div>
            <cc1:Num1GridView ID="ShipNum1GridViewShow" runat="server" AutoGenerateColumns="False"
                AllowPaging="True" AllowSorting="True" ascendingimageurl="~/images/SortAsc.gif"
                descendingimageurl="~/images/SortDesc.gif" AddSequenceColumn="False" Width="98%"
                Del="False" DeletePromptText="确实要删除指定的记录吗？" Edit="False" FixHeader="False" GridViewSortDirection="Ascending"
                PagingStyle="None" TableName="" AllowMultiColumnSorting="False"
                BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" GridLines="Vertical" EnableModelValidation="True" OnPageIndexChanging="ShipNum1GridViewShow_click">
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                <%--分页--%>
                <PagerStyle CssClass="lmf_page" BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            
                    <asp:TemplateField  HeaderText="总人数">
                    <ItemTemplate>
                    <%# Eval("MemLoginIDNum")%>
                    </ItemTemplate>
                    </asp:TemplateField>

                          <asp:TemplateField  HeaderText="日注册人数">
                    <ItemTemplate>
                    <%# Eval("yesterdayMemLoginID")%>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField  HeaderText="日新增NEC">
                    <ItemTemplate>
                    <%# Eval("ChongZhiNEC")%>
                    </ItemTemplate>
                    </asp:TemplateField>



                    <asp:TemplateField  HeaderText="释放">
                    <ItemTemplate>
                    <%# Eval("bonus1")%>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField  HeaderText="节点">
                    <ItemTemplate>
                    <%# Eval("bonus2")%>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField  HeaderText="推荐">
                    <ItemTemplate>
                    <%# Eval("bonus3")%>
                    </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField  HeaderText="算力返还">
                    <ItemTemplate>
                    <%# Eval("bonus4")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField  HeaderText="签到">
                    <ItemTemplate>
                    <%# Eval("bonus5")%>
                    </ItemTemplate>
                    </asp:TemplateField>

                    
                    <asp:TemplateField  HeaderText="理财返还">
                    <ItemTemplate>
                    <%# Eval("bonus6")%>
                    </ItemTemplate>
                    </asp:TemplateField>




                    <asp:TemplateField  HeaderText="日提现">
                    <ItemTemplate>
                    <%# Eval("NEC_TiXian_NEC")%>
                    </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField  HeaderText="日增锁仓">
                    <ItemTemplate>
                    <%# Eval("ShouldPayPrice")%>
                    </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField  HeaderText="可用NCE总数">
                    <ItemTemplate>
                    <%# Eval("dv")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    

                    <asp:TemplateField  HeaderText="冻结NCE总数">
                    <ItemTemplate>
                    <%# Eval("pv_a")%>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField  HeaderText="总NCE">
                    <ItemTemplate>
                    <%# Eval("dv_pv_a")%>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField  HeaderText="总USDT">
                    <ItemTemplate>
                    <%# Eval("AdvancePayment")%>
                    </ItemTemplate>
                    </asp:TemplateField>

                    
                    <asp:TemplateField  HeaderText="总ETH">
                    <ItemTemplate>
                    <%# Eval("hv")%>
                    </ItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField  HeaderText="锁60">
                    <ItemTemplate>
                    总个数：<%# Eval("Lock_60")%>
                    人数：<%# Eval("Lock_60_Num")%>
                    </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField  HeaderText="锁180">
                    <ItemTemplate>
                    总个数：<%# Eval("Lock_180")%>
                    人数：<%# Eval("Lock_180_Num")%>
                    </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField  HeaderText="锁270">
                    <ItemTemplate>
                    总个数：<%# Eval("Lock_270")%>
                    人数：<%# Eval("Lock_270_Num")%>
                    </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField  HeaderText="时间">
                    <ItemTemplate>
                    <%# Eval("createdate")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                            

                            
                        </Columns>
                    </cc1:Num1GridView>
        </div>
       
           
        <asp:HiddenField ID="CheckShipID" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
