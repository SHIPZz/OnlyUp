using DG.Tweening;
using UnityEngine;

namespace UI
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private float _openDuration;
        [SerializeField] private float _closeDuration;
        [SerializeField] private float _scaleX;
        [SerializeField] private float _startScaleX;
        
        [field: SerializeField] public WindowTypeId WindowTypeId { get; private set; }

        private void Awake() =>
            transform.localScale = new Vector3(_startScaleX, transform.localScale.y, transform.localScale.z);

        public void Open() =>
            DOTween.Sequence().AppendCallback(() => gameObject.SetActive(true))
                .OnComplete(() => transform.DOScaleX(_scaleX, _openDuration)).SetAutoKill(true);

        public void Close(bool withTime)
        {
            if (withTime)
            {
                Close();
                return;
            }
            
            gameObject.SetActive(false);
        }

        private void Close() =>
            transform.DOScaleX(0, _closeDuration).OnComplete(() => gameObject.SetActive(false)).SetAutoKill(true);
    }
}