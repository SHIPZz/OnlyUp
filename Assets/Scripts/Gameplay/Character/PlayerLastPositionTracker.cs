using Constants;
using Services.Providers;
using UnityEngine;
using Zenject;

public class PlayerLastPositionTracker : MonoBehaviour
{
    private const float AdditionalUpPosition = 2.5f;
    private const float RaycastHitDistance = 1.5f;

    private DataProvider _dataProvider;

    [Inject]
    private void Construct(DataProvider dataProvider) => 
        _dataProvider = dataProvider;

    private void Update() => 
        StartSavingLastPosition();

    private void StartSavingLastPosition()
    {
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, Vector3.down, out hit, RaycastHitDistance))
        {
            if (hit.collider.gameObject.layer == LayerId.Enviroment)
            {
                var collider = hit.collider;
                Vector3 center = collider.bounds.center;

                float halfHeight = collider.bounds.extents.y;

                Vector3 highestPoint = center + Vector3.up * halfHeight;
                _dataProvider.SaveLastPosition(highestPoint + Vector3.up * AdditionalUpPosition);
            }
        }
    }
}