using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Windows.Settings
{
    public class SettingView : MonoBehaviour
    {
        [SerializeField] private Button _openButton;
        [SerializeField] private Button _closeButton;

        public event Action OpenClicked;
        public event Action CloseClicked;

        private void OnEnable()
        {
            _openButton.onClick.AddListener(OnOpenedButtonClicked);
            _closeButton.onClick.AddListener(OnClosedButtonClicked);
        }

        private void OnDisable()
        {
            _openButton.onClick.RemoveListener(OnOpenedButtonClicked);
            _closeButton.onClick.RemoveListener(OnClosedButtonClicked);
        }

        private void OnOpenedButtonClicked() =>
            OpenClicked?.Invoke();

        private void OnClosedButtonClicked() => 
            CloseClicked?.Invoke();
    }
}