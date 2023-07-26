using System;
using System.Threading.Tasks;
using Agava.WebUtility;
using Agava.YandexGames;
using Gameplay.Character;
using I2.Loc;
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

        public GameInit(LocationProvider locationProvider, GameFactory gameFactory, DataProvider dataProvider,
            PlayerProvider playerProvider,
            AudioVolumeView audioVolumeView)
        {
            _audioVolumeView = audioVolumeView;
            _locationProvider = locationProvider;
            _gameFactory = gameFactory;
            _dataProvider = dataProvider;
            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            _dataProvider.DataReceived += Init;
        }

        public void Dispose()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
            _dataProvider.DataReceived -= Init;
        }

        private async void Init()
        {
            while (!YandexGamesSdk.IsInitialized)
            {
               await Task.Yield();
            }
            
            LocalizationManager.CurrentLanguage = YandexGamesSdk.Environment.i18n.lang;

            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
            Vector3 targetSpawnPosition = GetTargetSpawnPosition();

            vThirdPersonController vThirdPersonController = InitializePlayer(targetSpawnPosition);

            InitializePlayerProvider(vThirdPersonController);
            InitializeAudio();
        }

        private void InitializeAudio() =>
            _audioVolumeView.SetStartValue(_dataProvider.GetVolume());

        private Vector3 GetTargetSpawnPosition()
        {
            Vector3 targetSpawnPosition = _locationProvider.PlayerSpawnPosition.position;

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