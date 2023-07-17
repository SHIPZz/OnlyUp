using System;
using Invector;
using Services.Providers;

namespace UI.Audio
{
    public class AudioVolumeChanger : IDisposable
    {
        private vFootStep _footStep;
        private PlayerProvider _playerProvider;
        private DataProvider _dataProvider;

        public AudioVolumeChanger(PlayerProvider playerProvider, DataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            _playerProvider = playerProvider;
            _playerProvider.PlayerFootStepInstalled += SetFootStep;
        }

        public float LastVolumeValue { get; private set; }

        public void Change(float value)
        {
            _footStep.Volume = value;
            LastVolumeValue = value;
            _dataProvider.SaveVolume(value);
        }

        public void Disable() =>
            _footStep.Volume = 0f;

        public void Enable() =>
            _footStep.Volume = LastVolumeValue;

        private void SetFootStep(vFootStep vFootStep) =>
            _footStep = vFootStep;

        public void Dispose() => 
            _playerProvider.PlayerFootStepInstalled -= SetFootStep;
    }
}