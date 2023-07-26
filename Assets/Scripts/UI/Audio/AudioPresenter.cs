using System;
using Services;
using UI.Windows.Ad;
using Zenject;

namespace UI.Audio
{
    public class AudioPresenter : IInitializable, IDisposable
    {
        private readonly AudioVolumeChanger _audioVolumeChanger;
        private readonly AudioVolumeView _audioVolumeView;
        private readonly AdShowerOnButton _adShowerOnButton;

        public AudioPresenter(AudioVolumeChanger audioVolumeChanger, AudioVolumeView audioVolumeView,
            AdShowerOnButton adShowerOnButton)
        {
            _adShowerOnButton = adShowerOnButton;
            _audioVolumeChanger = audioVolumeChanger;
            _audioVolumeView = audioVolumeView;
        }

        public void Initialize()
        {
            _audioVolumeView.ValueChanged += _audioVolumeChanger.Change;
            _adShowerOnButton.AdOpened += _audioVolumeChanger.Disable;
            _adShowerOnButton.AdClosed += _audioVolumeChanger.Enable;
        }

        public void Dispose()
        {
            _audioVolumeView.ValueChanged -= _audioVolumeChanger.Change;
            _adShowerOnButton.AdOpened -= _audioVolumeChanger.Disable;
            _adShowerOnButton.AdClosed -= _audioVolumeChanger.Enable;
        }
    }
}