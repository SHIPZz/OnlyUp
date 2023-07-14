using I2.Loc;
using Services;
using Services.Providers;

namespace UI.Localization
{
    public class LocalizationChanger
    {
        private DataProvider _dataProvider;

        public LocalizationChanger(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void SetStartLanguage(string language) =>
            LocalizationManager.CurrentLanguage = language;

        public void Change(string language)
        {
            LocalizationManager.CurrentLanguage = language;
            _dataProvider.SaveLanguage(language);
        }
    }
}