using System;
using UnityEngine;

namespace Gameplay
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider> TriggerEntered;
        public event Action<Collision> CollisionEntered;
        public event Action<Collider> TriggerExited;

        private void OnCollisionEnter(Collision other)
        {
            CollisionEntered?.Invoke(other);
        }

        private void OnCollisionExit(Collision other)
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            TriggerEntered?.Invoke(other);
        }

        private void OnTriggerExit(Collider other)
        {
            TriggerExited?.Invoke(other);
        }
    }
}