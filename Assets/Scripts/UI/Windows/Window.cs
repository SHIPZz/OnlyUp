using System;
using DG.Tweening;
using UnityEngine;

namespace UI.Windows
{
    public class Window : MonoBehaviour
    {
        [SerializeField] private float _openDuration;
        [SerializeField] private float _closeDuration;
        [SerializeField] private float _scaleX;
        [SerializeField] private float _startScaleX;

        [field: SerializeField] public WindowTypeId WindowTypeId { get; private set; }

        public event Action Opened;
        public event Action Closed;

        private void Awake() =>
            transform.localScale = new Vector3(_startScaleX, transform.localScale.y, transform.localScale.z);

        public void Open()
        {
            DOTween.Sequence()
                .AppendCallback(() => gameObject.SetActive(true))
                .Append(transform.DOScaleX(_scaleX, _openDuration))
                .OnComplete(() => Opened?.Invoke())
                .SetAutoKill(true)
                .SetUpdate(true);
        }

        public void Close(bool withTime)
        {
            if (withTime)
            {
                Close();
                Closed?.Invoke();
                return;
            }

            Closed?.Invoke();
            gameObject.SetActive(false);
        }

        private void Close() =>
            transform.DOScaleX(0, _closeDuration).OnComplete(() => gameObject.SetActive(false)).SetAutoKill(true);
    }
}