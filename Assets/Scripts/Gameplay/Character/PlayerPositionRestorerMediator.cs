using System;
using Services;
using Services.Providers;
using UI.Windows.Ad;
using Zenject;

namespace Gameplay.Character
{
    public class PlayerPositionRestorerMediator : IInitializable, IDisposable
    {
        private readonly LocationProvider _locationProvider;
        private readonly AdShowerOnButton _adShowerOnButton;
        private readonly DataProvider _dataProvider;
        private readonly IPlayerPositionRestorer _playerPositionRestorer;
        private PlayerRaycastDownHitChecker _playerRaycastDownHitChecker;

        public PlayerPositionRestorerMediator(LocationProvider locationProvider, 
            AdShowerOnButton adShowerOnButton,
            IPlayerPositionRestorer playerPositionRestorer, DataProvider dataProvider,
            PlayerRaycastDownHitChecker playerRaycastDownHitChecker)
        {
            _dataProvider = dataProvider;
            _locationProvider = locationProvider;
            _adShowerOnButton = adShowerOnButton;
            _playerPositionRestorer = playerPositionRestorer;
            _playerRaycastDownHitChecker = playerRaycastDownHitChecker;
        }

        public void Initialize()
        {
            _adShowerOnButton.AdEnded += RestoreToLastPosition;
            _playerRaycastDownHitChecker.WaterHit += RestoreToSpawnPosition;
            _playerRaycastDownHitChecker.NullHit += RestoreToSpawnPosition;
        }

        public void Dispose()
        {
            _adShowerOnButton.AdEnded -= RestoreToLastPosition;
            _playerRaycastDownHitChecker.WaterHit -= RestoreToSpawnPosition;
            _playerRaycastDownHitChecker.NullHit -= RestoreToSpawnPosition;
        }
        
        private void RestoreToLastPosition() => 
            _playerPositionRestorer.Restore(_dataProvider.GetLastPosition());

        private void RestoreToSpawnPosition() => 
            _playerPositionRestorer.Restore(_locationProvider.PlayerSpawnPosition.position);
    }
}