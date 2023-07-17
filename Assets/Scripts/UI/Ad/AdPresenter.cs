using System;
using DG.Tweening;
using Gameplay.Character;
using Services.Providers;
using Services.UIServices;

namespace UI.Ad
{
    public class AdPresenter : IDisposable
    {
        private readonly PlayerProvider _playerProvider;
        private WindowService _windowService;
        private PlayerRaycastDownHitChecker _playerRaycastDown;
        private bool _canOpen;
        private bool _isOpenning;

        public AdPresenter(PlayerProvider playerProvider, WindowService windowService)
        {
            _windowService = windowService;
            _playerProvider = playerProvider;
            _playerProvider.PlayerRaycastDownInstalled += SetPlayerRaycastDown;
        }

        public void Dispose()
        {
            // _playerRaycastDown.EnviromentHit -= SetCanOpenWindow;
            // _playerRaycastDown.DefaultWorldHit -= OpenWindow;
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