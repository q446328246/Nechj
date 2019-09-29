using System;
using System.IO;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class Advertisement_List : PageBase, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                GetFileName();
                BindGrid();
            }
        }

        public string AdType(object object_0)
        {
            string str = "";
            string str2 = object_0.ToString();
            switch (str2)
            {
                case null:
                    return str;

                case "0":
                    return "文字";

                case "1":
                    return "图片";
            }
            if (!(str2 == "2"))
            {
                if (str2 == "3")
                {
                    str = "flash";
                }
                return str;
            }
            return "幻灯片";
        }

        public void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            CheckGuid.Value = "0";
            base.Response.Redirect("Advertisement_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            var action = (ShopNum1_Advertisement_Action) LogicFactory.CreateShopNum1_Advertisement_Action();
            if (action.Delete(CheckGuid.Value) > 0)
            {
                BindGrid();
                MessageShow.ShowMessage("DelYes");
                MessageShow.Visible = true;
            }
            else
            {
                MessageShow.ShowMessage("DelNo");
                MessageShow.Visible = true;
            }
        }

        protected void ButtonEdit_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("Advertisement_Operate.aspx?guid=" + CheckGuid.Value);
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string text = TextBoxdivid.Text;
            BindGrid();
        }

        public void GetFileName()
        {
            string[] files = Directory.GetFiles(base.Server.MapPath("~/Main/Themes/Skin_Default/"), "*.aspx");
            DropDownListFileName.Items.Clear();
            var item = new ListItem
                {
                    Text = " -全部-",//LocalizationUtil.GetCommonMessage("All"),
                    Value = "-1"
                };
            DropDownListFileName.Items.Add(item);
            for (int i = 0; i < files.Length; i++)
            {
                var item2 = new ListItem
                    {
                        Text = files[i].Substring(files[i].LastIndexOf('\\') + 1),
                        Value = files[i].Substring(files[i].LastIndexOf('\\') + 1)
                    };
                DropDownListFileName.Items.Add(item2);
            }
        }
    }
}