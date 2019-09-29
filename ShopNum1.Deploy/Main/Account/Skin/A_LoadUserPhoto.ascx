<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="A_LoadUserPhoto.ascx.cs"
    Inherits="ShopNum1.Deploy.Main.Account.Skin.A_LoadUserPhoto" %>
<script language="javascript">
    /// <reference path="JSintellisense/jquery-1.2.6-intellisense.js" />

    //全局变量定义
    var CANVAS_WIDTH = 284; //画布的宽
    var CANVAS_HEIGHT = 266; //画布的高
    var ICON_SIZE = 120;  //截取框的大小，正方形
    var LEFT_EDGE = (CANVAS_WIDTH - ICON_SIZE) / 2; //82
    var TOP_EDGE = (CANVAS_HEIGHT - ICON_SIZE) / 2; //73
    var CANVAS_LEFT_MARGIN = 4;


    //用document. ready事件中在上传后第一次转向时无法获取到图片的打开，应该是没有被下载来的缘故
    $(window).load(function () {
        var $iconElement = $("#<%=ImageIcon.ClientID %>");
        var $imagedrag = $("#<%=ImageDrag.ClientID %>");

        //获取上传图片的实际高度，宽度
        var image = new Image();
        image.src = $iconElement.attr("src");
        var realWidth = image.width;
        var realHeight = image.height;
        image = null;

        //计算缩放比例开始
        var minFactor = ICON_SIZE / Math.max(realWidth, realHeight);
        if (ICON_SIZE > realWidth && ICON_SIZE > realHeight) {
            minFactor = 1;
        }
        var factor = minFactor > 0.25 ? 8.0 : 4.0 / Math.sqrt(minFactor);

        //图片缩放比例
        var scaleFactor = 1;
        if (realWidth > CANVAS_WIDTH && realHeight > CANVAS_HEIGHT) {
            if (realWidth / CANVAS_WIDTH > realHeight / CANVAS_HEIGHT) {
                scaleFactor = CANVAS_HEIGHT / realHeight;
            }
            else {
                scaleFactor = CANVAS_WIDTH / realWidth;
            }
        }
        //计算缩放比例结束

        //设置滑动条的位置，设置滑动条的值的变化来改变缩放率是一个非线性的变化，而是幂函数类型 即类似y=factor（X）--此处x为幂指数
        //此处100 * (Math.log(scaleFactor * factor) / Math.log(factor)) 为知道y 求解x 的算法
        $(".child").css("left", 100 * (Math.log(scaleFactor * factor) / Math.log(factor)) + "px");

        //图片实际尺寸，并近似到整数
        var currentWidth = Math.round(scaleFactor * realWidth);
        var currentHeight = Math.round(scaleFactor * realHeight);


        //图片相对CANVAS的初始位置，图片相对画布居中
        var originLeft = Math.round((CANVAS_WIDTH - currentWidth) / 2);
        var originTop = Math.round((CANVAS_HEIGHT - currentHeight) / 2);
        //计算截取框中的图片的位置
        var dragleft = originLeft - LEFT_EDGE;
        var dragtop = originTop - TOP_EDGE;


        //设置图片当前尺寸和位置
        $iconElement.css({ width: currentWidth + "px", height: currentHeight + "px", left: originLeft + "px", top: originTop + "px" });
        $imagedrag.css({ width: currentWidth + "px", height: currentHeight + "px", left: dragleft + "px", top: dragtop + "px" });

        //初始化默认值
        $("#<%=txt_width.ClientID %>").val(currentWidth);
        $("#<%=txt_height.ClientID %>").val(currentHeight);
        $("#<%=txt_top.ClientID %>").val(0 - dragtop);
        $("#<%=txt_left.ClientID %>").val(0 - dragleft);
        $("#<%=txt_Zoom.ClientID %>").val(scaleFactor);

        var oldWidth = currentWidth;
        var oldHeight = currentHeight;

        //设置图片可拖拽，并且拖拽一张图片时，同时移动另外一张图片
        $imagedrag.draggable(
    {
        cursor: 'move',
        drag: function (e, ui) {
            var self = $(this).data("draggable");
            var drop_img = $("#<%=ImageIcon.ClientID %>");
            var top = drop_img.css("top").replace(/px/, ""); //取出截取框到顶部的距离
            var left = drop_img.css("left").replace(/px/, ""); //取出截取框到左边的距离
            drop_img.css({ left: (parseInt(self.position.left) + LEFT_EDGE) + "px", top: (parseInt(self.position.top) + TOP_EDGE) + "px" }); //同时移动内部的图片
            $("#<%=txt_left.ClientID %>").val(0 - parseInt(self.position.left));
            $("#<%=txt_top.ClientID %>").val(0 - parseInt(self.position.top));
        }
    }
    );
        //设置图片可拖拽，并且拖拽一张图片时，同时移动另外一张图片
        $iconElement.draggable(
    {
        cursor: 'move',
        drag: function (e, ui) {
            var self = $(this).data("draggable");
            var drop_img = $("#<%=ImageDrag.ClientID %>");
            var top = drop_img.css("top").replace(/px/, ""); //取出截取框到顶部的距离
            var left = drop_img.css("left").replace(/px/, ""); //取出截取框到左边的距离
            drop_img.css({ left: (parseInt(self.position.left) - LEFT_EDGE) + "px", top: (parseInt(self.position.top) - TOP_EDGE) + "px" }); //同时移动内部的图片
            $("#<%=txt_left.ClientID %>").val(0 - (parseInt(self.position.left) - LEFT_EDGE));
            $("#<%=txt_top.ClientID %>").val(0 - (parseInt(self.position.top) - TOP_EDGE));
        }
    }
    );

        //缩放的代码，要缩放以截取框为中心，所以要重新计算图片的left和top
        $(".child").draggable(
  {
      cursor: "move", containment: $("#bar"),
      drag: function (e, ui) {
          var left = parseInt($(this).css("left"));
          //前面讲过了y=factor（x），此处是知道x求y的值，即知道滑动条的位置，获取缩放率
          scaleFactor = Math.pow(factor, (left / 100 - 1));
          if (scaleFactor < minFactor) {
              scaleFactor = minFactor;
          }
          if (scaleFactor > factor) {
              scaleFactor = factor;
          }
          //以下代码同初始化过程，因为用到局部变量所以没有
          var iconElement = $("#<%=ImageIcon.ClientID %>");
          var imagedrag = $("#<%=ImageDrag.ClientID %>");

          var image = new Image();
          image.src = iconElement.attr("src");
          var realWidth = image.width;
          var realHeight = image.height;
          image = null;

          //图片实际尺寸
          var currentWidth = Math.round(scaleFactor * realWidth);
          var currentHeight = Math.round(scaleFactor * realHeight);

          //图片相对CANVAS的初始位置
          var originLeft = parseInt(iconElement.css("left"));
          var originTop = parseInt(iconElement.css("top"));

          originLeft -= Math.round((currentWidth - oldWidth) / 2);
          originTop -= Math.round((currentHeight - oldHeight) / 2);
          dragleft = originLeft - LEFT_EDGE;
          dragtop = originTop - TOP_EDGE;

          //图片当前尺寸和位置
          iconElement.css({ width: currentWidth + "px", height: currentHeight + "px", left: originLeft + "px", top: originTop + "px" });
          imagedrag.css({ width: currentWidth + "px", height: currentHeight + "px", left: dragleft + "px", top: dragtop + "px" });

          $("#<%=txt_Zoom.ClientID %>").val(scaleFactor);
          $("#<%=txt_left.ClientID %>").val(0 - dragleft);
          $("#<%=txt_top.ClientID %>").val(0 - dragtop);
          $("#<%=txt_width.ClientID %>").val(currentWidth);
          $("#<%=txt_height.ClientID %>").val(currentHeight);
          oldWidth = currentWidth;
          oldHeight = currentHeight;
      }
  });
        var SilderSetValue = function (i) {
            var left = parseInt($(".child").css("left"));
            left += i;

            if (left < 0) {
                left = 0;
            }
            if (left > 200) {
                left = 200;
            }

            scaleFactor = Math.pow(factor, (left / 100 - 1));
            if (scaleFactor < minFactor) {
                scaleFactor = minFactor;
            }
            if (scaleFactor > factor) {
                scaleFactor = factor;
            }
            var iconElement = $("#<%=ImageIcon.ClientID %>");
            var imagedrag = $("#<%=ImageDrag.ClientID %>");

            var image = new Image();
            image.src = iconElement.attr("src");
            var realWidth = image.width;
            var realHeight = image.height;
            image = null;

            //图片实际尺寸
            var currentWidth = Math.round(scaleFactor * realWidth);
            var currentHeight = Math.round(scaleFactor * realHeight);

            //图片相对CANVAS的初始位置
            var originLeft = parseInt(iconElement.css("left"));
            var originTop = parseInt(iconElement.css("top"));

            originLeft -= Math.round((currentWidth - oldWidth) / 2);
            originTop -= Math.round((currentHeight - oldHeight) / 2);
            dragleft = originLeft - LEFT_EDGE;
            dragtop = originTop - TOP_EDGE;

            //图片当前尺寸和位置
            $(".child").css("left", left + "px");
            iconElement.css({ width: currentWidth + "px", height: currentHeight + "px", left: originLeft + "px", top: originTop + "px" });
            imagedrag.css({ width: currentWidth + "px", height: currentHeight + "px", left: dragleft + "px", top: dragtop + "px" });

            $("#<%=txt_Zoom.ClientID %>").val(scaleFactor);
            $("#<%=txt_left.ClientID %>").val(0 - dragleft);
            $("#<%=txt_top.ClientID %>").val(0 - dragtop);
            $("#<%=txt_width.ClientID %>").val(currentWidth);
            $("#<%=txt_height.ClientID %>").val(currentHeight);

            oldWidth = currentWidth;
            oldHeight = currentHeight;
        }
        //点击加减号
        $("#moresmall").click(function () {
            SilderSetValue(-10);
        });
        $("#morebig").click(function () {
            SilderSetValue(10);
        });
    });
</script>
<div>
    <div class="left">
        <!--当前照片-->
        <div id="CurruntPicContainer">
            <div class="title">
                <b>当前照片</b></div>
            <div class="photocontainer">
                <asp:Image ID="imgphoto" runat="server" ImageUrl="../images/man.GIF" />
            </div>
        </div>
        <!--Step 2-->
        <div id="Step2Container">
            <div class="title">
                <b>头像照片</b></div>
            <div class="uploadtooltip">
                您可以拖动t滚动条以得到满意的头像</div>
            <div id="Canvas" class="uploaddiv">
                <div id="ImageDragContainer">
                    <asp:Image ID="ImageDrag" runat="server" ImageUrl="/images/blank.jpg" CssClass="imagePhoto"
                        ToolTip="" />
                </div>
                <div id="IconContainer">
                    <asp:Image ID="ImageIcon" runat="server" ImageUrl="/images/blank.jpg" CssClass="imagePhoto"
                        ToolTip="" />
                </div>
            </div>
            <div class="uploaddiv">
                <table>
                    <tr>
                        <td id="Min">
                            <img alt="缩小" src="images/_c.gif" onmouseover="this.src='images/_c.gif';" onmouseout="this.src='images/_h.gif';"
                                id="moresmall" class="smallbig" />
                        </td>
                        <td>
                            <div id="bar">
                                <div class="child" style="left: 50px;">
                                </div>
                            </div>
                        </td>
                        <td id="Max">
                            <img alt="放大" src="images/c.gif" onmouseover="this.src='images/c.gif';" onmouseout="this.src='images/h.gif';"
                                id="morebig" class="smallbig" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="uploaddiv">
                <asp:Button ID="btn_Image" runat="server" Text="保存头像" CssClass="selpic" OnClick="btn_Image_Click" />
            </div>
            <div style="display: none">
                图片实际宽度：
                <asp:TextBox ID="txt_width" runat="server" Text="1"></asp:TextBox><br />
                图片实际高度：
                <asp:TextBox ID="txt_height" runat="server" Text="1"></asp:TextBox><br />
                距离顶部：
                <asp:TextBox ID="txt_top" runat="server" Text="82"></asp:TextBox><br />
                距离左边：
                <asp:TextBox ID="txt_left" runat="server" Text="73"></asp:TextBox><br />
                截取框的宽：
                <asp:TextBox ID="txt_DropWidth" runat="server" Text="120"></asp:TextBox><br />
                截取框的高：
                <asp:TextBox ID="txt_DropHeight" runat="server" Text="120"></asp:TextBox><br />
                放大倍数：
                <asp:TextBox ID="txt_Zoom" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>
    <div class="right">
        <!--Step 1-->
        <div id="Step1Container">
            <div class="title">
                <b>更换照片</b></div>
            <div id="uploadcontainer">
                <div class="uploadtooltip">
                    请选择新的照片文件，文件需小于2.5MB,文件格式为jpg,gif,png</div>
                <div class="uploaddiv">
                    <asp:FileUpload ID="fuPhoto" runat="server" ToolTip="选择照片" Width="170" /></div>
                <div class="uploaddiv">
                    <asp:Button ID="btnUpload" runat="server" Text="上 传" CssClass="xiug" Style="border: none;
                        color: #ffffff;" OnClick="btnUpload_Click" /></div>
            </div>
        </div>
    </div>
</div>
<!---将left的值储存住，方便计算-->
<asp:HiddenField ID="hid_lefeValue" runat="server" Value="0px" />
<input type="hidden" id="hid_imgValue" runat="server" />
