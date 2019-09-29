using System;
using System.Data;
using System.Web.SessionState;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class CategoryAdID_SearchDetail : PageBase, IRequiresSessionState
    {
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("CategoryAdBuyAudit_List.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.CheckLogin();
                string adID = Page.Request.QueryString["Guid"].Replace("'", "");
                DataTable table =
                    ((ShopNum1_CategoryAdID_Action) LogicFactory.CreateShopNum1_CategoryAdID_Action()).Search("-1", adID);
                if ((table != null) && (table.Rows.Count > 0))
                {
                    TextBoxID.Text = table.Rows[0]["ID"].ToString();
                    TextBoxCategoryAdName.Text = table.Rows[0]["CategoryAdName"].ToString();
                    TextBoxCategoryType.Text = PageName(table.Rows[0]["CategoryType"]);
                    TextBoxWidth.Text = table.Rows[0]["Width"].ToString();
                    TextBoxHeight.Text = table.Rows[0]["Height"].ToString();
                    ImageAdDefalutPic.ImageUrl = Page.ResolveUrl("~/ImgUpload/" + table.Rows[0]["CategoryAdDefalutPic"]);
                    TextBoxAdDefalutLike.Text = table.Rows[0]["CategoryAdDefalutLike"].ToString();
                    TextBoxAdflow.Text = table.Rows[0]["CategoryAdflow"].ToString();
                    TextBoxvisitPeople.Text = table.Rows[0]["visitPeople"].ToString();
                    CheckBoxIsShow.Checked = table.Rows[0]["IsShow"].ToString() != "0";
                    TextBoxIntroduce.Text = table.Rows[0]["CategoryAdIntroduce"].ToString();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public string PageName(object object_0)
        {
            switch (object_0.ToString())
            {
                case "1":
                    return "��Ʒ����";

                case "2":
                    return "������Ϣ����";

                case "3":
                    return "�������";

                case "4":
                    return "���̷���";

                case "5":
                    return "��Ѷ����";

                case "6":
                    return "Ʒ�Ʒ���";
            }
            return "�Ƿ�ҳ��";
        }
    }
}