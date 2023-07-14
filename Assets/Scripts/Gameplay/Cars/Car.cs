using System;
using Gameplay.Car;
using UnityEngine;

namespace Gameplay.Cars
{
    public class Car : MonoBehaviour, IMovable
    {
        private readonly IMovement _movement = new CarMovement();

        public GameObject GameObject => gameObject;
        
        public Rigidbody Rigidbody => GetComponent<Rigidbody>();

        public void Move(Vector3 target, float duration)
        {
            _movement.Move(this, target, duration);
        }
    }
}