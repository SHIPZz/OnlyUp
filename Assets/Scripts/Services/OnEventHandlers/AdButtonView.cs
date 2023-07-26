using System;
using UnityEngine;
using UnityEngine.UI;

namespace Services.OnEventHandlers
{
    public class AdButtonView : MonoBehaviour
    {
        [SerializeField] private Button _button;

        public Button Button => _button;

        public event Action Clicked;

        private void OnEnable() => 
            _button.onClick.AddListener(OnButtonSettingClicked);

        private void OnDisable() => 
            _button.onClick.RemoveListener(OnButtonSettingClicked);

        private void OnButtonSettingClicked() => 
            Clicked?.Invoke();
    }
}