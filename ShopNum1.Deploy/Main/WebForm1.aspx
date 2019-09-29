<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ShopNum1.Deploy.Main.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="js/jquery-1.3.1.js" type="text/javascript"></script>
    <script type="text/javascript">
        function checkBox(cb) {
            var oOne = document.getElementById("one");
            var oTwo = document.getElementById("two");
            var oFree=document.getElementById("free");
            var oDiv1 = document.getElementById("div1");
            var oDiv2 = document.getElementById("div2");
            var oDiv3 = document.getElementById("div3");
            if (cb.id == "one") {
                oTwo.checked = false;
                oFree.checked = false;
                oDiv2.style.display = "none";
                oDiv3.style.display = "none"
                if (cb.checked) {
                    oDiv1.style.display = "block";
                } else {
                    oDiv1.style.display = "none";
                }
            } else if (cb.id == "two") {
                oOne.checked = false;
                oDiv3.style.display = "none"
                oDiv1.style.display = "none"
                oFree.checked = false;
                if (cb.checked) {
                    oDiv2.style.display = "block";
                } else {
                    oDiv2.style.display = "none";
                }
                
            } else if (cb.id == "free") {
                oOne.checked = false;
                oTwo.checked = false;
                oDiv2.style.display = "none";
                oDiv1.style.display = "none"
                if (cb.checked) {
                    oDiv3.style.display = "block";
                } else {
                    oDiv3.style.display = "none";
                }
                
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
   
     
        
    <input type="checkbox" id="one" onClick="checkBox(this);"/><label for="">大唐</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
 
 <input type="checkbox" id="two" onClick="checkBox(this);"/><label for="">VIP</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
 <input type="checkbox" id="free" onClick="checkBox(this);"/><label for="">积分</label>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp

    <div id="div1"  style="display:none;">
           <dl class="tibxxbg">
    <dt>可得积分：</dt>
    <dd>
        <input name="input" id="txtScore_Pv_a" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_Pv_a_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
<dl class="tibxxbg">
    <dt>可得红包：</dt>
    <dd>
        <input name="input" id="txtScore_hv" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_hv_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>

  </div>
   
    <div id="div2" style="display:none;">
              <dl class="tibxxbg">
    <dt>可得积分：</dt>
    <dd>
        <input name="input" id="txtScore_Pv_a_two" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_Pv_a_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
<!--这个方法我还没做-->
  <dl class="tibxxbg">
    <dt>可用红包：</dt>
    <dd>
        <input name="input" id="txtScore_cv" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_Pv_a_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>
</div>
<div id="div3" style="display:none;">
<dl class="tibxxbg">
    <dt>可用积分：</dt>
    <dd>
        <input name="input" id="txtScore_max_hv" type="text" onblur=" checkpriceTxt(this) "
            maxlength="6" class="textwb" value="0.00" /><span check="errorMsg" style="color: Red;
                display: none">市场价格必须是0.00~1000000之间的数字！</span><span style="color: Red;">*</span><br />
        <input name="goods_Score_max_hv_sum" value="" type="hidden" />
        <span class="gray1">市场价格必须是0.00~1000000之间的数字</span>
    </dd>
</dl>

    </div>
    </form>
</body>
</html>
