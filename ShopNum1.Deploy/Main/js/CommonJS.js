  //----------------------------------------check全选事件---start---------------------------------------
       // 点击复选框时触发事件
        function postBackByObject() 
        {
            var o = window.event.srcElement;
            if (o.tagName == "INPUT" && o.type == "checkbox") {
                __doPostBack("", "");
            }
        }

        function getcheck(evt) 
        {
            //var o = window.event.srcElement;
            var o = window.event ? window.event.srcElement : evt.target;

            if (o.tagName == "INPUT" && o.type == "checkbox") //点击treeview的checkbox是触发
            {
                var d = o.id; //获得当前checkbox的id;

                var e = d.replace("CheckBox", "Nodes"); //通过查看脚本信息,获得包含所有子节点div的id

                var div = window.document.getElementById(e); //获得div对象
                if (div != null) //如果不为空则表示,存在子节点
                {
                    var check = div.getElementsByTagName("INPUT"); //获得div中所有的已input开始的标记
                    
                    for (i = 0; i < check.length; i++) {
                        if (check[i].type == "checkbox") //如果是checkbox
                        {
                            check[i].checked = o.checked; //子节点的状态和父节点的状态相同,即达到全不选
                        }

                    }

                }

//                //else //点子节点的时候,使父节点的状态改变,即不为全选
//                //{
//                //处理父节点
             
//                var divid = o.parentNode.parentNode.parentNode.parentNode.parentNode; //子节点所在的div
//                while (divid != null && divid.getAttribute("ID")!="TreeViewData") 
//                {

//                    var id = divid.getAttribute("ID").replace("Nodes", "CheckBox"); //获得根节点的id
//                    if (window.document.getElementById(id) != null) 
//                    {
//                       if(o.checked==true)
//                       {
//                          window.document.getElementById(id).checked = true;
//                         
//                        }
//                      divid = window.document.getElementById(id).parentNode.parentNode.parentNode.parentNode.parentNode;
//                    }
//                    else 
//                    {
//                        divid = null;
//                    }
//                }

            }

        }

  //----------------------------------------check全选事件---end---------------------------------------




//Checkbox全选
function SelectAllCheckboxes(obj){
    var theTable = obj.parentNode.parentNode.parentNode;
    var inputs = theTable.getElementsByTagName('input');
    for(var i = 0;i<inputs.length;i++) {
        if(inputs[i].type == "checkbox") {
            inputs[i].checked = obj.checked;
        }
    }
}

//返回 chk 所在行的单元格值
 // @param chk 表示行中的 input type=check 对象
    function GetItmeValue(checkboxitem)
    {
            var tblRow = checkboxitem.parentNode.parentNode;
            // 改变 tblRow.cells[<cellIndex>] 中占位符 <cellIndex> 访问不同单元格
            document.getElementById("CheckGuid").value=tblRow.cells[1].innerHTML;         
    }

 /*       
       返回指定 grdId 中所有选中行的单元格值
       @param grdId 表示 GridView/DataGrid 客户端 ID，实际上他们均呈现为 <table />
       @param chkIdPart 表示待处理 input type=check 控件的 ID 中的部分，考虑行中可能存在多个 checkbox， 通过此参数可以准确确定目标
    */
    function GetAllItmeValue(gridviewid, chkIdPart)
    {
        var tbl = document.getElementById(gridviewid);
        var checkboxlist;
        var checkvalues = "";
       
        checkboxlist = tbl.getElementsByTagName("input");  // 返回表内嵌的所有 input 控件
       
        for(var j = 0; j < checkboxlist.length; j++) {
            // 多条件准确确定目标 checkbox
            if(checkboxlist[j].type == "checkbox" && checkboxlist[j].checked && checkboxlist[j].id.indexOf(chkIdPart) > -1) {
                checkvalues += ReturnItemValue(checkboxlist[j])+",";
                                          
            }
        }
        //
        document.getElementById("CheckGuid").value=checkvalues;
    }

//返回选中CheckBox所在行的第一列的值
  function ReturnItemValue(checkboxitem)
    {   
            var tblRow = checkboxitem.parentNode.parentNode;
            // 改变 tblRow.cells[<cellIndex>] 中占位符 <cellIndex> 访问不同单元格
           return tblRow.cells[1].innerHTML;
        
    }

//公交变量，存放选中的checkbox个数
var checkCount = 0;

/***********************检查编辑按钮******************************/
function EditButton()
{
    checkCount = 0;
    var checkedBoxValues = GetCheckedBoxValues();
    if(checkedBoxValues == "0")
    {
       alert("请选择要操作的记录！");
        return false;
    }else if(checkCount > 1)
    {
       alert("您每次只能选择一条记录操作！");
        return false;
    }else
    {
      document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,','');

        return true;
    }
}



/***********************检查审核按钮******************************/
function AuditButton()
{
    
    var checkedBoxValues = GetCheckedBoxValues();
    if(checkedBoxValues == "0")
    {
       alert("请选择要审核的记录！");
        return false;
    }else if(window.confirm("您确定要审核吗?"))
    {
          document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,','');
        return true;
    }else
    {
        return false;
    }
}


/***********************检查删除按钮******************************/
function DeleteButton()
{
    
    var checkedBoxValues = GetCheckedBoxValues();
    if(checkedBoxValues == "0")
    {
       alert("请选择要删除的记录！");
        return false;
    }else if(window.confirm("您确定要删除吗?"))
    {
          document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,','');
        return true;
    }else
    {
        return false;
    }
}
/***********************检查编辑按钮******************************/
function DeleteOneButton()
{
    checkCount = 0;
    var checkedBoxValues = GetCheckedBoxValues();

     if(checkedBoxValues == "0")
    {
       alert("请选择要删除的记录！");
        return false;
    }
    else if(checkCount > 1)
    {
       alert("您每次只能删除一条！");
        return false;
    }
    else if(window.confirm("您确定要删除吗?"))
    {
          document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,','');
        return true;
    }else
    {
        return false;
    }
}
/***********************检查商品列表中的执行操作按钮******************************/
function OperateButton()
{
    
    var checkedBoxValues = GetCheckedBoxValues();
    if(checkedBoxValues == "0")
    {
       alert("请选择您要操作的记录！");
        return false;
    }else if(window.confirm("您确定要执行操作吗?"))
    {
          document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,','');
        return true;
    }else
    {
        return false;
    }
}

/***********************提示选择商品然后加入订单******************************/
function CheckAddProduct()
{
    checkCount = 0;
    var checkedBoxValues = GetCheckedBoxValues();
    if(checkedBoxValues == "0")
    {
       alert("请选择要加入订单的商品！");
        return false;
    }else if(checkCount > 1)
    {
       alert("您每次只能选择一种商品！");
        return false;
    }else
    {
     //因为添加到购物车只能每次添加一个商品，所以每次设为空
      document.getElementById("CheckGuid").value = "";
      document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,','');
      return true;
    }
}

/***********************提示选择配送方式******************************/
function CheckSelectDispatchMode()
{
    checkCount = 0;
    var checkedBoxValues = GetCheckedBoxValues();
    if(checkedBoxValues == "0")
    {
       alert("请选择配送方式！");
        return false;
    }else if(checkCount > 1)
    {
       alert("您已经选择了一个配送方式！");
        return false;
    }else
    {
     //因为只能选择一个配送方式，所以每次设为空
      document.getElementById("CheckGuid").value = "";
      document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,','');
      return true;
    }
}

/***********************提示选择支付方式******************************/
function CheckSelectPayment()
{
    checkCount = 0;
    var checkedBoxValues = GetCheckedBoxValues();
    if(checkedBoxValues == "0")
    {
       alert("请选择支付方式！");
        return false;
    }else if(checkCount > 1)
    {
       alert("您已经选择了一个支付方式！");
        return false;
    }else
    {
     //因为只能选择一个支付方式，所以每次设为空
      document.getElementById("CheckGuid").value = "";
      document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,','');
      return true;
    }
}

/***********************提示不能选择多个包装******************************/
function CheckSelectPack()
{
    checkCount = 0;
    var checkedBoxValues = GetCheckedBoxValues();
    if(checkedBoxValues == "0")
    {

        return true;
    }else if(checkCount > 1)
    {
       alert("您已经选择了一个包装！");
        return false;
    }else
    {
     //因为只能选择一个包装，所以每次设为空
      document.getElementById("CheckGuid").value = "";
      document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,','');
      return true;
    }
}

/***********************提示不能选择多个贺卡******************************/
function CheckSelectBlessCard()
{
    checkCount = 0;
    var checkedBoxValues = GetCheckedBoxValues();
    if(checkedBoxValues == "0")
    {

        return true;
    }else if(checkCount > 1)
    {
       alert("您已经选择了一个贺卡！");
        return false;
    }else
    {
     //因为只能选择一个贺卡，所以每次设为空
      document.getElementById("CheckGuid").value = "";
      document.getElementById("CheckGuid").value = checkedBoxValues.replace('0,','');
      return true;
    }
}

/***********************得到选中的CheckBox的行绑定的值，如Eval("Guid")******************************/
function GetCheckedBoxValues()
{
    var checkedBoxValues = "0";
    var inputs = document.getElementsByTagName("input");
    for(var j = 0 ; j < inputs.length ; j++){
        if(inputs[j].type == "checkbox" && inputs[j].id != "checkboxAll" && inputs[j].id != "CheckBoxListGroup_0"){
            if(inputs[j].checked == true){
                checkedBoxValues +=( "," +"'"+inputs[j].value+"'");
                checkCount++;             
            }
        }
    }
    return checkedBoxValues;
}



//Num1GridVeiw鼠标经过行时的颜色改变
 var oldgridSelectedColor;
function setMouseOverColor(element) {

    oldgridSelectedColor = element.style.backgroundColor;
    element.style.backgroundColor='yellow';
    element.style.cursor='hand';
    element.style.textDecoration='underline';
}

function setMouseOutColor(element) {

    element.style.backgroundColor=oldgridSelectedColor;
    element.style.textDecoration='none';
}

