using System;
using System.Data;
using ShopNum1.BusinessLogic;
using ShopNum1.Deploy.App_Code;
using ShopNum1.Factory;

namespace ShopNum1.Deploy.Main.Account.Skin
{
    public partial class A_PwdSer : BaseMemberControl
    {
        private string url1;

        public string Url1
        {
            get { return url1; }
            set { url1 = value; }
        }

        private string url2;

        public string Url2
        {
            get { return url2; }
            set { url2 = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            var action = (ShopNum1_Member_Action) LogicFactory.CreateShopNum1_Member_Action();

            
            DataTable table1 = action.SearchMembertwo(base.MemLoginID);
            if (table1.Rows[0]["PayPwd"].ToString() == null || table1.Rows[0]["PayPwd"].ToString() == "")
            {
                Url1 = "../A_UpPayPwd1.aspx";
                Url2 = "A_UpPayPwd1.aspx";
            }
            else 
            {
                Url1 = "../A_ChangePwdWay.aspx";
                Url2 = "A_ChangePwdWay.aspx";
            }





            var table = new DataTable();
            try
            {
                if (action.CheckSafeRank(base.MemLoginID, "and").Rows.Count > 0)
                {
                    Lab_SafeRank.Text = "��";
                    Lab_SafeRankTitle.Text = "�˺��Ѿ������˽���������ֻ��󶨣��뱣�ܺ��ֻ����������������";
                    Image_SafeRankImg.ImageUrl = "/Main/Account/images/jidongt03.jpg";
                    LinkButton_Mobile.Visible = false;
                    LinkButton_Email.Visible = false;
                }
                else
                {
                    table = action.CheckSafeRank(base.MemLoginID, "or");
                    if (table.Rows.Count > 0)
                    {
                        Lab_SafeRank.Text = "��";
                        Lab_SafeRankTitle.Text = "�˺��Ѿ������˽���������ֻ��󶨣��뱣�ܺ��ֻ����������������";
                        Image_SafeRankImg.ImageUrl = "/Main/Account/images/jidongt02.jpg";
                        string str = table.Rows[0]["IsEmailActivation"].ToString();
                        string str2 = table.Rows[0]["IsMobileActivation"].ToString();
                        if (str != "1")
                        {
                            Lab_SafeRankTitle.Text = "�����˻���ȫ����һ�㣬Ϊȷ�����˻���ȫ������������߰�ȫ�ȼ���������";
                            LinkButton_Email.Visible = true;
                            LinkButton_Mobile.Visible = false;
                        }
                        else if (str2 != "1")
                        {
                            Lab_SafeRankTitle.Text = "�����˻���ȫ����һ�㣬Ϊȷ�����˻���ȫ������������߰�ȫ�ȼ������ֻ�����";
                            LinkButton_Mobile.Visible = true;
                            LinkButton_Email.Visible = false;
                        }
                    }
                    else
                    {
                        Lab_SafeRank.Text = "��";
                        Lab_SafeRankTitle.Text = "�����˻���ȫ����ϵͣ�Ϊȷ�����˻���ȫ������������߰�ȫ�ȼ�";
                        Image_SafeRankImg.ImageUrl = "/Main/Account/images/jidongt01.jpg";
                        LinkButton_Mobile.Text = "�ֻ���|";
                        LinkButton_Email.Text = "�����";
                        LinkButton_Mobile.Visible = true;
                        LinkButton_Email.Visible = true;
                        hfTradePwd.Value = "0";
                    }
                }
            }
            catch
            {
            }
        }
    }
}
                                            
