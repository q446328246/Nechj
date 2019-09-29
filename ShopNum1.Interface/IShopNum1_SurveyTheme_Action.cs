using System.Data;
using ShopNum1MultiEntity;

namespace ShopNum1.Interface
{
    public interface IShopNum1_SurveyTheme_Action
    {
        int Add(ShopNum1_SurveyTheme shopNum1_SurveyTheme);
        int Delete(string guids);
        DataTable GetEditInfo(string guid);
        int GetMaxCount(string surveyGuid);
        int GetSurveyOptionMaxCount(string surveyOptionGuid);
        DataTable Search(string name);
        DataTable SearchFirst(string startTime, string endTime);
        DataTable SearchSurveyOption(string surveyGuid);
        int SurveyAdd(string surveyGuid, string surveyOptionGuid);
        int Update(string guid, ShopNum1_SurveyTheme shopnum1_surveytheme);
    }
}