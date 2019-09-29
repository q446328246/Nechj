using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_SurveyOption_Action
    {
        int Add(ShopNum1_SurveyOption shopnum1_surveyoption);
        int Delete(string guids);
        DataTable Search(string name);
    }
}