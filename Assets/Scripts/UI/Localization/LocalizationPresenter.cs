using System;
using Zenject;

namespace UI.Localization
{
    public class LocalizationPresenter : IInitializable, IDisposable
    {
        private readonly LocalizationChanger _localizationChanger;
        private readonly LocalizationView _localizationView;

        public LocalizationPresenter(LocalizationChanger localizationChanger, LocalizationView localizationView)
        {
            _localizationChanger = localizationChanger;
            _localizationView = localizationView;
        }

        public void Initialize()
        {
            _localizationView.LanguageChoosed += _localizationChanger.Change;
        }

        public void Dispose()
        {
            _localizationView.LanguageChoosed -= _localizationChanger.Change;
        }
    }
}