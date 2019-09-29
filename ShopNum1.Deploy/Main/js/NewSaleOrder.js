jQuery(function($){
        $('.marquee').marquee({
            step: 82, // 步长
            time: 300, // 动画速度
            wait: 1500 // 间隔时间
        });
    });

    jQuery.fn.extend({
        marquee: function(setting){
            if(this.length <= 0){
                return this;
            }

            var main = this;
            var marquee_items = main.children();

            // 为了在边界值连续循环，需要把原来的元素复制一份
            var html = main.html();
            main.html(html + html);
            var marquee_current = 0;
            var marquee_timer = null;
            var marquee_run = function(){
                if(marquee_current >= marquee_items.length){
                    marquee_current = 0;
                    main.css({
                        top: '0px'
                    });
                }

                clearTimeout(marquee_timer);

                main.stop().animate({
                    top: - marquee_current * setting.step + 'px'
                }, setting.time, function(){
                    marquee_timer = setTimeout(function(){
                        marquee_run();
                    }, setting.wait);
                });

                marquee_current++;
            }
            marquee_run();

            // 鼠标移上去暂停
            main.children().bind({
                mouseover: function(e){
                    main.stop();
                    clearTimeout(marquee_timer);
                },
                mouseout: function(e){
                    marquee_timer = setTimeout(function(){
                        marquee_run();
                    }, setting.wait);
                }
            });
        }
    })