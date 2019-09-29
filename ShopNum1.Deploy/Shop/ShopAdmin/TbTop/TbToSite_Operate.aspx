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
                //������


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
                alert("��ѡ����Ʒ��ҳ����");
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

            //������¼�
            var posX;
            var posY;
            var popDiv;
            var dragable;

            function down(e) {
                popDiv = document.getElementById("editDiv");
                e = e || window.event; //�����IE   
                popDiv.style.cursor = "move"; //������״ 
                posX = e.clientX - parseInt(popDiv.style.left);
                posY = e.clientY - parseInt(popDiv.style.top);
                dragable = true;
                document.onmousemove = move;
            }

            function move(ev) {
                if (dragable == true) {
                    ev = ev || window.event; //�����IE   
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
                    <a href="../S_Welcome.aspx">��������</a><span class="breadcrume_icon">>></span><span
                                                                                                   class="breadcrume_text">�Ա�������������</span></p>
                <div style="line-height: 30px; padding-left: 8px; padding-top: 8px; width: 740px;">
                    <table style="margin: 10px 5px; text-align: center; width: 300px;">
                        <tr>
                            <td>
                                <asp:RadioButton ID="radSort" runat="server" Text="�����Ա��Զ������" GroupName="radTtS"
                                                 Checked="true" />
                            </td>
                            <td>
                                <asp:RadioButton ID="radUpdateCount" runat="server" Text="�������µ�����Ʒ���" GroupName="radTtS"
                                                 Visible="false" />
                            </td>
                            <td>
                                <asp:RadioButton ID="radDownNew" runat="server" Text="�����Ա����ϼܵ���Ʒ" GroupName="radTtS" />
                            </td>
                            <td>
                                <asp:RadioButton ID="radUpdate" runat="server" Text="���±����Ա���Ʒ" GroupName="radTtS"
                                                 Visible="false" />
                            </td>
                        </tr>
                    </table>
                    <div style="height: 30px; line-height: 30px; padding-left: 13px;">
                        <span style="float: left;">
                            <asp:LinkButton ID="btnLead" runat="server" Text="����" UseSubmitBehavior="false" OnClick="btnLead_Click"
                                            CssClass="tjbtn" Style="position: relative;" OnClientClick=" this.disabled = 'disabled';document.getElementById('imgSpan').style.display = 'inline'; "></asp:LinkButton>
                        </span><span style="color: #f00; height: 30px; line-height: 30px; padding-left: 5px;">
                                   (�����ڼ��벻Ҫˢ��)</span> <span id="imgSpan" runat="server" style="display: none;">
                                                          <img src="images/load.gif" /></span>
                    </div>
                    <div class="zhuyi">
                        <ul class="scbdul" style="margin-left: 18px;">
                            <li class="ultit">����˵��</li>
                            <li>1. �����Ա��Զ�����ࣺ���Ա��������ϴ����²�Ʒ���ص����ĵ��̣�</li>
                            <li>2. �����²�Ʒ�����Ա��������ϴ��Ĳ�Ʒ���ص������̳ǣ�</li>
                            <li>3. ��ע:����ʱ�����ȵ����Ա�����Ʒ���࣬�ٲ�����Ʒ���������Ա�֤��Ʒ�ܹ���ȷ��Ӧ�����</li>
                        </ul>
                    </div>
                </div>
                <div id="editDiv" runat="server" onmousedown='down(event)' onmouseup='up()' style="background: url(images/20120903dr.jpg) top left no-repeat; display: none; height: 160px; width: 254px;">
                    <table cellpadding="0" cellspacing="0" border="0" style="padding: 50px 0 0 0px;">
                        <tr>
                            <td align="left">
                                <asp:Label ID="Label12" runat="server" Text="��ѡ�����ҳ����" Style="color: #222222; font-size: 12px; padding-left: 20px;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="padding-left: 40px; padding-top: 10px;">
                                <asp:RadioButtonList ID="RadioButtonList1" name="RadioButton" RepeatDirection="Horizontal"
                                                     runat="server" Style="color: #222; font-size; 12px

                                                                    ;">
                                </asp:RadioButtonList>
                                <asp:Label ID="LabelNoCount" Visible="false" runat="server" Text="��ǰû��ҳ��"></asp:Label>
                            </td>
                        </tr>
                        <tr align="center">
                            <td style="padding-left: 40px;">
                                <asp:Button ID="Button1" runat="server" Text="ȷ��" CssClass="bt2_tan" OnClientClick=" return GetSelectValue(); "
                                            OnClick="Button1_Click" Style="background: url(images/20120903botton.jpg) top left no-repeat; color: #79797a; font-size: 12px; height: 21px; line-height: 21px; margin-top: 10px; width: 60px;" />
                                <asp:Button ID="Button2" runat="server" OnClientClick=" QxButton() " CssClass="bt2_tan"
                                            Text="ȡ��" Style="background: url(images/20120903botton.jpg) top left no-repeat; color: #79797a; font-size: 12px; height: 21px; line-height: 21px; margin-left: 40px; margin-top: 10px; width: 60px;" />
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