<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Test.aspx.cs" Inherits="ShopNum1.Deploy.Main.Admin.Test" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div class="dataTable">
        <asp:HiddenField ID="hfRptColumns" runat="server" Value="name" />
        <table cellpadding="1" cellspacing="0" border="1" style="width: 800px">
            <thead>
                <tr>
                    <th>
                        序号
                    </th>
                    <th>
                        规格值名称
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptTest" runat="server" OnItemCommand="rptTest_OnItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <%# Container.ItemIndex + 1 %>
                            </td>
                            <td>
                                <asp:TextBox ID="txtExpenseAmount" runat="server" Text='<%#Eval("name") %>'></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="butDelete" runat="server" CommandArgument='<%#Eval("name") %>' CommandName="del"
                                    Text="删除" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        <div>
            <asp:Button ID="btnAddNewRow" runat="server" OnClick="btnAddNewRow_Click" Text="添加一行" />
            <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="保存" />
        </div>
    </div>
    </form>
</body>
</html>
