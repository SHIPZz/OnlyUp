using UnityEngine;

namespace Services.Providers
{
    public struct LocationProvider
    {
        public Transform PlayerSpawnPosition { get; }

        public LocationProvider(Transform playerSpawnPosition)
        {
            PlayerSpawnPosition = playerSpawnPosition;
        }
    }
}