using System;
using Services;
using Zenject;

namespace UI.Audio
{
    public class AudioPresenter : IInitializable, IDisposable
    {
        private readonly AudioVolumeChanger _audioVolumeChanger;
        private readonly AudioVolumeView _audioVolumeView;
        private readonly AdsButtonHandler _adsButtonHandler;

        public AudioPresenter(AudioVolumeChanger audioVolumeChanger, AudioVolumeView audioVolumeView,
            AdsButtonHandler adsButtonHandler)
        {
            _adsButtonHandler = adsButtonHandler;
            _audioVolumeChanger = audioVolumeChanger;
            _audioVolumeView = audioVolumeView;
        }

        public void Initialize()
        {
            _audioVolumeView.ValueChanged += _audioVolumeChanger.Change;
            _adsButtonHandler.AdOpened += _audioVolumeChanger.Disable;
            _adsButtonHandler.AdClosed += _audioVolumeChanger.Enable;
        }

        public void Dispose()
        {
            _audioVolumeView.ValueChanged -= _audioVolumeChanger.Change;
            _adsButtonHandler.AdOpened -= _audioVolumeChanger.Disable;
            _adsButtonHandler.AdClosed -= _audioVolumeChanger.Enable;
        }
    }
}