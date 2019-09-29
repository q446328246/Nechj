using System;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1MultiEntity;
using System.Data;
using System.Net;
using System.IO;

namespace ShopNum1.Deploy.Main.Admin
{
    public partial class NewBlackList : PageBase, IRequiresSessionState
    {
        ShopNum1_Member_Action memberaction = new ShopNum1_Member_Action();
        protected void Page_Load(object sender, EventArgs e)
        {
            //base.CheckLogin();
            if (!Page.IsPostBack)
            {
                string str = (base.Request.QueryString["operateStatus"] == null) ? "-1" : base.Request.QueryString["operateStatus"];
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            try
            {
                Num1GridViewShow.DataSource = memberaction.SelectWHJ_BlackList();

                Num1GridViewShow.DataBind();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }




        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            string kkkk = TextBox1.Text.Trim();
            Num1GridViewShow.DataSource = memberaction.SelectWHJ_BlackList(kkkk);
            Num1GridViewShow.DataBind();
            //BindGrid();
        }

        protected void ADDBTN_Click(object sender, EventArgs e)
        {
            string kkkk = TextBox1.Text.Trim();
            if (kkkk != null && kkkk != "") {
                int res = memberaction.AddWHJ_BlackList(kkkk);
                if (res == 1)
                {
                    MessageBox.Show("操作成功!");
                    Num1GridViewShow.DataSource = memberaction.SelectWHJ_BlackList(null);
                    Num1GridViewShow.DataBind();
                    //BindGrid();
                }
                else {
                    MessageBox.Show("操作失败!");
                }
            }
        }

        protected void DELBTN_Click(object sender, EventArgs e)
        {
            string kkkk = TextBox1.Text.Trim();
            if (kkkk != null && kkkk != "")
            {
                int res = memberaction.DelWHJ_BlackList(kkkk);
                if (res >= 1)
                {
                    Num1GridViewShow.DataSource = memberaction.SelectWHJ_BlackList(null);
                    Num1GridViewShow.DataBind();
                    //BindGrid();
                    MessageBox.Show("操作成功!");
                }
                else
                {
                    MessageBox.Show("操作失败!");
                }
            }
          
        }
    }
}