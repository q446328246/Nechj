using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class AAA_NEC_WenZhangOperate : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["ID"] == null) ? "0" : base.Request.QueryString["guid"];
            if (!Page.IsPostBack)
            {
                GetOrderID();
                if (hiddenFieldGuid.Value != "0")
                {
                    GetEditInfo();
                    ButtonConfirm.Text = "更新";
                }

            }
        }

        protected string FileUpload(FileUpload ControlName)
        {
            if (ControlName.HasFile)
            {
                var info = new FileInfo(ControlName.PostedFile.FileName);
                string str2 = "~/main/admin/images";
                string filepath = str2 + "/" + info.Extension;
                string retstr = string.Empty;
                if (ShopNum1UpLoad.ImageUpLoadWithName(ControlName, filepath, out retstr))
                {
                    return (info.Extension);
                }
                MessageBox.Show(retstr);
                return "0";
            }
            return "1";
        }

        protected void Add()
        {


            ShopNum1_Brand_Action action2 = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
            if (action2.AddWenZhang(TextBoxName.Text.Trim(), TextBoxWebSite.Text.Trim(), FileUpload(FileUploadOrganizationImage)) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员新增文章",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "AAA_NEC_WenZhangOperate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                base.Response.Redirect("AAA_NEC_WenZhang.aspx");
                MessageShow.ShowMessage("AddYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }

        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (hiddenFieldGuid.Value != "0")
            {
                Edit();
            }
            else
            {
                Add();
            }
        }

        protected void ClearControl()
        {
            TextBoxName.Text = string.Empty;

            TextBoxWebSite.Text = string.Empty;

        }

        protected void Edit()
        {
            string images = string.Empty;
            if (FileUploadOrganizationImage.HasFile)
            {
                images = FileUpload(FileUploadOrganizationImage);
            }
            else
            {
                images = ImageOriginalImge.Src;
            }
            var action = (ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action();
            if (action.UpdateWenZhang(hiddenFieldGuid.Value, TextBoxName.Text.Trim(), TextBoxWebSite.Text.Trim(), images) > 0)
            {
                HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
                HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);

                var operateLog = new ShopNum1_OperateLog
                {
                    Record = "管理员修改文章",
                    OperatorID = cookie2.Values["LoginID"].ToString(),
                    IP = Globals.IPAddress,
                    PageName = "AAA_NEC_WenZhangOperate.aspx",
                    Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                };
                base.OperateLog(operateLog);
                base.Response.Redirect("AAA_NEC_WenZhang.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected void GetEditInfo()
        {
            DataTable editInfo =
                ((ShopNum1_Brand_Action)LogicFactory.CreateShopNum1_Brand_Action()).GetWenZhangEditInfo(hiddenFieldGuid.Value);
            TextBoxName.Text = editInfo.Rows[0]["Title"].ToString();


            if (editInfo.Rows[0]["Image"].ToString() != string.Empty)
            {
                ImageOriginalImge.Src = editInfo.Rows[0]["Image"].ToString();
            }
            else
            {
                ImageOriginalImge.Src = Globals.ApplicationPath + "/Images/noImage.gif";
            }

            TextBoxWebSite.Text = editInfo.Rows[0]["HtmlAddress"].ToString();

            ButtonConfirm.Text = "更新";
            LabelPageTitle.Text = "编辑文章";
        }

        protected int GetOrderID()
        {
            return ShopNum1_Common_Action.ReturnMaxID("ID", "Nec_WenZhang");
        }


    }
}