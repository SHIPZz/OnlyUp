using UnityEngine;

namespace Gameplay.Car
{
    public interface IMovement
    {
        void Move(IMovable movable, Vector3 target, float duration);
    }
}