using System;
using Constants;
using UnityEngine;

namespace Gameplay.Character
{
    public class PlayerRaycastDownHitChecker : MonoBehaviour
    {
        public event Action EnviromentHit;
        public event Action DefaultWorldHit;

        private void Update()
        {
            RaycastHit hit;
            
            if (Physics.Raycast(gameObject.transform.position, Vector3.down, out hit,
                    2f))
            {
                if (hit.collider.gameObject.layer == LayerId.Enviroment)
                    EnviromentHit?.Invoke();
                else if (hit.collider.gameObject.layer == LayerId.DefaultWorld)
                    DefaultWorldHit?.Invoke();
            }
        }
    }
}