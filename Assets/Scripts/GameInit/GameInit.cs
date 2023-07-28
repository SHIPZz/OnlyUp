using System;
using System.Collections.Generic;
using Agava.WebUtility;
using Agava.YandexGames;
using Cysharp.Threading.Tasks;
using Gameplay.Character;
using Initialize;
using Invector;
using Invector.vCharacterController;
using Services.Factories;
using Services.Providers;
using UI.Audio;
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
        private readonly Canvas _mainUi;

        public GameInit(LocationProvider locationProvider, GameFactory gameFactory, DataProvider dataProvider,
            PlayerProvider playerProvider,
            AudioVolumeView audioVolumeView, Canvas mainUi)
        {
            _mainUi = mainUi;
            _audioVolumeView = audioVolumeView;
            _locationProvider = locationProvider;
            _gameFactory = gameFactory;
            _dataProvider = dataProvider;
            _playerProvider = playerProvider;
        }

        public void Initialize()
        {
            Debug.Log("initialize/");
            InitWithDelay().Forget();
        }

        public void Dispose()
        {
            WebApplication.InBackgroundChangeEvent -= OnInBackgroundChange;
        }

        private async UniTask InitWithDelay()
        {
            await _dataProvider.LoadInitialData();
            Init();
        }

        private void Init()
        {
            WebApplication.InBackgroundChangeEvent += OnInBackgroundChange;
            Vector3 targetSpawnPosition = GetTargetSpawnPosition();

            vThirdPersonController vThirdPersonController = InitializePlayer(targetSpawnPosition);

            InitMainUI(_mainUi.GetComponent<CanvasGroup>());
            InitializePlayerProvider(vThirdPersonController);
            InitializeAudio();
        }

        private void InitMainUI(CanvasGroup mainUI) =>
            mainUI.alpha = 1;

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