using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using ShopNum1.Common;
using ShopNum1.MultiBaseWebControl;
using ShopNum1.ShopBusinessLogic;
using ShopNum1.ShopFactory;
using ShopNum1MultiEntity;

namespace ShopNum1.ShopAdminWebControl
{
    [ParseChildren(true)]
    public class S_ShopLinkEdit : BaseShopWebControl
    {
        private Button ButtonBackList;
        private Button ButtonSubmit;
        private CheckBox CheckBoxIsShow;
        private Label LabelTitle;
        private TextBox TextBoxNote;
        private TextBox TextBoxShopMemLoginID;
        private string skinFilename = "S_ShopLinkEdit.ascx";

        public S_ShopLinkEdit()
        {
            if (base.SkinFilename == null)
            {
                base.SkinFilename = skinFilename;
            }
        }

        public string ShopID { get; set; }

        public string ShopName { get; set; }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (Page.Request.QueryString["guid"] != null)
            {
                method_1();
                TextBoxShopMemLoginID.ReadOnly = true;
            }
            else
            {
                BindData();
            }
        }

        protected void ButtonBackList_Click(object sender, EventArgs e)
        {
            Page.Response.Redirect("S_ShopLink.aspx");
        }

        public bool CheckMemLoginID(string memloginID)
        {
            DataTable table =
                ((Shop_ShopLink_Action) LogicFactory.CreateShop_ShopLink_Action()).CheckMemLoginID(memloginID);
            if ((table.Rows.Count > 0) && (table.Rows.Count < 2))
            {
                ShopID = table.Rows[0]["ShopID"].ToString();
                ShopName = table.Rows[0]["ShopName"].ToString();
                return true;
            }
            return false;
        }

        public void GetDataInfo()
        {
            DataTable table =
                ((Shop_ShopLink_Action) LogicFactory.CreateShop_ShopLink_Action()).Edit(Page.Request.QueryString["guid"]);
            if ((table != null) && (table.Rows.Count > 0))
            {
                TextBoxShopMemLoginID.Text = table.Rows[0]["ShopMemLoginID"].ToString();
                if (table.Rows[0]["IsShow"].ToString() == "1")
                {
                    CheckBoxIsShow.Checked = true;
                }
                else
                {
                    CheckBoxIsShow.Checked = false;
                }
            }
            TextBoxNote.Text = table.Rows[0]["Note"].ToString();
        }

        protected override void InitializeSkin(Control skin)
        {
            LabelTitle = (Label) skin.FindControl("LabelTitle");
            TextBoxShopMemLoginID = (TextBox) skin.FindControl("TextBoxShopMemLoginID");
            CheckBoxIsShow = (CheckBox) skin.FindControl("CheckBoxIsShow");
            TextBoxNote = (TextBox) skin.FindControl("TextBoxNote");
            ButtonSubmit = (Button) skin.FindControl("ButtonSubmit");
            ButtonSubmit.Click += ButtonSubmit_Click;
            ButtonBackList = (Button) skin.FindControl("ButtonBackList");
            ButtonBackList.Click += ButtonBackList_Click;
            if (Page.Request.QueryString["guid"] != null)
            {
                GetDataInfo();
                LabelTitle.Text = "编辑友情链接";
                ButtonSubmit.Text = "编辑";
            }
            else
            {
                LabelTitle.Text = "添加友情链接";
                ButtonSubmit.Text = "添加";
            }
        }

        protected void BindData()
        {
            CheckMemLoginID(TextBoxShopMemLoginID.Text);
            var action = (Shop_ShopLink_Action) LogicFactory.CreateShop_ShopLink_Action();
            var link = new ShopNum1_Shop_Link
            {
                CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")),
                Guid = Guid.NewGuid()
            };
            if (CheckBoxIsShow.Checked)
            {
                link.IsShow = 1;
            }
            else
            {
                link.IsShow = 0;
            }
            link.MemLoginID = base.MemLoginID;
            link.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            link.Note = TextBoxNote.Text.Trim();
            link.ShopMemLoginID = TextBoxShopMemLoginID.Text;
            link.ShopName = ShopName;
            link.ShopUrl = "http://" + ShopSettings.GetValue("PersonShopUrl") + ShopID +
                           ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.'));
            try
            {
                if (action.Add(link) > 0)
                {
                    MessageBox.Show("添加成功！");
                    TextBoxNote.Text = "";
                    TextBoxShopMemLoginID.Text = "";
                }
                else
                {
                    MessageBox.Show("添加失败！");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("添加失败！");
            }
        }

        protected void method_1()
        {
            var action = (Shop_ShopLink_Action) LogicFactory.CreateShop_ShopLink_Action();
            var link = new ShopNum1_Shop_Link
            {
                Guid = new Guid(Page.Request.QueryString["guid"])
            };
            if (CheckBoxIsShow.Checked)
            {
                link.IsShow = 1;
            }
            else
            {
                link.IsShow = 0;
            }
            link.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            link.Note = TextBoxNote.Text.Trim();
            link.MemLoginID = base.MemLoginID;
            link.ShopMemLoginID = TextBoxShopMemLoginID.Text;
            link.ShopName = ShopName;
            link.ShopUrl = "http://" + ShopSettings.GetValue("PersonShopUrl") + ShopID +
                           ShopSettings.siteDomain.Substring(ShopSettings.siteDomain.IndexOf('.'));
            try
            {
                if (action.Updata(link) > 0)
                {
                    MessageBox.Show("编辑成功！");
                }
                else
                {
                    MessageBox.Show("编辑失败！");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("编辑失败！");
            }
        }
    }
}