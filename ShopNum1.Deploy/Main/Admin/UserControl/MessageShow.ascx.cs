using System;

namespace ShopNum1.Deploy.Main.Admin.UserControl
{
    public partial class MessageShow : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public void ShowMessage(string string_0)
        {
            switch (string_0)
            {
                case "AddYes":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "添加成功！";
                    return;
                case "AddNo":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "添加失败！";
                    return;
                case "DelYes":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除成功！";
                    return;
                case "DelNo":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除失败！";
                    return;
                case "EditYes":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "编辑成功！";
                    return;
                case "EditNo":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "编辑失败！";
                    return;
                case "UpdateYes":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "编辑成功！";
                    return;
                case "UpdateNo1":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "文件上传失败！";
                    return;
                case "UpdateNo2":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "文件已经存在！";
                    return;
                case "UpdateNo3":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "文件类型不符！";
                    return;
                case "OperateYes":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "操作成功！";
                    return;
                case "OperateNo":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "操作失败！";
                    return;
                case "Audit1Yes":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "操作成功！";
                    return;
                case "Audit1No":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "操作失败！";
                    return;
                case "Audit2Yes":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "操作成功！";
                    return;
                case "Audit2No":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "操作失败！";
                    return;
                case "EmailState1Success":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "同意订阅成功！";
                    return;
                case "EmailState1Fail":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "同意订阅失败！";
                    return;
                case "EmailState2Success":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "拒绝订阅成功！";
                    return;
                case "EmailState2Fail":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "拒绝订阅失败！";
                    return;
                case "SendYes":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "拒绝订阅成功！";
                    return;
                case "SendNo":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "拒绝订阅失败！";
                    return;
                case "SendNoteYes":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "发送成功！";
                    return;
                case "SendNoteNo":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "发送失败！";
                    return;
                case "-01":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "当前账号余额不足！";
                    return;
                case "-02":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "当前用户ID错误！";
                    return;
                case "-03":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "当前密码错误！";
                    return;
                case "-04":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "参数不够或参数内容的类型错误！";
                    return;
                case "-05":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "手机号码格式不对！";
                    return;
                case "-06":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "短信内容编码不对！";
                    return;
                case "-07":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "短信内容含有敏感字符！";
                    return;
                case "-08":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "无接收数据";
                    return;
                case "-09":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "系统维护中..";
                    return;
                case "-10":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "手机号码数量超长！";
                    return;
                case "-11":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "短信内容超长！（70个字符）";
                    return;
                case "-12":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "其它错误！";
                    return;
                case "-13":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "文件传输错误";
                    return;
                case "SendNotNull":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "发送对象为空不能发送";
                    return;
                case "NoteImgSize":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "彩信图片不能大于50KB！";
                    return;
                case "NoteImgFormat":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "彩信图片格式不正确！";
                    return;
                case "NoteImgExists":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "彩信图片已存在！";
                    return;
                case "NoteLengthOne":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "短信内容长度应该在1到70个字！";
                    return;
                case "NoteLengthTwo":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "彩信内容长度应该在1到500个字 标题长度应该在1到5个字！";
                    return;
                case "NoImg":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "请选择图片！";
                    return;
                case "TelBeyond":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "输入的手机号过多！";
                    return;
                case "TelError":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "会员手机号格式不正确！";
                    return;
                case "imagecategory":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除内容中含有相关图片,无法删除!";
                    return;
                case "AnnouncementCategory":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除内容中含有相关资讯,无法删除!";
                    return;
                case "Region":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除内容中含有相关地区,无法删除!";
                    return;
                case "ShopType":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除内容中含有相关店铺信息,无法删除!";
                    return;
                case "productCategory":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除内容中含有其它商品，无法删除!";
                    return;
                case "EmailTyep":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除内容中含有系统文件，无法删除!";
                    return;
                case "SupplyCategory":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除内容中含有其它子类，无法删除!";
                    return;
                case "Category":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除内容中含有其它分类，无法删除!";
                    return;
                case "productCategoryContent":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除内容中含有其它子目录，无法删除!";
                    return;
                case "ShopTypeContent":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除内容中含有其它子目录，无法删除!";
                    return;
                case "Image":
                    this.ImageShow.ImageUrl = "../images/success.gif";
                    this.LabelShow.Text = "删除内容中含有图片，无法删除!";
                    return;
            }
            this.ImageShow.ImageUrl = "../images/success.gif";
            this.LabelShow.Text = string_0;
        }
    }
}