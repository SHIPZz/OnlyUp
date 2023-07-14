using System;
using Gameplay;
using Invector.vCharacterController;
using UnityEngine;

namespace UI
{
    public class PlayerEndPointChecker : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;

        public event Action PlayerReached;

        private void OnEnable() =>
            _triggerObserver.TriggerEntered += OnPlayerReachedEndPoint;

        private void OnDisable() =>
            _triggerObserver.TriggerEntered -= OnPlayerReachedEndPoint;

        private void OnPlayerReachedEndPoint(Collider obj)
        {
            if (obj.gameObject.TryGetComponent(out vThirdPersonController thirdPersonController))
            {
                PlayerReached?.Invoke();
            }
        }
    }
}