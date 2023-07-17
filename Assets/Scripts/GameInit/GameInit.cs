using System;
using Agava.WebUtility;
using Agava.YandexGames;
using Gameplay.Character;
using Invector;
using Invector.vCharacterController;
using Services.Factories;
using Services.Providers;
using UI.Ad;
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
        private readonly LocalizationChanger _localizationChanger;
        private readonly AdPresenter _adPresenter;

        public GameInit(LocationProvider locationProvider, GameFactory gameFactory, DataProvider dataProvider,
            PlayerProvider playerProvider,
            LocalizationChanger localizationChanger, 
            AudioVolumeView audioVolumeView,
            AdPresenter adPresenter)
        {
            _adPresenter = adPresenter;
            _localizationChanger = localizationChanger;
            _audioVolumeView = audioVolumeView;
            _locationProvider = locationProvider;
            _gameFactory = gameFactory;
            _dataProvider = dataProvider;
            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            InitializeLocalization();
            
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
            Vector3 targetSpawnPosition = GetTargetSpawnPosition();
            
            vThirdPersonController vThirdPersonController = InitializePlayer(targetSpawnPosition);

            InitializePlayerProvider(vThirdPersonController);
            InitializeAudio();
        }

        public void Dispose()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
            _adPresenter.Dispose();
        }

        private void InitializeAudio() => 
            _audioVolumeView.SetStartValue(_dataProvider.GetVolume());

        private void InitializeLocalization() => 
            _localizationChanger.SetStartLanguage(_dataProvider.GetLanguage());

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