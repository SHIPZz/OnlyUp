using System;
using DG.Tweening;
using Invector.vCharacterController;
using Services.Providers;
using UI;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput.PlatformSpecific;
using Zenject;

namespace Gameplay
{
    public class PlayerDeactivatorHandler : IInitializable, IDisposable
    {
        private PlayerEndPointChecker _playerEndPointChecker;
        private PlayerProvider _playerProvider;
        private vThirdPersonController _player;

        public PlayerDeactivatorHandler(PlayerEndPointChecker playerEndPointChecker, PlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
            _playerEndPointChecker = playerEndPointChecker;
            _playerProvider.PlayerInstalled += SetPlayer;
        }

        public void Initialize()
        {
            _playerEndPointChecker.PlayerReached += Disable;
        }

        public void Dispose()
        {
            _playerEndPointChecker.PlayerReached -= Disable;
            _playerProvider.PlayerInstalled -= SetPlayer;
        }

        private void SetPlayer(vThirdPersonController player) =>
            _player = player;

        private void Disable() =>
            DOTween.Sequence().AppendInterval(0.5f).OnComplete(() => _player.gameObject.SetActive(false));
    }
}