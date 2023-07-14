using System;
using Invector.vCharacterController;
using Services;
using Services.Providers;
using UnityEngine;
using Zenject;

namespace Gameplay.Character
{
    public class PlayerLastPositionRestorerHandler : IInitializable, IDisposable
    {
        private readonly DataProvider _dataProvider;
        private readonly AdsButtonHandler _adsButtonHandler;
        private readonly PlayerProvider _playerProvider;
        private vThirdPersonController _player;

        public PlayerLastPositionRestorerHandler(DataProvider dataProvider, AdsButtonHandler adsButtonHandler)
        {
            _adsButtonHandler = adsButtonHandler;
            _dataProvider = dataProvider;
        }

        public void Initialize()
        {
            _adsButtonHandler.AdEnded += RestorePosition;
            _adsButtonHandler.AdOpened += RestorePosition;
        }

        public void Dispose()
        {
            _adsButtonHandler.AdEnded -= RestorePosition;
            _adsButtonHandler.AdOpened -= RestorePosition;
        }

        private void RestorePosition() => 
            _player.transform.position = _dataProvider.GetLastPosition();

        public void SetPlayer(vThirdPersonController player) => 
            _player = player;
    }
}