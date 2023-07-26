using System;
using Agava.YandexGames;
using Services.OnEventHandlers;
using Zenject;

namespace UI.Windows.Ad
{
    public class AdShowerOnButton : IInitializable, IDisposable
    {
        private readonly AdButtonView _adButtonView;

        public AdShowerOnButton(AdButtonView adButtonView) =>
            _adButtonView = adButtonView;

        public event Action AdClosed;
        public event Action AdOpened;
        public event Action AdEnded;

        public void Initialize() => 
            _adButtonView.Clicked += ShowAd;

        public void Dispose() =>
            _adButtonView.Clicked -= ShowAd;

        private void ShowAd() =>
            VideoAd.Show(OnOpenCallback, OnRewardedCallBack, () => AdClosed?.Invoke());

        private void OnOpenCallback() =>
            AdOpened?.Invoke();

        private void OnRewardedCallBack() =>
            AdEnded?.Invoke();
    }
}