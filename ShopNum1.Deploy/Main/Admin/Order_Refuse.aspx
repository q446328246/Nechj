<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order_Refuse.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Order_Refuse" %>

<%@ Import Namespace="System.Data" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ShopNum1" %>
<%@ Register Assembly="ShopNum1.Control" Namespace="ShopNum1.Control" TagPrefix="cc1" %>
<%@ Register Src="UserControl/MessageShow.ascx" TagName="MessageShow" TagPrefix="ShopNum1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>被A网拒绝的订单审核</title>
     <link rel="stylesheet" type="text/css" href="style/css.css" />
    <script type="text/javascript" language="javascript" src="js/CommonJS.js"> </script>
  <script language="Javascript" type="text/javascript">
      //----------------------------------------check全选事件---start---------------------------------------
      // 点击复选框时触发事件

      function postBackByObject() {
          var o = window.event.srcElement;
          if (o.tagName == "INPUT" && o.type == "checkbox") {
              __doPostBack("", "");
          }
      }
       
      function getcheck(evt) {
          //var o = window.event.srcElement;
          var o = window.event ? window.event.srcElement : evt.target;

          if (o.tagName == "INPUT" && o.type == "checkbox") //点击treeview的checkbox是触发
          {
              var d = o.id; //获得当前checkbox的id;

              var e = d.replace("CheckBox", "Nodes"); //通过查看脚本信息,获得包含所有子节点div的id

              var div = window.document.getElementById(e); //获得div对象
              if (div != null) //如果不为空则表示,存在子节点
              {
                  var check = div.getElementsByTagName("INPUT"); //获得div中所有的已input开始的标记

                  for (i = 0; i < check.length; i++) {
                      if (check[i].type == "checkbox") //如果是checkbox
                      {
                          check[i].checked = o.checked; //子节点的状态和父节点的状态相同,即达到全不选
                      }

                  }

              }

              //                //else //点子节点的时候,使父节点的状态改变,即不为全选
              //                //{
              //                //处理父节点

              //                var divid = o.parentNode.parentNode.parentNode.parentNode.parentNode; //子节点所在的div
              //                while (divid != null && divid.getAttribute("ID")!="TreeViewData") 
              //                {

              //                    var id = divid.getAttribute("ID").replace("Nodes", "CheckBox"); //获得根节点的id
              //                    if (window.document.getElementById(id) != null) 
              //                    {
              //                       if(o.checked==true)
              //                       {
              //                          window.document.getElementById(id).checked = true;
              //                         
              //                        }
              //                      divid = window.document.getElementById(id).parentNode.parentNode.parentNode.parentNode.parentNode;
              //                    }
              //                    else 
              //                    {
              //                        divid = null;
              //                    }
              //                }

          }

      }

      //----------------------------------------check全选事件---end---------------------------------------


      function SelectAllCheckboxesNew(obj) {
          var inputs = document.getElementById("ShipNum1GridViewShow").getElementsByTagName('input');
          for (var i = 0; i < inputs.length; i++) {
              if (inputs[i].type == "checkbox") {
                  inputs[i].checked = obj.checked;
              }
          }
      }

      //Checkbox全选

      function SelectAllCheckboxes(obj) {
          var theTable = obj.parentNode.parentNode.parentNode;
          var inputs = theTable.getElementsByTagName('input');
          for (var i = 0; i < inputs.length; i++) {
              if (inputs[i].type == "checkbox") {
                  inputs[i].checked = obj.checked;
              }
          }
      }

      //返回 chk 所在行的单元格值
      // @param chk 表示行中的 input type=check 对象

      function GetItmeValue(checkboxitem) {
          var tblRow = checkboxItem.parentNode.parentNode;
          // 改变 tblRow.cells[<cellIndex>] 中占位符 <cellIndex> 访问不同单元格
          document.getElementById("CheckShipID").value = tblRow.cells[1].innerHTML;
      }

      /*       
      返回指定 grdId 中所有选中行的单元格值
      @param grdId 表示 GridView/DataGrid 客户端 ID，实际上他们均呈现为 <table />
      @param chkIdPart 表示待处理 input type=check 控件的 ID 中的部分，考虑行中可能存在多个 checkbox， 通过此参数可以准确确定目标
      */

      function GetAllItmeValue(gridviewid, chkIdPart) {
          var tbl = document.getElementById(gridviewid);
          var checkboxlist;
          var checkvalues = "";

          checkboxlist = tbl.getElementsByTagName("input"); // 返回表内嵌的所有 input 控件

          for (var j = 0; j < checkboxlist.length; j++) {
              // 多条件准确确定目标 checkbox
              if (checkboxlist[j].type == "checkbox" && checkboxlist[j].checked && checkboxlist[j].id.indexOf(checkboxItem) > -1) {
                  checkvalues += ReturnItemValue(checkboxlist[j]) + ",";

              }
          }
          //
          document.getElementById("CheckShipID").value = checkvalues;
      }

      //返回选中CheckBox所在行的第一列的值

      function ReturnItemValue(checkboxItem) {
          var tblRow = checkboxitem.parentNode.parentNode;
          // 改变 tblRow.cells[<cellIndex>] 中占位符 <cellIndex> 访问不同单元格
          return tblRow.cells[1].innerHTML;

      }

      //公交变量，存放选中的checkbox个数
      var checkCount = 0;

      function MangeShop(msg) {
          checkCount = 0;
          var checkedBoxValues = GetCheckedBoxValues();
          if (checkedBoxValues == "0") {
              alert("请选择要操作的记录！");
              return false;
          } else if (checkCount > 1) {
              alert(msg);
              return false;
          } else {
              document.getElementById("CheckShipID").value = checkedBoxValues.replace('0,', '');
              return true;
          }
      }
      function GetCheckedBoxValues() {
          var checkedBoxValues = "0";
          var inputs = document.getElementsByTagName("input");
          for (var j = 0; j < inputs.length; j++) {
              if (inputs[j].type == "checkbox" && inputs[j].id != "checkboxAll" && inputs[j].id != "CheckBoxListGroup_0") {
                  if (inputs[j].checked == true) {
                      checkedBoxValues += ("," + "'" + inputs[j].value + "'");
                      checkCount++;
                  }
              }
          }
          return checkedBoxValues;
      }
     




    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="right">
            <div class="mhead">
                <div class="ml">
                    <div class="mr">
                        <ul class="mul">
                            <li id="current1">
                                <asp:LinkButton ID="LinkButtonAll" runat="server" CssClass="cur" OnClick="LinkButtonAll_Click">未审核</asp:LinkButton>
                            </li>
                            <li id="current2">
                                <asp:LinkButton ID="LinkButtonNopayment" runat="server" OnClick="LinkButtonNopayment_Click">已审核</asp:LinkButton>
                            </li>
                            
                        </ul>
                    </div>
                </div>
            </div>
        </div>
        <div class="welcon clearfix">
            <div class="order_edit">
                <div class="sbtn">
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                        
                            <td valign="top" style="text-align: right;">
                                订单编号：
                            </td>
                            <td valign="top" class="lmf_app">
                                <input type="text" id="txtMemLoginID" class="tinput" style="width: 200px;" runat="server" />
                            </td>
                            <td>
                             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                            <td valign="top" style="text-align: right;">
                                会员编号：
                            </td>
                            <td valign="top" class="lmf_app">
                                <input type="text" id="Textmemloginid" class="tinput" style="width: 200px;" runat="server" />
                            </td>
                            <td>
                             &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                            </td>
                            <td valign="top" style="text-align: right;">
                                错误信息：
                            </td>
                            <td valign="top" class="lmf_app">
                                <input type="text" id="TextMome" class="tinput" style="width: 200px;" runat="server" />
                            </td>

                            <td style="text-align: left;">
                                <asp:Button ID="ButtonSearch" runat="server" OnClick="ButtonSearch_Click" Text="查询"
                                    CssClass="dele" />
                            </td>
                        </tr>
                        <tr >
                        <td valign="top" style="text-align: right;">
                          <asp:LinkButton ID="Button1" runat="server" OnClick="ButtonDelete_Click" OnClientClick=" return AuditButton() "
                                    CssClass="shanchu lmf_btn"><span>批量审核  &nbsp;&nbsp;&nbsp;&nbsp;  </span></asp:LinkButton>
                                    </td>
                        <td valign="top" style="text-align: right;">
                       &nbsp;
                                    </td>
                        <td valign="top" style="text-align: right;">
                          <asp:LinkButton ID="LinkButton1" runat="server" OnClick="ButtonTui_Click" OnClientClick=" return OperateButton() "
                                    CssClass="shanchu lmf_btn"><span>批量重推  &nbsp;&nbsp;&nbsp;&nbsp;  </span></asp:LinkButton>
                                    </td>
                                    
                                    </tr>
                        </tr>
                    </table>
                </div>
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
                     <asp:TemplateField>
                            <HeaderTemplate>
                                <input id="checkboxAll" onclick=" javascript: SelectAllCheckboxes(this); " type="checkbox" />
                            </HeaderTemplate>
                            <HeaderStyle CssClass="select_width" />
                            <ItemTemplate>
                                <input id="checkboxItem" value='<%# Eval("OrderID") %>' type="checkbox" />
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    <asp:TemplateField  HeaderText="订单ID">
                    <ItemTemplate>
                    <%# Eval("OrderID")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="付款人ID">
                    <ItemTemplate>
                    <%# Eval("MemberloginID")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="被拒绝退款原因">
                    <ItemTemplate>
                    <%# Eval("Remark")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="被拒绝的时间">
                    <ItemTemplate>
                    <%# Eval("EndTime")%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="是否审核">
                    <ItemTemplate>
                    <%# Eval("Status").ToString() =="1"?"已审核":"未审核"%>
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="被拒操作">
                    <ItemTemplate>
                    <%# Eval("AdminID")%>
                    </ItemTemplate>
                    </asp:TemplateField>
               
                   
                    <asp:TemplateField HeaderText="操作" >
                        <ItemTemplate>
                        <asp:LinkButton ID="LinkService" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("OrderID") %>'
                                OnClientClick=" return window.confirm('您确定要推送吗?'); " OnClick="LinkService_Click">重新推送</asp:LinkButton>
                            <asp:LinkButton ID="LinkPass" runat="server" Style="color: #4482b4;" CommandArgument='<%# Eval("OrderID") %>'
                                OnClientClick=" return window.confirm('您确定要审批通过吗?'); " OnClick="ButtonPassByShip_Click">审核</asp:LinkButton>
                            
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="15%" />
                    </asp:TemplateField>
                </Columns>
            </cc1:Num1GridView>

        </div>
        
        <asp:HiddenField ID="CheckGuid" runat="server" Value="0" />
    </div>
    </form>
</body>
</html>
