using System;
using Agava.WebUtility;
using Agava.YandexGames;
using Gameplay.Character;
using Invector;
using Invector.vCharacterController;
using Services.Factories;
using Services.Providers;
using UI.Audio;
using UI.Localization;
using UnityEngine;
using Zenject;

namespace GameInit
{
    public class GameInit : IInitializable, IDisposable
    {
        private readonly LocationProvider _locationProvider;
        private readonly GameFactory _gameFactory;
        private readonly DataProvider _dataProvider;
        private readonly PlayerProvider _playerProvider;
        private readonly AudioVolumeView _audioVolumeView;
        private readonly PlayerLastPositionRestorerHandler _playerLastPositionRestorerHandler;
        private LocalizationChanger _localizationChanger;

        public GameInit(LocationProvider locationProvider, GameFactory gameFactory, DataProvider dataProvider,
            PlayerProvider playerProvider,LocalizationChanger localizationChanger  , AudioVolumeView audioVolumeView,
            PlayerLastPositionRestorerHandler playerLastPositionRestorerHandler)
        {
            _localizationChanger = localizationChanger;
            _audioVolumeView = audioVolumeView;
            _playerLastPositionRestorerHandler = playerLastPositionRestorerHandler;
            _locationProvider = locationProvider;
            _gameFactory = gameFactory;
            _dataProvider = dataProvider;
            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            // InterstitialAd.Show();
            InitializeLocalization();
            
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
            Vector3 targetSpawnPosition = GetTargetSpawnPosition();
            
            vThirdPersonController vThirdPersonController = InitializePlayer(targetSpawnPosition);
            InitializePlayerProvider(vThirdPersonController);
            InitializePlayerPositionRestorer(vThirdPersonController);
            InitializeAudio();
        }

        public void Dispose()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        }

        private void InitializePlayerPositionRestorer(vThirdPersonController vThirdPersonController)
        {
            _playerLastPositionRestorerHandler.SetPlayer(vThirdPersonController);
        }

        private void InitializeAudio()
        {
            _audioVolumeView.SetStartValue(_dataProvider.GetVolume());
        }

        private void InitializeLocalization()
        {
            _localizationChanger.SetStartLanguage(_dataProvider.GetLanguage());
        }

        private Vector3 GetTargetSpawnPosition()
        {
            Vector3 targetSpawnPosition;

            if (_dataProvider.GetLastPosition() == Vector3.zero)
                targetSpawnPosition = _locationProvider.PlayerSpawnPosition.position;
            else
                targetSpawnPosition = _dataProvider.GetLastPosition();

            return targetSpawnPosition;
        }

        private void OnInBackgroundChange(bool inBackground)
        {
            AudioListener.pause = inBackground;
            AudioListener.volume = inBackground ? 0f : 1f;
        }

        private void InitializePlayerProvider(vThirdPersonController player)
        {
            _playerProvider.Player = player;
            _playerProvider.PlayerRaycastDownHitChecker = player.GetComponent<PlayerRaycastDownHitChecker>();
            _playerProvider.vFootStep = player.GetComponent<vFootStep>();
        }

        private vThirdPersonController InitializePlayer(Vector3 targetSpawnPosition)
        {
            vThirdPersonController player =
                _gameFactory.Create(PlayerTypeId.DefaultPlayer, targetSpawnPosition);

            return player;
        }
    }
}