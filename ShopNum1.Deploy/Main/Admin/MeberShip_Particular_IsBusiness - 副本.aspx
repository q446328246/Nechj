<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MeberShip_Particular_IsBusiness.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.MeberShip_Particular_IsBusiness" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>会员等级申请详细</title>
     <link rel="stylesheet" type="text/css" href="style/css.css" />
</head>
<body>
     <form id="form1" runat="server">
    <div id="right">
        <div class="rhigth">
            <div class="rl">
            </div>
            <div class="rcon">

                <h3>
                    <span id="Span1">
                        <asp:Label ID="LabelPageTitle" runat="server" Font-Bold="True" Text="会员等级申请详细"></asp:Label></span></h3>
            </div>
            <div class="rr">
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="inner_page_list">
                <table cellpadding="0" cellspacing="1" border="0">
                    <tr>
                        <th align="right">
                            会员ID：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxName" ReadOnly="true" CssClass="allinput3 tinput" 
                                runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            姓名：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopCategory" ReadOnly="true" CssClass="allinput3 tinput" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>                        <tr>
                        <th align="right" width="20%">
                            身份证号：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopName" ReadOnly="true" CssClass="allinput3 tinput" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            商家名称：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopType" ReadOnly="true" CssClass="allinput3 tinput" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
               
                    <tr style="display: none">
                        <th align="right" width="20%">
                            审核状态：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxSalesRange" ReadOnly="true" CssClass="allinput3 tinput" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    
            
                    <tr>
                        <th align="right">
                            提交申请日期：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxTel" ReadOnly="true" CssClass="allinput3 tinput" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
               






                    
 
            <%--       
                    <tr>
                        <th align="right">
                            身份证（正反）：
                        </th>
                        <td align="left">
                            <a runat="server" target="_blank" id="aCardImage1">
                                <asp:Image ID="ImageCardImage1" runat="server" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                    Height="178px" Width="190px" /></a>
                        </td>
                    </tr>--%>
                    

                   <%-- <asp:Panel ID="PanelShowBusinessLicense" runat="server" Visible="true">
                        <tr>
                            <th align="right">
                                驾驶证：
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aBusinessLicense">
                                    <asp:Image ID="ImageBusinessLicense" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>--%>
<%--                    <asp:Panel ID="PanelTaxRegistrationtr" runat="server" Visible="true">
                        <tr>
                            <th align="right">
                                行驶证：
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aTaxRegistrationtr">
                                    <asp:Image ID="ImageTaxRegistrationtr" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>--%>
                    <asp:Panel ID="PanelOrganization" runat="server" Visible="true">
                        <tr>
                            <th align="right">
                                身份证正面：
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aOrganization">
                                    <asp:Image ID="ImageOrganization" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelShopImageone" runat="server" Visible="true">
                        <tr>
                            <th align="right">
                                身份证反面：
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="ImageCardImageFanCardImage">
                                    <asp:Image ID="ImageBusinessLicenseFanCardImage" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="Panel1" runat="server" Visible="true">
                        <tr>
                            <th align="right">
                                营业执照：
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="ImageLicenseImage">
                                    <asp:Image ID="ImageBusinessLicense" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>


                    
<%--                    <asp:Panel ID="PanelShopImagetwo" runat="server" Visible="true">
                        <tr>
                            <th align="right">
                                店铺内部情况2：
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aShopImagetwo">
                                    <asp:Image ID="ImageShopImagetwo" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>--%>
                    
                     

                    
                    
                </table>
                <div class="tablebtn">
                    <asp:Button ID="LinkPass" runat="server" Text="通过" CssClass="fanh"  OnClientClick=" return window.confirm('您确定要审批通过吗?'); " OnClick="ButtonPassByShip_Click"/>
                    <asp:Button ID="LinkDelte" runat="server" Text="拒绝" CssClass="fanh"  OnClientClick=" return window.confirm('您确定要审批拒绝吗?'); " OnClick="ButtonRefuseByShip_Click" />
                    <asp:Button ID="ButtonBank" runat="server" Text="返回列表" CssClass="fanh" OnClick="ButtonBank_Click" />
                </div>
            </div>
        </div>
        
    </div>
    </form>
</body>
</html>
