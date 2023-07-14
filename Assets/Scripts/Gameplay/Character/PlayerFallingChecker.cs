using System;
using Constants;
using UnityEngine;

namespace Gameplay.Character
{
    public class PlayerFallingChecker : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;

        public event Action FloorTouched;

        private void OnEnable() => 
            _triggerObserver.TriggerEntered += OnTriggerEntered;

        private void OnDisable() => 
            _triggerObserver.TriggerEntered -= OnTriggerEntered;

        private void OnTriggerEntered(Collider obj)
        {
            if (obj.gameObject.layer == LayerId.DefaultWorld)
            {
                FloorTouched?.Invoke();
            }
        }
    }
}