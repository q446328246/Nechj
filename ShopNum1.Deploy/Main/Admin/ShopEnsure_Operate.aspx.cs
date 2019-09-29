using System;
using System.Data;
using System.IO;
using System.Web.SessionState;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.ShopBusinessLogic;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ShopEnsure_Operate : PageBase, IRequiresSessionState
    {
        protected void Add()
        {
            var ensure = new ShopNum1_ShopEnsure
                {
                    Name = TextBoxName.Text,
                    ImagePath = BindData()
                };
            if (ensure.ImagePath == "flag")
            {
                MessageBox.Show("请上传图片！");
            }
            else
            {
                ensure.Href = textBoxhref.Text;
                ensure.Remark = TextBoxRemark.Text;
                ensure.EnsureMoney = Convert.ToDecimal(TextBoxEnsureMoney.Text);
                var action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
                if (action.Add(ensure) > 0)
                {
                    MessageShow.Visible = true;
                    MessageShow.ShowMessage("AddYes");
                }
                else
                {
                    MessageShow.Visible = true;
                    MessageShow.ShowMessage("AddNo");
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (CheckGuid.Value == "0")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "新增店铺担保信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopEnsure_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "修改店铺担保信息",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "ShopEnsure_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Updata();
            }
        }

        protected void Edit()
        {
            DataTable shopEnsure =
                ((Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action()).GetShopEnsure(
                    Convert.ToInt32(CheckGuid.Value.Replace("'", "")));
            TextBoxName.Text = shopEnsure.Rows[0]["Name"].ToString();
            textBoxhref.Text = shopEnsure.Rows[0]["Href"].ToString();
            TextBoxRemark.Text = shopEnsure.Rows[0]["Remark"].ToString();
            TextBoxEnsureMoney.Text = shopEnsure.Rows[0]["EnsureMoney"].ToString();
            ImagePath.ImageUrl = Page.ResolveClientUrl(shopEnsure.Rows[0]["ImagePath"].ToString());
            ViewState["imgPath"] = shopEnsure.Rows[0]["ImagePath"].ToString();
        }

        private string BindData()
        {
            if (FileUploadImage.HasFile)
            {
                string contentType = FileUploadImage.PostedFile.ContentType;
                if ((((contentType.ToLower() == "image/bmp") || (contentType.ToLower() == "image/gif")) ||
                     ((contentType.ToLower() == "image/jpeg") || (contentType.ToLower() == "image/png"))) ||
                    (contentType.ToLower() == "image/pjpeg"))
                {
                    string fileName = Operator.FilterString(FileUploadImage.PostedFile.FileName);
                    var random = new Random();
                    string str4 = (10 + random.Next(70)).ToString();
                    string str5 = DateTime.Now.ToString("yyyyMMddHHmmss") + str4;
                    var info = new FileInfo(fileName);
                    string str6 = str5 + "_" + info.Name;
                    string path = base.Server.MapPath("~/ImgUpload/ShopEnsureImg/" + str6);
                    if (!Directory.Exists(base.Server.MapPath("~/ImgUpload/ShopEnsureImg")))
                    {
                        Directory.CreateDirectory(path);
                    }
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    FileUploadImage.SaveAs(path);
                    return ("~/ImgUpload/ShopEnsureImg/" + str6);
                }
                MessageBox.Show("请选择正确的图片格式！");
                return "flag";
            }
            return "flag";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            CheckGuid.Value = (base.Request.QueryString["id"] == null) ? "0" : base.Request.QueryString["id"];
            if (!Page.IsPostBack && (CheckGuid.Value != "0"))
            {
                Edit();
                Label_Oprate.Text = "编辑店铺担保";
                btnConfirm.Text = "更新";
            }
        }

        protected void Updata()
        {
            var ensure = new ShopNum1_ShopEnsure
                {
                    Name = TextBoxName.Text
                };
            if (BindData() != "flag")
            {
                ensure.ImagePath = BindData();
            }
            else
            {
                ensure.ImagePath = ViewState["imgPath"].ToString();
            }
            ensure.Href = textBoxhref.Text;
            ensure.Remark = TextBoxRemark.Text;
            ensure.EnsureMoney = Convert.ToDecimal(TextBoxEnsureMoney.Text);
            ensure.ID = int.Parse(CheckGuid.Value.Replace("'", ""));
            var action = (Shop_Ensure_Action)ShopNum1.ShopFactory.LogicFactory.CreateShop_Ensure_Action();
            if (action.Updata(ensure) > 0)
            {
                base.Response.Redirect("ShopEnsure_List.aspx");
            }
            else
            {
                MessageShow.Visible = true;
                MessageShow.ShowMessage("UpdateNo1");
            }
        }
    }
}