using System;
using System.Collections.Generic;
using Constants;
using UnityEngine;

namespace Gameplay.Character
{
    public class PlayerRaycastDownHitChecker : MonoBehaviour
    {
        private const float MaxFallingTime = 20;
        
        private Dictionary<int, Action> _hitColliders;
        private float _fallingTime;

        public event Action EnviromentHit;
        public event Action DefaultWorldHit;
        public event Action WaterHit;
        public event Action NullHit;

        private void Awake()
        {
            _hitColliders = new Dictionary<int, Action>()
            {
                { LayerId.Enviroment, () => EnviromentHit?.Invoke() },
                { LayerId.DefaultWorld, () => DefaultWorldHit?.Invoke() },
                { LayerId.Water, () => WaterHit?.Invoke() },
            };
        }

        private void Update()
        {
            RaycastHit hit;

            if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit,
                    2f))
            {
                if (!_hitColliders.ContainsKey(hit.collider.gameObject.layer))
                    return;

                _hitColliders[hit.collider.gameObject.layer]?.Invoke();

                _fallingTime = 0f;
                return;
            }

            _fallingTime += Time.deltaTime;
            
            if (!(_fallingTime > MaxFallingTime))
                return;
            
            _fallingTime = 0;
            NullHit?.Invoke();
        }
    }
}