
function shifeidata(farmid,num){

	$('.land'+farmid).attr('value','2');
	$('.land'+farmid).children('.beans').text(num);
	$('.land'+farmid).children('.tree').attr('lever','tree_lever_2');
}