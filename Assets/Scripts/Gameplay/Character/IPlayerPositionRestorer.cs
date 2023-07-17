using Invector.vCharacterController;
using UnityEngine;

namespace Gameplay.Character
{
    public interface IPlayerPositionRestorer
    {
        void Restore(Vector3 targetPosition);
        void SetPlayer(vThirdPersonController player);
    }
}