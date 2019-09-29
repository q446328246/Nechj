<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="TbToSite_Operate.aspx.cs" Inherits="ShopNum1.Deploy.Shop.ShopAdmin.TbTop.TbToSite_Operate" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
    <head id="Head1" runat="server">
        <title></title>
        <link rel='stylesheet' type='text/css' href='../style/style.css' />
        <script type="text/javascript">

            function showMsg() {

                var msgDiv = document.createElement("div");
                msgDiv.style.position = "absolute";
                msgDiv.style.left = "0px";
                msgDiv.style.top = "0px";
                msgDiv.style.width = window.screen.availWidth + "px";
                msgDiv.style.height = window.screen.availHeight + "px";
                msgDiv.style.backgroundColor = "gray";
                msgDiv.style.zIndex = 1000;
                msgDiv.style.filter = "alpha(opacity='40')";
                msgDiv.id = "myMsg";

                msgDiv.setAttribute("class", "dialog-box");

                document.body.appendChild(msgDiv);
                //弹出层


                var contentDiv = document.getElementById("editDiv");
                contentDiv.style.display = "block";
                contentDiv.style.position = "absolute";
                contentDiv.style.width = "254px";
                var w = contentDiv.clientWidth || contentDiv.offsetWidth;
                contentDiv.style.height = "160px";
                contentDiv.style.left = (window.screen.availWidth - w) / 2 - w / 2 + "px";
                contentDiv.style.top = (window.screen.availHeight - 480) / 2 - 45 - 40 + "px";
                //          contentDiv.style.border = "solid 1px green";
                //          contentDiv.style.backgroundColor = "gray";
                contentDiv.style.fifter = "alpha(opacity='100')";
                contentDiv.style.zIndex = 1001;


            }


            function GetSelectValue() {
                var radioButton = document.getElementsByName("RadioButtonList1");
                var selectvalue = document.getElementById("<%= HiddenFieldradioButton.ClientID %>");

                for (var i = 0; i < radioButton.length; i++) {

                    if (radioButton[i].checked) {

                        selectvalue.value = radioButton[i].value;
                        this.disabled = 'disabled';
                        document.getElementById('imgSpan').style.display = 'inline';
                        return true;

                    }
                }
                alert("请选择商品的页数！");
                return false;


            }

            function CheckReturn() {

                var radioButton = document.getElementById("radDownNew");

                if (radioButton.checked) {

                } else {
                    this.disabled = 'disabled';
                    document.getElementById('imgSpan').style.display = 'inline';
                }

            }

            function QxButton() {
                document.getElementById("editDiv").style.display = 'none';
            }

            //弹框的事件
            var posX;
            var posY;
            var popDiv;
            var dragable;

            function down(e) {
                popDiv = document.getElementById("editDiv");
                e = e || window.event; //如果是IE   
                popDiv.style.cursor = "move"; //光标的形状 
                posX = e.clientX - parseInt(popDiv.style.left);
                posY = e.clientY - parseInt(popDiv.style.top);
                dragable = true;
                document.onmousemove = move;
            }

            function move(ev) {
                if (dragable == true) {
                    ev = ev || window.event; //如果是IE   
                    popDiv.style.left = (ev.clientX - posX) + "px";
                    popDiv.style.top = (ev.clientY - posY) + "px";
                }
            }

            function up() {
                dragable = false;
            }

        </script>
    </head>
    <body>
        <form id="form1" runat="server">
            <div class="dpsc_mian">
                <p class="ptitle">
                    <a href="../S_Welcome.aspx">我是卖家</a><span class="breadcrume_icon">>></span><span
                                                                                                   class="breadcrume_text">淘宝店铺批量操作</span></p>
                <div style="line-height: 30px; padding-left: 8px; padding-top: 8px; width: 740px;">
                    <table style="margin: 10px 5px; text-align: center; width: 300px;">
                        <tr>
                            <td>
                                <asp:RadioButton ID="radSort" runat="server" Text="导入淘宝自定义分类" GroupName="radTtS"
                                                 Checked="true" />
                            </td>
                            <td>
                                <asp:RadioButton ID="radUpdateCount" runat="server" Text="批量更新店铺商品库存" GroupName="radTtS"
                                                 Visible="false" />
                            </td>
                            <td>
                                <asp:RadioButton ID="radDownNew" runat="server" Text="下载淘宝新上架的商品" GroupName="radTtS" />
                            </td>
                            <td>
                                <asp:RadioButton ID="radUpdate" runat="server" Text="更新本地淘宝商品" GroupName="radTtS"
                                                 Visible="false" />
                            </td>
                        </tr>
                    </table>
                    <div style="height: 30px; line-height: 30px; padding-left: 13px;">
                        <span style="float: left;">
                            <asp:LinkButton ID="btnLead" runat="server" Text="操作" UseSubmitBehavior="false" OnClick="btnLead_Click"
                                            CssClass="tjbtn" Style="position: relative;" OnClientClick=" this.disabled = 'disabled';document.getElementById('imgSpan').style.display = 'inline'; "></asp:LinkButton>
                        </span><span style="color: #f00; height: 30px; line-height: 30px; padding-left: 5px;">
                                   (操作期间请不要刷新)</span> <span id="imgSpan" runat="server" style="display: none;">
                                                          <img src="images/load.gif" /></span>
                    </div>
                    <div class="zhuyi">
                        <ul class="scbdul" style="margin-left: 18px;">
                            <li class="ultit">功能说明</li>
                            <li>1. 导入淘宝自定义分类：把淘宝店铺新上传的新产品下载到您的店铺；</li>
                            <li>2. 下载新产品：把淘宝店铺新上传的产品下载到您的商城；</li>
                            <li>3. 备注:操作时，请先导入淘宝的商品分类，再操作商品。这样可以保证商品能够正确对应其分类</li>
                        </ul>
                    </div>
                </div>
                <div id="editDiv" runat="server" onmousedown='down(event)' onmouseup='up()' style="background: url(images/20120903dr.jpg) top left no-repeat; display: none; height: 160px; width: 254px;">
                    <table cellpadding="0" cellspacing="0" border="0" style="padding: 50px 0 0 0px;">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label12" runat="server" Text="请选择导入的页数：" Style="color: #222222; font-size: 12px; padding-left: 20px;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-left: 40px; padding-top: 10px;">
                                <asp:RadioButtonList ID="RadioButtonList1" name="RadioButton" RepeatDirection="Horizontal"
                                                     runat="server" Style="color: #222; font-size; 12px

                                                                    ;">
                                </asp:RadioButtonList>
                                <asp:Label ID="LabelNoCount" Visible="false" runat="server" Text="当前没有页数"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 40px;">
                                <asp:Button ID="Button1" runat="server" Text="确定" CssClass="bt2_tan" OnClientClick=" return GetSelectValue(); "
                                            OnClick="Button1_Click" Style="background: url(images/20120903botton.jpg) top left no-repeat; color: #79797a; font-size: 12px; height: 21px; line-height: 21px; margin-top: 10px; width: 60px;" />
                                <asp:Button ID="Button2" runat="server" OnClientClick=" QxButton() " CssClass="bt2_tan"
                                            Text="取消" Style="background: url(images/20120903botton.jpg) top left no-repeat; color: #79797a; font-size: 12px; height: 21px; line-height: 21px; margin-left: 40px; margin-top: 10px; width: 60px;" />
                            </td>
                        </tr>
                    </table>
                </div>
                <asp:HiddenField ID="HiddenFieldradioButton" runat="server" />
                <div style="line-height: 30px; padding-left: 8px; padding-top: 8px; width: 740px;">
                </div>
            </div>
        </form>
    </body>
</html>