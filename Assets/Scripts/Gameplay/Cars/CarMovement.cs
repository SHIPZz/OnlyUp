using DG.Tweening;
using UnityEngine;

namespace Gameplay.Car
{
    public class CarMovement : IMovement
    {
        public void Move(IMovable movable, Vector3 target, float duration)
        {
            // movable.GameObject.transform.DOMoveZ(target.z, duration);
            movable.GameObject.transform.DOMove(target, duration);
        }
    }
}