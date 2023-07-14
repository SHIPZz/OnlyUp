using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Audio
{
    public class AudioVolumeView : MonoBehaviour
    {
        private const float StartSliderValue = 0.5f;
        
        [SerializeField] private Slider _slider;

        public event Action<float> ValueChanged;

        private void OnEnable()
        {
            _slider.onValueChanged.AddListener(OnAudioVolumeChanged);
        }

        public void SetStartValue(float value) =>
            _slider.value = value;

        private void OnDisable() => 
            _slider.onValueChanged.RemoveListener(OnAudioVolumeChanged);

        private void OnAudioVolumeChanged(float volume) => 
            ValueChanged?.Invoke(volume);
    }
}