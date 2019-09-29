using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class DefaultAd_Operate : PageBase, IRequiresSessionState
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                        ? "0"
                                        : base.Request.QueryString["guid"].Replace("'", "");
            if (!Page.IsPostBack && (hiddenFieldGuid.Value != "0"))
            {
                LabelPageTitle.Text = "编辑幻灯片图片";
                GetEditInfo();
            }
        }

        public void Add()
        {
            var advertisement = new DefaultAdImg
                {
                    Guid = Guid.NewGuid().ToString(),
                    title = TextBoxExplain.Text,
                    Type = "1",
                    Href = TextBoxHref.Text,
                    Width = TextBoxWidth.Text,
                    Height = TextBoxHeight.Text,
                    orderID = TextBoxLocation.Text.Trim()
                };
            if (DropDownListPathType.SelectedValue == "1")
            {
                string retstr = "";
                if (FileUpload(FileUploadpath, "~/ImgUpload/", out retstr))
                {
                    advertisement.imgsrc = TextBoxpath.Text;
                }
                else
                {
                    advertisement.imgsrc = TextBoxpath.Text;
                }
            }
            else
            {
                advertisement.imgsrc = TextBoxpath.Text;
            }
            var action = (ShopNum1_DefaultAdImg_Action) LogicFactory.CreateShopNum1_DefaultAdImg_Action();
            if (action.Add(advertisement))
            {
                base.Response.Redirect("DefaultAd_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("DefaultAd_List.aspx");
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

        protected void DropDownListPathType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListPathType.SelectedValue == "0")
            {
                TextBoxpath.Visible = true;
                FileUploadpath.Visible = false;
                ButtonSelectSingleImage.Visible = true;
            }
            else
            {
                TextBoxpath.Visible = false;
                FileUploadpath.Visible = true;
                ButtonSelectSingleImage.Visible = false;
            }
        }

        public void Edit()
        {
            var advertisement = new DefaultAdImg
                {
                    Guid = hiddenFieldGuid.Value,
                    title = TextBoxExplain.Text,
                    Type = "1",
                    Href = TextBoxHref.Text,
                    Width = TextBoxWidth.Text,
                    Height = TextBoxHeight.Text,
                    orderID = TextBoxLocation.Text.Trim()
                };
            if (DropDownListPathType.SelectedValue == "1")
            {
                string retstr = "";
                if (FileUpload(FileUploadpath, "~/ImgUpload/", out retstr))
                {
                    advertisement.imgsrc = retstr;
                }
                else
                {
                    advertisement.imgsrc = retstr;
                }
            }
            else
            {
                advertisement.imgsrc = TextBoxpath.Text;
            }
            var action = (ShopNum1_DefaultAdImg_Action) LogicFactory.CreateShopNum1_DefaultAdImg_Action();
            if (action.Update(advertisement))
            {
                base.Response.Redirect("DefaultAd_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("EditNo");
                MessageShow.Visible = true;
            }
        }

        protected bool FileUpload(FileUpload fileUpload, string filepath, out string retstr)
        {
            if (fileUpload.HasFile)
            {
                var random = new Random();
                string fileName = fileUpload.PostedFile.FileName;
                string str2 = HttpContext.Current.Server.MapPath(filepath);
                string str3 = fileName.Substring(fileName.LastIndexOf(".") + 1);
                string contentType = fileUpload.PostedFile.ContentType;
                int contentLength = fileUpload.PostedFile.ContentLength;
                string str5 = DateTime.Now.ToString("yyyyMMddHHmmss") + random.Next(100, 0x3e7).ToString() + "." + str3;
                if (contentLength < 0xfa000)
                {
                    fileUpload.PostedFile.SaveAs(str2 + str5);
                    retstr = "~/ImgUpload/" + str5;
                    return true;
                }
                retstr = "文件不能大于1M！";
                return false;
            }
            retstr = "请选择文件！";
            return false;
        }

        public void GetEditInfo()
        {
            var action = (ShopNum1_DefaultAdImg_Action) LogicFactory.CreateShopNum1_DefaultAdImg_Action();
            DataRow row = action.SelectByID(hiddenFieldGuid.Value).Rows[0];
            TextBoxExplain.Text = row["title"].ToString();
            TextBoxHref.Text = row["href"].ToString();
            TextBoxpath.Text = row["imgsrc"].ToString();
            TextBoxHeight.Text = row["height"].ToString();
            TextBoxWidth.Text = row["width"].ToString();
            TextBoxLocation.Text = row["orderID"].ToString();
        }


    }
}