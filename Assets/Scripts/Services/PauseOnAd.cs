using System;
using UnityEngine;
using Zenject;

namespace Services
{
    public class PauseOnAd : IInitializable, IDisposable
    {
        private readonly AdsButtonHandler _adsButtonHandler;

        public PauseOnAd(AdsButtonHandler adsButtonHandler)
        {
            _adsButtonHandler = adsButtonHandler;
        }

        public void Initialize()
        {
            _adsButtonHandler.AdOpened += SetPause;
            _adsButtonHandler.AdClosed += UnPause;
        }

        public void Dispose()
        {
            _adsButtonHandler.AdOpened -= SetPause;
            _adsButtonHandler.AdClosed -= UnPause;
        }

        private void UnPause() =>
            Time.timeScale = 1f;

        private void SetPause() =>
            Time.timeScale = 0f;
    }
}