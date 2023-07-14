using System;
using System.Collections.Generic;
using Constants;
using Invector.vCharacterController;
using Services.Providers;
using UnityEngine;
using Zenject;

namespace Services.Factories
{
    public class PlayerFactory
    {
        private readonly Dictionary<PlayerTypeId, string> _players;
        private readonly AssetProvider _assetProvider;
        private readonly DiContainer _diContainer;

        public PlayerFactory(AssetProvider assetProvider, DiContainer diContainer)
        {
            _players = new Dictionary<PlayerTypeId, string>
            {
                { PlayerTypeId.DefaultPlayer, AssetPath.DefaultPlayerPrefab },
            };

            _assetProvider = assetProvider;
            _diContainer = diContainer;
        }

        public vThirdPersonController Create(PlayerTypeId playerTypeId, Vector3 spawnPoint)
        {
            if (!_players.TryGetValue(playerTypeId, out string path))
                throw new ArgumentException("ERROR");
            
            var playerPrefab = _assetProvider.Get<PlayerLastPositionTracker>(path);
            return _diContainer
                .InstantiatePrefabForComponent<vThirdPersonController>(playerPrefab, spawnPoint, 
                    Quaternion.identity, null);
        }
    }
}