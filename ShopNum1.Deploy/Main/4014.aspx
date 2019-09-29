<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>404错误页面</title>
    
</head>
<body>
    <form id="form1" runat="server">
      
    <script>
    <%
         var dataSet = new DataSet();
                    dataSet.ReadXml(HttpContext.Current.Server.MapPath("~/Settings/ShopSetting.xml"));
                    DataRow dataRow = dataSet.Tables["ShopSetting"].Rows[0];
                    string INDEXURL = dataRow["shop2007"].ToString();
         %>
        var t = 10; //设定跳转的时间 
        setInterval("refer()", 1000); //启动1秒定时 
        function refer() {
            if (t == 0) {
                location = '<%=INDEXURL %>'; //#设定跳转的链接地址 
            }
            document.getElementById('show').innerHTML = "" + t + "秒后跳转到首页"; // 显示倒计时 
            t--; // 计数器递减 
            if (t<0) {
                document.getElementById('show').style.display = 'none';
            }
            //本文转自： 
        } 
    </script> 

     <img id="myimg" src="../ImgUpload/jja02q7rRW_meitu_1.jpg" style="left:131px; position:absolute;" />
<span id="show" style=" position:absolute; left:865px; top:323px;"></span> 
    </form>
</body>
</html>
