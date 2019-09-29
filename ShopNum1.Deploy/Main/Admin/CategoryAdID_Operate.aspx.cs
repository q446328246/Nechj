using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using ShopNum1MultiEntity;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CategoryAdID_Operate : PageBase, IRequiresSessionState
    {
        public void Add()
        {
            ShopNum1_CategoryAdID did = new ShopNum1_CategoryAdID
            {
                CategoryType = this.DropDownListPageName.SelectedValue,
                CategoryAdName = this.TextBoxAdName.Text.Trim(),
                CategoryAdIntroduce = this.TextBoxAdIntroduce.Text.Trim(),
                Width = int.Parse(this.TextBoxAdWidth.Text.Trim()),
                Height = int.Parse(this.TextBoxHeight.Text.Trim()),
                CategoryAdPic = "",
                CategoryAdflow = new int?(int.Parse(this.TextBoxCategoryAdflow.Text.Trim())),
                visitPeople = new int?(int.Parse(this.TextBoxvisitPeople.Text.Trim())),
                CategoryAdDefalutPic = this.TextBoxAdDefaultPic.Text.Trim(),
                CategoryAdDefalutLike = "http://" + this.TextBoxDefaultLike.Text.Trim().ToLower().Replace("http://", ""),
                IsShow = this.CheckBoxIsShow.Checked ? 1 : 0
            };
            ShopNum1_CategoryAdID_Action action = (ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action();
            if (action.Add(did) > 0)
            {
                this.ClearControl();
                this.MessageShow.ShowMessage("AddYes");
                this.MessageShow.Visible = true;
            }
            else
            {
                this.MessageShow.ShowMessage("AddNo");
                this.MessageShow.Visible = true;
            }
        }

        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CategoryAdID_List.aspx");
        }

        protected void ButtonConfirm_Click(object sender, EventArgs e)
        {
            if (this.hiddenFieldGuid.Value != "0")
            {
                this.Edit();
            }
            else
            {
                this.Add();
            }
        }

        public void ClearControl()
        {
            this.DropDownListPageName.SelectedValue = "-1";
            this.TextBoxAdName.Text = string.Empty;
            this.TextBoxAdIntroduce.Text = string.Empty;
            this.TextBoxAdWidth.Text = string.Empty;
            this.TextBoxHeight.Text = string.Empty;
            this.TextBoxAdDefaultPic.Text = string.Empty;
            this.TextBoxDefaultLike.Text = string.Empty;
            this.ImageOriginalImge.Src = string.Empty;
        }

        public void Edit()
        {
            ShopNum1_CategoryAdID did = new ShopNum1_CategoryAdID
            {
                CategoryType = this.DropDownListPageName.SelectedValue,
                CategoryAdName = this.TextBoxAdName.Text.Trim(),
                CategoryAdIntroduce = this.TextBoxAdIntroduce.Text.Trim(),
                Width = int.Parse(this.TextBoxAdWidth.Text.Trim()),
                Height = int.Parse(this.TextBoxHeight.Text.Trim()),
                CategoryAdPic = "",
                CategoryAdflow = 0,
                visitPeople = 0,
                CategoryAdDefalutPic = this.TextBoxAdDefaultPic.Text.Trim(),
                CategoryAdDefalutLike = this.TextBoxDefaultLike.Text.Trim(),
                IsShow = this.CheckBoxIsShow.Checked ? 1 : 0,
                ID = int.Parse(this.hiddenFieldGuid.Value)
            };
            ShopNum1_CategoryAdID_Action action = (ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action();
            if (action.Updata(did) > 0)
            {
                base.Response.Redirect("CategoryAdID_List.aspx");
            }
            else
            {
                this.MessageShow.ShowMessage("EditNo");
                this.MessageShow.Visible = true;
            }
        }

        public void GetEditInfo()
        {
            DataTable table = ((ShopNum1_CategoryAdID_Action)LogicFactory.CreateShopNum1_CategoryAdID_Action()).Search("-1", this.hiddenFieldGuid.Value);
            if ((table != null) && (table.Rows.Count > 0))
            {
                this.ImageOriginalImge.Src = this.Page.ResolveUrl("~/ImgUpload/" + table.Rows[0]["CategoryAdDefalutPic"].ToString());
                this.DropDownListPageName.SelectedValue = table.Rows[0]["CategoryType"].ToString();
                this.TextBoxAdName.Text = table.Rows[0]["CategoryAdName"].ToString();
                this.TextBoxAdIntroduce.Text = table.Rows[0]["CategoryAdIntroduce"].ToString();
                this.TextBoxAdWidth.Text = table.Rows[0]["Width"].ToString();
                this.TextBoxHeight.Text = table.Rows[0]["Height"].ToString();
                this.TextBoxAdDefaultPic.Text = table.Rows[0]["CategoryAdDefalutPic"].ToString();
                this.TextBoxDefaultLike.Text = table.Rows[0]["CategoryAdDefalutLike"].ToString();
                if (table.Rows[0]["IsShow"].ToString() == "0")
                {
                    this.CheckBoxIsShow.Checked = false;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            this.hiddenFieldGuid.Value = (base.Request.QueryString["ID"] == null) ? "0" : base.Request.QueryString["ID"].Replace("'", "");
            if (!this.Page.IsPostBack && (this.hiddenFieldGuid.Value != "0"))
            {
                this.GetEditInfo();
            }
        }
    }
}