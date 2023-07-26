using System;
using UI.Windows.Ad;
using UnityEngine;
using Zenject;

namespace Services.OnEventHandlers
{
    public class PauseOnAd : IInitializable, IDisposable
    {
        private readonly AdShowerOnButton _adShowerOnButton;

        public PauseOnAd(AdShowerOnButton adShowerOnButton)
        {
            _adShowerOnButton = adShowerOnButton;
        }

        public void Initialize()
        {
            _adShowerOnButton.AdOpened += SetPause;
            _adShowerOnButton.AdClosed += UnPause;
        }

        public void Dispose()
        {
            _adShowerOnButton.AdOpened -= SetPause;
            _adShowerOnButton.AdClosed -= UnPause;
        }

        private void UnPause() =>
            Time.timeScale = 1f;

        private void SetPause() =>
            Time.timeScale = 0f;
    }
}