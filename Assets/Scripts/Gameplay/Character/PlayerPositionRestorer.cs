using Invector.vCharacterController;
using UnityEngine;

namespace Gameplay.Character
{
    public class PlayerPositionRestorer : IPlayerPositionRestorer
    {
        private vThirdPersonController _player;

        public PlayerPositionRestorer(vThirdPersonController player)
        {
            _player = player;
        }

        public void Restore(Vector3 targetPosition) => 
            _player.transform.position = targetPosition;

        public void SetPlayer(vThirdPersonController player) => 
            _player = player;
    }
}