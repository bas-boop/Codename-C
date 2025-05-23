using UnityEngine;
using UnityEngine.Events;

namespace Framework
{
    public sealed class Timer : MonoBehaviour
    {
        [SerializeField] private float time;
        [SerializeField] private UnityEvent onTimerDone = new();

        private float _currentTimer;
        private bool _canCount;

        private void Start() => _currentTimer = time;

        private void Update()
        {
            if (_canCount)
                UpdateTimer();
        }

        public void StartTimer() => _canCount = true;

        public float GetCurrentTime() => _currentTimer;

        private void UpdateTimer()
        {
            _currentTimer -= Time.deltaTime;

            if (_currentTimer > 0)
                return;
            
            onTimerDone?.Invoke();
            _canCount = false;
        }
    }
}