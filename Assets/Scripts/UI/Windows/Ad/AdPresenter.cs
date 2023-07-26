using System;
using DG.Tweening;
using Gameplay.Character;
using Services.OnEventHandlers;
using Services.Providers;
using Services.UIServices;

namespace UI.Windows.Ad
{
    public class AdPresenter : IDisposable
    {
        private readonly PlayerProvider _playerProvider;
        private WindowService _windowService;
        private PlayerRaycastDownHitChecker _playerRaycastDown;
        private bool _canOpen;
        private bool _isOpenning;
        private AdButtonView _adButtonView;

        public AdPresenter(PlayerProvider playerProvider, WindowService windowService, AdButtonView adButtonView)
        {
            _adButtonView = adButtonView;
            _windowService = windowService;
            _playerProvider = playerProvider;
            _playerProvider.PlayerRaycastDownInstalled += SetPlayerRaycastDown;
            _adButtonView.Clicked += CloseWindow;
        }

        public void Dispose()
        {
            _adButtonView.Clicked -= CloseWindow;

            if (_playerRaycastDown is null)
                return;

            _playerRaycastDown.EnviromentHit -= SetCanOpenWindow;
            _playerRaycastDown.DefaultWorldHit -= OpenWindow;
        }

        private void CloseWindow()
        {
            _adButtonView.Button.interactable = false;
            _windowService.Close(WindowTypeId.AdWindow);
        }

        private void SetPlayerRaycastDown(PlayerRaycastDownHitChecker playerRaycastDownHitChecker)
        {
            _playerRaycastDown = playerRaycastDownHitChecker;
            _playerRaycastDown.EnviromentHit += SetCanOpenWindow;
            _playerRaycastDown.DefaultWorldHit += OpenWindow;
        }

        private void OpenWindow()
        {
            if (_canOpen == false || _isOpenning)
                return;

            _adButtonView.Button.interactable = true;
            _windowService.CloseAll();
            _windowService.Open(WindowTypeId.AdWindow);
            _isOpenning = true;

            DOTween.Sequence().AppendInterval(5f).OnComplete(() =>
            {
                _windowService.Close(WindowTypeId.AdWindow);
                _windowService.OpenHud();
                _canOpen = false;
                _isOpenning = false;
            });
        }

        private void SetCanOpenWindow() =>
            _canOpen = true;
    }
}