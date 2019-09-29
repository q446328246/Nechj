<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MerDinpayUTF_8.aspx.cs" Inherits="ShopNum1.Deploy.PayReturn.Dinpay.MerDinpayUTF_8" ResponseEncoding="utf-8" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title>正在创建唐江快捷支付...</title>
    <style type="text/css">
    body{ margin:0; padding:0; }
	#cc{ width:80%; height:600px; margin:0 auto; }/*这里的width height 大于图片的宽高*/
	table{ height:100%; width:100%; text-align:center;}
 </style>
      </head>
<body >

        <div id="cc">
            <table>
                <tr>
                    <td>  
                    <asp:Image ID="Image1" runat="server" ImageUrl="../../Main/Themes/Skin_Default/Images/20150413150752.jpg" />
                    <asp:Label  ID="Label1" runat="server" Text="正在创建智付安全链接"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>


    <form action="https://pay.dinpay.com/gateway?input_charset=UTF-8" id="dinpayForm" name="dinpayForm" method="POST" runat="server">
            <input type="hidden" name="sign" id="sign" size="40" runat="server" />

            <input type="hidden" name="merchant_code" id="merchant_code" runat="server" />

            <input type="hidden" name="bank_code" id="bank_code" runat="server" />

            <input type="hidden" name="order_no" id="order_no" runat="server" />

            <input type="hidden" name="order_amount" id="order_amount" runat="server" />

            <input type="hidden" name="service_type" id="service_type" runat="server" />

            <input type="hidden" name="input_charset" id="input_charset" runat="server" />

            <input type="hidden" name="notify_url" id="notify_url" runat="server" />

            <input type="hidden" name="interface_version" id="interface_version" runat="server" />

            <input type="hidden" name="sign_type" id="sign_type" runat="server" />

            <input type="hidden" name="order_time" id="order_time" runat="server" />

            <input type="hidden" name="product_name" id="product_name" runat="server"  />

            <input type="hidden" name="client_ip" id="client_ip" runat="server" />

            <input type="hidden" name="extend_param" id="extend_param" runat="server" />

            <input type="hidden" name="extra_return_param" id="extra_return_param"  runat="server" />

            <input type="hidden" name="product_code" id="product_code" runat="server" />

            <input type="hidden" name="product_desc" id="product_desc" runat="server" />

            <input type="hidden" name="product_num" id="product_num" runat="server" />

            <input type="hidden" name="return_url" id="return_url" runat="server" />

            <input type="hidden" name="show_url" id="show_url" runat="server" />

            <input type="hidden" name="redo_flag" id="redo_flag" runat="server" />

            <script type="text/javascript">
               
                
                function jumpurl() {
                    document.getElementById("dinpayForm").submit();
                }
                setTimeout('jumpurl()', 3000);  

            </script>
           
       
    </form>
</body>
</html>

