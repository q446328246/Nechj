<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberShip_Edit.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.MemberShip_Edit" %>
<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>会员等级操作</title>
     <link rel="stylesheet" type="text/css" href="style/css.css" />
     <script src="/js/jquery-1.6.2.min.js" type="text/javascript"></script>
     <script src="/main/js/location.js" type="text/javascript"></script>
     <script src="../js/areas.js" type="text/javascript"></script>
    
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
                            <asp:TextBox ID="TextBoxName"   CssClass="allinput3 tinput" 
                                runat="server" ></asp:TextBox>
                        </td>
                    </tr>
                    <%--<tr>
                        <th align="right" width="20%">
                            原有会员等级：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopName"   CssClass="allinput3 tinput" runat="server" Enabled="false" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            升级的会员等级：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopType"   CssClass="allinput3 tinput" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>--%>
                    <tr>
                        <th align="right" width="20%">
                            姓名：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxShopCategory"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right" width="20%">
                            用户编号：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxMainGoods"   CssClass="allinput3 tinput" runat="server"
                                 ></asp:TextBox>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <th align="right" width="20%">
                            审核状态：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxSalesRange"   CssClass="allinput3 tinput" runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    
            
                    <tr>
                        <th align="right">
                            提交申请日期：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxTel"   CssClass="allinput3 tinput" runat="server" Enabled="false"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            生日：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxPhone"   CssClass="allinput3 tinput" runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            身份证：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxPostalCode"   CssClass="allinput3 tinput" runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            性别：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxIdentityCard"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
            <th align="right">
                电话：
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxRegistrationNum"   CssClass="allinput3 tinput" runat="server" Enabled="true"></asp:TextBox>
            </td>
        </tr>
                    <tr>
            <th align="right">
                手机：
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxCompanName"   CssClass="allinput3 tinput" runat="server" Enabled="true"></asp:TextBox>
            </td>
        </tr>
                   <tr>
            <th align="right">
                居住地址：
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxLegalPerson"   CssClass="allinput3 tinput" runat="server" Enabled="true"></asp:TextBox>
            </td>
        </tr>
                    <tr>
            <th align="right">
                申办区县代理的地址：
            </th>
                <td align="left">
                <asp:TextBox ID="TextBoxRegisteredCapital"   CssClass="allinput3 tinput" runat="server" Enabled="false" ></asp:TextBox>
            </td>
        </tr>

        <tr>
            <th align="right">
                修改申办区县代理的地址：
            </th>
            
            <td width="150" colspan="2" style="border-bottom: 1px solid #C6DFFF;">
                    <div id="p_local" style="float: left;">
                    </div>
                    <span class="star" style="float: left;" id="diqu"></span>
                </td>
        </tr>

             <tr>
            <th align="right">
                曾从事职业：
            </th>
            <td align="left">
                <asp:TextBox ID="TextBoxBusinessTerm"   CssClass="allinput3 tinput" runat="server" Enabled="true"></asp:TextBox>
            </td>
        </tr>
                   
                    <tr >
                        <th align="right">
                            招商人姓名：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxAddress"   CssClass="allinput3 tinput" runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            招商人用户编号：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxAddressValue"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            招商人注册时间：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxAddressDeteil"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            招商人生日：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxHeBathday"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            招商人身份证号：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxHeCar"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                 <tr>
                        <th align="right">
                            招商人性别：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxHeSex"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            招商人电话：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxHePhone"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            招商人手机：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxHeModel"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            招商人居住地址：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxHeAdress"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <th align="right">
                            区代名称：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxHeReplaceName"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <th align="right">
                            上级区代：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxHeReplace"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                   
                   </tr>
                   <tr>
                        <th align="right">
                            结算时间：
                        </th>
                        <td align="left">
                            <asp:TextBox ID="TextBoxExamineTime"   CssClass="allinput3 tinput"
                                runat="server" Enabled="true"></asp:TextBox>
                        </td>
                   
                   </tr>
                   
                    <tr>
                        <th align="right">
                            身份证（正反）：
                        </th>
                        <td align="left">
                            <a runat="server" target="_blank" id="aCardImage1">
                                <asp:Image ID="ImageCardImage1" runat="server" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                    Height="178px" Width="190px" /></a>
                        </td>
                    </tr>
                    

                    <asp:Panel ID="PanelShowBusinessLicense" runat="server" Visible="true">
                        <tr>
                            <th align="right">
                                营业执照：
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aBusinessLicense">
                                    <asp:Image ID="ImageBusinessLicense" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelTaxRegistrationtr" runat="server" Visible="true">
                        <tr>
                            <th align="right">
                                税务登记证：
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aTaxRegistrationtr">
                                    <asp:Image ID="ImageTaxRegistrationtr" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>
                    <asp:Panel ID="PanelOrganization" runat="server" Visible="true">
                        <tr>
                            <th align="right">
                                房屋租赁合同：
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
                                店铺内部情况1：
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aShopImageone">
                                    <asp:Image ID="ImageShopImageone" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>
                    
                    <asp:Panel ID="PanelShopImagetwo" runat="server" Visible="true">
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
                    </asp:Panel>
                    
                     
                    <asp:Panel ID="PanelOpeningImage" runat="server" Visible="true">
                        <tr>
                            <th align="right">
                                开业门头：
                            </th>
                            <td align="left">
                                <a runat="server" target="_blank" id="aOpeningImage">
                                    <asp:Image ID="ImageOpeningImage" onerror="javascript:this.src='/ImgUpLoad/noImage.gif'"
                                        runat="server" Height="178px" Width="190px" /></a>
                            </td>
                        </tr>
                    </asp:Panel>
                    
                    
                </table>
                <div class="tablebtn">
                    <asp:Button ID="Button_Update" runat="server" Text="修改" CssClass="fanh" onclick="Button_Update_Click" OnClientClick=" return  checkSumbitDetil();"
                         />
                    <asp:Button ID="Button_Delete" runat="server" Text="删除" CssClass="fanh" 
                        onclick="Button_Delete_Click"  />
                    <asp:Button ID="ButtonBank" runat="server" Text="返回列表" CssClass="fanh" OnClick="ButtonBank_Click" />
                </div>
            </div>
        </div>
        
    </div>

    <%--地址信息--%>
<script type="text/javascript" language="javascript">


    $(document).ready(
  function () {
      // 加载区域
      $("#p_local").LocationSelect();

  }
  );


    function checkSumbitDetil() {

        var info = $("#p_local").getLocation();
        if (info.pcode == "0") {
            $("#p_local").next().show();
        }
        $("#<%=hid_AreaValue.ClientID%>").val(info.province + "," + info.city + "," + info.district + "|" + info.pcode + "," + info.ccode + "," + info.dcode);
        if (info.dcode != "0") {
            $("#<%=hid_AreaCode.ClientID%>").val(info.dcode);

        }
        else {
            if (info.ccode != "0") {
                $("#<%=hid_AreaCode.ClientID%>").val(info.ccode);

            }
            else {
                $("#<%=hid_AreaCode.ClientID%>").val(info.pcode);
            }
        };


    }
    </script>
    <script type="text/javascript" language="javascript">
        $(document).ready(
        function () {
            var area = $("#<%=hid_AreaValue.ClientID%>").val().split("|");
            var areaCode = $("#<%=hid_AreaCode.ClientID%>").val();
            var code1;
            var code2;
            var code3;
            if (areaCode.length > 8) {
                //areaCode 有三级
                code1 = areaCode.substring(0, 3);
                code2 = areaCode.substring(4, 6);
                code3 = areaCode.substring(7, 9);
            }
            if ($("#<%=hid_AreaValue.ClientID%>").val() != "") {
                var areacode = area[1].split(",");
                var areaname = area[0].split(",");
                if (areaname[0] != "")
                    $("select[name='province']").append("<option value=\"" + code1 + "\" selected=\"selected\">" + areaname[0] + "</option>");
                if (areaname[1] != "")
                    $("select[name='city']").append("<option value=\"" + code2 + "\" selected=\"selected\">" + areaname[1] + "</option>");
                if (areaname[2] != "")
                    $("select[name='district']").append("<option value=\"" + code3 + "\" selected=\"selected\">" + areaname[2] + "</option>");
            }

        });

       
</script>
<input id="hid_AreaCode" type="hidden" runat="server" value="" />
<input id="hid_AreaValue" type="hidden" runat="server" value="" />



    </form>
</body>
</html>
