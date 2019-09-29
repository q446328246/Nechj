<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Article_List.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Article_List" %>
<%@ Import Namespace="ShopNum1.Common" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title>资讯列表</title>
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
                            平台文章列表</h3>
                    </div>
                    <div class="rr">
                    </div>
                </div>
                <div class="welcon clearfix">
                    <div class="order_edit">
                        <table border="0" cellspacing="0" cellpadding="0">
                            <tr style="height: 35px; vertical-align: top;">
                                <td>
                                    文章标题：
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxTitle" Width="200" runat="server" CssClass="tinput"></asp:TextBox>
                                </td>
                                <td class="lmf_padding">
                                    文章类别：
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListArticleCategoryID" runat="server" Width="207px"
                                                      CssClass="tselect">
                                    </asp:DropDownList>
                                </td>
                                <td class="lmf_padding">
                                    前台是否显示：
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsShow" runat="server" Width="207px" CssClass="tselect">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr style="height: 35px; vertical-align: top;">
                                <td style="text-align: right;">
                                    发布人：
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxPublisher" runat="server" Width="200" CssClass="tinput"></asp:TextBox>
                                </td>
                                <td class="lmf_padding">
                                    是否头条：
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsHead" runat="server" Width="207px" CssClass="tselect">
                                    </asp:DropDownList>
                                </td>
                                <td class="lmf_padding">
                                    是否推荐：
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsRecommend" runat="server" Width="207px" CssClass="tselect">
                                    </asp:DropDownList>
                                </td>
                                <%-- <td align="right">
                            是否允许评论：
                        </td>
                        <td>--%>
                                <asp:DropDownList ID="DropDownListIsAllowComment" runat="server" Width="180px" Visible="false"
                                                  CssClass="tselect">
                                </asp:DropDownList>
                                <%-- </td>--%>
                            </tr>
                            <tr style="height: 35px; vertical-align: top;">
                                <td align="right">
                                    是否热点：
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListIsHot" runat="server" Width="207px" CssClass="tselect">
                                    </asp:DropDownList>
                                </td>
                                <td class="lmf_padding">
                                    发布时间：
                                </td>
                                <td colspan="3">
                                    <table cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="textBoxStartDate" runat="server" CssClass="tinput_data"></asp:TextBox>
                                            </td>
                                            <td>
                                                <ShopNum1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
                                                                               EnableScriptLocalization="True">
                                                </ShopNum1:ToolkitScriptManager>
                                            </td>
                                            <td style="padding-left: 4px; vertical-align: top;">
                                                <img id="imgCalendarStartTime" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative; top: 3px; width: 16px;" />
                                            </td>
                                            <td>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatortextBoxStartDate" runat="server"
                                                                                ControlToValidate="textBoxStartDate" Display="Dynamic" ErrorMessage="时间格式不正确"
                                                                                ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <ShopNum1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="textBoxStartDate"
                                                                           PopupButtonID="imgCalendarStartTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                                </ShopNum1:CalendarExtender>
                                            </td>
                                            <td class="lmf_px">
                                                -
                                            </td>
                                            <td>
                                                <asp:TextBox ID="textBoxEndDate" runat="server" CssClass="tinput_data"></asp:TextBox>
                                            </td>
                                            <td style="padding-left: 4px; vertical-align: top;">
                                                <img id="imgCalendarEndTime" alt="" src="/ImgUpload/Calendar.png" style="height: 18px; position: relative; top: 3px; width: 16px;" />
                                            </td>
                                            <td>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidatortextBoxEndDate" runat="server"
                                                                                ControlToValidate="textBoxEndDate" Display="Dynamic" ErrorMessage="时间格式不正确" ValidationExpression="^((((1[6-9]|[2-9]\d)\d{2})-(0?[13578]|1[02])-(0?[1-9]|[12]\d|3[01]))|(((1[6-9]|[2-9]\d)\d{2})-(0?[13456789]|1[012])-(0?[1-9]|[12]\d|30))|(((1[6-9]|[2-9]\d)\d{2})-0?2-(0?[1-9]|1\d|2[0-9]))|(((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))-0?2-29-))( (20|21|22|23|[0-1]?\d):[0-5]?\d:[0-5]?\d)?$"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <ShopNum1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="textBoxEndDate"
                                                                           PopupButtonID="imgCalendarEndTime" CssClass="ajax__calendar" Format="yyyy-MM-dd">
                                                </ShopNum1:CalendarExtender>
                                            </td>
                                            <td>
                                                <asp:Button ID="ButtonSearch" runat="server" Text="查询" OnClick="ButtonSearch_Click"
                                                            CssClass="dele" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                        <div class="sbtn">
                            <asp:Button ID="ButtonAdd" runat="server" Text="添加" OnClick="ButtonAdd_Click" CausesValidation="False"
                                        CssClass="tianjia2 picbtn" />
                            <asp:Button ID="ButtonEdit" runat="server" CausesValidation="False" Text="编辑" OnClientClick=" return EditButton() "
                                        OnClick="ButtonEdit_Click" CssClass="dele" Visible="false" />
                            <asp:Button ID="ButtonUp" runat="server" Text="向上" CssClass="dele" />
                            <asp:Button ID="ButtonDown" runat="server" Text="向下" CssClass="dele" />
                            <asp:Button ID="ButtonDelete" runat="server" CausesValidation="False" Text="批量删除"
                                        OnClientClick=" if (Page_ClientValidate()) return DeleteButton();return false; "
                                        OnClick="ButtonDelete_Click" CssClass="shanchu com" />
                            <asp:Button ID="ButtonShow" runat="server" Text="前台显示" CssClass="qb" />
                            <asp:Button ID="ButtonHidden" runat="server" Text="前台隐藏" CssClass="qb" />
                            <asp:Button ID="ButtonBrowse" runat="server" Text="前台预览" CssClass="qb" />
                            <asp:Button ID="ButtonViewComment" runat="server" Text="查看评论" CssClass="chakanpl picbtn"
                                        OnClick="ButtonViewComment_Click" OnClientClick=" return EditButton() " />
                            <uc1:MessageShow ID="MessageShow" runat="server" Visible="False" />
                        </div>
                    </div>
                    <ShopNum1:num1gridview id="Num1GridViewShow" runat="server" autogeneratecolumns="False"
                                           allowpaging="True" allowsorting="True" ascendingimageurl="~/images/SortAsc.gif"
                                           descendingimageurl="~/images/SortDesc.gif" width="98%" addsequencecolumn="False"
                                           allowmulticolumnsorting="False" bordercolor="#CCDDEF" borderstyle="Solid" borderwidth="1px"
                                           cellpadding="4" del="False" deleteprompttext="确实要删除指定的记录吗？" edit="False" fixheader="False"
                                           gridviewsortdirection="Ascending" pagingstyle="None" tablename="" datasourceid="ObjectDataSourceData">
                        <HeaderStyle HorizontalAlign="Center" CssClass="list_header" ForeColor="White"></HeaderStyle>
                        <PagerStyle HorizontalAlign="left" BackColor="#EEEEEE" ForeColor="#6699CC"></PagerStyle>
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <input id="checkboxAll" onclick=" javascript:SelectAllCheckboxes(this); " type="checkbox" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <input id="checkboxItem" value='<%# Eval("Guid") %>' type="checkbox" />
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Guid" HeaderText="Guid" Visible="False" SortExpression="Guid">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="标题" SortExpression="Title">
                                <ItemTemplate>
                                    <a href="<%# GetUrl(Eval("Guid")) %>" target="_blank"  title="<%#Eval("Title") %>">
                                        <asp:Label ID="LabelTitle" runat="server" Text='<%#(Eval("Title").ToString().Length > 15 ? Eval("Title").ToString
                                                                                                                                       ().Substring(0, 15) : Eval("Title").ToString()) %>'></asp:Label></a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Publisher" HeaderText="发布人" SortExpression="Publisher"   ItemStyle-HorizontalAlign="Center" />
                            <asp:BoundField DataField="Name" HeaderText="所属类型" SortExpression="Name"   ItemStyle-HorizontalAlign="Center"  />
                            <asp:BoundField HeaderText="排序号" DataField="OrderID" SortExpression="OrderID">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="发布时间" DataField="CreateTime" SortExpression="CreateTime">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="是否显示" SortExpression="IsShow">
                                <ItemTemplate>
                                    <asp:Image ID="Image1" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(DataBinder.Eval(Container, "DataItem(IsShow)", "{0}") == "0" ? "1" : "0") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="是否热点" SortExpression="IsHot">
                                <ItemTemplate>
                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(DataBinder.Eval(Container, "DataItem(IsHot)", "{0}") == "0" ? "1" : "0") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="是否推荐" SortExpression="IsRecommend">
                                <ItemTemplate>
                                    <asp:Image ID="Image3" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(DataBinder.Eval(Container, "DataItem(IsRecommend)", "{0}") == "0" ? "1" : "0") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="是否头条" SortExpression="IsHead">
                                <ItemTemplate>
                                    <asp:Image ID="Image4" runat="server" ImageUrl='<%# PageOperator.GetListImageStatus(DataBinder.Eval(Container, "DataItem(IsHead)", "{0}") == "0" ? "1" : "0") %>' />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                    <a href="<%# "Article_Operate.aspx?Guid='" + Eval("Guid") + "'" %>" style="color: #4482b4;">
                                        编辑</a>
                                    <asp:LinkButton ID="LinkDelte" runat="server" Style="color: #4482b4;" OnClick="ButtonDeleteBylink_Click"
                                                    CommandArgument='<%# Eval("Guid") %>' OnClientClick=" return window.confirm('您确定要删除吗?'); ">删除</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </ShopNum1:num1gridview>
                </div>
                <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
                <asp:ObjectDataSource ID="ObjectDataSourceData" runat="server" SelectMethod="Search"
                                      TypeName="ShopNum1.BusinessLogic.ShopNum1_Article_Action">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="TextBoxTitle" Name="title" PropertyName="Text" Type="String" />
                        <asp:ControlParameter ControlID="TextBoxPublisher" Name="publisher" PropertyName="Text"
                                              Type="String" />
                        <asp:ControlParameter ControlID="DropDownListArticleCategoryID" Name="articlecategoryid"
                                              PropertyName="SelectedValue" Type="Int32" />
                        <asp:ControlParameter ControlID="textBoxStartDate" Name="startdate" PropertyName="Text"
                                              Type="String" />
                        <asp:ControlParameter ControlID="textBoxEndDate" Name="enddate" PropertyName="Text"
                                              Type="String" />
                        <asp:ControlParameter ControlID="DropDownListIsShow" Name="isshow" PropertyName="SelectedValue"
                                              Type="Int32" />
                        <asp:ControlParameter ControlID="DropDownListIsHot" Name="ishot" PropertyName="SelectedValue"
                                              Type="Int32" />
                        <asp:ControlParameter ControlID="DropDownListIsRecommend" Name="isrecommand" PropertyName="SelectedValue"
                                              Type="Int32" />
                        <asp:ControlParameter ControlID="DropDownListIsHead" Name="ishead" PropertyName="SelectedValue"
                                              Type="Int32" />
                        <asp:ControlParameter ControlID="DropDownListIsAllowComment" Name="isallowcomment"
                                              PropertyName="SelectedValue" Type="Int32" />
                        <asp:Parameter Name="isDeleted" Type="Int32" DefaultValue="0" />
                    </SelectParameters>
                </asp:ObjectDataSource>
            </div>
        </form>
    </body>
</html>