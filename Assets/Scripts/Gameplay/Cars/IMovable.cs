using UnityEngine;

namespace Gameplay.Car
{
    public interface IMovable
    {
        GameObject GameObject { get; }
        Rigidbody Rigidbody { get; }
        void Move(Vector3 target, float duration);
    }
}