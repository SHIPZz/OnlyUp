using System;
using Services;
using Services.Providers;
using Zenject;

namespace Gameplay.Character
{
    public class PlayerPositionRestorerMediator : IInitializable, IDisposable
    {
        private readonly LocationProvider _locationProvider;
        private readonly AdsButtonHandler _adsButtonHandler;
        private readonly DataProvider _dataProvider;
        private readonly IPlayerPositionRestorer _playerPositionRestorer;
        private PlayerRaycastDownHitChecker _playerRaycastDownHitChecker;

        public PlayerPositionRestorerMediator(LocationProvider locationProvider, 
            AdsButtonHandler adsButtonHandler,
            IPlayerPositionRestorer playerPositionRestorer, DataProvider dataProvider,
            PlayerRaycastDownHitChecker playerRaycastDownHitChecker)
        {
            _dataProvider = dataProvider;
            _locationProvider = locationProvider;
            _adsButtonHandler = adsButtonHandler;
            _playerPositionRestorer = playerPositionRestorer;
            _playerRaycastDownHitChecker = playerRaycastDownHitChecker;
            _playerRaycastDownHitChecker.WaterHit += RestoreToSpawnPosition;
        }

        public void Initialize()
        {
            _adsButtonHandler.AdEnded += RestoreToLastPosition;
        }

        public void Dispose()
        {
            _adsButtonHandler.AdEnded -= RestoreToLastPosition;
            _playerRaycastDownHitChecker.WaterHit -= RestoreToSpawnPosition;
        }
        
        private void RestoreToLastPosition() => 
            _playerPositionRestorer.Restore(_dataProvider.GetLastPosition());

        private void RestoreToSpawnPosition() => 
            _playerPositionRestorer.Restore(_locationProvider.PlayerSpawnPosition.position);
    }
}