using System;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.UI;

namespace Services
{
    public class AdsButtonHandler : MonoBehaviour
    {
        [SerializeField] private Button _adButton;

        public event Action AdClosed;
        public event Action AdOpened;
        public event Action AdEnded;

        private void OnEnable() =>
            _adButton.onClick.AddListener(ShowAd);

        private void OnDisable() =>
            _adButton.onClick.RemoveListener(ShowAd);

        private void ShowAd() =>
            VideoAd.Show(OnOpenCallback, OnRewardedCallBack, () => AdClosed?.Invoke());

        private void OnOpenCallback() =>
            AdOpened?.Invoke();

        private void OnRewardedCallBack() =>
            AdEnded?.Invoke();
    }
}