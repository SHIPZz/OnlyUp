using System;
using Zenject;

namespace UI.Audio
{
    public class AudioPresenter : IInitializable, IDisposable
    {
        private readonly AudioVolumeChanger _audioVolumeChanger;
        private readonly AudioVolumeView _audioVolumeView;

        public AudioPresenter(AudioVolumeChanger audioVolumeChanger, AudioVolumeView audioVolumeView)
        {
            _audioVolumeChanger = audioVolumeChanger;
            _audioVolumeView = audioVolumeView;
        }

        public void Initialize() => 
            _audioVolumeView.ValueChanged += _audioVolumeChanger.Change;

        public void Dispose() => 
            _audioVolumeView.ValueChanged -= _audioVolumeChanger.Change;
    }
}