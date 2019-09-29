using System;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Advertisement_Operate : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();

            hiddenFieldGuid.Value = (base.Request.QueryString["guid"] == null)
                                        ? "0"
                                        : base.Request.QueryString["guid"].Replace("'", "");
            if (!Page.IsPostBack)
            {
                if (hiddenFieldGuid.Value != "0")
                {
                    LabelPageTitle.Text = "编辑广告";
                    GetEditInfo();
                }
                else
                {
                    DropDownListAdType_SelectedIndexChanged(null, null);
                }
            }
        }

        public void Add()
        {
            var advertisement = new Advertisement
                {
                    Guid = Guid.NewGuid().ToString(),
                    Explain = TextBoxExplain.Text,
                    PageName = TextBoxPageName.Text,
                    FileName = TextBoxFileName.Text,
                    DivID = TextBoxDivID.Text,
                    Type = DropDownListAdType.SelectedValue,
                    Href = TextBoxHref.Text
                };
            if (advertisement.Type == "0")
            {
                advertisement.Width = "";
                advertisement.Height = "";
                advertisement.Content = TextBoxContent.Text;
            }
            else
            {
                advertisement.Width = TextBoxWidth.Text;
                advertisement.Height = TextBoxHeight.Text;
                if (DropDownListPathType.SelectedValue == "1")
                {
                    string retstr = "";
                    if (FileUpload(FileUploadpath, "../ImgUpload/", out retstr))
                    {
                        advertisement.Content = retstr;
                    }
                    else
                    {
                        advertisement.Content = "";
                    }
                }
                else
                {
                    advertisement.Content = TextBoxpath.Text;
                }
            }
            var action = (ShopNum1_Advertisement_Action) LogicFactory.CreateShopNum1_Advertisement_Action();
            if (action.Add(advertisement) > 0)
            {
                base.Response.Redirect("Advertisement_List.aspx");
            }
            else
            {
                MessageShow.ShowMessage("AddNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Advertisement_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            ShopNum1_OperateLog log;
            if (hiddenFieldGuid.Value != "0")
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "编辑广告位",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Advertisement_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Edit();
            }
            else
            {
                log = new ShopNum1_OperateLog
                    {
                        Record = "添加广告位",
                        OperatorID = base.ShopNum1LoginID,
                        IP = Globals.IPAddress,
                        PageName = "Advertisement_Operate.aspx",
                        Date = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    };
                base.OperateLog(log);
                Add();
            }
        }

        protected void DropDownListAdType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListAdType.SelectedValue == "0")
            {
                TextBoxContent.Visible = true;
                TextBoxpath.Visible = false;
                FileUploadpath.Visible = false;
                adheight.Visible = false;
                adwidth.Visible = false;
                DropDownListPathType.Visible = false;
                ButtonSelectSingleImage.Visible = false;
            }
            else
            {
                adheight.Visible = true;
                adwidth.Visible = true;
                DropDownListPathType.Visible = true;
                ButtonSelectSingleImage.Visible = true;
                DropDownListPathType_SelectedIndexChanged(null, null);
            }
        }

        protected void DropDownListPathType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListPathType.SelectedValue == "0")
            {
                TextBoxContent.Visible = false;
                TextBoxpath.Visible = true;
                FileUploadpath.Visible = false;
                ButtonSelectSingleImage.Visible = true;
            }
            else
            {
                TextBoxContent.Visible = false;
                TextBoxpath.Visible = false;
                FileUploadpath.Visible = true;
                ButtonSelectSingleImage.Visible = false;
            }
        }

        public void Edit()
        {
            var advertisement = new Advertisement
                {
                    Guid = hiddenFieldGuid.Value,
                    Explain = TextBoxExplain.Text,
                    PageName = TextBoxPageName.Text,
                    FileName = TextBoxFileName.Text,
                    DivID = TextBoxDivID.Text,
                    Type = DropDownListAdType.SelectedValue,
                    Href = TextBoxHref.Text
                };
            if (advertisement.Type == "0")
            {
                advertisement.Width = "";
                advertisement.Height = "";
                advertisement.Content = TextBoxContent.Text;
            }
            else
            {
                advertisement.Width = TextBoxWidth.Text;
                advertisement.Height = TextBoxHeight.Text;
                if (DropDownListPathType.SelectedValue == "1")
                {
                    string retstr = "";
                    if (FileUpload(FileUploadpath, "/ImgUpload/", out retstr))
                    {
                        advertisement.Content = retstr;
                    }
                    else
                    {
                        advertisement.Content = retstr;
                    }
                }
                else
                {
                    advertisement.Content = TextBoxpath.Text;
                }
            }
            var action = (ShopNum1_Advertisement_Action) LogicFactory.CreateShopNum1_Advertisement_Action();
            if (action.Update(advertisement) > 0)
            {
                base.Response.Redirect("Advertisement_List.aspx");
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
                    retstr = "ImgUpload/" + str5;
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
            var action = (ShopNum1_Advertisement_Action) LogicFactory.CreateShopNum1_Advertisement_Action();
            DataRow row = action.SelectByID(hiddenFieldGuid.Value).Rows[0];
            TextBoxPageName.Text = row["pagename"].ToString();
            TextBoxFileName.Text = row["filename"].ToString();
            TextBoxDivID.Text = row["divid"].ToString();
            TextBoxExplain.Text = row["explain"].ToString();
            DropDownListAdType.SelectedValue = row["type"].ToString();
            DropDownListAdType_SelectedIndexChanged(null, null);
            TextBoxHref.Text = row["href"].ToString();
            if (DropDownListAdType.SelectedValue == "0")
            {
                TextBoxContent.Text = row["content"].ToString();
            }
            else
            {
                TextBoxpath.Text = row["content"].ToString();
                TextBoxHeight.Text = row["height"].ToString();
                TextBoxWidth.Text = row["width"].ToString();
            }
        }
    }
}