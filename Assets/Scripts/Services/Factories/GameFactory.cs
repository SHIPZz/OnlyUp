using Invector.vCharacterController;
using UnityEngine;

namespace Services.Factories
{
    public class GameFactory
    {
        private readonly PlayerFactory _playerFactory;

        public GameFactory(PlayerFactory playerFactory)
        {
            _playerFactory = playerFactory;
        }

        public vThirdPersonController Create(PlayerTypeId playerTypeId, Vector3 spawnPoint) =>
            _playerFactory.Create(playerTypeId, spawnPoint);

    }
}