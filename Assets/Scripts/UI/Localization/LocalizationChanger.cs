using I2.Loc;
using Services.Providers;

namespace UI.Localization
{
    public class LocalizationChanger
    {
        private readonly DataProvider _dataProvider;

        public LocalizationChanger(DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public void Change(string language)
        {
            LocalizationManager.CurrentLanguage = language;
            _dataProvider.SaveLanguage(language);
        }
    }
}