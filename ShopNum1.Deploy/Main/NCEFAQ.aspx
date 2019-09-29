<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NCEFAQ.aspx.cs" Inherits="ShopNum1.Deploy.Main.NCEFAQ" %>


<html xmlns="http://www.w3.org/1999/xhtml">
  <head>
    <title>账户信息</title>
    <meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no">
    <link href="res/lib/weui.min.css" rel="stylesheet" type="text/css" />
    <link href="res/css/jquery-weui.min.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript">

            function back() {
                window.history.back(-1);
            }

            function Blocknone(id1,id2,id3) {
                document.getElementById(id1).style.display = 'block';
                document.getElementById(id2).style.display = 'none';
                document.getElementById(id3).style.display = 'none';
            }
</script>
 
</head>
<body ontouchstart>
<div class='demos-content-padded'>
    <form id="Form1" class="cd-form" runat="server" >
    <div onclick="back()">返回</div>

<div class="register-title"  style="font-size:30px;margin:10px;text-align: center;">常见问题</div>
<hr />
<div onclick="Blocknone('first','second','three')">问题标题
<div id="first" style="display:none">
    <div class="weui-cells__title" >1、问题问题问题问题?</div>
        <div class="weui-cells">
          <div class="weui-cell">
            <div class="weui-cell__bd">
            <p>答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案
                 答案答案答案答案答案 </p>
            </div>
          </div>
    </div>
    <div class="weui-cells__title">2、问题问题问题问题?</div>
        <div class="weui-cells">
          <div class="weui-cell">
            <div class="weui-cell__bd">
                 <p>答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案
                 答案答案答案答案答案 </p>
            </div>
          </div>
    </div>
    </div>
</div>
 
 <div  onclick="Blocknone('second','first','three')">问题标题1
 <div id="second" style="display:none">
    <div class="weui-cells__title" >1、问题问题问题问题?</div>
        <div class="weui-cells">
          <div class="weui-cell">
            <div class="weui-cell__bd">
                 <p>答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案
                 答案答案答案答案 </p>
            </div>
          </div>
    </div>
    <div class="weui-cells__title">2、问题问题问题问题?</div>
        <div class="weui-cells">
          <div class="weui-cell">
            <div class="weui-cell__bd">
                 <p>答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案
                 答案答案答</p>
            </div>
          </div>
    </div>
</div>
</div>

 <div  onclick="Blocknone('three','second','first')">问题标题2
 <div id="three"style="display:none">
    <div class="weui-cells__title" >1、问题问题问题问题?</div>
        <div class="weui-cells">
          <div class="weui-cell">
            <div class="weui-cell__bd">
                 <p>答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案
                 答案答案答案答案答案答案 </p>
            </div>
          </div>
    </div>
    <div class="weui-cells__title">2、问题问题问题问题?</div>
        <div class="weui-cells">
          <div class="weui-cell">
            <div class="weui-cell__bd">
                 <p>答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案答案
                 答案答案答案答案答案答 </p>
            </div>
          </div>
    </div>
</div>
</div>
    </form>
    </div>
    <script src="res/lib/jquery-2.1.4.js" type="text/javascript"></script>
    <script src="res/js/jquery-weui.min.js" type="text/javascript"></script>
</body>
</html>
