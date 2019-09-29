<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbOrderView_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbOrderView_Operate" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
        <script type="text/javascript" language="javascript" src="js/jquery.pack.js"> </script>
        <script src="js/SpryTabbedPanels.js" type="text/javascript"> </script>
        <script type="text/javascript" src="../js/SpryTabbedPanels.js"> </script>
        <style type="text/css">
            #DivConmmentlist {
                border-bottom: 2px solid #6699cc;
                height: 100%;
                margin-top: 10px;
                overflow: hidden;
            }

            #DivConmmentlist a {
                background: url(image/organizationdetail_titlebj_.png) no-repeat;
                color: #333333;
                display: block;
                float: left;
                font-weight: bold;
                height: 27px;
                line-height: 27px;
                margin: 3px 3px 0 0;
                position: relative;
                text-align: center;
                white-space: nowrap;
                width: 87px;
            }

            #DivConmmentlist a:hover {
                background: url(image/organizationdetail_titlebj.png) no-repeat;
                color: #B70113;
                font-weight: bold;
            }

            #DivConmmentlist .cur {
                background: url(image/organizationdetail_titlebj.png) no-repeat 0 0;
                color: #B70113;
                display: block;
                font-weight: bold;
                height: 27px;
                line-height: 27px;
                position: relative;
                white-space: nowrap;
            }

            .diis { display: block; }

            .undiis { display: none; }
        </style>
        <script type="text/javascript">
            function turn_scrolll(n) {
                for (var i = 0; i < 2; i++) {
                    var product_meau1 = document.getElementById("A" + i);
                    var product_box1 = document.getElementById("scroll_div" + i);
                    product_meau1.className = "";
                    product_box1.style.display = "none";
                }
                document.getElementById("A" + n).className = "cur";
                document.getElementById("scroll_div" + n).style.display = "block";
            }
        </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="dpsc_mian">
                <p class="ptitle">
                    <a href="../S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><a href="TbOrderView.aspx">淘宝订单</a><span
                                                                                                                                      class="breadcrume_icon">>></span><span class="breadcrume_text">淘宝订单详细操作</span></p>
                <div id="list_main">
                    <ul id="sidebar">
                        <li id="0" class="TabbedPanelsTab">订单信息</li>
                        <li id="1" class="TabbedPanelsTab">物流信息</li>
                    </ul>
                    <div id="content" class="ordmain1">
                        <div class="biaogenr">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
                                <tr>
                                    <th colspan="4">
                                        <span class="navigator" style="font-weight: bold; padding-left: 5px;">买家信息</span>
                                    </th>
                                </tr>
                                <tr>
                                    <td class="bordleft" width="130">
                                        <asp:Label ID="Labelnick" runat="server" Text="昵称："></asp:Label>
                                    </td>
                                    <td class="bordrig">
                                        <asp:Label ID="Labelvaluenick" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="bordleft" width="130">
                                        <asp:Label ID="LabelName" runat="server" Text="真实姓名："></asp:Label>
                                    </td>
                                    <td class="bordrig">
                                        <asp:Label ID="LabelValueName" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bordleft" width="130">
                                        <asp:Label ID="LabelRegion" runat="server" Text="所在地区："></asp:Label>
                                    </td>
                                    <td class="bordrig">
                                        <asp:Label ID="LabelValueRegion" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="bordleft" width="130">
                                        <asp:Label ID="LabelPhone" runat="server" Text="联系电话："></asp:Label>
                                    </td>
                                    <td class="bordrig">
                                        <asp:Label ID="LabelValuePhone" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bordleft" width="130">
                                        <asp:Label ID="LabelEmail" runat="server" Text="邮箱："></asp:Label>
                                    </td>
                                    <td class="bordrig">
                                        <asp:Label ID="LabelValueEmail" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="bordleft" width="130">
                                        <asp:Label ID="LabelZhifubao" runat="server" Text="支付宝："></asp:Label>
                                    </td>
                                    <td class="bordrig">
                                        <asp:Label ID="LabelValueZhifubao" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bordleft" width="130">
                                        <asp:Label ID="LabelOrderNum" runat="server" Text="订单编号："></asp:Label>
                                    </td>
                                    <td class="bordrig">
                                        <asp:Label ID="LabelValueOrderNum" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td class="bordleft" width="130">
                                        <asp:Label ID="LabelZhifubaoNum" runat="server" Text="支付宝交易号："></asp:Label>
                                    </td>
                                    <td class="bordrig">
                                        <asp:Label ID="LabelValueZhifubaoNum" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bordleft" width="130">
                                        <asp:Label ID="LabelCreateTime" runat="server" Text="成交时间："></asp:Label>
                                    </td>
                                    <td colspan="3" class="bordrig">
                                        <asp:Label ID="LabelValueCreateTime" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <ShopNum1:Num1GridView ID="Num1GridView1" runat="server" AutoGenerateColumns="False"
                                                   AllowSorting="True" AscendingImageUrl="~/images/SortAsc.gif" DescendingImageUrl="~/images/SortDesc.gif"
                                                   Width="98%" AddSequenceColumn="False" AllowMultiColumnSorting="False" BorderColor="#CCDDEF"
                                                   BorderStyle="Solid" BorderWidth="0" CellPadding="4" Del="False" DeletePromptText="确实要删除指定的记录吗？"
                                                   Edit="False" FixHeader="False" GridViewSortDirection="Ascending" PagingStyle="None"
                                                   Style="margin: 14px auto 0;" TableName="">
                                <headerstyle horizontalalign="Center">
                                </headerstyle>
                                <pagerstyle horizontalalign="Left" backcolor="#EEEEEE" forecolor="#6699CC"></pagerstyle>
                                <columns>
                                    <asp:TemplateField HeaderText="宝贝">
                                        <ItemTemplate>
                                            <a href="<%# GetUrl(Eval("tid")) %>" target="_blank">
                                                <img src='<%# Eval("pic_path") %> ' style="height: 50px; width: 50px;" /></a>
                                            <a href="<%# GetUrl(Eval("tid")) %>" target="_blank">
                                                <asp:Label ID="Label1" Text='<%# Eval("title") %>' runat="server"></asp:Label></a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="300px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="宝贝属性">
                                        <ItemTemplate>
                                            <asp:Label ID="Label2" runat="server" Text='-'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="状态">
                                        <ItemTemplate>
                                            <asp:Label ID="Label3" runat="server" Text='<%# Changestatus(Eval("status")) %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="单价">
                                        <ItemTemplate>
                                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="购买数量">
                                        <ItemTemplate>
                                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("num") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="优惠">
                                        <ItemTemplate>
                                            <asp:Label ID="Label7" Text='<%# ChangePromotion(Eval("price"), Eval("point_fee")) %>'
                                                       runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="商品总价(元)">
                                        <ItemTemplate>
                                            <asp:Label ID="Label6" runat="server" Text='<%# Eval("total_fee") %>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="post_fee" HeaderText="运费(元)">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </columns>
                            </ShopNum1:Num1GridView>
                        </div>
                        <div class="biaogenr">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="biaod">
                                <tr>
                                    <th colspan="2">
                                        <span class="navigator" style="font-weight: bold; padding-left: 5px;">物流信息</span>
                                    </th>
                                </tr>
                                <tr>
                                    <td class="bordleft" width="130">
                                        <asp:Label ID="LabelSAdress" runat="server" Text="收货地址："></asp:Label>
                                    </td>
                                    <td class="bordrig">
                                        <asp:Label ID="LabelValueSAdress" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="bordleft" width="130">
                                        <asp:Label ID="LabelTrade" runat="server" Text="运送方式："></asp:Label>
                                    </td>
                                    <td class="bordrig">
                                        <asp:Label ID="Label1ValueTrade" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div class="btconfig">
                            <asp:Button ID="btnBack" runat="server" Text="返回列表" CssClass="bt2" OnClick="btnBack_Click" />
                        </div>
                        <asp:HiddenField ID="hiddenFieldGuid" runat="server" Value="0" />
                    </div>
                </div>
                <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td align="right" width="20%" valign="top">
                            <asp:Label ID="LabelNote" runat="server" Width="60%" Text="备忘："></asp:Label>
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="TextBoxNote" TextMode="MultiLine" runat="server" CssClass="op_area"></asp:TextBox>
                        </td>
                        <td align="left" valign="top" style="padding-left: 8px;">
                            <div class="vote">
                                <asp:LinkButton ID="ButtonConfirm" runat="server" CssClass="tjbtn" ToolTip="Submit"
                                                OnClick="ButtonConfirm_Click">确定</asp:LinkButton>
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
            <script type="text/javascript">
            <!--
                var TabbedPanels1 = new Spry.Widget.TabbedPanels("list_main");
            //-->
    </script>
        </form>
    </body>
</html>