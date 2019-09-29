using System;
using System.Web;
using System.Web.UI;
using ShopNum1.BusinessLogic;
using ShopNum1.Common;
using ShopNum1.Factory;
using ShopNum1.TbLinq;

namespace ShopNum1.Deploy.Shop.ShopAdmin.TbTop
{
    public partial class TbSetAppKey : Page
    {
        // private TextBox TextBoxTbKey;//�Ա�key
        // private TextBox TextBoxTbSecret;//�Ա�secret

        /// <summary>
        ///     ��Ա��
        /// </summary>
        private string MemLoginID { get; set; }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            //TextBoxTbKey = (TextBox)Page.FindControl("TextBoxTbKey");
            //TextBoxTbSecret = (TextBox)Page.FindControl("TextBoxTbSecret");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //��֤��Ա���ĵ�cookies
            if (Page.Request.Cookies["MemberLoginCookie"] == null)
            {
                //�˳�
                GetUrl.RedirectTopLogin();
            }
            else
            {
                HttpCookie cookieMemberLogin = Page.Request.Cookies["MemberLoginCookie"];
                HttpCookie decodedCookieMemberLogin = HttpSecureCookie.Decode(cookieMemberLogin);
                string MemberType = decodedCookieMemberLogin.Values["MemberType"];
                if (MemberType != "2")
                {
                    //�˳�
                    GetUrl.RedirectTopLogin();
                    return;
                }
                //��Ա��¼ID
                MemLoginID = decodedCookieMemberLogin.Values["MemLoginID"];
            }

            if (!IsPostBack)
            {
                BindAppKey();
            }
        }

        private void BindAppKey()
        {
            var tbTopKeyAction = (ShopNum1_TbTopKey_Action) LogicTbFactory.CreateShopNum1_TbTopKey_Action();
            ShopNum1_TbTopKey tbTop = tbTopKeyAction.SearchTopKey(MemLoginID);


            if (tbTop == null)
            {
                ViewState["isadd"] = "1";
            }
            else
            {
                //���ýڵ��ֵ
                TextBoxTbKey.Text = tbTop.AppKey;
                TextBoxTbSecret.Text = tbTop.AppSecret;
                //����Ϊ�༭
                ViewState["isadd"] = "0";
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            var tbTop = new ShopNum1_TbTopKey();
            tbTop.Guid = Guid.NewGuid();

            tbTop.CreateTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            tbTop.CreateUser = MemLoginID;
            tbTop.URL = "";
            tbTop.AppKey = TextBoxTbKey.Text.Trim();
            tbTop.AppSecret = TextBoxTbSecret.Text.Trim();
            tbTop.IsForbid = 0;
            tbTop.MemloginID = MemLoginID;
            tbTop.ModifyTime = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            tbTop.ModifyUser = MemLoginID;
            try
            {
                var tbTopKeyAction = (ShopNum1_TbTopKey_Action) LogicTbFactory.CreateShopNum1_TbTopKey_Action();
                bool isopreate = true; //����״̬
                ///���
                if (ViewState["isadd"].ToString().Trim() == "1")
                {
                    if (tbTopKeyAction.AddTbTopKey(tbTop))
                    {
                        isopreate = true;
                        //����Ϊ�޸ĵ�
                        ViewState["isadd"] = "0";
                    }
                    else
                    {
                        isopreate = false;
                    }
                }
                    //�޸�
                else
                {
                    if (tbTopKeyAction.UpdateTopKey(tbTop))
                    {
                        isopreate = true;
                    }
                    else
                    {
                        isopreate = false;
                    }
                }
                if (isopreate)
                {
                    MessageBox.Show("�����ɹ��˿�!");
                }
                else
                {
                    MessageBox.Show("����ʧ��!");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}