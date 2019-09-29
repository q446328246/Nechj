<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuthenticationHtml5.aspx.cs" Inherits="ShopNum1.Deploy.Main.AuthenticationHtml5" %>

<html lang="zh-CN">
<head>
<meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
<title>用户注册</title>

    <script src="jquery/common/js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="jquery/common/layer/layer.js" type="text/javascript"></script>
    <script src="jquery/common/js/index.js" type="text/javascript"></script>
    <script src="jquery/js/rem.js" type="text/javascript"></script>
    <style>
        #Button1
        {
            transform:rotate(180deg);
            }  
       .td{width:100px}
    </style>
</head>
<body class="bgf5" >
<form id="Form1" runat="server">
<div class="login-container register-container" >
    <div class="register-title"  style="color:Black;font-size:30px;margin-top:30px;text-align: center;">用户身份信息验证</div>
<div class="pad">
        <div style="text-align:center;  margin-bottom:30px">
            <span style="font-size: 20px; color: red; margin-bottom: 20px;">绑定车辆</span>
       </div>
        
        <div style="font-size: 14px;  margin-bottom:30px ;text-align: center;">
                    请选车辆类型：
                
                    <asp:RadioButton GroupName="radbutton" ID="RadioButtonAgentMember" name="RadioButtonAgentMember" runat="server"
                        Checked="True" />&nbsp;&nbsp;<span style="font-size: 15px; color: red;">新能源汽车</span>
                    <asp:RadioButton GroupName="radbutton" ID="RadioButtonCommunityMember" 
                        name="RadioButtonCommunityMember" runat="server"  />&nbsp;&nbsp;<span
                        style="font-size: 15px; color: red;">燃油汽车</span>

                        <div style="font-size: 14px;  margin:30px 0 30px 0 ">
                    车牌号： <input type="text" name="" id="TextBoxShopNames" runat="server" style="border-radius: 15px;"  />
                    </div>
                     <div style="font-size: 14px;  margin-bottom:30px ">
                    设备号： <asp:TextBox ID="Textshebei" runat="server" class="ss_nr1" MaxLength="32" style="border-radius: 15px;"></asp:TextBox>
                     </div>
                       <div class="pad" style="font-size:16px; text-align:center">
       
                    &nbsp;&nbsp;上传车辆行驶证：<asp:FileUpload ID="FileUploadOrganizationImage" runat="server" onchange="funUpdateImage1()" /><span
                        class="gray1" id="Span1" style="color: red">&nbsp;</span>
                        
                
                <div style="margin-top:30px; width:100%;text-align:center">
            <asp:Button ID="Button3" runat="server" Text="提交申请" class="chax btn_spc" name="12"
                        OnClick="ButtonUpgrade_Click" />
                </div>
          
    </div>
        </div>

    </div>

  
</div>

    </form>
</body>
</html>
