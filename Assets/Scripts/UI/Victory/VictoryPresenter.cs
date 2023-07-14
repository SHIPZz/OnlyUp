using System;
using Services.UIServices;
using Zenject;

namespace UI.Victory
{
    public class VictoryPresenter : IInitializable, IDisposable
    {
        private readonly PlayerEndPointChecker _playerEndPointChecker;
        private readonly WindowService _windowService;

        public VictoryPresenter(PlayerEndPointChecker playerEndPointChecker, WindowService windowService)
        {
            _playerEndPointChecker = playerEndPointChecker;
            _windowService = windowService;
        }
        
        public void Initialize()
        {
            _playerEndPointChecker.PlayerReached += OnPlayerReachedEndPoint;
        }

        public void Dispose()
        {
            _playerEndPointChecker.PlayerReached -= OnPlayerReachedEndPoint;
        }

        private void OnPlayerReachedEndPoint()
        {
            _windowService.CloseAll();
            _windowService.Open(WindowTypeId.VictoryWindow);
        }
    }
}