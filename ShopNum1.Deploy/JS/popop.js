 (function($) {
        $.fn.extend({
            Show: function(widht,height) {
            var TopY=0;//��ʼ��Ԫ�ؾุԪ�صľ���
            $(this).css("width",widht+"px").css("height",height+"px");//������Ϣ��Ĵ�С
            $(this).slideDown(1000);//����
            $("#messageTool").css("margin-top",-height);//Ϊ���ݲ��ִ����߶�  ���
            $("#message_close").click(function() {//������رհ�ť��ʱ��
                 if(TopY==0)
                 {
                       $("#message").slideUp(1000);//����֮������slideUp��Ϊ�˼���Firefox�����
                 }
                else
                {
                      $("#message").animate({top: TopY+height}, "slow", function() { $("#message").hide(); });//��TopY������0ʱ  ie�º�FirefoxЧ��һ��
                }
             });
             $(window).scroll(function() {
                 $("#message").css("top", $(window).scrollTop() + $(window).height() - $("#message").height());//��������������ʱ��ʼ������Ļ�����½�
                 TopY=$("#message").offset().top;//��������������ʱ����ʱ����Ԫ�ؾุԭ�ؾ���
              });
            }
         })}
)(jQuery);