using System;
using System.Web.SessionState;
using System.Web;
using ShopNum1.Common;
using ShopNum1.BusinessLogic;
using ShopNum1.Factory;
using System.Web.UI.WebControls;
using System.Data;



namespace ShopNum1.Deploy.Main.Admin
{
    public partial class ChangeRankScoreLog_List : PageBase, IRequiresSessionState
    {
        protected void BindGrid()
        {
            Num1GridViewShow.DataBind();
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        public string ChangeOperateType(string operateType)
        {
            if (operateType == "1")
            {
                return "���ͺ��";
            }
            if (operateType == "2")
            {
                return "ת�˺��";
            }
            if (operateType == "3")
            {
                return "�һ���Ʒ";
            }
            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            base.CheckLogin();
            if (!Page.IsPostBack)
            {
                hiddenGuid.Value = (base.Request.QueryString["guid"] == null) ? "0" : base.Request.QueryString["guid"];
                BindGrid();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Cardno = this.TextMemLoginIDValue.Text;
            decimal Money = Convert.ToDecimal(this.Money.Text);
            string mome = this.beizhu.Text;
            HttpCookie cookie = base.Request.Cookies["AdminLoginCookie"];
            HttpCookie cookie2 = HttpSecureCookie.Decode(cookie);
            string EnterName = cookie2.Values["LoginID"];
            ShopNum1_Member_Action action = ((ShopNum1_Member_Action)LogicFactory.CreateShopNum1_Member_Action());
            DataTable isCardno = action.isCardno(Cardno);

            if (isCardno!=null && isCardno.Rows.Count > 0)
            {

                int count = action.AddHv(Cardno, Money, mome, EnterName);
                if (count > 0)
                {
                    Response.Write("<script>alert('������ӳɹ��һ�����');</script>");
                }
            }
            else 
            {
                Response.Write("<script>alert('������Ĺ��Ų�����');</script>");
            }

        }
    }
}