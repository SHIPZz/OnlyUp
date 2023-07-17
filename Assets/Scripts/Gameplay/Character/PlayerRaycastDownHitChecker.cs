using System;
using System.Collections.Generic;
using Constants;
using UnityEngine;

namespace Gameplay.Character
{
    public class PlayerRaycastDownHitChecker : MonoBehaviour
    {
        private Dictionary<int, Action> _hitColliders;

        public event Action EnviromentHit;
        public event Action DefaultWorldHit;
        public event Action WaterHit;

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
                if(!_hitColliders.ContainsKey(hit.collider.gameObject.layer))
                    return;
                
                _hitColliders[hit.collider.gameObject.layer]?.Invoke();
            }
        }
    }
}